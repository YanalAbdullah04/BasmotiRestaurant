\*\*Basmoli\*\* is a full-stack web application designed for restaurants. It features a modern, responsive customer-facing website for browsing menus and making reservations, coupled with a powerful Admin Dashboard for complete content management.



\## ✨ Features



\### 🥗 Customer Portal (Client Side)

The public-facing website allows customers to interact with the restaurant virtually.

\* \*\*Dynamic Home Page:\*\* Features an attractive hero slider and introductory content managed via the backend.

\* \*\*Interactive Menu:\*\* Filter items by category (Breakfast, Lunch, Dinner, etc.) and view detailed descriptions.

\* \*\*Online Reservations:\*\* "Book A Table" form allowing users to select dates and enter contact details.

\* \*\*About \& Contact:\*\* Information pages with integrated Google Maps and a "Leave us a message" form.



\### 🛠️ Admin Dashboard (Back Office)

A secure administration panel that gives the business owner full control.

\* \*\*Secure Authentication:\*\* Built using \*\*ASP.NET Core Identity\*\* for robust user management, login, and registration.

\* \*\*Content Management (CRUD):\*\*

&nbsp;   \* Manage \*\*Menu Items\*\* and \*\*Categories\*\*.

&nbsp;   \* Update \*\*Working Hours\*\* and \*\*Services\*\*.

&nbsp;   \* Manage \*\*Partners\*\* and \*\*Offers\*\*.

\* \*\*Communication:\*\* View contact form submissions and manage newsletter subscribers.

\* \*\*User Management:\*\* Securely create and manage admin profiles.

\## 🚀 Tech Stack



\* \*\*Framework:\*\* ASP.NET Core MVC

\* \*\*Language:\*\* C#

\* \*\*Database:\*\* SQL Server

\* \*\*ORM:\*\* Entity Framework Core (Code-First approach)

\* \*\*Architecture:\*\* MVC Pattern with ViewModels and Areas

\* \*\*Frontend:\*\* HTML5, CSS3, JavaScript, Bootstrap.



\## 📂 Project Structure



The solution is organized using standard ASP.NET Core conventions:



\* \*\*`Areas/`\*\*: Modular separation of concerns (likely separating the Admin dashboard logic from the main site).

\* \*\*`Controllers/`\*\*: Handles the incoming HTTP requests and application logic.

\* \*\*`Data/`\*\*: Contains the Database Context and connection configuration.

\* \*\*`Migrations/`\*\*: Database schema history and updates (Entity Framework Core).

\* \*\*`Models/`\*\*: Represents the database entities and domain logic.

\* \*\*`ViewModels/`\*\*: Custom data models designed specifically for views to keep the UI logic clean.

\* \*\*`Views/`\*\*: The Razor (`.cshtml`) pages that render the user interface.

\* \*\*`wwwroot/`\*\*: Static files including images, CSS styles, and JavaScript libraries.

\* \*\*`Program.cs`\*\*: The entry point for the application and service configuration.



\## 📦 Installation \& Setup



1\.  \*\*Clone the repository\*\*

&nbsp;   ```bash

&nbsp;   git clone \[https://github.com/](https://github.com/)\[your-username]/Basmoli.git

&nbsp;   ```

2\.  \*\*Configure Database\*\*

&nbsp;   \* Open `appsettings.json`.

&nbsp;   \* Update the connection string to point to your local SQL Server instance.

3\.  \*\*Apply Migrations\*\*

&nbsp;   Initialize the database using the Entity Framework CLI:

&nbsp;   ```bash

&nbsp;   dotnet ef database update

&nbsp;   ```

4\.  \*\*Run the Application\*\*

&nbsp;   ```bash

&nbsp;   dotnet run

&nbsp;   ```

&nbsp;   \* The application will typically launch on `localhost` (check the console for the specific port).



\## 👤 Author



\*\*Yanal Abdullah\*\*

\* \[LinkedIn Profile](www.linkedin.com/in/yanal-abdullah)

\* \[GitHub Profile](https://github.com/YanalAbdullah04)



\## 📝

