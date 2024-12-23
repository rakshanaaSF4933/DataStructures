using System;

namespace ECommerceDictionary
{
    /// <summary>
    /// Class <see cref="Shopping"/> used to do shopping
    /// </summary>
    public static class Shopping
    {
        /// <summary>
        /// List orders used to store orders list 
        /// </summary>
        /// <typeparam name="OrderDetails"></typeparam>
        /// <returns>orders</returns>
        public static CustomDictionary<string, OrderDetails> orders = new CustomDictionary<string, OrderDetails>();

        /// <summary>
        /// List products used to store product list 
        /// </summary>
        /// <typeparam name="ProductDetails"></typeparam>
        /// <returns>products</returns>
        public static CustomDictionary<string, ProductDetails> products = new CustomDictionary<string, ProductDetails>();

        /// <summary>
        /// List customers used to store customer details
        /// </summary>
        /// <typeparam name="CustomerDetails"></typeparam>
        /// <returns>customers</returns>
        public static CustomDictionary<string, CustomerDetails> customers = new CustomDictionary<string, CustomerDetails>();

        /// <summary>
        /// Object productStock creates instance of <see cref="ProductDetails"/>
        /// </summary>
        /// <returns></returns>
        public static ProductDetails productStock = new ProductDetails();

        public static CustomerDetails customer;

        /// <summary>
        /// Method DefaultData used to add default values
        /// </summary>
        public static void DefaultData()
        {
            customer = new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com");
            customers.Add("CID3001", customer);
            customer = new CustomerDetails("Baskaran", "Chennai", "9888475757", "baskaran@mail.com");
            customers.Add("CID3002", customer);

            products.Add("PID2001", new ProductDetails("Mobile (Samsung)", 10, 10000, 3));
            products.Add("PID2002", new ProductDetails("Tablet (Lenovo)", 5, 15000, 2));
            products.Add("PID2003", new ProductDetails("Camara (Sony)", 3, 20000, 4));
            products.Add("PID2004", new ProductDetails("iPhone", 5, 50000, 6));
            products.Add("PID2005", new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3));
            products.Add("PID2006", new ProductDetails("HeadPhone (Boat)", 5, 1000, 2));
            products.Add("PID2007", new ProductDetails("Speakers (Boat)", 4, 500, 2));

            orders.Add("OID3001", new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orders.Add("OID3002", new OrderDetails("CID3001", "PID2002", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orders.Add("OID3003", new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered));

        }

        /// <summary>
        /// Method Operation used to perform shopping
        /// </summary>
        public static void Operation()
        {
            try
            {
                string repeat = "yes";
                do
                {
                    Console.WriteLine("***************MAIN MENU***************");
                    Console.WriteLine("    1.Customer Registration\n    2.Customer Login\n    3.Exit");
                    int option;
                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid...Try Again\n    1. CustomerRegistration\n    2. Customer Login\n    3. Exit");
                    }
                    switch (option)
                    {
                        case 1:
                            {
                                GetDetails();
                                break;
                            }
                        case 2:
                            {
                                CustomerLogin();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Thank You :)");
                                repeat = "no";
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter valid option...");
                                break;
                            }
                    }
                } while (repeat == "yes");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Method GetDetails used to get customer details
        /// </summary>
        public static void GetDetails()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter mobile number: ");
            string mobile = Console.ReadLine();
            Console.WriteLine("Enter mail id: ");
            string mailID = Console.ReadLine();

            customer = new CustomerDetails(name, city, mobile, mailID);
            customers.Add(customer.CustomerID, customer);

            Console.WriteLine($"Customer details registered successfully...\nCustomerID : {customer.CustomerID}\n");
        }

        /// <summary>
        /// Method CustomerLogin used to do shopping
        /// </summary>
        public static void CustomerLogin()
        {
            Console.WriteLine("Enter Customer ID : ");
            string customerID = Console.ReadLine().ToUpper();
            int found = 0;
            foreach (KeyValue<string, CustomerDetails> customer in customers)
            {
                if (customerID.Equals(customer.Key))
                {
                    found = 1;
                    SubMenu();
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Customer ID not found");
            }
        }

        public static void SubMenu()
        {
            int showAgain = 1;
            do
            {
                Console.WriteLine("***************MENU***************");
                Console.WriteLine("    a.Purchase\n    b.Order History\n    c.Cancel Order\n    d.Wallet Balance\n    e.Wallet Recharge\n    f.Exit\n");
                char option;
                while (!char.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid...Try Again \n    a.Purchase\n    b.Order History\n    c.Cancel Order\n    d.Wallet Balance\n    e.WalletRecharge\n    f.Exit\n");
                }
                switch (option)
                {
                    case 'a':
                        {
                            //Purchase
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            //Order History
                            ShowOrder();
                            break;
                        }
                    case 'c':
                        {
                            //Cancel Order
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            //Wallet Balance
                            CheckBalance();
                            break;
                        }
                    case 'e':
                        {
                            //Wallet Recharge
                            WalletRecharge();
                            break;
                        }
                    case 'f':
                        {
                            //Exit
                            showAgain = 0;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter valid option...");
                            break;
                        }
                }
            } while (showAgain == 1);
        }

        /// <summary>
        /// Method Purchase used to purchase products
        /// </summary>
        /// <param name="customer">instance of current customer</param>
        public static void Purchase()
        {
            //Show list of products
            ShowProducts();

            // Ask the customer to select a product using the Product ID.
            Console.WriteLine("\nEnter Product ID : ");
            string productID = Console.ReadLine().ToUpper();

            int found = 0;
            //Validate ProductID
            foreach (KeyValue<string, ProductDetails> product in products)
            {
                if (productID.Equals(product.Key))
                {
                    found = 1;
                    //Get count he wishes to purchase.
                    Console.WriteLine("Enter Count you need to purchase : ");
                    int count;
                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Enter correct number");
                    }
                    if (count > product.Value.Stock)
                    {
                        //Not enough stock
                        Console.WriteLine($"Required count not available. Current availability is {product.Value.Stock}.");
                    }
                    else
                    {
                        //calculate the total amount
                        double total = (count * product.Value.Price) + 50;
                        //Sufficient balance
                        if (customer.WalletBalance >= total)
                        {
                            //Deduct balance
                            customer.DeductBalance(total);
                            //Decrease stock count
                            product.Value.Stock -= count;
                            //add it to the order list
                            OrderDetails order = new OrderDetails(customer.CustomerID, product.Value.ProductID, total, DateTime.Now, count, OrderStatus.Ordered);
                            orders.Add(order.OrderID, order);
                            Console.WriteLine($"\nOrder Placed Successfully. Order ID: {order.OrderID}");
                            Console.WriteLine($"Order placed successfully.Your order will be delivered on {order.PurchaseDate.AddDays(product.Value.Duration)}.\n");

                        }
                        //Insufficient balance
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do the purchase again.");
                        }
                    }
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Invalid Product ID");
            }
        }

        /// <summary>
        /// Method ShowProducts used to show list of products
        /// </summary>
        public static void ShowProducts()
        {
            //Product details
            Grid<string, ProductDetails> productGrid = new Grid<string, ProductDetails>();
            productGrid.ShowTable(products);
        }

        /// <summary>
        /// Method showOrder used to show details of products ordered by the customer
        /// </summary>
        public static void ShowOrder()
        {
            //Show all orders placed by the current logged-in customer whose order status is Ordered.
            CustomDictionary<string, OrderDetails> customerOrders = new CustomDictionary<string, OrderDetails>();
            Grid<string, OrderDetails> orderGrid = new Grid<string, OrderDetails>();

            foreach (KeyValue<string, OrderDetails> order in orders)
            {
                if (order.Value.CustomerID.Equals(customer.CustomerID))
                {
                    customerOrders.Add(order.Key, order.Value);
                }
            }
            if (customerOrders.Count <= 0)
            {
                System.Console.WriteLine("NO ORDER HISTORY");
            }
            else
            {
                orderGrid.ShowTable(customerOrders);
            }
        }

        public static int ShowOrderHistory()
        {
            //Show all orders placed by the current logged-in customer whose order status is Ordered.
            CustomDictionary<string, OrderDetails> customerOrders = new CustomDictionary<string, OrderDetails>();
            Grid<string, OrderDetails> orderGrid = new Grid<string, OrderDetails>();

            foreach (KeyValue<string, OrderDetails> order in orders)
            {
                if (order.Value.OrderStatus.Equals(OrderStatus.Ordered) && order.Value.CustomerID.Equals(customer.CustomerID))
                {
                    customerOrders.Add(order.Key, order.Value);
                }
            }
            if (customerOrders.Count <= 0)
            {
                System.Console.WriteLine("NO ORDER HISTORY");
            }
            else
            {
                orderGrid.ShowTable(customerOrders);
            }
            return customerOrders.Count;
        }

        /// <summary>
        /// Method CheckBalance used to check the wallet balance
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void CheckBalance()
        {
            Console.WriteLine($"WalletBalance : {customer.WalletBalance}");
        }

        /// <summary>
        /// Method WalletRecharge used to recgarge the wallet amount
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void WalletRecharge()
        {
            //Ask the customer whether he wishes to recharge the wallet. 
            int repeat;
            string ask;
            do
            {
                Console.WriteLine("Do you want to recharge your wallet? yes or no : ");
                ask = Console.ReadLine().ToLower();
                if (ask == "yes" || ask == "no")
                {
                    repeat = 0;
                }
                else
                {
                    Console.WriteLine("Please answer yes or no.");
                    repeat = 1;
                }
            } while (repeat == 1);
            if (ask.Equals("yes"))
            {
                //Get amount
                Console.WriteLine("Enter amount : ");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Enter valid amount.");
                }
                customer.WalletRecharge(amount);
                Console.WriteLine($"WalletBalance : {customer.WalletBalance}");
            }

        }

        /// <summary>
        /// Method CancelOrder used to cancel order of the customer
        /// </summary>
        /// <param name="customer">represent current customer</param>
        public static void CancelOrder()
        {
            // Show all orders placed by the current logged-in customer whose order status is Ordered.
            int count = ShowOrderHistory();
            if (count > 0)
            {
                Console.WriteLine("\nEnter order ID : ");
                string orderID = Console.ReadLine().ToUpper();
                int found = 0;
                //Validate orderID
                foreach (KeyValue<string, OrderDetails> order in orders)
                {
                    if (orderID.Equals(order.Key))
                    {
                        found = 1;
                        //Increase the available stock quantity by the count of products purchased in the current order to be cancelled.
                        productStock.Stock = order.Value.Quantity;
                        //Refund the amount to the customer’s wallet balance.
                        customer.WalletRecharge(order.Value.TotalPrice);
                        //Change the order status to “Cancelled”
                        order.Value.OrderStatus = OrderStatus.Cancelled;

                        Console.WriteLine($"\nOrder:{order.Value.OrderID} cancelled successfully.");

                    }
                }
                if (found == 0)
                {
                    Console.WriteLine("Invalid OrderID..Enter Again");
                }
            }
        }
    }
}