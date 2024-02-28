First, extract the SQL_DATABASES.ZIP file, and run both .SQL Scripts to create and load each database (QuoteDB and AccountDB).  You may need
to modify the location of your SQL Server Database Files at the top of each Script.

Once Databases are created, just clone the repositories, open the main VS 2022 Solution, fixup your connection strings to all databases in appsettings.json to point to your
SQL Server, and then you can run/debug the application. 
