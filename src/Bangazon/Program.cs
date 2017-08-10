using System;
using Bangazon.Managers;
using Bangazon.Actions;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create database tables if none exist
            DatabaseInterface dab = new DatabaseInterface("BANGAZONCLI_DB");
            dab.CheckCustomerTable();
            dab.CheckOrderTable();
            dab.CheckProductTable();
            dab.CheckProductOrderTable();
            dab.CheckPaymentTypeTable();
            DbInitializer.Initialize(dab);

            // Seed the database if none exists
            // var db = new DatabaseInitializer();
            // db.VerifyDataExists();

            // Present the main menu from MainMenu.cs file
            MainMenu menu = new MainMenu();
            CustomerManager cm = new CustomerManager(dab);
            OrderManager om = new OrderManager(dab);
            PaymentTypeManager ptm = new PaymentTypeManager(dab);
            ProductManager pm = new ProductManager(dab);

			// Read in the user's choice
			int choice;
			// Int32.TryParse (Console.ReadLine(), out choice);

            // If option 1 was chosen, create a new customer account
            do
            {
                // Show the main menu
                choice = menu.Show();

                switch (choice)
                {
                    // Menu option 1: Adding Customer
                    case 1:
                        CreateCustomer.DoAction(cm);
                        break;

                    // Menu option 2: Choosing Active Customer
                    case 2:
                        
                        break;
                    // Menu option 3: Create Payment Options
                    case 3:
                        
                        break;
                    // Menu option 4: Add product to sell
                    case 4:
                        CreateProduct.DoAction(pm);
                        break;
                    // Menu option 5: Add product to shopping cart
                    case 5:
                        AddProductCart.DoAction(om, pm);
                        break;
                    // Menu option 6: Complete an order
                    case 6:
                        
                        break;
                    // Menu option 7: Remove customer product
                    case 7:
                        
                        break;
                    // Menu option 8: Update product information
                    case 8:
                        
                        break;
                    // Menu option 9: Show stale products
                    case 9:
                        
                        break;
                    // Menu option 10: Show customer revenue report
                    case 10:
                        
                        break;
                    // Menu option 11: Show overall product popularity
                    case 11:
                        
                        break;
                }
            } while (choice != 12);
        }
    }
}
