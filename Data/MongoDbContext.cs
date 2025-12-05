using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.IO;
using ClinicAppointmentManager.Models;
using ClinicAppointmentManager.Exceptions;
using DotNetEnv;

namespace ClinicAppointmentManager.Data
{
    /// <summary>
    /// MongoDB context provider that manages database connections and collections.
    /// Reads MongoDB connection details from .env file or environment variables.
    /// </summary>
    public class MongoDbContext
    {
        private readonly string _mongoConnectionString;
        private readonly string _mongoDbName;
        private IMongoClient _client;
        private IMongoDatabase _database;

        /// <summary>
        /// Initializes the MongoDB context with connection string and database name from environment variables or .env file.
        /// </summary>
        public MongoDbContext()
        {
            try
            {
                // Load .env file if it exists
                var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                if (File.Exists(envPath))
                {
                    Env.Load(envPath);
                }
                else
                {
                    // Try loading from parent directories (common in development)
                    var parentEnvPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.FullName ?? "", ".env");
                    if (File.Exists(parentEnvPath))
                    {
                        Env.Load(parentEnvPath);
                    }
                }

                // Read from environment variables or use fallback
                _mongoConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") 
                    ?? throw new DatabaseException("MONGODB_CONNECTION_STRING environment variable not set. Please configure .env file or environment variable.");
                
                _mongoDbName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME") 
                    ?? throw new DatabaseException("MONGODB_DATABASE_NAME environment variable not set. Please configure .env file or environment variable.");

                if (string.IsNullOrWhiteSpace(_mongoConnectionString) || string.IsNullOrWhiteSpace(_mongoDbName))
                {
                    throw new DatabaseException(
                        "MongoDB configuration not set. Please configure MONGODB_CONNECTION_STRING and MONGODB_DATABASE_NAME in .env file or environment variables.");
                }

                _client = new MongoClient(_mongoConnectionString);
                _database = _client.GetDatabase(_mongoDbName);

                // Verify connection by performing a ping
                var admin = _database.Client.GetDatabase("admin");
                var result = admin.RunCommand<BsonDocument>(new BsonDocument("ping", 1));

                Console.WriteLine("✓ MongoDB connection established successfully.");
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Failed to connect to MongoDB: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the MongoDB collection for patients.
        /// </summary>
        public IMongoCollection<Patient> Patients
        {
            get
            {
                return _database.GetCollection<Patient>("patients");
            }
        }

        /// <summary>
        /// Gets the MongoDB collection for doctors.
        /// </summary>
        public IMongoCollection<Doctor> Doctors
        {
            get
            {
                return _database.GetCollection<Doctor>("doctors");
            }
        }

        /// <summary>
        /// Gets the MongoDB collection for appointments.
        /// </summary>
        public IMongoCollection<Appointment> Appointments
        {
            get
            {
                return _database.GetCollection<Appointment>("appointments");
            }
        }

        /// <summary>
        /// Creates necessary indexes for improved query performance.
        /// </summary>
        public void CreateIndexes()
        {
            try
            {
                // Create index for patient email (unique constraint)
                var patientEmailIndexModel = new CreateIndexModel<Patient>(
                    Builders<Patient>.IndexKeys.Ascending(p => p.Email),
                    new CreateIndexOptions { Unique = true }
                );
                Patients.Indexes.CreateOne(patientEmailIndexModel);

                // Create index for doctor license number (unique constraint)
                var doctorLicenseIndexModel = new CreateIndexModel<Doctor>(
                    Builders<Doctor>.IndexKeys.Ascending(d => d.LicenseNumber),
                    new CreateIndexOptions { Unique = true }
                );
                Doctors.Indexes.CreateOne(doctorLicenseIndexModel);

                // Create indexes for appointment queries
                var appointmentDoctorDateIndexModel = new CreateIndexModel<Appointment>(
                    Builders<Appointment>.IndexKeys
                        .Ascending(a => a.DoctorId)
                        .Ascending(a => a.StartTime)
                );
                Appointments.Indexes.CreateOne(appointmentDoctorDateIndexModel);

                var appointmentPatientIndexModel = new CreateIndexModel<Appointment>(
                    Builders<Appointment>.IndexKeys.Ascending(a => a.PatientId)
                );
                Appointments.Indexes.CreateOne(appointmentPatientIndexModel);

                Console.WriteLine("✓ Database indexes created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Warning: Could not create indexes: {ex.Message}");
            }
        }

        /// <summary>
        /// Drops all collections (use only for testing/cleanup).
        /// </summary>
        public void DropAllCollections()
        {
            try
            {
                _database.DropCollection("patients");
                _database.DropCollection("doctors");
                _database.DropCollection("appointments");
                Console.WriteLine("✓ All collections dropped.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Warning: {ex.Message}");
            }
        }
    }
}
