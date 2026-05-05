# Numerical Reasoning App

A web application built using ASP.NET Core MVC that allows users to create, manage, and practise numerical reasoning questions.

This project demonstrates core full-stack development skills using C#, Entity Framework Core, and SQL Server, including CRUD operations, database migrations, and a quiz system with scoring.

---

## Features

- Create, edit, and delete numerical reasoning questions  
- Categorise questions (Numerical Reasoning, Number Patterns, Percentages, Ratios)  
- Assign difficulty levels (Easy, Medium, Hard)  
- Search functionality  
- Randomised quiz mode  
- Answer submission with scoring  
- MVC architecture (Model, View, Controller)

---

## Quiz Mode

The application includes a quiz system that:

- Randomly selects questions from the database  
- Allows users to input answers  
- Compares answers against correct values  
- Displays a final score with feedback  

---

## Tech Stack

- C#  
- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- Razor Views  

---

## Database

- Code-first approach using Entity Framework Core  
- Migrations used to manage schema changes  
- Questions stored with category and difficulty  

---

## Running the Project

1. Clone the repository:
   git clone https://github.com/YOUR-USERNAME/numerical-reasoning-app.git

2. Open in Visual Studio 2022

3. Update your connection string in:
   appsettings.json

4. Apply migrations:
   Update-Database

5. Run the application

---

## Notes

- Built to demonstrate ASP.NET Core and backend development concepts  
- Designed as a lightweight assessment-style practice tool  
- Can be extended with additional features such as authentication or analytics  

---

## Future Improvements

- Timed quizzes  
- Difficulty-weighted question selection  
- User performance tracking  
- Leaderboards  
- API-based architecture  

---

## Author

Dannie Watkins
