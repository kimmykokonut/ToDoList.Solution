## What Is This?

This is an example repo corresponding to multiple lessons within the LearnHowToProgram.com walkthrough on creating a To Do List application in [Section 2: Basic Web Applications](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications).

There are multiple branches in this repo that are described more below.

## How To Run This Project

1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory called "ToDoList". 
3. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
4. Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Available Branches

**1_mvc_setup**: this is the default branch with the starter code for the To Do List project as an ASP.NET Core MVC web application. The walkthrough of this example project starts in this lesson:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/to-do-list-mvc-setup

**2_forms_and_http_methods**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/to-do-list-with-mvc-forms
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/request-response-loop-and-http-methods-with-asp-net-mvc

**3_list_redirects_loops_and_conditionals**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/lists-and-redirects-in-a-controller
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/loops-and-conditionals-with-razor

**4_multiple_controllers**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/multiple-controllers

**5_deleting_and_finding_objects**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/http-crud-methods
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/deleting-items
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/finding-objects-with-unique-ids

**6_applying_restful_routing**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/introduction-to-restful-routing
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/applying-restful-routing

**7_objects_within_objects_setup**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/objects-within-objects-setup

**8_saving_OWO_and_interface_update**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/saving-objects-within-other-objects
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/objects-within-objects-interface-part-1
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/objects-within-objects-interface-part-2

**9_static_content_layouts_and_partials**: This branch includes the code we added after working through the following lessons:

- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/using-static-content
- https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/layouts-and-partials


----------------
Readme from C# Console App- toupdate
# TodoList
_by Kim Robinson_

## Code Review for Epicodus. Build a C# Console Application using Test Driven Development with MSTest.  Use classes, namespaces, auto-implemented properties and methods.

###  This app will allow a user to:
    - Be greeted and given menu with prices
    - Order quantities of bread (french or sourdough) and pastry
    - Receive the total price
    - Update order to add more items
    - Receipt reflects deal price (bread, buy 2 get 1 free; pastry buy 3 get 1 free)

### Technologies Used

* C#
* MSTest
* TDD (Test Driven Development)
* RGR Workflow (Red Green Refactor)
* .Net
* Git
* NuGet package with dotnet CLI

## Setup/Installation Requirements

_This is a basic console application, not viewable on gh-pages. Please follow steps below to set up locally_

1. Navigate to [my github repository](https://github.com/kimmykokonut/Bakery.Solution) for this project 

2. Click the `Fork` button and  you will be taken to a new page where you can give your repository a new name and description. Choose "create fork".

3. Click the `Code` button and copy the url for HTTPS.

4. On your local computer, create a working directory for my files and name appropriately.

5. On your terminal, type `$ git clone 'url'` (using the url from step 3.)

6. Once you have this on your local directory, if you ever want to push it to GitHub, you need to do these steps first so Git knows to ignore the obj and bin directories:
`$ git init` to initialize Git (if cloning, this step automatically happened)
`$ touch .gitignore` adds .gitignore file in the root directory. 

7. On your terminal, type `$ code .` to open in VS Code.  If you do not have VS Code Editor, you may download [here](https://code.visualstudio.com/)

8. In the .gitignore file, add `bin` and `obj` and save.
In the Terminal:
`$ git add .gitignore`
`$ git commit -m 'add .gitignore`
`$ git push origin main`

9. While in the terminal, navigate to the project's production directory called "Bakery" and type `$ dotnet build` to compile the application's code.

10.  To use MSTest, you need to use the NuGet package manager to install the packages in the .csproj file.  Navigate to the Bakery.Tests directory in the terminal and run the command `$ dotnet restore`

11.  Optionally you can use a file watcher so you don't have to restart the server every time the code changes. Run this command `$ dotnet watch run` to make the server automatically update.

12. In the terminal, type `$ dotnet run` (to compile and execute the console application ). Since this is a console application, you'll interact with it through text commands in your terminal.

13. Enjoy my first solo official C# Console Application!  You can exit the program at anytime by entering `ctrl` + `c` at any time.

* To run tests using MSTest, navigate to the Bakery.Tests directory in your terminal and type `$ dotnet test`

## Known Bugs
* None known at this time

## License
MIT License. See license.md for further information