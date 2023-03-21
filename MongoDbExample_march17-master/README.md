# MongoDbExample

Here Backend API for the crud on MongoDB is implemented.

The Frontend UI is implemented in the 'productsMongo' git repository.

STEPS FOR PROJECT CREATION:

1: MongoDb server is configured and the db collection is created.

2: In the Backend Framework(.NET 6.0):
  NugetPackages: MongoDB.Driver, Swashbuckle
  a)Models for the mongodb collection is created.
  b)appsettings.json is configured with the connection string, database collection etc to connect the backend api with the mongodb server.
  c)program.cs is configured with the connection string 
  d)Inside Service all the business logic is written for CRUD operation
  e)Controller is created to handle all the http requests and pass to the frontend
  f)CORS policy is added to the program.cs so that the api can be connected to the frontend.

3: In the Frontend Framework(Angular 15.1):
  InstalledPackages:Bootstrap
  a)index.html is updated with the bootstrap and jquery scripts.
  b)app.module.ts: FormsModule and HTTPClientModule are imported
  c)Model is created with respect to the model created in the backend
  d)Services: All the services for fetching the https requests are handled here.
  e)3 Components are created:
    Products: the get and delete operations are handled here along with the respective html and css file.
    add-Products: add product field in table operation is handled here along with the respective html and css file.
    edit-Products: edit product field with id operation is handled here along with the respective html and css file.
  f)Nav-bar is created.
  g)all the routing is done in 'app-routing.module.ts'
  
4: The backend is Run
   The Frontend is Run using 'ngserve'
   
   
All the screeenshots of the running we app is inside the screenshots folder.


--------------------- THANKY YOU ! -------------------------------------------------------------------
