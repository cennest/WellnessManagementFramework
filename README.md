WellnessManagementSystem
======================


1. Run the DB script at ....\WellnessManagementSystem\DataLayer\WellnessManagementSystemDBscript into local SQL database.


2. Take connection string and replace connectionStrings in ...WellnessManagementSystem\DataLayer\app.config.
eg:
  <connectionStrings>
   <add name="SimulationDataLayer.Properties.Settings.WellnessManagementSystemDBConnectionString"
            connectionString="Data Source=omudcknnkm.database.windows.net;Initial Catalog=WellnessManagementSystemDB;User ID=cennest;Password=cennest"
            providerName="System.Data.SqlClient" /
  </connectionStrings>


4. Ensure VS(Visual Studio) has the "WPFUI" project as start up projects.


5. Then Debug or Press f5.


6. You should see WellnessManagementSystem popping up.