# Widget Management System Setup Instructions

## Backend Setup (ASP.NET Core Web API)

1. Navigate to the backend project folder -> WidgetApi

2. Restore NuGet packages and build the project:

    dotnet restore
    dotnet build

3. Run the API Server

    dotnet run

    API is at:
        http://localhost:5014/api/widgets

## Frontend Setup (Vue.js)

1. Navigate to the frontend folder -> widget-app

2. Install all frontend dependencies

    npm install

3. Start the front end app
    npm run serve

    The frontend runs at:
        http://localhost:8080