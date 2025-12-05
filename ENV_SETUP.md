# Environment Configuration Guide

## Overview
This project uses environment variables to manage sensitive configuration data. All sensitive information such as MongoDB connection strings should be stored in a `.env` file instead of hardcoded values.

## Files Created

### 1. `.env` - Environment Variables File
**Location**: `ClinicAppointmentManager/.env`

Contains all sensitive configuration:
```
MONGODB_CONNECTION_STRING=mongodb+srv://user:password@cluster.mongodb.net/
MONGODB_DATABASE_NAME=appointmentBooking
APP_NAME=Clinic Appointment Manager
APP_VERSION=1.0.0
APP_DESCRIPTION=Desktop application for managing patient appointments with MongoDB
ERROR_LOG_FILE=errors.log
NOTIFICATION_LOG_FILE=notifications.log
SEEDING_LOG_FILE=seeding.log
```

**Important**: This file is automatically copied to the build output directory (`bin/Debug/net10.0-windows/`) during build.

### 2. `.gitignore` - Git Ignore Rules
**Location**: `ClinicAppointmentManager/.gitignore`

Ensures that sensitive files are NOT committed to version control:
- `.env` - Prevents uploading local configuration
- `.env.local` - Local overrides
- `bin/`, `obj/` - Build artifacts
- `*.log` - Log files
- `.vscode/`, `.idea/` - IDE files
- Other sensitive data

## How Configuration Works

### Loading Order
1. Application checks for `.env` file in the executable's directory (`bin/Debug/net10.0-windows/`)
2. If not found, checks the parent directory
3. Loads all variables from the `.env` file using the `DotNetEnv` NuGet package
4. Reads variables via `Environment.GetEnvironmentVariable()`
5. Falls back to system environment variables if `.env` file is not found

### Code Implementation
**File**: `Data/MongoDbContext.cs`

```csharp
// Load .env file if it exists
var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
}

// Read configuration from environment variables
_mongoConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
_mongoDbName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");
```

## Setup Instructions

### For Development
1. Create a `.env` file in the project root with your MongoDB credentials:
   ```
   MONGODB_CONNECTION_STRING=mongodb+srv://youruser:yourpassword@cluster.mongodb.net/
   MONGODB_DATABASE_NAME=your_database_name
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. The `.env` file will be automatically copied to the output directory.

4. Run the application:
   ```bash
   dotnet run
   ```

### For Production
1. Set environment variables directly in the deployment environment:
   ```bash
   export MONGODB_CONNECTION_STRING="your_connection_string"
   export MONGODB_DATABASE_NAME="your_db_name"
   ```

2. Do NOT commit the `.env` file to version control.

3. The application will use the system environment variables.

## Security Best Practices

✅ **DO:**
- Keep `.env` file in `.gitignore`
- Use strong passwords for MongoDB Atlas
- Rotate credentials regularly
- Use environment-specific `.env` files (`.env.local`, `.env.production`)
- Document configuration requirements in README

❌ **DON'T:**
- Hardcode credentials in source code
- Commit `.env` files to version control
- Share `.env` files via email or chat
- Use weak/generic passwords
- Log sensitive information

## NuGet Package Used

- **DotNetEnv** (v2.5.0): Loads environment variables from `.env` files
  - Simple and lightweight
  - Works with .NET applications
  - Supports multiple .env file locations

## Verification

To verify the configuration is working:

1. Build the project:
   ```bash
   dotnet build
   ```

2. Check that `.env` file exists in `bin/Debug/net10.0-windows/`:
   ```bash
   ls bin/Debug/net10.0-windows/.env
   ```

3. Run the application and check for MongoDB connection message:
   ```bash
   dotnet run
   ```
   You should see: "✓ MongoDB connection established successfully."

## Troubleshooting

### Error: "MONGODB_CONNECTION_STRING environment variable not set"
- Ensure `.env` file exists in the correct location
- Verify the file has the correct variable name (case-sensitive on Linux/Mac)
- Check that the file is readable

### Error: "MongoDB configuration not set"
- Verify both `MONGODB_CONNECTION_STRING` and `MONGODB_DATABASE_NAME` are defined
- Ensure no leading/trailing spaces in values
- Check that the values are not empty strings

### Application builds but won't start
- Verify the `.env` file is copied to the build output directory
- Check the MongoDB connection string is valid
- Ensure MongoDB server is accessible at the specified URL

## Files Modified

1. **MongoDbContext.cs**
   - Added System.IO namespace
   - Added DotNetEnv using statement
   - Changed from hardcoded constants to environment variable loading
   - Added .env file path detection logic

2. **ClinicAppointmentManager.csproj**
   - Added DotNetEnv NuGet package reference
   - Added `.env` file to project with `CopyToOutputDirectory` setting

## Summary

The application now securely manages sensitive configuration:
- ✅ No hardcoded credentials in source code
- ✅ Environment variables for all environments
- ✅ `.env` file excluded from version control
- ✅ Automatic file copying during build
- ✅ Backward compatible with system environment variables
- ✅ Zero breaking changes to existing functionality
