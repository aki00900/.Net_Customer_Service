
# CustomerService and CustomerSimulator Setup Guide

This guide provides comprehensive instructions for setting up and running both the CustomerService server and the CustomerSimulator application.

## Prerequisites

Before proceeding, please ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)  
- A code editor (e.g., Visual Studio Code)

## Steps to Run CustomerService and CustomerSimulator

### 1. Set Up and Run CustomerService

1. **Navigate to the CustomerService directory**:
   ```bash
   cd CustomerService
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

4. **Run the CustomerService server**:
   ```bash
   dotnet run
   ```

5. **Copy the server URL**:  
   Once the server is running, take note of the local host URL where CustomerService is active (e.g., `http://localhost:5000`).

6. **Update the CustomerSimulator BASEURL**:
   - Open `Program.cs` located in the `customerService` directory.
   - Update the `BASEURL` variable with the URL and port number of the running CustomerService server.

### 2. Set Up and Run CustomerSimulator

1. **Navigate to the CustomerSimulator directory**:
   ```bash
   cd CustomerSimulator
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

4. **Run the CustomerSimulator application**:
   ```bash
   dotnet run
   ```
