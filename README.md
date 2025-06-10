# ElectronicMarket - .NET MVC Application

This repository contains the source code for an Electronic Market web application built using the .NET Framework MVC framework.

## Technologies Used

* **Backend Framework:** .NET Framework 4.7.2 or 4.8 MVC
* **Programming Language:** C#
* **Database:** SQL Server 2014
* **Development Environment:** Visual Studio 2017
* **Data Access Layer:** Entity Framework

## Setup and Configuration

To run this application, you will need to have:

1.  **Visual Studio 2017** installed on your machine.
2.  **SQL Server 2014** installed and running.
3.  **The database backup file `ElectronicMarket.bak`**.

### Database Recovery

The application relies on a SQL Server database named `ElectronicMarket`. To set up the database, you will need to **restore the database from the provided backup file `ElectronicMarket.bak` using SQL Server Management Studio (SSMS)** or other SQL Server administration tools.

**Steps to restore the database:**

1.  **Open SQL Server Management Studio (SSMS) and connect to your SQL Server 2014 instance.**
2.  **In Object Explorer, right-click on the "Databases" folder.**
3.  **Select "Restore Database...".**
4.  **Under the "Source" section, select "Device" and click the "..." button.**
5.  **In the "Select backup devices" dialog, click "Add" and browse to the location of the `ElectronicMarket.bak` file on your machine.**
6.  **Select the `ElectronicMarket.bak` file and click "OK".**
7.  **In the "Restore Database" dialog, under the "Destination" section, ensure the "Database" field is set to `ElectronicMarket`.**
8.  **[Optional]** You may need to adjust the physical file locations under the "Files" page if your SQL Server has different default paths.
9.  **Click "OK" to start the database restore process.**

Once the database is successfully restored, you can proceed with configuring the connection string.

### Database Connection String Configuration

The connection string to the SQL Server database is located in the `App.config` file within the Data Access Layer (DAL) project. **You will need to modify the username and password in this connection string to match your local SQL Server configuration.**

**Locate the following section in the `App.config` file:**

```xml
<connectionStrings>
    <add name="ElectronicMarketEntities" connectionString="metadata=res://*/ElectronicMarketEntities.csdl|res://*/ElectronicMarketEntities.ssdl|res://*/ElectronicMarketEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=ElectronicMarket;user id=sa;password=123456;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```

**Important:**

* **`data source=.;`**: This assumes your SQL Server instance is running on the local machine. If it's on a different server, replace `.` with the server name or IP address.
* **`initial catalog=ElectronicMarket;`**: This specifies the name of the database that the application will connect to. **Ensure you have successfully restored the `ElectronicMarket` database as described in the "Database Recovery" section.**
* **`user id=sa;`**: **Replace `sa` with your SQL Server username.**
* **`password=123456;`**: **Replace `123456` with your SQL Server password.**

**Example of a modified connection string:**

```xml
<connectionStrings>
    <add name="ElectronicMarketEntities" connectionString="metadata=res://*/ElectronicMarketEntities.csdl|res://*/ElectronicMarketEntities.ssdl|res://*/ElectronicMarketEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=YOUR_SERVER_NAME;initial catalog=ElectronicMarket;user id=YOUR_USERNAME;password=YOUR_PASSWORD;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```

**After updating the connection string, ensure that the specified user has the necessary permissions to access the `ElectronicMarket` database.**

### Building and Running the Application

1.  **Clone the repository** to your local machine:
    ```bash
    git clone [repository URL]
    ```
2.  **Open the `ElectronicMarket.sln` file** using Visual Studio 2017.
3.  **Build the solution:** Navigate to `Build` \> `Build Solution` in the Visual Studio menu. Ensure there are no build errors.
4.  **Run the application:** Press `Ctrl + F5` (Start Without Debugging) or click the "IIS Express" button to run the application. This will typically open the application in your default web browser.

## Contributing

[Optional: Add information about how others can contribute to your project, such as bug reports, pull requests, etc.]

## License

[Optional: Add information about the project's license.]
