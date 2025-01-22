## Repository pattern
By using the repository pattern, one adds a layer between the appliaction's logic and the database. It's purpose is to create a strucutred way to for the application to access and manipulate data in the database. It also creates for a more testable and adaptable application.  

### Purpose
This folder contain generic repository pattern with the purpose to be applyable to pojects that could use this pattern.

This folder contains two implementations of the repository pattern.
* InMemoryRepository: This implementation uses an in-memory database to store data.
* MongoDBRepository: This implementation uses a MongoDB database to store data. 

The purpose is both to show how the repository pattern can be implemented and to show how it can be used with different types of databases. But it can also be used as a template for future use.
