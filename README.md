# Blue Bank
___
### .NET 5 Project
---
Blue Bank is an ASP.NET project based on DDD clean architecture and microservices.

## Table Of Contents
- [Goals](#goals)
- [Getting Started](#getting-started)
- [Design Decisions and Dependencies](#design-decisions-and-dependencies)
- [Github Actions](#github-actions)
- [Next Steps](#next-steps)



# Goals

The goal of this repository is to provide a basic solution structure based on clean architecture, DDD and microservice to implement a simple backend simulating simple bank transactions. 

# Getting Started

To run this project locally, There are few steps
- Install docker desktop.
- Download this Repository.
- Navigate to src/BlueBank.
- Run command 
-- ```docker-compose up```
- Open http://localhost:7005/swagger/index.html
- The above the swagger for a gateway from there all the endpoints of all the microservices could be consumed.
- 
### The active endpoints
- GET {{apihost}}/accountsservice/Customers
-- To list all the customers in the system.
- GET {{apihost}}/accountsservice/Customers/{id}
-- To get single customer details.
- POST {{apihost}}/accountsservice/Accounts
-- To create and account for an existing customer.
- {{apihost}}/transactionsservice/{everything}
-- These are the ednpoints of the Transactions microservices. These endpoints are consumed internally be the accounts microservices.
 
# Design Decisions and Dependencies

This sample does not include every possible framework, tool, or feature that a particular enterprise application might benefit from, but it represent a base solution which can fit and grow easily in an enterprise. Its choices of technology for things like data access are rooted in what is the most common, accessible technology for most business software developers using Microsoft's technology stack. It doesn't (currently) include extensive support for things like logging, monitoring, or analytics, though these can all be added easily. Below is a list of the sub projects included in BlueBank solution.

## Accounts Microservice
It a microservice for creating and retrieving accounts for the bank customers.
### The Core Project
The Core project is the center of the Clean Architecture design, and all other project dependencies point toward it. As such, it has very few external dependencies. The Core project should include things like:
- Entities
- Aggregates
- Domain Events
- DTOs
- Interfaces
- Event Handlers
- Domain Services
- Specifications

### The SharedKernel Project
It's a **Shared Kernel** project/package. It has its own git flow to be published as a NuGet package (currently it's public on Azure DevOps to make it easy for any view to restore it) and referenced as a NuGet dependency by those projects that require it. It contains types that would likely be shared between multiple bounded contexts (VS solutions, typically).

### The Infrastructure Project
It includes most of the application's dependencies on external resources. It implements interfaces defined in Core.

The Infrastructure project depends on `Microsoft.EntityFrameworkCore.SqlServer` and `Autofac`. Autofac is used to allow wire up of dependencies to take place closest to where the implementations reside.

### The SharedApplication Project
It's a **Shared Application** project/package. It has its own git flow to be published as a NuGet package (currently it's public on Azure DevOps to make it easy for any view to restore it) and referenced as a NuGet dependency by those projects that require it. It contains types that would likely be shared between multiple bounded contexts (VS solutions, typically). It mainly targets to be shared be Web Apps and APIs.

### The API Project
The entry point of the application is the ASP.NET Core web project.

### The Test Projects
Test projects are organized on the kind of test (unit, functional). In terms of dependencies, there are three worth noting:

- [xunit](https://www.nuget.org/packages/xunit).

- [Moq](https://www.nuget.org/packages/Moq/) .

- [Microsoft.AspNetCore.TestHost](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost) I'm using TestHost to test my web project using its full stack.

## Transactions Microservice
It a microservice for maintaining transactions and has the same architecture and projects mapping like the accounts microservice.

## API-Gateway
It's an API gateway based on ocelot gateway to unify points of entry to the microservices.
Ocelot is lightweight, fast, scalable and provides routing and authentication among many other features.

#Github Actions
The repository includes 5 GitHub actions. Two of the actions are used to publish the needed NuGet packages to azure DevOps public feed registry.
The other three actions are used to build, test and push docker images to GitHub docker registry

#Next Steps
The next steps for this repo/project are
- Implement Saga Orchestration to handle the communications between the APIs.
- Implement simple client app.
