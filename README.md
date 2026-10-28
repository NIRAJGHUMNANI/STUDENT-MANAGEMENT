# Student Management REST API (ASP.NET Core)

A beginner-friendly ASP.NET Core Web API practical demonstrating **Middleware, REST API endpoints, and project structure**. It uses in-memory storage, so no database setup is required. Data resets when the app stops.

## Requirements
- .NET 8 SDK
- Visual Studio 2022 (ASP.NET and web development workload) or VS Code

## Run in Visual Studio
1. Extract the ZIP.
2. Open `StudentManagementRestAPI.csproj` in Visual Studio.
3. Restore NuGet packages if prompted.
4. Press **F5** (or Ctrl+F5).
5. Open Swagger at `http://localhost:5168/swagger` if it does not open automatically.

## Run in terminal
Open a terminal in the extracted `StudentManagementRestAPI` folder and run:

```bash
dotnet restore
dotnet run
```

Then visit `http://localhost:5168/swagger`.

## API endpoints
Base URL: `http://localhost:5168/api/students`

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/students` | Get all students |
| GET | `/api/students/1` | Get a student by ID |
| POST | `/api/students` | Add a student |
| PUT | `/api/students/1` | Update a student |
| DELETE | `/api/students/1` | Delete a student |

### Example POST/PUT JSON
```json
{
  "name": "Niraj Ghum n ani",
  "email": "niraj@example.com",
  "course": "CSE AI/ML",
  "semester": 5
}
```
Use a valid email and semester from 1 to 6. The API validates model fields automatically.

## Project structure
- `Controllers/StudentsController.cs` — handles HTTP requests and responses.
- `Models/Student.cs` — student data model and validation rules.
- `Services/IStudentService.cs` — service contract.
- `Services/StudentService.cs` — CRUD logic and sample in-memory data.
- `Middleware/RequestLoggingMiddleware.cs` — logs requests and status codes.
- `Middleware/ExceptionHandlingMiddleware.cs` — returns a safe JSON response for unexpected errors.
- `Program.cs` — registers services and middleware and maps controllers.

## Notes
- This is a practical/demo project, not a production database-backed system.
- It includes two sample students at startup.
- Swagger is enabled in Development mode.
