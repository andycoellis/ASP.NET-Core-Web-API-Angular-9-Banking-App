**ASP.NET Core Banking Administarion Application**<br>
**ASP.NET Core Web API**<br>
**Angular 8 Administation Portal**

#### Summary
*National Wealth Bank of Australasia*

Code Influences and templates
---
>Please note that throughout the code you will come across comments that reference inspiration of structure behind code and common design templates shown from tutorials. Any code not of this projects developers design is referenced and attributed to in comments. There are however three main sources of online tutorials that influenced **security** and **respository pattern**. **Jason Watmore's** tutorial helped develop the structure of this projects JWT Authentication Token system, and **Programming with Mosh** and his tutorial was the base template for our *Repository Design Pattern.* Links are found in code.

#### Notes
>Please take **note** there are two ways of running this application, one way involves using hardcoded values for 
username and password and for a secret key string that is important for JWT Token Authentication. The system is currently setup for hardcoded so there are minimal steps required. If you want to utilise dotnets user-secrets there will be attached a .microsoft.zip file that needs to be placed in your local root folder <usually cd ~>

Startup Procedures
---
**Hardcoded Start**
+ Download
+ Navigate to the ClientApp folder of <WDT2020-a3> *project*
+ then open terminal or cmd shell and npm install
+ This will download all node-modules for the project
  
 **Hidden Keys Mode**
+ Download
+ Navigate to the ClientApp folder of <WDT2020-a3> *project*
+ then open terminal or cmd shell and npm install
+ This will download all node-modules for the project
+ Retrieve microsoft.zip from Project Root in git
+ Open zip in your root folder, cd~ *this will install a dotnet user-secret with json, this will link to the project*
+ **WARNING: Once unzipped the containg folder is hidden, so only unzip once placed in the root directory**
+ Navigate to the to project folders in <WDT2020-a3> project. **startup.cs** & **AuthController.cs**
+ In these two classes you will find sections which tell you what to uncomment and what to comment
+ Project will now be ready for launch


#### Application Features
Admin Portal
---
+ **Secure Http Requests**
+ **View Transaction History:** *Generate Tables, Generate Graphs, View Specific Dates*
+ **Customer Profile:** *Update, Delete and Modify*
+ **User Accounts:** *Lock and Unlock customer login accounts*
+ **BillPay Accounts:** *Block and Unblock a users schedule BillPay transaction*

Banking Website
---
+ **Auto Logout:** *after one minute of inactivity*
+ **Account Lockout:** *after three failed attempts at logging in users account will be locked for one minute*
+ **Customised Error Pages** *users will be presented with a specific error page*

#### System Requirements

**ASP.NET Core**
.NET Core SDK 3.1.101
.Net Core Runtime 3.1.1

VisualStudio Version 8.4.2 (build 59)

**Client Side**
Angular CLI: 9.0.1
Node: 12.14.1
NPM: 6.13.4

#### Dependencies

**Frameworks**
- Microsoft.AspNetCore.App (3.1.0)
- Microsoft.NETCore.App (3.1.0)

**NuGet** *packages*
Microsoft.AspNetCore.SpaServices.Extensions
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.IdentityModel.Tokens
System.IdentityModel.Tokens.Jwt
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.EntityFrameworkCore

#### Application Architecture
The application was with ASP.NET Core Web API

- Please *NOTE* that only folders which implement the Repository Pattern are shown

```bash
├── Controllers
│   ├── AuthController.cs
│
├── Services
│   ├── DB Contexts
│   │   ├── AdminContext.cs
│   │
│   ├── IRepositories
│   │   ├── IRepository.cs
│   │   │
│   │   ├── IAccountRepository.cs
│   │   ├── IBillPaysRepository.cs
│   │   ├── ICustomerRepository.cs
│   │   ├── ILoginsRepository.cs
│   │   ├── ITransactionRepository.cs
│   │
│   ├── Repositories
│   │   ├── UnitOfWork.cs
│   │   ├── Repository.cs
│   │   │
│   │   ├── AccountRepository.cs
│   │   ├── BillPaysRepository.cs
│   │   ├── CustomerRepository.cs
│   │   ├── LoginsRepository.cs
│   │   ├── TransactionRepository.cs
│   │
│   ├── IUnitOfWork.cs
│
├── Startup.cs
```
