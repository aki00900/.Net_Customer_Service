# CustomerService and CustomerSimulator Setup

This guide provides step-by-step instructions for setting up and running the CustomerService server followed by the CustomerSimulator application.

## Prerequisites

Before you begin, ensure that you have the following prerequisites installed on your system:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- Code editor (e.g., Visual Studio Code)

## Running CustomerService and CustomerSimulator

1. <b>Navigate to the CustomerService directory:
   ```bash
   cd CustomerService

   dotnet restore
   dotnet build
   dotnet run


2. <b>After running the server, take note of the local host URL where CustomerService is running.</b><br> 

<br>Typically, it will be something like http://localhost:5000 and paste in the customerService/Program.cs -> update the BASEURL variable wit the copied current localHost url along with the port number.

3 <b> Navigate to the CustomerSimulator directory:
   ```bash
   cd CustomerService

   dotnet restore
   dotnet build
   dotnet run