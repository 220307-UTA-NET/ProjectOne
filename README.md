# Project 1: VLLM - Very Local Library Management Tool - Web Application
220307 UTA .NET / Tryggve Rogness

This is a library management tool that mainly consists of three parts. The front end is a .NET console app that sends HTTP requests to an API. The API in turn sends queries to an SQL database. This interaction allows a user to perform some CRUD functions.

To get started configuring the tool, first create the database. Open the VLLstart.sql file in the root folder with your SQL management studio of choice. Connect to a database server and run the file (it will create the schema, tables, and insert example data into the db). Using a brand new Azure account will use the intro credit to pay for this database subscription cost.

Moving over to the API. The API needs to be deployed, this can be done by opening the solution in visual studio and using the publish option under the Build menu. Using a newer Azure account will allow for deploying this resource for free. Your SQL database connectionstring (found in the database overview under Settings>Connection Strings, make sure to replace the password placeholder with your password) can be added in the API's Setting>Configuration menu. You will also want to okay your API's outgoing IP addresses (found in API's Settings>Networking in Azure) with the server your database is on. Copy them and paste them into the server's firewall (from the server Security>Netwworking, add a rule for each of the API's outgoing IP addresses)

The user interface console will need to be updated with the location of where your deployed API is located. Then run the UI from Visual Studio, the console app will ask for inputs and give back the requested information.