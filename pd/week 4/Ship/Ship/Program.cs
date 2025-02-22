using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DepartmentStore
{
    //==========================
    // Model Classes
    //==========================
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Threshold { get; set; }  // Minimum stock quantity to trigger an order

        public Product(string name, string category, double price, int stock, int threshold)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
            Threshold = threshold;
        }

        // Calculate sales tax based on product category:
        // Grocery: 10%, Fruit: 5%, Other: 15%
        public double GetSalesTax()
        {
            if (Category.ToLower() == "grocery")
                return Price * 0.10;
            else if (Category.ToLower() == "fruit")
                return Price * 0.05;
            else
                return Price * 0.15;
        }

        public override string ToString()
        {
            // Format: Name,Category,Price,Stock,Threshold
            return $"{Name},{Category},{Price},{Stock},{Threshold}";
        }

        public static Product Parse(string data)
        {
            string[] parts = data.Split(',');
            return new Product(
                parts[0],
                parts[1],
                double.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4])
            );
        }
    }

    public class Customer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public Customer(string username, string password, string email, string address, string contact)
        {
            Username = username;
            Password = password;
            Email = email;
            Address = address;
            ContactNumber = contact;
        }

        public override string ToString()
        {
            // Format: Username,Password,Email,Address,ContactNumber
            return $"{Username},{Password},{Email},{Address},{ContactNumber}";
        }

        public static Customer Parse(string data)
        {
            string[] parts = data.Split(',');
            return new Customer(
                parts[0],
                parts[1],
                parts[2],
                parts[3],
                parts[4]
            );
        }
    }

    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            // Format: Username,Password
            return $"{Username},{Password}";
        }

        public static Admin Parse(string data)
        {
            string[] parts = data.Split(',');
            return new Admin(parts[0], parts[1]);
        }
    }

    //==========================
    // Data Layer (DL)
    //==========================
    public static class ProductDL
    {
        public static List<Product> Products = new List<Product>();

        public static void LoadProducts(string filePath)
        {
            Products.Clear();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Products.Add(Product.Parse(line));
                    }
                }
            }
        }

        public static void SaveProducts(string filePath)
        {
            File.WriteAllLines(filePath, Products.Select(p => p.ToString()));
        }
    }

    public static class CustomerDL
    {
        public static List<Customer> Customers = new List<Customer>();

        public static void LoadCustomers(string filePath)
        {
            Customers.Clear();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Customers.Add(Customer.Parse(line));
                    }
                }
            }
        }

        public static void SaveCustomers(string filePath)
        {
            File.WriteAllLines(filePath, Customers.Select(c => c.ToString()));
        }
    }

    public static class AdminDL
    {
        public static Admin AdminUser;

        public static void LoadAdmin(string filePath)
        {
            if (File.Exists(filePath))
            {
                var content = File.ReadAllText(filePath).Trim();
                if (!string.IsNullOrEmpty(content))
                {
                    AdminUser = Admin.Parse(content);
                }
            }
            else
            {
                // Create a default admin if file doesn't exist
                AdminUser = new Admin("admin", "admin");
                SaveAdmin(filePath);
            }
        }

        public static void SaveAdmin(string filePath)
        {
            File.WriteAllText(filePath, AdminUser.ToString());
        }
    }

    //==========================
    // Business Logic Layer (BL)
    //==========================
    public static class ProductBL
    {
        public static void AddProduct(Product p)
        {
            ProductDL.Products.Add(p);
        }

        public static List<Product> GetAllProducts()
        {
            return ProductDL.Products;
        }

        public static Product GetHighestPricedProduct()
        {
            return ProductDL.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public static List<Product> GetProductsToOrder()
        {
            return ProductDL.Products.Where(p => p.Stock < p.Threshold).ToList();
        }
    }

    public static class CustomerBL
    {
        public static Customer SignUp(string username, string password, string email, string address, string contact)
        {
            // Check for duplicate username
            if (CustomerDL.Customers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            Customer newCustomer = new Customer(username, password, email, address, contact);
            CustomerDL.Customers.Add(newCustomer);
            return newCustomer;
        }

        public static Customer SignIn(string username, string password)
        {
            return CustomerDL.Customers.FirstOrDefault(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && c.Password == password);
        }

        // Deduct the purchased quantity from stock
        public static void BuyProduct(Product p, int quantity)
        {
            if (p.Stock >= quantity)
            {
                p.Stock -= quantity;
            }
        }

        // Generate invoice based on purchased items
        // Sales tax is applied to each product (Price + SalesTax) * quantity.
        public static double GenerateInvoice(Dictionary<Product, int> items)
        {
            double total = 0;
            foreach (var kvp in items)
            {
                Product p = kvp.Key;
                int qty = kvp.Value;
                double productTotal = (p.Price + p.GetSalesTax()) * qty;
                total += productTotal;
            }
            return total;
        }
    }

    public static class AdminBL
    {
        public static Admin SignIn(string username, string password)
        {
            if (AdminDL.AdminUser != null &&
                AdminDL.AdminUser.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                AdminDL.AdminUser.Password == password)
            {
                return AdminDL.AdminUser;
            }
            return null;
        }
    }

    //==========================
    // User Interface (UI)
    //==========================
    public static class ConsoleUtility
    {
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    public static class ProductUI
    {
        public static void AddProductUI()
        {
            string name = ConsoleUtility.ReadInput("Enter Product Name: ");
            string category = ConsoleUtility.ReadInput("Enter Product Category: ");
            double price = double.Parse(ConsoleUtility.ReadInput("Enter Product Price: "));
            int stock = int.Parse(ConsoleUtility.ReadInput("Enter Available Stock Quantity: "));
            int threshold = int.Parse(ConsoleUtility.ReadInput("Enter Minimum Stock Threshold: "));

            Product p = new Product(name, category, price, stock, threshold);
            ProductBL.AddProduct(p);
            ConsoleUtility.PrintLine("Product added successfully!");
        }

        public static void ViewAllProductsUI()
        {
            ConsoleUtility.PrintLine("\n--- List of Products ---");
            foreach (var p in ProductBL.GetAllProducts())
            {
                ConsoleUtility.PrintLine($"Name: {p.Name}, Category: {p.Category}, Price: {p.Price}, Stock: {p.Stock}, Threshold: {p.Threshold}");
            }
        }

        public static void ViewSalesTaxUI()
        {
            ConsoleUtility.PrintLine("\n--- Sales Tax for Each Product ---");
            foreach (var p in ProductBL.GetAllProducts())
            {
                ConsoleUtility.PrintLine($"Product: {p.Name}, Sales Tax: {p.GetSalesTax()}");
            }
        }

        public static void ViewHighestPricedProductUI()
        {
            Product p = ProductBL.GetHighestPricedProduct();
            if (p != null)
            {
                ConsoleUtility.PrintLine("\n--- Highest Priced Product ---");
                ConsoleUtility.PrintLine($"Name: {p.Name}, Price: {p.Price}");
            }
            else
            {
                ConsoleUtility.PrintLine("No products available.");
            }
        }

        public static void ViewProductsToOrderUI()
        {
            ConsoleUtility.PrintLine("\n--- Products to Order (Stock Below Threshold) ---");
            var productsToOrder = ProductBL.GetProductsToOrder();
            foreach (var p in productsToOrder)
            {
                ConsoleUtility.PrintLine($"Name: {p.Name}, Stock: {p.Stock}, Threshold: {p.Threshold}");
            }
        }
    }

    public static class CustomerUI
    {
        public static Customer CurrentCustomer;

        public static void SignUpUI()
        {
            string username = ConsoleUtility.ReadInput("Enter Username: ");
            string password = ConsoleUtility.ReadInput("Enter Password: ");
            string email = ConsoleUtility.ReadInput("Enter Email: ");
            string address = ConsoleUtility.ReadInput("Enter Address: ");
            string contact = ConsoleUtility.ReadInput("Enter Contact Number: ");

            Customer customer = CustomerBL.SignUp(username, password, email, address, contact);
            if (customer != null)
            {
                ConsoleUtility.PrintLine("Customer registered successfully!");
            }
            else
            {
                ConsoleUtility.PrintLine("Username already exists. Please try a different one.");
            }
        }

        public static bool SignInUI()
        {
            string username = ConsoleUtility.ReadInput("Enter Username: ");
            string password = ConsoleUtility.ReadInput("Enter Password: ");
            Customer customer = CustomerBL.SignIn(username, password);
            if (customer != null)
            {
                CurrentCustomer = customer;
                ConsoleUtility.PrintLine("Customer Sign In Successful!");
                return true;
            }
            else
            {
                ConsoleUtility.PrintLine("Invalid credentials for customer.");
                return false;
            }
        }

        public static void ViewAllProductsUI()
        {
            ProductUI.ViewAllProductsUI();
        }

        public static void BuyProductsUI()
        {
            // Using a dictionary to simulate a shopping cart: Product => quantity
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            bool shopping = true;
            while (shopping)
            {
                string prodName = ConsoleUtility.ReadInput("Enter product name to buy: ");
                Product p = ProductBL.GetAllProducts().FirstOrDefault(prod => prod.Name.Equals(prodName, StringComparison.OrdinalIgnoreCase));
                if (p != null)
                {
                    int qty = int.Parse(ConsoleUtility.ReadInput("Enter quantity: "));
                    if (p.Stock >= qty)
                    {
                        // Deduct stock and add to cart
                        CustomerBL.BuyProduct(p, qty);
                        if (cart.ContainsKey(p))
                            cart[p] += qty;
                        else
                            cart.Add(p, qty);
                        ConsoleUtility.PrintLine("Product added to cart.");
                    }
                    else
                    {
                        ConsoleUtility.PrintLine("Insufficient stock.");
                    }
                }
                else
                {
                    ConsoleUtility.PrintLine("Product not found.");
                }
                string cont = ConsoleUtility.ReadInput("Do you want to buy another product? (y/n): ");
                if (cont.ToLower() != "y")
                {
                    shopping = false;
                }
            }
            double invoiceTotal = CustomerBL.GenerateInvoice(cart);
            ConsoleUtility.PrintLine("\n--- Invoice Generated ---");
            foreach (var kvp in cart)
            {
                ConsoleUtility.PrintLine($"Product: {kvp.Key.Name}, Quantity: {kvp.Value}, Unit Price: {kvp.Key.Price}, Sales Tax: {kvp.Key.GetSalesTax()}");
            }
            ConsoleUtility.PrintLine("Total Amount (including sales tax): " + invoiceTotal);
        }

        public static void ViewProfileUI()
        {
            ConsoleUtility.PrintLine("\n--- Customer Profile ---");
            ConsoleUtility.PrintLine($"Username: {CurrentCustomer.Username}");
            ConsoleUtility.PrintLine($"Password: {CurrentCustomer.Password}");
            ConsoleUtility.PrintLine($"Email: {CurrentCustomer.Email}");
            ConsoleUtility.PrintLine($"Address: {CurrentCustomer.Address}");
            ConsoleUtility.PrintLine($"Contact: {CurrentCustomer.ContactNumber}");
        }
    }

    public static class AdminUI
    {
        public static Admin CurrentAdmin;

        public static bool SignInUI()
        {
            string username = ConsoleUtility.ReadInput("Enter Username: ");
            string password = ConsoleUtility.ReadInput("Enter Password: ");
            Admin admin = AdminBL.SignIn(username, password);
            if (admin != null)
            {
                CurrentAdmin = admin;
                ConsoleUtility.PrintLine("Admin Sign In Successful!");
                return true;
            }
            else
            {
                ConsoleUtility.PrintLine("Invalid credentials for admin.");
                return false;
            }
        }

        public static void ViewProfileUI()
        {
            ConsoleUtility.PrintLine("\n--- Admin Profile ---");
            ConsoleUtility.PrintLine($"Username: {CurrentAdmin.Username}");
            ConsoleUtility.PrintLine($"Password: {CurrentAdmin.Password}");
        }

        public static void AdminMenu()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleUtility.PrintLine("\n--- Admin Menu ---");
                ConsoleUtility.PrintLine("1. Add Product");
                ConsoleUtility.PrintLine("2. View All Products");
                ConsoleUtility.PrintLine("3. Find Product with Highest Unit Price");
                ConsoleUtility.PrintLine("4. View Sales Tax of All Products");
                ConsoleUtility.PrintLine("5. Products to be Ordered (Stock below threshold)");
                ConsoleUtility.PrintLine("6. View Profile");
                ConsoleUtility.PrintLine("7. Exit");
                string choice = ConsoleUtility.ReadInput("Enter your choice: ");
                switch (choice)
                {
                    case "1":
                        ProductUI.AddProductUI();
                        break;
                    case "2":
                        ProductUI.ViewAllProductsUI();
                        break;
                    case "3":
                        ProductUI.ViewHighestPricedProductUI();
                        break;
                    case "4":
                        ProductUI.ViewSalesTaxUI();
                        break;
                    case "5":
                        ProductUI.ViewProductsToOrderUI();
                        break;
                    case "6":
                        ViewProfileUI();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        ConsoleUtility.PrintLine("Invalid choice.");
                        break;
                }
            }
        }
    }

    //==========================
    // Main Program (UI Entry Point)
    //==========================
    class Program
    {
        static void Main(string[] args)
        {
            // File paths for persistence (ensure the application has rights to read/write these files)
            string productFile = "products.txt";
            string customerFile = "customers.txt";
            string adminFile = "admin.txt";

            // Load existing data
            ProductDL.LoadProducts(productFile);
            CustomerDL.LoadCustomers(customerFile);
            AdminDL.LoadAdmin(adminFile);

            bool running = true;
            while (running)
            {
                ConsoleUtility.PrintLine("\n=== Main Menu ===");
                ConsoleUtility.PrintLine("1. Sign In");
                ConsoleUtility.PrintLine("2. Sign Up");
                ConsoleUtility.PrintLine("3. Exit");
                string mainChoice = ConsoleUtility.ReadInput("Enter your choice: ");
                switch (mainChoice)
                {
                    case "1":
                        string userType = ConsoleUtility.ReadInput("Are you Admin or Customer? (A/C): ");
                        if (userType.ToLower() == "a")
                        {
                            if (AdminUI.SignInUI())
                            {
                                AdminUI.AdminMenu();
                            }
                        }
                        else if (userType.ToLower() == "c")
                        {
                            if (CustomerUI.SignInUI())
                            {
                                bool exitCustomer = false;
                                while (!exitCustomer)
                                {
                                    ConsoleUtility.PrintLine("\n--- Customer Menu ---");
                                    ConsoleUtility.PrintLine("1. View All Products");
                                    ConsoleUtility.PrintLine("2. Buy Products");
                                    ConsoleUtility.PrintLine("3. Generate Invoice (Integrated in Buy Products)");
                                    ConsoleUtility.PrintLine("4. View Profile");
                                    ConsoleUtility.PrintLine("5. Exit");
                                    string custChoice = ConsoleUtility.ReadInput("Enter your choice: ");
                                    switch (custChoice)
                                    {
                                        case "1":
                                            CustomerUI.ViewAllProductsUI();
                                            break;
                                        case "2":
                                            CustomerUI.BuyProductsUI();
                                            break;
                                        case "3":
                                            // If the customer wishes to generate another invoice, they can use option 2
                                            CustomerUI.BuyProductsUI();
                                            break;
                                        case "4":
                                            CustomerUI.ViewProfileUI();
                                            break;
                                        case "5":
                                            exitCustomer = true;
                                            break;
                                        default:
                                            ConsoleUtility.PrintLine("Invalid choice.");
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ConsoleUtility.PrintLine("Invalid user type selected.");
                        }
                        break;
                    case "2":
                        // Customer sign up
                        CustomerUI.SignUpUI();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        ConsoleUtility.PrintLine("Invalid choice.");
                        break;
                }

                // Save data after each main loop iteration
                ProductDL.SaveProducts(productFile);
                CustomerDL.SaveCustomers(customerFile);
                AdminDL.SaveAdmin(adminFile);
            }
        }
    }
}
