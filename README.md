# BookMarkManager
- `target framework of the project is .Net 5.`
- `you should set your PostgreSQL database connection string at "appsettings.json".`
- `After the first run and first call of the services, the Database will be created itself, and the tables will be filled with some initial data.`
- `Swagger will run in both development and production environments, the purpose is to test the services easily.`
- `I have assumed the same BaseResponse<T> response for all of the services. so after calling the services you will get a 200 response with a JSON of  BaseResponse<T> type.`
