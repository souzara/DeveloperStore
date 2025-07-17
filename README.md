# Developer Store - Sales API

Sales management system developed as a technical evaluation, implementing clean architecture with modern development patterns.

## 🚀 Main Features

### 📊 Sales
- **Complete CRUD**: Create, list, get, update and delete sales
- **Cancellation**: Cancel complete sales or specific items
- **Advanced Filters**: Search by ID, sale number, branch, customer, period and status
- **Pagination**: Paginated listing with page and size control
- **Validations**: Complete input data validation

### 🛍️ Sales Items
- **Item Management**: Add items to existing sales
- **Individual Cancellation**: Cancel specific items from a sale
- **Automatic Calculations**: Discount and total calculated automatically
- **Validations**: Quantity, price and product verification

### 📋 Event Logs
- **Audit**: Automatic recording of all operations
- **Filters**: Search by event ID, type, period
- **Pagination**: Paginated listing of logs
- **Persistence**: MongoDB storage for performance

### 👥 Users
- **User Management**: Create, get and delete users
- **Authentication**: JWT-based login system
- **Roles and Status**: User permission and status control
- **Validations**: Email, password, phone and required data

### 🔐 Authentication
- **JWT Tokens**: Token-based authentication
- **BCrypt**: Secure password hashing
- **Authorization**: Role-based access control

## 🏗️ Architecture and Patterns

### Clean Architecture
- **Domain**: Entities, business rules and specifications
- **Application**: Use cases, commands and queries (CQRS)
- **Infrastructure**: Repositories, ORM and external services
- **WebApi**: Controllers, middlewares and configurations

### Implemented Patterns
- **CQRS**: Separation of commands and queries
- **Mediator**: Communication between layers via MediatR
- **Repository**: Data access abstraction
- **Specification**: Complex and reusable filters
- **Event Sourcing**: Event logs for auditing
- **Validation**: Fluent validation with FluentValidation
- **AutoMapper**: Object mapping

## 🛠️ Technologies

### Backend
- **.NET 8**: Main framework
- **ASP.NET Core**: Web API
- **Entity Framework Core**: ORM for PostgreSQL
- **MongoDB**: NoSQL database for event logs
- **Redis**: Distributed cache
- **MediatR**: Mediator pattern implementation
- **AutoMapper**: Object mapping
- **FluentValidation**: Data validation
- **JWT**: Authentication and authorization
- **BCrypt**: Password hashing

### Databases
- **PostgreSQL**: Main relational database
- **MongoDB**: Event logs storage
- **Redis**: In-memory cache

### Containerization
- **Docker**: Application containerization
- **Docker Compose**: Service orchestration

### Testing
- **Unit Tests**: Unit testing
- **Integration Tests**: Integration testing
- **Functional Tests**: Functional testing

## 📁 Project Structure

```
backend/
├── src/
│   ├── Ambev.DeveloperEvaluation.Domain/          # Entities and business rules
│   ├── Ambev.DeveloperEvaluation.Application/     # Use cases and CQRS
│   ├── Ambev.DeveloperEvaluation.ORM/             # Entity Framework and PostgreSQL
│   ├── Ambev.DeveloperEvaluation.NoSql/           # MongoDB
│   ├── Ambev.DeveloperEvaluation.EventBus/        # Event system
│   ├── Ambev.DeveloperEvaluation.Common/          # Shared utilities
│   ├── Ambev.DeveloperEvaluation.IoC/             # Dependency injection
│   └── Ambev.DeveloperEvaluation.WebApi/          # REST API
├── tests/
│   ├── Ambev.DeveloperEvaluation.Unit/            # Unit tests
│   ├── Ambev.DeveloperEvaluation.Integration/     # Integration tests
│   └── Ambev.DeveloperEvaluation.Functional/      # Functional tests
└── postman/                                        # Test collections
```

## 🚀 How to Run

### Prerequisites
- .NET 8 SDK
- Docker and Docker Compose
- PostgreSQL (via Docker)
- MongoDB (via Docker)
- Redis (via Docker)


## Step 1: Environment Configuration

Create a `.env` file inside the `./src/Ambev.DeveloperEvaluation.WebApi` folder and adjust the information from the template below:

```
DOCKER_REGISTRY=
APPDATA=C:/Users/{your user}/AppData/Roaming
```

## Step 2: Build Docker Containers

Execute the docker-compose build command inside the `./backend` folder:

```bash
docker-compose build
```

## Step 3: Start Services

Execute the docker-compose up -d command to start the service and its dependencies:

```bash
docker-compose up -d
```

## Step 4: Verify Services Status

Execute the docker ps command to verify that all services are running:

```bash
docker ps
```

The following list of services should appear:

```
CONTAINER ID   IMAGE                            COMMAND                  NAMES
b9aeec8249da   ambevdeveloperevaluationwebapi   "dotnet Ambev.Develo…"   ambev_developer_evaluation_webapi
7f501574ab6e   postgres:13                      "docker-entrypoint.s…"   ambev_developer_evaluation_database
b02687ba258e   redis:7.4.1-alpine               "docker-entrypoint.s…"   ambev_developer_evaluation_cache
c3a7c7a2470c   mongo:8.0                        "docker-entrypoint.s…"   ambev_developer_evaluation_nosql
```

## Step 5: Import Postman Collection

Open Postman and import the collection `sales-api.postman_collection`. To import, click on `Collections` > `Import`.

The structure below should be loaded:

### API Structure

The collection contains the following endpoints organized in folders:

#### **auth**
- `POST /auth`

#### **sales**
- `GET /sales/{id}`
- `GET /sales/{filter}`
- `POST /sales`
- `PUT /sales/{id}`
- `DEL /sales/{id}`
- `PATCH /sales/{id}/cancel`

#### **sale-items**
- `GET /sales/{id}/items`
- `PATCH /sales/{id}/items/{id}/cancel`
- `POST /sales/{id}/items`

#### **users**
- `POST /users`
- `GET /users/{id}`
- `DEL /users`

#### **event-logs**
- `GET /eventlogs`

## Step 6: Import Postman Environments

Import the environment files in the same way: `Development.postman_environment` and `Docker.postman_environment`. To import, click on `Environments` > `Import`.

## Step 7: Select Docker Environment in Postman

Configure Postman to use the `Docker` environment for testing. This configuration can be found at the top right corner of the Postman interface.

## Step 8: Create User

Go to the request `POST /users` in Postman, adjust the data as needed, and execute the request to create a user and password. This endpoint is open (does not require authentication).

A JSON response similar to this should be returned:

```json
{
    "data": {
        "id": "352e36ae-cc20-461d-984b-222df0c944d8",
        "name": "",
        "email": "",
        "phone": "",
        "role": 0,
        "status": 0
    },
    "success": true,
    "message": "User created successfully",
    "errors": []
}
```

## Step 9: Authenticate User

Now make a call to `POST /auth` with the user and password created previously. A JSON response similar to this should be returned:

```json
{
    "data": {
        "data": {
            "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzNTJlMzZhZS1jYzIwLTQ2MWQtOTg0Yi0yMjJkZjBjOTQ0ZDgiLCJ1bmlxdWVfbmFtZSI6IlVzZXIiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE3NTI3MjQ0NTMsImV4cCI6MTc1Mjc1MzI1MywiaWF0IjoxNzUyNzI0NDUzfQ.8nTOCXwbfP5RE4sZj7Rf4g7XithLoH9bsBz61SywCu0",
            "email": "user@email.com",
            "name": "User",
            "role": "Admin"
        },
        "success": true,
        "message": "User authenticated successfully",
        "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```

This call automatically configures the access token in the current environment, so we can start consuming the other endpoints without worrying about configuring this step.

## Step 10: Test Sales Endpoints

For example, let's make a POST and GET call to sales, then feel free to explore the additional endpoints.

### Create a Sale

Make a call to `POST /sales` with the payload below (feel free to customize as preferred):

```json
{
    "saleNumber": "X1Y2Z3A4B5C6D7E",
    "date": "2025-07-13T08:19:07.480Z",
    "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "customerName": "Maria Silva",
    "branchId": "b13e8f46-71a7-4562-b3fc-9e2f3d66af02",
    "branchName": "Filial Centro",
    "items": [
        {
            "productId": "d549ec11-22c1-4f3b-9abc-4a2b3c4d5e6f",
            "productName": "Smartwatch Samsung",
            "quantity": 5,
            "unitPrice": 99.90
        },
        {
            "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "productName": "Phone QCY ANC 2",
            "quantity": 3,
            "unitPrice": 250.35
        }
    ]
}
```

This call will return the JSON below containing the generated sale ID:

```json
{
    "data": {
        "id": "0f585cff-2852-4ae5-b24f-8628b2c48ed8"
    },
    "success": true,
    "message": "Sale created successfully",
    "errors": []
}
```

### Retrieve the Sale

Now we can make two test calls. First, `GET {{api_url}}/api/Sales/0f585cff-2852-4ae5-b24f-8628b2c48ed8` should return the following structure:

```json
{
    "data": {
        "data": {
            "id": "0f585cff-2852-4ae5-b24f-8628b2c48ed8",
            "saleNumber": "X1Y2Z3A4B5C6D7E",
            "date": "2025-07-13T08:19:07.48Z",
            "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "customerName": "Maria Silva",
            "branchId": "b13e8f46-71a7-4562-b3fc-9e2f3d66af02",
            "branchName": "Filial Centro",
            "isCancelled": false,
            "createdAt": "2025-07-17T03:57:56.310898Z",
            "updatedAt": "2025-07-17T03:57:56.313781Z",
            "totalAmount": 1200.60,
            "items": [
                {
                    "id": "c015a15b-80ac-453c-a2be-c839a1e350cf",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "productName": "Phone QCY ANC 2",
                    "quantity": 3,
                    "unitPrice": 250.35,
                    "discount": 0.00,
                    "total": 751.05,
                    "isCancelled": false,
                    "createdAt": "2025-07-17T03:57:56.311563Z",
                    "updatedAt": null,
                    "saleId": "0f585cff-2852-4ae5-b24f-8628b2c48ed8"
                },
                {
                    "id": "c0ebd4a8-09db-4bfd-b4bb-5d3fdc9e80da",
                    "productId": "d549ec11-22c1-4f3b-9abc-4a2b3c4d5e6f",
                    "productName": "Smartwatch Samsung",
                    "quantity": 5,
                    "unitPrice": 99.90,
                    "discount": 49.95,
                    "total": 449.55,
                    "isCancelled": false,
                    "createdAt": "2025-07-17T03:57:56.311533Z",
                    "updatedAt": null,
                    "saleId": "0f585cff-2852-4ae5-b24f-8628b2c48ed8"
                }
            ]
        },
        "success": true,
        "message": "Sale retrieved successfully",
        "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```

### Check Event Logs

We can also analyze the simulated queue event for sale creation. This event log is being stored in the MongoDB database. Use the call `{{api_url}}/api/EventLogs?Page=1&PageSize=10`. The JSON below should be returned:

```json
{
    "data": {
        "currentPage": 1,
        "totalPages": 1,
        "totalCount": 1,
        "data": [
            {
                "id": "687874c43b1b8b2b78a0827a",
                "eventId": "f38d73e4-d82d-4d37-9165-c09ceceb3e98",
                "eventType": "Ambev.DeveloperEvaluation.Domain.Events.SaleCreatedEvent",
                "eventData": "{\"EventId\":\"f38d73e4-d82d-4d37-9165-c09ceceb3e98\",\"CreatedAt\":\"2025-07-17T03:57:56.3108982Z\",\"EventName\":\"SaleCreatedEvent\"}",
                "createdAt": "2025-07-17T03:57:56.31Z"
            }
        ],
        "success": true,
        "message": "Event logs retrieved successfully",
        "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```


## Conclusion of how to run 

Congratulations! You have successfully set up and tested the Ambev Developer Evaluation API. The application is now running with all its services (Web API, PostgreSQL, Redis, and MongoDB) and you have verified the core functionality through the sales endpoints.

You can now explore the remaining endpoints in the Postman collection to test additional features such as user management, sale item operations, and event logging. The API is fully functional and ready for development and testing purposes.

--- 


## 📚 API Documentation

The API is documented with Swagger and can be accessed at:
- **Development**: http://localhost:8080/swagger
- **Production**: https://localhost:8081/swagger

### Main Endpoints

#### Sales
- `GET /api/sales` - List sales
- `GET /api/sales/{id}` - Get sale by ID
- `POST /api/sales` - Create new sale
- `PUT /api/sales/{id}` - Update sale
- `DELETE /api/sales/{id}` - Delete sale
- `PATCH /api/sales/{id}/cancel` - Cancel sale

#### Sales Items
- `GET /api/sales/{id}/items` - List sale items
- `POST /api/sales/{id}/items` - Add item to sale
- `PATCH /api/sales/{id}/items/{itemId}/cancel` - Cancel item

#### Event Logs
- `GET /api/eventlogs` - List event logs

#### Users
- `POST /api/users` - Create user
- `GET /api/users/{id}` - Get user
- `DELETE /api/users/{id}` - Delete user

#### Authentication
- `POST /api/auth` - Authenticate user

## 🔧 Configuration

### Environment Variables
```env
ConnectionStrings__DefaultConnection=Host=localhost;Database=developer_evaluation;Username=developer;Password=ev@luAt10n
ConnectionStrings__MongoDb=mongodb://developer:ev%40luAt10n@localhost:27017
ConnectionStrings__Redis=localhost:6379,password=ev@luAt10n
```

### Default Ports
- **API**: 8080 (HTTP) / 8081 (HTTPS)
- **PostgreSQL**: 5432
- **MongoDB**: 27017
- **Redis**: 6379

## 🧪 Testing

### Run Tests
```bash
# All tests
dotnet test

# Unit tests
dotnet test tests/Ambev.DeveloperEvaluation.Unit/

# Integration tests
dotnet test tests/Ambev.DeveloperEvaluation.Integration/

# Functional tests
dotnet test tests/Ambev.DeveloperEvaluation.Functional/
```

## 📝 License

This project is under the license specified in the [LICENSE.txt](LICENSE.txt) file.

## 👨‍💻 Development

### Code Patterns
- **Clean Code**: Clean and readable code
- **SOLID**: Applied SOLID principles
- **DRY**: Avoid code repetition
- **KISS**: Keep it simple

### Commits
- Semantic commits
- Messages in English
- Reference to issues when applicable

### Code Review
- Mandatory review before merge
- Tests must pass
- Code coverage maintained
