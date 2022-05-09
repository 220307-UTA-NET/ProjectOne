# Project 1: Web Application
Betta Fish Information

Functionality
* The program is an interactive console application with a REST HTTP API backend.
* The program has input validation (in the console app and also in the server).
* The program has exception handling, including foreseen SQL and HTTP errors.
* The program can store persistent data.
* The program uses asynchronous network & other I/O, at least on the REST API.
* The program has logging of exceptions and other events.

Design
* The program used ADO.NET.
* The program used ASP.NET Core Web API.
* The program used an Azure SQL DB in third normal form.
* The program have a SQL script that can set up the database from scratch.
* The program does not use public fields.
* The program used an interface to call data from the database.
* The program used best practices: separation of concerns, OOP principles, SOLID, REST, HTTP.

REST API
* The program used dependency injection for controller dependencies.
* The program has separated different concerns into different classes.
* The program use repository pattern for data access.
* The program used Web API for only HTTP input/output concerns.
* The program used separate classes to help validate/format the HTTP message bodies (DTOs for model binding and action results)
* The program used separate business logic into a separate project from the Web API project and any HTTP or ADO.NET concerns
* The program separated the data access into a separate project too.

### Console App
* The program's console app provides a UI, interprets user input, uses the REST API over HTTP, and formats output.
* The program gracefully handle HTTP error codes from the server, as well as connection errors.
* The program separated different concerns into different classes.
* The program separated the connection to the API into a separate project.
* The program kept the console app project for only console interface concerns, not HTTP concerns.

Tests
* The program tested six methods utlizing Moq.

Azure
* The program is live on Azure Wepp Service.
