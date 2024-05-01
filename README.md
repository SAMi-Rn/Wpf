# WPF Application
## Description
This WPF application is designed to provide a comprehensive user interface for managing customers, transactions, orders, and viewing analytics on a dashboard. It is developed using the MVVM architectural pattern to ensure clean separation of concerns, facilitating maintenance and scalability.
## Features
- **Login System**: Secure authentication system connected to the Microsoft SQL database.
![image](https://github.com/SAMi-Rn/Wpf/assets/108373193/2b883b00-cfd2-45cf-bcc3-3a657ef04f6c)
- **Dashboard**: Displays various analytics in forms of pie charts, line charts, and column charts.
![image](https://github.com/SAMi-Rn/Wpf/assets/108373193/30b14e48-2394-4f1f-85f9-2f22e7ee864c)
- **Customer Management**: Allows adding, viewing, and searching for customers.
![image](https://github.com/SAMi-Rn/Wpf/assets/108373193/f6d60a87-0645-469a-9498-c9b97aa21538)
- **Transaction Management**: Track and record transactions. (Not designed yet!)
- **Order Processing**: Interface to manage orders. (Not designed yet!)
## Prerequisites
- .NET Core 7.0 or later
- Visual Studio 2019 or later
- SQL Server 2019
## Setup
Clone the repository and open the solution in Visual Studio. Ensure all NuGet packages are restored and rebuild the solution.

```sh 
git clone https://github.com/SAMi-Rn/Wpf.git
cd Login
dotnet restore
```
## Running the Application
Run the application from Visual Studio by pressing `F5` or using the following command:
```sh
dotnet run
```
## Architecture
This WPF application is structured according to the Model-View-ViewModel (MVVM) architectural pattern, making it easier to manage and scale the application. Here’s a breakdown of each component within the MVVM pattern:

### Model
The Model represents the data and business logic layer of the application. It is responsible for retrieving data, manipulating it, and maintaining the state. This includes communicating with databases to handle the application's domain. In this project, models include data classes such as `UserModel`, `UserAccModel` and `IUserRepository` , which represent the structure and constraints of the data the application handles.

### View
The View is responsible for defining the structure, layout, and appearance of what the user sees on the screen. It is implemented in XAML (Extensible Application Markup Language) and is kept as simple as possible, with no direct code behind except for minimal logic pertaining to visual effects and animations. The views in this application include `LoginView`, `MainView`, `CustomerView`, and `HomeView` that provide user interfaces for interaction.

### ViewModel
The ViewModel acts as an intermediary between the View and the Model, handling most of the view's logic. It receives input from interactions on the View, processes that input with the help of model objects, and returns the results back to the View. ViewModels in this application, such as `ViewModel`, `MainViewModel`, `RelayCommand`, `LoginViewModel`, `HomeViewModel`, ,  and `CustomerViewModel`, `implement properties and commands that are data-bound to elements in the View.

## Database Configuration
The application is configured to use a SQL Server database. Ensure the following steps are completed:

- Set up SQL Server and create a database named LoginDb.
- Execute the SQL scripts provided in the Scripts directory to set up the required tables.
![image](https://github.com/SAMi-Rn/Wpf/assets/108373193/19404ca3-2fd0-4a3c-aeea-6c0f8cbf3cd0)
