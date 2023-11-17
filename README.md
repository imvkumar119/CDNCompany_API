# CDN_Company


CDN - Complete Developer Network

Description:

CDN aims to build a comprehensive directory of freelancers. This repository contains the implementation of a RESTful API using ASP.NET Core Web API and a simple MVC application for managing user information, including registration, deletion, updating, and retrieval operations.

Installation of Softwares & Packages:
       - Visual Studio 2022 & Sql Server Management Studio 2019
       - .nuget\Dapper (it is act as middleware of api & Database)
       - packages\microsoft.data.sqlclient - api
       - packages\microsoft.extensions.configuration.abstractions - dapper
       - packages\microsoft.data.sqlclient - Dapper
       - packages\microsoft.aspnetcore.openapi - api
       - packages\microsoft.aspnetcore.mvc.razor.runtimecompilation - mvc
       - jQuery plugin - mvc

References of projects:
      - CDN_Company(api) - reference DapperData Project
      - CDN_UI - reference of CDN_Company Project

 Technologies Used:
       -  Backend Framework :  ASP.NET Core Web API and MVC & Dapper
       -  Frontend Technologies :  HTML, jQuery, Ajax
       -  Database :  My SQL Server 

Explanation of Building  Application:
     - Open the solution in Visual Studio 2022.
     - Run the application.
     - This will start the development server at https://localhost:7285/api/User/    for the  Web API and https://localhost:7138/ for the MVC application.

Backend API Endpoints: 

Get List of CDN Users - 
Method: GET
Endpoint: /api/user
URL: https://localhost:7285/api/user

Add a New User-
Method: POST
Endpoint: /api/user/Post
URL: https://localhost:7285/api/user/Post
Payload: JSON containing user details (username, mail, phone number, skillsets, hobby)

Update User Details-
Method: PUT
Endpoint: /api/users/{id}
URL: https://localhost:7285/api/user/1
Payload: JSON containing updated user details

Delete a User-
Method: DELETE
Endpoint: /api/users/{id}
URL: https://localhost:7285/api/user/1

