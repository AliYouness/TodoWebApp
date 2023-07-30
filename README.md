# TodoWebApp 
# Overview: Todo App

The Todo App is a multi-project solution consisting of three main projects: Backend (C#), Frontend (AngularJS), and Todo.Test (Unit Test).
# Key Feature

Task List: Displaying a list of tasks, often categorized.

Task Creation: Allowing users to add new tasks by entering a title and its status.

Task Editing: Enabling users to edit existing tasks to update their titles and its status.

Task Completion: Providing a checkbox or button to mark a task as isDone when it is done.

Task Deletion: Allowing users to remove tasks from the list when they are no longer needed.

Persistence: Saving tasks in a ManagoDB.

# Backend (C# Project):
The Backend project serves as the server-side component of the Todo App. It is developed using C# and provides APIs to handle data storage and retrieval. To set up the Backend project, ensure you have MongoDB installed on your machine. Update the DBconnection settings in appsettings.json to match your MongoDB connection details. Modify the following section:

'''
"TODOStoreDatabase": {
  "connectionString": "mongodb://localhost:27017",
  "databaseName": "TODOStore",
  "tododCollectionName": "TODODocs"
},
''' 

- TODO_Solution
  - Todo.API
    - Controllers
      - TodoController.cs
    - Model
      - TodoItem.cs
      - TodoDataBaseSettings.cs
    - Repository
      - InMemoryTodoDataStorage.cs
    - Services
      - TodoService.cs
    - Dockerfile
    - appsettings.json
    - package.json
    - Program.cs
         
  - TodoWebApp
    - src
      - app
        - shared
          - todo-items.model.ts
          - todo-items.service.ts
          - 
      - app-routing.module.ts
      - app.component.css
      - app.component.html
      - app.component.spec.ts
      - app.component.ts
      - app.module.ts
      - assets
      - index.html
      - main.ts
      - styles.css
      - angular.json
      - package-lock.json
      - package.json
      - tsconfig.app.json
      - tsconfig.json
      - tsconfig.spec.json

  - TODO.Test
    - TodoServiceTests.cs
  - MySolution.sln


# TodoWebApp (Client App)
    Frontend (AngularJS Project):
    The Frontend project is the client-side component of the Todo App, built using AngularJS. It provides the user interface to interact with the Todo list. To run the Frontend, you don't need to build a Docker image. Instead, you can use a development server or host the compiled files on a web server.


# Todo.Test (Unit Test Project):
The Todo.Test project contains unit tests to ensure the functionality and reliability of the application. It verifies the correctness of the Backend and Frontend components.

# Running the App:
The Todo App can be executed in two ways: using Docker or running the app directly from Visual Studio. Below are the steps for each method:

   1. Ensure MongoDB is installed on your machine.
      Update the appsettings.json file in the Backend project with your MongoDB connection details.
      Build the Backend project.

   2. Building Docker Image for Backend:
      a. docker build --tag todob-backend .
      b. docker run --name todob-backend -d -p host-port:container-port todob-backend

## Development server
Navigate to the root directory of the Frontend (AngularJS) project.TODOWEBAPP
Run `ng serve` for a dev server.
1. Install the required dependencies by running:
   npm install
2. ng serve --open 

The Frontend app will be served at http://localhost:4200 by default.
