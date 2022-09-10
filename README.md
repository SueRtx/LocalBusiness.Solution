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
* JWT Authentication

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
* Download MySQL WorkBench & Postman 
* Go to terminal  → $ dotnet restore → $ dotnet build → $ dotnet ef database update
* Run Program: $ dotnet watch run  
* Open web browser: http://localhost:5000/  (Swagger) or Open Postman

### Swagger Option

* Swagger is an open-source standardized and language-agnostic interface for designing and documenting REST APIs. It can be used to design APIs before they’re built or to document APIs after the code has already been implemented.

 ![Swagger](/LocalApi/image/swagger.png)
 
* AuthManagement    
   - Post [/api/Authmanagement/Register] → Select [drop down] → Click: [Try it out] button → Enter your information → [Excute] → Copy token  
   - POSt [[/api/Authmanagement/Login] → Select [drop down] → Click: [Try it out] button → Enter login information → [Excute] → Copy token  
   
* Authorize    
   -Value box: Paste [token] → Authorize  
   
* Businesses    
   - Select [drop down]    
     GET (Local Business List) / POST (Create Local Business) / GET (Find Local Business by Id)  /  PUT (Update Local Business) /DELETE (DElete Local Business)   
   - Click: [Try it out] button  
  
### Postman Option
* Postman is an API platform for building and using APIs. Postman simplifies each step of the API lifecycle and streamlines collaboration so you can create better APIs—faster.
  
 ![Postman](/LocalApi/image/postman.png)
  
* Register (New User) 
  - URL [https://localhost:5001/api/authmanagement/register] → [POST] → [Body] → [raw] → JSON → Create your account [paste and enter your informations] → [Send] → copy token 
```
{
  "Username": "[your username here]",
  "email": "[your email here]",
  "password": "[your password here. require upper & lower case letter, special character, number]"
}
  
```
  
* Login   
  - URL [https://localhost:5001/api/authmanagement/login]  → [POST] → [Body] → [raw] → [JSON] → Login  account [paste and enter your informations]  → [Send]  → copy token  
  
``` 
{
  "email": "[your email here]",
  "password": "[your password here]"
}
  
```
* Authorize User
  [GET] → [Headers] → Type[Authorization] in Key box → Type [Bearer] in Value → Paste your token [Bearer [Your token]]  
  
```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9ey
JJZCI6ImFmZWZjYzE3LWQ4OGQtNDE1OS1hYjU1LTA1OWQ
xODFiNGViMSIsImVtYWlsIjoic2FtbXkyMDIyQHlhaG9v
LmNvbSIsInN1YiI6InNhbW15MjAyMkB5YWhvby5jb20iLCJqdGkiOiI0

```  
  
* Business List  
   - URL https://localhost:5001/api/businesses → [GET]  → [Send]    
   
* Find Business by Id  
   - URL https://localhost:5001/api/businesses/1 → [GET]  → [Send]    
  
* Create Business    
   - URL https://localhost:5001/api/businesses → [POST] → [Body] → [raw] → [JSON] →Enter Business informatin to create → [Send]      
  
   ``` 
  {
    "businessId": 7,
    "name": "Candy Bar",
    "description": "Restaurant",
    "location": "Baytown"
  }
  
  ```  
   
* Edit Business   
   - URL https://localhost:5001/api/businesses/7 → [PUT] → [Body] → [raw] → [JSON] →Enter Business Informatin to Edit → [Send]   
   
   ``` 
  {
    "businessId": 7,
    "name": "Candy Bar",
    "description": "Restaurant",
    "location": "Huston"
  }
  
  ```  
   
* Delete Business    
   - URL https://localhost:5001/api/businesses/7 → [DELETE]  → [Send]    
   
## Known Bugs

* Authorize user are not allow to do anything at Businesses section in swagger.

## License

MIT

Copyright (c) 2022 Sue Roberts