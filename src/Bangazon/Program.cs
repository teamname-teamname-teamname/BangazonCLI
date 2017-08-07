using System;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seed the database if none exists
            DatabaseInterface db = new DatabaseInterface("BANGAZONCLI_DB");
            db.CheckCustomerTable();
            db.CheckOrderTable();
            db.CheckProductTable();
            db.CheckProductOrderTable();
            db.CheckPaymentTypeTable();

            // Present the main menu from MainMenu.cs file
            MainMenu menu = new MainMenu();

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
                        
                        break;

                    // Menu option 2: Choosing Active Customer
                    case 2:
                        
                        break;
                    // Menu option 3: Create Payment Options
                    case 3:
                        
                        break;
                    // Menu option 4: Add product to sell
                    case 4:
                        
                        break;
                    // Menu option 5: Add product to shopping cart
                    case 5:
                        
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
                    // Menu option 12: Leave Bangazon!
                    case 12:
                        
                        break;
                }
            } while (choice != 13);
        }
    }
}
