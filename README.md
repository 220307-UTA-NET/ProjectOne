# Project 1: Web Application

This project is about performing CRUD operations on an employee database that is hosted in Azure Web Service. The user can interact through a console app, communicating to the web API, which will then connect to the SQL Server database to make the changes. Console app is pushed to DockerHub repo: https://hub.docker.com/repository/docker/aek94/p1

## Technologies Used
* dotnet 6.0.2
* Visual Studio 2022
* Azure Data Studio 
* Docker

## Features
* interactive console application with a REST HTTP API backend
* input validation (in the console app and also in the server)
* exception handling, including foreseen SQL and HTTP errors
* persistent data
* asynchronous network & other I/O

## To-do List:
### Test
* at least 10 test methods, some using Moq

### CI/CD
* Include a CI pipeline to analyze with SonarCloud and perform any unit tests
* Include a CD pipeline to build, publish, and create a Docker image of the app, and push it to DockerHub repo
* Include a CI pipeline to analyze with SonarCloud and perform any unit tests
* Include a CD pipeline to build, publish, and deploy the app to Azure App Service for deployment

## Getting started
### Clone the repo
git clone https://github.com/220307-UTA-NET/ProjectOne.git

### Environment Set up Steps
* Open project in dotnet IDE, preferrably Visual Studio
* Run the API //Should connect to the database server
* Run the console app //Should open console user interface

### Using Docker
* Pull from dockerhub: docker pull aek/p1:production
* Run image: docker run -i aek/p1:production

### Disclaimer
The app contains bugs. Future implementations needed for better functionality.
