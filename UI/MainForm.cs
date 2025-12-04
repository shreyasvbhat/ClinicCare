using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using ClinicAppointmentManager.Data;
using ClinicAppointmentManager.Models;
using ClinicAppointmentManager.Repositories;
using ClinicAppointmentManager.Services;
using ClinicAppointmentManager.Exceptions;

namespace ClinicAppointmentManager.UI
{
    /// <summary>
    /// Main application form with tabbed interface for managing patients, doctors, and appointments.
    /// </summary>
    public partial class MainForm : Form
    {
        private MongoDbContext _dbContext;
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IAppointmentRepository _appointmentRepository;
        private SchedulerService _schedulerService;
        private NotificationService _notificationService;
        private ReportService _reportService;
        private SampleDataSeeder _seeder;

        public MainForm()
        {
            InitializeComponent();
            InitializeServices();
        }

        /// <summary>
        /// Initializes all services and repositories.
        /// </summary>
        private void InitializeServices()
        {
            try
            {
                _dbContext = new MongoDbContext();
                _dbContext.CreateIndexes();

                _patientRepository = new PatientRepository(_dbContext);
                _doctorRepository = new DoctorRepository(_dbContext);
                _appointmentRepository = new AppointmentRepository(_dbContext);

                _schedulerService = new SchedulerService(_appointmentRepository, _doctorRepository, _patientRepository);
                _notificationService = new NotificationService();
                _reportService = new ReportService(_appointmentRepository, _doctorRepository, _patientRepository);
                _seeder = new SampleDataSeeder(_patientRepository, _doctorRepository, _appointmentRepository);

                Text = "Clinic Appointment Manager";
                this.Load += MainForm_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize services: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            LoadDoctors();
            LoadAppointments();
        }

        /// <summary>
        /// Loads and displays all patients.
        /// </summary>
        private async void LoadPatients()
        {
            try
            {
                var patients = await _patientRepository.GetAllAsync();
                PatientListBox.Items.Clear();
                foreach (var patient in patients)
                {
                    PatientListBox.Items.Add(patient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Loads and displays all doctors.
        /// </summary>
        private async void LoadDoctors()
        {
            try
            {
                var doctors = await _doctorRepository.GetAllAsync();
                DoctorListBox.Items.Clear();
                DoctorComboBox.Items.Clear();

                foreach (var doctor in doctors)
                {
                    DoctorListBox.Items.Add(doctor);
                    DoctorComboBox.Items.Add(doctor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Loads and displays all appointments.
        /// </summary>
        private async void LoadAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAsync();
                AppointmentListBox.Items.Clear();

                foreach (var appointment in appointments)
                {
                    var patient = await _patientRepository.GetByIdAsync(appointment.PatientId);
                    var doctor = await _doctorRepository.GetByIdAsync(appointment.DoctorId);
                    var display = $"{appointment.StartTime:yyyy-MM-dd HH:mm} - {patient?.Name ?? "Unknown"} / Dr. {doctor?.Name ?? "Unknown"}";
                    AppointmentListBox.Items.Add(new { Appointment = appointment, Display = display });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles booking a new appointment.
        /// </summary>
        private async void BookButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoctorComboBox.SelectedItem == null || PatientComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor and patient.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var doctor = (Doctor)DoctorComboBox.SelectedItem;
                var patient = (Patient)PatientComboBox.SelectedItem;
                var appointmentDate = AppointmentDatePicker.Value.Date;
                var startTime = appointmentDate.Add(StartTimePicker.Value.TimeOfDay);
                var endTime = startTime.AddMinutes(doctor.AppointmentDurationMinutes);
                var reason = ReasonTextBox.Text;

                if (string.IsNullOrWhiteSpace(reason))
                {
                    MessageBox.Show("Please enter a reason for the appointment.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var appointment = await _schedulerService.BookAppointmentAsync(patient.Id, doctor.Id, startTime, endTime, reason);

                MessageBox.Show($"Appointment booked successfully!\nID: {appointment.Id}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Queue a notification
                _notificationService.QueueReminder(appointment, patient, doctor);

                LoadAppointments();
                ClearAppointmentFields();
            }
            catch (DoubleBookingException ex)
            {
                MessageBox.Show($"Booking Failed - Double Booking Detected:\n{ex.Message}", "Conflict",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogException(ex);
            }
            catch (InvalidTimeSlotException ex)
            {
                MessageBox.Show($"Booking Failed - Invalid Time Slot:\n{ex.Message}", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogException(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking appointment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles cancelling an appointment.
        /// </summary>
        private async void AppointmentCancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppointmentListBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select an appointment to cancel.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dynamic selectedItem = AppointmentListBox.SelectedItem;
                var appointment = (Appointment)selectedItem.Appointment;

                var result = MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _schedulerService.CancelAppointmentAsync(appointment.Id);
                    MessageBox.Show("Appointment cancelled successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling appointment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles seeding sample data.
        /// </summary>
        private async void SeedDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("This will add sample data to the database. Continue?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _seeder.SeedSampleDataAsync();
                    MessageBox.Show("Sample data seeded successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatients();
                    LoadDoctors();
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error seeding data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles exporting appointments to CSV.
        /// </summary>
        private async void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var date = AppointmentDatePicker.Value.Date;
                var filePath = await _reportService.ExportAppointmentsToCSVAsync(date);
                MessageBox.Show($"Appointments exported to:\n{filePath}", "Export Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles viewing doctor schedule.
        /// </summary>
        private async void ViewScheduleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoctorComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var doctor = (Doctor)DoctorComboBox.SelectedItem;
                var date = AppointmentDatePicker.Value.Date;
                var summary = await _reportService.GenerateDoctorDaySummaryAsync(doctor.Id, date);

                MessageBox.Show(summary, $"Dr. {doctor.Name} - Schedule",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing schedule: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        /// <summary>
        /// Handles sending queued notifications.
        /// </summary>
        private void SendNotificationsButton_Click(object sender, EventArgs e)
        {
            try
            {
                _notificationService.SendAllNotifications();
                MessageBox.Show("All notifications sent.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending notifications: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        private void ClearAppointmentFields()
        {
            ReasonTextBox.Clear();
            AppointmentDatePicker.Value = DateTime.Now.AddDays(1);
            DoctorComboBox.SelectedIndex = -1;
            PatientComboBox.SelectedIndex = -1;
            StartTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Logs exceptions to a file for debugging.
        /// </summary>
        private void LogException(Exception ex)
        {
            try
            {
                var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Exception: {ex.GetType().Name} - {ex.Message}\n{ex.StackTrace}\n";
                System.IO.File.AppendAllText("errors.log", logMessage);
            }
            catch { }
        }
    }
}
