


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


## Development server
Navigate to the root directory of the Frontend (AngularJS) project.TODOWEBAPP
Run `ng serve` for a dev server.
1. Install the required dependencies by running:
   npm install
2. ng serve --open 

The Frontend app will be served at http://localhost:4200 by default.

