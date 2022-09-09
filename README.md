# Local Business API (C# Project 6)

#### By Sue Roberts

####  Local business Api lookup for restaurants and shops in town.

## Technologies Used

* C#
* .NET 5.0
* SQL Workbench
* Entity Framework
* ASP.Net 
* API
* Swagger

## Description

This application has an API for a local business lookup. The API includes a list of restaurants and shops in town that users can add, delete, search, and update with Swagger documentation.

## Setup/Installation Requirements

* Clone repository: $ git clone https://github.com/SueRtx/LocalBusiness.Solution.git 
* Open Vs Code: $ code .   
* Open TERMINAL in Vs Code
* Go to SavorySweets directory: $ cd LocalApi
* Create file at root directory: $ touch "appsettings.json"
* Add following code to "appsettings.json" (Add your own password)
```

{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=sun_roberts;uid=root;[YOUR-PASSWORD];"
  }
}

``` 
* Download MySQL WorkBench  
* Go to terminal  → $ dotnet restore → $ dotnet build → dotnet ef database update
* Run Program: $ dotnet watch run  
* Open web browser: http://localhost:5000/  

## Swagger
* wagger is an open-source standardized and language-agnostic interface for designing and documenting REST APIs. It can be used to design APIs before they’re built or to document APIs after the code has already been implemented
* Select drop down: GET(Business List), POST(Create business), Return individual business base by Id, PUT(Update Business), or DELETE(DElete business)
* Click: [Try it out] button

## Known Bugs

* none

## License

MIT

Copyright (c) 2022 Sue Roberts