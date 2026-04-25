# Course Management System

A minimal and classy full-stack application for managing courses, built with .NET 10 and Angular 21.

## 🎨 Features

- **Minimal & Classy UI** - Clean, modern interface with smooth animations
- **Full CRUD Operations** - Create, Read, Update, and Delete courses
- **Responsive Design** - Works beautifully on all screen sizes
- **Real-time Updates** - Instant feedback on all operations
- **One-Click Launch** - Run both backend and frontend with a single batch file

## 🚀 Quick Start

### Prerequisites

- .NET 10 SDK
- Node.js (v18 or higher)
- ~~SQL Server (LocalDB or full instance)~~ **No database needed! Uses in-memory mock data**

### Running the Application

**Option 1: One-Click Launch (Recommended)**

Simply double-click `run-all.bat` in the CourseManagement folder. This will:
- Start the .NET backend API on https://localhost:5288
- Start the Angular frontend on http://localhost:4200
- Open both in separate command windows
- **No database setup required!** The app uses in-memory mock data

**Option 2: Manual Launch**

Backend:
```bash
cd CourseManagementWebApi
dotnet run
```

Frontend:
```bash
cd frontend
npm install  # First time only
npm start
```

## 📁 Project Structure

```
CourseManagement/
├── CourseManagementWebApi/     # .NET 10 Web API
│   ├── Controllers/            # API endpoints
│   ├── Data/                   # Database context
│   ├── Models/                 # Data models
│   └── Migrations/             # EF Core migrations
├── frontend/                   # Angular 21 application
│   └── src/
│       └── app/
│           ├── services/       # HTTP services
│           ├── app.ts          # Main component
│           ├── app.html        # Component template
│           └── app.css         # Minimal & classy styles
└── run-all.bat                 # One-click launcher
```

## 🎨 UI Design

The interface features:
- **Gradient backgrounds** with soft, elegant colors
- **Smooth hover effects** and transitions
- **Card-based layout** for clean content organization
- **Modern typography** using Inter font family
- **Subtle shadows** for depth and hierarchy
- **Responsive grid** that adapts to screen size

## 🛠️ Technology Stack

**Backend:**
- .NET 10
- ~~Entity Framework Core 10~~
- ~~SQL Server~~
- **In-Memory Mock Data** (no database required!)
- ASP.NET Core Web API

**Frontend:**
- Angular 21
- TypeScript 5.9
- RxJS 7.8
- Standalone Components
- Signals API

## 📝 API Endpoints

- `GET /api/courses` - Get all courses
- `GET /api/courses/{id}` - Get course by ID
- `POST /api/courses` - Create new course
- `PUT /api/courses/{id}` - Update course
- `DELETE /api/courses/{id}` - Delete course

## 🎯 Development

### Backend Development
```bash
cd CourseManagementWebApi
dotnet watch run
```

### Frontend Development
```bash
cd frontend
npm start
```

### Mock Data

The backend includes 3 sample courses by default:
1. Introduction to C#
2. Angular Fundamentals  
3. ASP.NET Core Web API

All data is stored in-memory and will reset when the backend restarts.

## 📄 License

This project is open source and available for educational purposes.
