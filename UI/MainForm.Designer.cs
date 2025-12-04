namespace ClinicAppointmentManager.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.PatientsTab = new System.Windows.Forms.TabPage();
            this.PatientListBox = new System.Windows.Forms.ListBox();
            this.PatientsLabel = new System.Windows.Forms.Label();

            this.DoctorsTab = new System.Windows.Forms.TabPage();
            this.DoctorListBox = new System.Windows.Forms.ListBox();
            this.DoctorsLabel = new System.Windows.Forms.Label();

            this.AppointmentsTab = new System.Windows.Forms.TabPage();
            this.AppointmentListBox = new System.Windows.Forms.ListBox();
            this.AppointmentLabel = new System.Windows.Forms.Label();
            this.BookingGroupBox = new System.Windows.Forms.GroupBox();

            this.DoctorLabel = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();

            this.PatientLabel = new System.Windows.Forms.Label();
            this.PatientComboBox = new System.Windows.Forms.ComboBox();

            this.DateLabel = new System.Windows.Forms.Label();
            this.AppointmentDatePicker = new System.Windows.Forms.DateTimePicker();

            this.TimeLabel = new System.Windows.Forms.Label();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();

            this.ReasonLabel = new System.Windows.Forms.Label();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();

            this.BookButton = new System.Windows.Forms.Button();
            this.AppointmentCancelButton = new System.Windows.Forms.Button();

            this.ToolsGroupBox = new System.Windows.Forms.GroupBox();
            this.SeedDataButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ViewScheduleButton = new System.Windows.Forms.Button();
            this.SendNotificationsButton = new System.Windows.Forms.Button();

            this.MainTabControl.SuspendLayout();
            this.PatientsTab.SuspendLayout();
            this.DoctorsTab.SuspendLayout();
            this.AppointmentsTab.SuspendLayout();
            this.BookingGroupBox.SuspendLayout();
            this.ToolsGroupBox.SuspendLayout();
            this.SuspendLayout();

            // MainTabControl
            this.MainTabControl.Controls.Add(this.PatientsTab);
            this.MainTabControl.Controls.Add(this.DoctorsTab);
            this.MainTabControl.Controls.Add(this.AppointmentsTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(900, 250);
            this.MainTabControl.TabIndex = 0;

            // PatientsTab
            this.PatientsTab.Controls.Add(this.PatientsLabel);
            this.PatientsTab.Controls.Add(this.PatientListBox);
            this.PatientsTab.Location = new System.Drawing.Point(4, 24);
            this.PatientsTab.Name = "PatientsTab";
            this.PatientsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PatientsTab.Size = new System.Drawing.Size(892, 222);
            this.PatientsTab.TabIndex = 0;
            this.PatientsTab.Text = "Patients";
            this.PatientsTab.UseVisualStyleBackColor = true;

            this.PatientsLabel.AutoSize = true;
            this.PatientsLabel.Location = new System.Drawing.Point(10, 10);
            this.PatientsLabel.Name = "PatientsLabel";
            this.PatientsLabel.Size = new System.Drawing.Size(80, 13);
            this.PatientsLabel.TabIndex = 0;
            this.PatientsLabel.Text = "Registered Patients:";

            this.PatientListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientListBox.Location = new System.Drawing.Point(10, 30);
            this.PatientListBox.Name = "PatientListBox";
            this.PatientListBox.Size = new System.Drawing.Size(872, 192);
            this.PatientListBox.TabIndex = 1;

            // DoctorsTab
            this.DoctorsTab.Controls.Add(this.DoctorsLabel);
            this.DoctorsTab.Controls.Add(this.DoctorListBox);
            this.DoctorsTab.Location = new System.Drawing.Point(4, 24);
            this.DoctorsTab.Name = "DoctorsTab";
            this.DoctorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DoctorsTab.Size = new System.Drawing.Size(892, 222);
            this.DoctorsTab.TabIndex = 1;
            this.DoctorsTab.Text = "Doctors";
            this.DoctorsTab.UseVisualStyleBackColor = true;

            this.DoctorsLabel.AutoSize = true;
            this.DoctorsLabel.Location = new System.Drawing.Point(10, 10);
            this.DoctorsLabel.Name = "DoctorsLabel";
            this.DoctorsLabel.Size = new System.Drawing.Size(69, 13);
            this.DoctorsLabel.TabIndex = 0;
            this.DoctorsLabel.Text = "Clinic Doctors:";

            this.DoctorListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoctorListBox.Location = new System.Drawing.Point(10, 30);
            this.DoctorListBox.Name = "DoctorListBox";
            this.DoctorListBox.Size = new System.Drawing.Size(872, 192);
            this.DoctorListBox.TabIndex = 1;

            // AppointmentsTab
            this.AppointmentsTab.Controls.Add(this.ToolsGroupBox);
            this.AppointmentsTab.Controls.Add(this.BookingGroupBox);
            this.AppointmentsTab.Controls.Add(this.AppointmentLabel);
            this.AppointmentsTab.Controls.Add(this.AppointmentListBox);
            this.AppointmentsTab.Location = new System.Drawing.Point(4, 24);
            this.AppointmentsTab.Name = "AppointmentsTab";
            this.AppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AppointmentsTab.Size = new System.Drawing.Size(892, 222);
            this.AppointmentsTab.TabIndex = 2;
            this.AppointmentsTab.Text = "Appointments";
            this.AppointmentsTab.UseVisualStyleBackColor = true;

            // AppointmentListBox
            this.AppointmentListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AppointmentListBox.Location = new System.Drawing.Point(10, 30);
            this.AppointmentListBox.Name = "AppointmentListBox";
            this.AppointmentListBox.Size = new System.Drawing.Size(872, 95);
            this.AppointmentListBox.TabIndex = 1;

            this.AppointmentLabel.AutoSize = true;
            this.AppointmentLabel.Location = new System.Drawing.Point(10, 10);
            this.AppointmentLabel.Name = "AppointmentLabel";
            this.AppointmentLabel.Size = new System.Drawing.Size(80, 13);
            this.AppointmentLabel.TabIndex = 0;
            this.AppointmentLabel.Text = "Scheduled Appointments:";

            // BookingGroupBox
            this.BookingGroupBox.Controls.Add(this.DoctorLabel);
            this.BookingGroupBox.Controls.Add(this.DoctorComboBox);
            this.BookingGroupBox.Controls.Add(this.PatientLabel);
            this.BookingGroupBox.Controls.Add(this.PatientComboBox);
            this.BookingGroupBox.Controls.Add(this.DateLabel);
            this.BookingGroupBox.Controls.Add(this.AppointmentDatePicker);
            this.BookingGroupBox.Controls.Add(this.TimeLabel);
            this.BookingGroupBox.Controls.Add(this.StartTimePicker);
            this.BookingGroupBox.Controls.Add(this.ReasonLabel);
            this.BookingGroupBox.Controls.Add(this.ReasonTextBox);
            this.BookingGroupBox.Controls.Add(this.BookButton);
            this.BookingGroupBox.Controls.Add(this.AppointmentCancelButton);
            this.BookingGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.BookingGroupBox.Location = new System.Drawing.Point(10, 130);
            this.BookingGroupBox.Name = "BookingGroupBox";
            this.BookingGroupBox.Size = new System.Drawing.Size(872, 50);
            this.BookingGroupBox.TabIndex = 2;
            this.BookingGroupBox.TabStop = false;
            this.BookingGroupBox.Text = "Book Appointment";

            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Location = new System.Drawing.Point(10, 20);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(41, 13);
            this.DoctorLabel.TabIndex = 0;
            this.DoctorLabel.Text = "Doctor:";

            this.DoctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoctorComboBox.Location = new System.Drawing.Point(60, 15);
            this.DoctorComboBox.Name = "DoctorComboBox";
            this.DoctorComboBox.Size = new System.Drawing.Size(100, 21);
            this.DoctorComboBox.TabIndex = 1;

            this.PatientLabel.AutoSize = true;
            this.PatientLabel.Location = new System.Drawing.Point(170, 20);
            this.PatientLabel.Name = "PatientLabel";
            this.PatientLabel.Size = new System.Drawing.Size(41, 13);
            this.PatientLabel.TabIndex = 0;
            this.PatientLabel.Text = "Patient:";

            this.PatientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatientComboBox.Location = new System.Drawing.Point(220, 15);
            this.PatientComboBox.Name = "PatientComboBox";
            this.PatientComboBox.Size = new System.Drawing.Size(100, 21);
            this.PatientComboBox.TabIndex = 1;

            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(330, 20);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date:";

            this.AppointmentDatePicker.Location = new System.Drawing.Point(375, 15);
            this.AppointmentDatePicker.Name = "AppointmentDatePicker";
            this.AppointmentDatePicker.Size = new System.Drawing.Size(100, 20);
            this.AppointmentDatePicker.TabIndex = 2;
            this.AppointmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(485, 20);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(30, 13);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "Time:";

            this.StartTimePicker.Location = new System.Drawing.Point(520, 15);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.Size = new System.Drawing.Size(80, 20);
            this.StartTimePicker.TabIndex = 2;
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.ShowUpDown = true;

            this.ReasonLabel.AutoSize = true;
            this.ReasonLabel.Location = new System.Drawing.Point(610, 20);
            this.ReasonLabel.Name = "ReasonLabel";
            this.ReasonLabel.Size = new System.Drawing.Size(44, 13);
            this.ReasonLabel.TabIndex = 0;
            this.ReasonLabel.Text = "Reason:";

            this.ReasonTextBox.Location = new System.Drawing.Point(660, 15);
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(80, 20);
            this.ReasonTextBox.TabIndex = 3;

            this.BookButton.Location = new System.Drawing.Point(750, 15);
            this.BookButton.Name = "BookButton";
            this.BookButton.Size = new System.Drawing.Size(50, 23);
            this.BookButton.TabIndex = 4;
            this.BookButton.Text = "Book";
            this.BookButton.UseVisualStyleBackColor = true;
            this.BookButton.Click += new System.EventHandler(this.BookButton_Click);

            this.AppointmentCancelButton.Location = new System.Drawing.Point(810, 15);
            this.AppointmentCancelButton.Name = "AppointmentCancelButton";
            this.AppointmentCancelButton.Size = new System.Drawing.Size(50, 23);
            this.AppointmentCancelButton.TabIndex = 4;
            this.AppointmentCancelButton.Text = "Cancel";
            this.AppointmentCancelButton.UseVisualStyleBackColor = true;
            this.AppointmentCancelButton.Click += new System.EventHandler(this.AppointmentCancelButton_Click);

            // ToolsGroupBox
            this.ToolsGroupBox.Controls.Add(this.SeedDataButton);
            this.ToolsGroupBox.Controls.Add(this.ExportButton);
            this.ToolsGroupBox.Controls.Add(this.ViewScheduleButton);
            this.ToolsGroupBox.Controls.Add(this.SendNotificationsButton);
            this.ToolsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolsGroupBox.Location = new System.Drawing.Point(10, 180);
            this.ToolsGroupBox.Name = "ToolsGroupBox";
            this.ToolsGroupBox.Size = new System.Drawing.Size(872, 35);
            this.ToolsGroupBox.TabIndex = 3;
            this.ToolsGroupBox.TabStop = false;
            this.ToolsGroupBox.Text = "Tools";

            this.SeedDataButton.Location = new System.Drawing.Point(10, 10);
            this.SeedDataButton.Name = "SeedDataButton";
            this.SeedDataButton.Size = new System.Drawing.Size(100, 23);
            this.SeedDataButton.TabIndex = 5;
            this.SeedDataButton.Text = "Seed Sample Data";
            this.SeedDataButton.UseVisualStyleBackColor = true;
            this.SeedDataButton.Click += new System.EventHandler(this.SeedDataButton_Click);

            this.ExportButton.Location = new System.Drawing.Point(120, 10);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 23);
            this.ExportButton.TabIndex = 5;
            this.ExportButton.Text = "Export to CSV";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);

            this.ViewScheduleButton.Location = new System.Drawing.Point(230, 10);
            this.ViewScheduleButton.Name = "ViewScheduleButton";
            this.ViewScheduleButton.Size = new System.Drawing.Size(100, 23);
            this.ViewScheduleButton.TabIndex = 5;
            this.ViewScheduleButton.Text = "View Schedule";
            this.ViewScheduleButton.UseVisualStyleBackColor = true;
            this.ViewScheduleButton.Click += new System.EventHandler(this.ViewScheduleButton_Click);

            this.SendNotificationsButton.Location = new System.Drawing.Point(340, 10);
            this.SendNotificationsButton.Name = "SendNotificationsButton";
            this.SendNotificationsButton.Size = new System.Drawing.Size(120, 23);
            this.SendNotificationsButton.TabIndex = 5;
            this.SendNotificationsButton.Text = "Send Notifications";
            this.SendNotificationsButton.UseVisualStyleBackColor = true;
            this.SendNotificationsButton.Click += new System.EventHandler(this.SendNotificationsButton_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinic Appointment Manager";

            this.MainTabControl.ResumeLayout(false);
            this.PatientsTab.ResumeLayout(false);
            this.PatientsTab.PerformLayout();
            this.DoctorsTab.ResumeLayout(false);
            this.DoctorsTab.PerformLayout();
            this.AppointmentsTab.ResumeLayout(false);
            this.AppointmentsTab.PerformLayout();
            this.BookingGroupBox.ResumeLayout(false);
            this.BookingGroupBox.PerformLayout();
            this.ToolsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage PatientsTab;
        private System.Windows.Forms.TabPage DoctorsTab;
        private System.Windows.Forms.TabPage AppointmentsTab;
        private System.Windows.Forms.ListBox PatientListBox;
        private System.Windows.Forms.ListBox DoctorListBox;
        private System.Windows.Forms.ListBox AppointmentListBox;
        private System.Windows.Forms.Label PatientsLabel;
        private System.Windows.Forms.Label DoctorsLabel;
        private System.Windows.Forms.Label AppointmentLabel;
        private System.Windows.Forms.GroupBox BookingGroupBox;
        private System.Windows.Forms.Label DoctorLabel;
        private System.Windows.Forms.ComboBox DoctorComboBox;
        private System.Windows.Forms.Label PatientLabel;
        private System.Windows.Forms.ComboBox PatientComboBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DateTimePicker AppointmentDatePicker;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.TextBox ReasonTextBox;
        private System.Windows.Forms.Button BookButton;
        private System.Windows.Forms.Button AppointmentCancelButton;
        private System.Windows.Forms.GroupBox ToolsGroupBox;
        private System.Windows.Forms.Button SeedDataButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ViewScheduleButton;
        private System.Windows.Forms.Button SendNotificationsButton;
    }
}
