# BioProject - API

## Requirements to run
1. Create an MSSQL Database
2. Open `appsettings.json` and change the connection string properties to match your newly created db options. The properties in connection strings are:
    - `Server` (name and port)
    - `Database`
    - `User`
    - `Password`
3. Open Visual Studio/ Visual Studio for Mac and run the project
4. There is a migration with seed data that have to automatically run on starting

`Note`: the default port of the server is `5001`