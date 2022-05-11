# Project 1: Alpha Demo Web Application
220307 UTA .NET / Richard Hawkins

## The purpose of the project
* The purpose of the project is to work as a banking system.

## Description of the project
* Project as the administration of the bank which can see the information of user and the user's account 
* Does have the project for getting inforamtion of all users, register a certin user's information, updating user's information,
getting all count information(ex.balance), making new account, updating an account information
* Despite saying 'Login', actually is the controller for the user 
* Despite saying 'Front', actually is the controller for the account
* Does not contain finding the individual information or deleting the information either the user or the account


## Future Plan
* Add the controller which contains finding the individual information of a user or the account
* Add the controller to delete the individual information of a user or the account
* Login controller needs to be corrected
* Role Access whether is able to control the information or not is plan to add 
* Console App is still under construction 


### Tests
* set four tests (two for user and two for account)
* two tests are involved in the moq.



# The requirements

## Functionality
* interactive console application with a REST HTTP API backend
* input validation (in the console app and also in the server)
* exception handling, including foreseen SQL and HTTP errors
* persistent data
* (recommended: asynchronous network & other I/O, at least on the REST API)
* (optional: logging of exceptions and other events


## Design
* use ADO.NET (not Entity Framework)
* use ASP.NET Core Web API
* use an Azure SQL DB in third normal form
* have a SQL script that can set up the database from scratch
* don't use public fields
* define and use at least one interface
* best practices: separation of concerns, OOP principles, SOLID, REST, HTTP
* XML documentation


### REST API
* the API should own the business logic of the application, not just the data access logic
* it shouldn't trust that the console app hasn't been tampered with
* should be able to handle multiple instances of the console app connecting to it at the same time
* use dependency injection for controller dependencies
* separate different concerns into different classes
* use repository pattern for data access
* recommended to keep the Web API project for only HTTP input/output concerns
* recommended to use separate classes to help validate/format the HTTP message bodies (DTOs for model binding and action results)
* recommended to separate business logic into a separate project from the Web API project and any HTTP or ADO.NET concerns
* recommended to separate the data access into a separate project too


### Console App
* the console app provides a UI, interprets user input, uses the REST API over HTTP, and formats output
* should gracefully handle HTTP error codes from the server, as well as connection errors
* separate different concerns into different classes
* recommended to separate the connection to the API into a separate project
* recommended to keep the console app project for only console interface concerns, not HTTP concerns


### Tests
* at least 10 test methods
* at least 1 test should use Moq
* no tests should connect to the app's actual database


### CI/CD
* your console app should include a CI pipeline to analyze with SonarCloud and perform any unit tests you have written
* your console app should include a CD pipeline to build, publish, and create a Docker image of your app, and push it to your DockerHub repo
* your API should include a CI pipeline to analyze with SonarCloud and perform any unit tests you have written
* your API should include a CD pipeline to build, publish, and deploy your app to Azure App Service for deployment

