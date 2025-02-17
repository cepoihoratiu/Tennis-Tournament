
# Tennis Tournament Management Application

## Project Overview
This application is designed to manage a tennis tournament, allowing different types of users to interact with the system based on their roles. The system ensures smooth organization, scheduling, and user management within the tournament.

## Features

### 1. **User Roles and Permissions**
The application supports four types of users:
- **Tennis Player**: Can register for the tournament and view the match schedule.
- **Referee**: Can log in and view their assigned matches.
- **Tournament Organizer**: Can perform CRUD operations on players, referees, and matches, as well as generate the tournament schedule.
- **Administrator**: Manages user accounts requiring authentication and can view all authenticated users.

### 2. **Authentication & Authorization**
- Referees, organizers, and administrators require authentication to access their functionalities.
- Tennis players can register and participate without authentication.

### 3. **Match Scheduling**
- The system allows tournament organizers to create matches and assign players and referees.
- Players and referees can view their schedules.

### 4. **User Management**
- Administrators can manage all users who require authentication.
- Organizers can manage tournament participants and officials.

### 5. **Database Management**
- The application ensures data persistence for users, matches, and schedules.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET
- **Database**: MySQL
- **Development Tools**: Microsoft Visual Studio, XAMPP, MySQL Workbench

## Installation & Setup
1. Clone the repository.
2. Set up the MySQL database and import the necessary tables.
3. Configure the database connection in the application.
4. Open the project in Microsoft Visual Studio.
5. Run the application.

## Usage Guide
1. **Login**: Administrators, referees, and organizers must log in to access their functionalities.
2. **Tournament Registration**: Players can register without authentication.
3. **Match Scheduling**: Organizers can create matches and assign referees.
4. **User Management**: Administrators can manage authenticated users.




