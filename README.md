# Decision Maker Backend

# [Demo](https://decideapi20231119093623.azurewebsites.net/)

This project is the backend for [the decision maker website](https://take-decision.netlify.app). 
It is an ASP.NET Core Web API project that provides the following API endpoints:
- POST /api/decisions: Adds a decision by specifying the decision ID and the decision maker, importance.
- GET /api/decisions: Returns a list of all decisions in the database.
- GET /api/decisions/{id}: Returns a decision by specifying the decision ID.
- PUT /api/decisions/{id}: Updates a decision by specifying the decision ID and the decision maker, importance.
- PATCH /api/decisions/{id}: Modifies the value of a property on a decision by specifying the decision ID, property name, and value.
- POST /api/decision/pros: Adds a pro to a decision by specifying the pro ID and the decision maker, importance.
- POST /api/decision/cons: Adds a con to a decision by specifying the pro ID and the decision maker, importance.

## Prerequisites

- [.NET 5.0 SDK]
- [Visual Studio 2019] or [Visual Studio Code]
- [SQL Server Express] or any other SQL Server edition

## Installation
 install this project, follow these steps:

- Clone this repository to your local machine.
- Open the solution file DecisionMakerBackend.sln in Visual Studio 2019 or the folder DecisionMakerBackend in Visual Studio Code.
- Update the connection string in the appsettings.json file to point to your SQL Server instance.
- Run the command dotnet ef database update in the Package Manager Console (Visual Studio 2019) or the Terminal (Visual Studio Code) to create the database and apply the migrations.
- Run the project by pressing F5 or clicking the Run button.

## Usage
To use this project, you can either use a tool like [Postman](https://www.postman.com/) or [Swagger UI](https://decideapi20231119093623.azurewebsites.net/) to test the API endpoints, or use the [Decision Maker Frontend](https://take-decision.netlify.app) project to interact with the backend through a web interface.