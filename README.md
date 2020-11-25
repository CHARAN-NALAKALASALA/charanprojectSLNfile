# charanprojectSLNfile
Steps to setup and run the project

1. Download all the files from the given URL
2. Open it in visual studio (I used Visual studio 2019 version)
3. Before that create database and table with following code
CREATE DATABASE assessment1DB;(Execute this first)
CREATE TABLE ComponentsTable (
    product_id int NOT NULL PRIMARY KEY,
    product_name varchar(40) NOT NULL,
    product_price varchar(40) NOT NULL,
    product_description varchar(255) NOT NULL
);
4. once its done connect your visual studio and database with following steps 
visual studio 2019(Tools--> Connect to database--> In Add connection window--> select Microsoft SQL Server(SqlClient)-->
Server Name(Give your local server name in which you have created your DB and Table)-->
Authentication(window authentication or Server authentication based upon your SQl Server connection)-->
connect to a database(Select the given database assessment1DB)-->
Test Connection-->Once its shows test connection is succeed you are good to go)
5. Go to the visual studio open views-->ShopBridgeD-->Index.cshtml (Build and Run)
5. Execute on IIS Express(Google chrome)
6. Your ShopBridge Application Launches.

Project:
Task: a website that helps to track different items we have for sale.

Frontend : ASP.Net MVC(3 hrs) Backend : C#(2 hrs) Database : SQL server 2014 Visual Studio 2019

FrontEnd Functionality: MVC Model: Shopbridgedata1.cs Shopbridgedata1.cs : Model File, I have Initialised the properties of the database with get and set method

Views: Index.cshtml,Create.cshtml,Details.cshtml

In the Index view, I have shown the Title and List of Products available for sales. On the top, I added a link “Add New products” to add the new product to the Inventory *To make asynchronous i have added a pop up window to add new items

Once you give the details of the new item and save “The popup window automatically closes” and without loading the full Index page, I have added a script to refresh the table data every 5 seconds once.

<script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script>
        $(document).ready(function () {
            setInterval(function () {
                $("#refreshWithoutFullpage").load("Index");
                refresh();
            }, 5000);
        }
        );
    </script>
By using “Details.cshtml and ActionResult Details” I have added the link “Detail” on every row

when you click on the corresponding row it will take “product_id” as a parameter and it will display the corresponding Product details on the pop-up window(without loading or navigating to the new page)

I have added another button “Delete” in each row to delete the data by passing product_id as parameter.

Controller: ShopBridgeDController.cs In the controller I have declared the “ConnectionString” to establish the connection between database and MVC application. I have created 4 ActionResults Index() - getting the data from database.table and displaying it to the list Details() - getting the data from database.table by passing “Product_id” as a parameter and displaying it to the pop-up window. Create() - Inserting Data into the database.table from pop-up window to the Index List. Delete() - Removing the data from table and reflecting on the list.

Testing: By passing different values I have successfully displayed data on the list from database, created the data and added to list without loading full index page using pop-up window Deleted the data successfully Displayed the product details on clickLink.
