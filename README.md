# MojoCMS

Building a CMS for my personal website. This project is a work in progress. 

## Running the Application

Prior to running the application, the following must be done:
- Navigate to `MojoCMS.App` and run `npm i`
- Navigate to `MojoCMS.AppHost` and set a password using:
  - `dotnet user-secrets set Parameters:postgresql-password <password>`

## Project Structure

- `MojoCMS.App` - The front-end application built with NextJs
- `MojoCMS.API` - The back-end API built with ASP.NET 
- `MojoCMS.AppHost` - Aspire AppHost for quick development (DX QoL)


