# Rectangle Drawing App

## Overview

This application allows users to draw and resize a rectangle SVG figure. The initial dimensions of the rectangle are loaded from a JSON file, and the user can resize the figure by mouse. The perimeter of the figure is displayed next to it. After resizing, the system updates the JSON file with the new dimensions and validates the rectangle on the backend.

## Backend (ASP.NET Core)

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (for Windows)

### Running the Backend

#### On Windows

1. Open the solution in Visual Studio 2022.
2. Ensure the `rectangle.json` file exists in the `wwwroot` folder with initial dimensions.
3. Press `F5` or click on the "Run" button to start the backend.

Alternatively, you can run the backend using the command line:

1. Open a command prompt.
2. Navigate to the project directory.
3. Run the following command to start the API with the `https` profile: dotnet run --launch-profile https
    
#### On Linux

1. Open a terminal.
2. Navigate to the project directory.
3. Ensure the `rectangle.json` file exists in the `wwwroot` folder with initial dimensions.
4. Run the following command to start the API with the `https` profile: dotnet run --launch-profile https


## Frontend (React)

### Prerequisites

- [Node.js](https://nodejs.org/) (which includes npm)

### Running the Frontend

1. Open the solution in Visual Studio 2022.
2. Navigate to the `rectangle.ui` folder in the terminal: cd rectangle.ui
3. Install the dependencies: npm install
4. Start the React application using Vite: npm run dev
5. The open the browser and go to http://localhost:65014/

## Running Both Projects Simultaneously in Visual Studio 2022

You can run both the backend and frontend projects simultaneously using Visual Studio 2022. Here are the steps:

1. Open the solution in Visual Studio 2022.
2. Right-click on the solution in the Solution Explorer and select "Set Startup Projects...".
3. In the dialog that appears, select "Multiple startup projects".
4. Set the "Action" for both the backend and frontend projects to "Start".
5. Click "OK" to save the settings.
6. Press `F5` or click on the "Run" button to start both projects.


    

    