# Bangazon

## The Command Line Ordering System

In this group project, you will be allowing a user to interact with a basic product ordering database via a command line interface.

## Requirements

### OSX Users

```
brew install sqlite
```

### Windows Users

Visit https://www.sqlite.org/download.html and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

### Visual Studio Code

https://code.visualstudio.com/download is Microsoft's cross-platform editor that we'll be using during orientation for writing C# and building .NET applications. Make sure you add the C# extension immediately after installation completes.

### Windows

[Install .NET Core](https://www.microsoft.com/net/core#windows)
Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
Once installed open a command line app to initialize some code.
Make a directory for your app: `mkdir HelloWorld`
Move to the newly created directory. : `cd HelloWorld`
Create a new app: `dotnet new`
Build the app and restore any get any missing libraries (packages) : `dotnet restore`
Run the app: `dotnet run`
You should see the test "Hello World".
Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

### OSX

[Install .NET Core](https://www.microsoft.com/net/core#macos)
Create and run an ASP.NET application using .NET Core
(https://docs.asp.net/en/latest/getting-started.html)
Review .NET Core Documentation
(https://docs.microsoft.com/en-us/dotnet/)

## Installation for Bangazon CLI

The CLI will be hosted on your local computer. In order to run this program, follow these steps.

#### Setting Up An Environmental Variable

In your .bashrc or .zshrc file, create an environmental variable with the following syntax:

```
Example: export BANGAZONCLI_DB="/Users/Jackie/workspace/Bangazon/BangazonCLI/bangazoncli.db"
```

Create a new directory and cd into it. Once in new directory, run the following command to clone the repo:
`` git clone https://github.com/teamname-teamname-teamname/BangazonCLI.git ``

Now that you have the BangazonCLI repository cloned on your local machine, create a database specific to your environmental variable such as `` bangazoncli.db ``

Run the following commands to finish installation:

```
dotnet restore
dotnet run

```

# Running BangazonCLI

## Ordering System Interface

### Main Menu

```bash
*********************************************************
**  Welcome to Bangazon! Command Line Ordering System  **
*********************************************************
1. Create a customer account
2. Choose active customer
3. Create a payment option
4. Add product to sell
5. Add product to shopping cart
6. Complete an order
7. Remove customer product
8. Update product information
9. Show stale products
10. Show customer revenue report
11. Show overall product popularity
12. Leave Bangazon!
>
```

## 1. Create A Customer Account

Selecting 1. will prompt user to create a customer account

## 2. Choose Active Customer

Selecting 2. will display list of customers that have been added. User will be able to select a specific customer.

## 3. Create A Payment Option

Selecting 3. will prompt user to create a payment type for the active customer.

## 4. Add Product To Sell

Selecting 4. will prompt user to create a new product for the active customer.

## 5. Add Product To Shopping Customer

Selecting 5. will have user add a product to a shopping cart for the active customer.

## 12. Leave Bangazon

Selecting 12. will exit BangazonCLI.


