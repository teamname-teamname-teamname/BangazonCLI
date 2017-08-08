using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace Bangazon
{
    /*
    Class: DatabaseInterface
    Purpose: The DatabaseInterface class is used to 
    Author: Teamname-Teamname-Teamname
    Properties:
        Query: 
        Delete: 
        Insert: 
        BulkInsert:
        CheckCustomerTable:
        CheckProductTable:
        CheckOrderTable:
        CheckProductOrderTable:
        ChekcPaymentTypeTable:
    */

    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface(string database)
        {
            string env = $"{Environment.GetEnvironmentVariable(database)}";
            _connectionString = $"Data Source={env}";
            _connection = new SqliteConnection(_connectionString);
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader()) 
                {
                    handler (dataReader);
                }

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        public void Delete(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                
                dbcmd.ExecuteNonQuery ();

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                
                dbcmd.ExecuteNonQuery ();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose ();
                _connection.Close ();
            }

            return insertedItemId;
        }

        // Bulk Insert to seed the databse using data/DBInitializer - Ollie
        public void BulkInsert(string command)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand;
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery();

                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckCustomerTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the customer table to see if table is created
                dbcmd.CommandText = $"select id from customer";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table customer (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `firstName`	varchar(80) not null, 
                            `lastName` varchar(80) not null,
                            `address` varchar(80) not null,
                            `city` varchar(20) not null,
                            `state` varchar(2) not null,
                            `zipCode`  varchar(5) not null,
                            `phoneNumber` varchar(12) not null
                        )";
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        public void CheckProductTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the product table to see if table is created
                dbcmd.CommandText = $"select id from product";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table product (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name` varchar(80) not null, 
                            `customerId` integer not null,
                            `price` decimal(5, 2) not null,
                            `quantity` integer not null,
                            `description` varchar(150) not null,
                            FOREIGN KEY(`customerId`) REFERENCES `customer`(`id`)
                        )";
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }

                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        public void CheckOrderTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the order table to see if table is created
                dbcmd.CommandText = $"select id from [order]";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table [order] (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT, 
                            `customerId` integer not null,
                            `paymentTypeId` integer,
                            FOREIGN KEY(`customerId`) REFERENCES `customer`(`id`),
                            FOREIGN KEY(`paymentTypeId`) REFERENCES `paymentType`(`id`)
                        )";
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }

                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        public void CheckProductOrderTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the productOrder table to see if table is created
                dbcmd.CommandText = $"select id from productOrder";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table productOrder (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `productId` integer not null,
                            `orderId` integer not null,
                            FOREIGN KEY(`productId`) REFERENCES `product`(`id`),
                            FOREIGN KEY(`orderId`) REFERENCES `order`(`id`)
                        )";
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }

                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        public void CheckPaymentTypeTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the paymentType table to see if table is created
                dbcmd.CommandText = $"select id from paymentType";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table paymentType (
                            `id` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name` varchar(80) not null, 
                            `customerId` integer not null,
                            `accountNumber` integer not null,
                            FOREIGN KEY(`customerId`) REFERENCES `customer`(`id`)
                        )";
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }

                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }
    }
}