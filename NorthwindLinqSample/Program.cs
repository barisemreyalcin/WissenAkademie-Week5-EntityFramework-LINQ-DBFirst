// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//using NorthwindLinqSample.Models;
//using NorthwindLinqSample.NorthwindDTO;

//NorthwindContext context = new NorthwindContext(); // Instance almam db'ye bağlantı atacağım anlamına gelmiyor. Data çekeceğiim zaman bağlantı açar datayı çeker ve geri kapatır. Sql profiler'da gördük

// Method Syntax
//var customers = context.Customers.ToList();
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Company Name: {customer.CompanyName}");
//}

// Query Synatx
//var customers = from customer in context.Customers
//                select customer;
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Company Name: {customer.CompanyName}");
//}

// --------------------------------------------------------------------------------------------------------------------------

//// Customers from UK or USA
//var customers = from customer in context.Customers
//                where customer.Country == "USA" || customer.Country == "UK"
//                select customer;
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Customer Country: {customer.Country} - Company Name: {customer.CompanyName}");
//}

// Customers from UK or USA
//var customers = context.Customers.Where(cus => cus.Country == "UK" || cus.Country == "USA");
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Customer Country: {customer.Country} - Company Name: {customer.CompanyName}");
//}

// --------------------------------------------------------------------------------------------------------------------------

// Country: USA or UK & Country ascending & Region descending
// QS
//var customers = from customer in context.Customers
//                where customer.Country == "UK" || customer.Country == "USA"
//                orderby customer.Country ascending, customer.Region descending
//                select customer;
//    foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Customer Country: {customer.Country} - Company Name: {customer.CompanyName} - Company Region: {customer.Region}");
//}

// MS
//var customers = context.Customers.Where(cus => cus.Country == "UK" || cus.Country == "USA").OrderBy(cus => cus.Country).ThenByDescending(cus => cus.Region);
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerId} - Customer Country: {customer.Country} - Company Name: {customer.CompanyName} - Company Region: {customer.Region}");
//}

// --------------------------------------------------------------------------------------------------------------------------

// Country UK, USA, Mexico or France & Country order ascending & Region order descending --- Dönüş tipinde sadece CustomerId, CompanyName, Country, Region olacak
// QS
//var customers = from customer in context.Customers
//                where customer.Country == "UK" || customer.Country == "USA" || customer.Country == "Mexico" || customer.Country == "France"
//                orderby customer.Country ascending, customer.Region descending
//                select new CustomerDTO
//                {
//                    CustomerID = customer.CustomerId,
//                    CustomerName = customer.CompanyName,
//                    Country = customer.Country,
//                    Region = customer.Region
//                };
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Customer Country: {customer.Country} - Company Name: {customer.CustomerName} - Company Region: {customer.Region}");
//}

// MS
//var customers = context.Customers
//    .Where(cus => cus.Country == "UK" || cus.Country == "USA" || cus.Country == "Mexico" || cus.Country == "France")
//    .OrderBy(cus => cus.Country)
//    .ThenByDescending(cus => cus.Region)
//    .Select(cus => new CustomerDTO
//    {
//        CustomerID = cus.CustomerId,
//        CustomerName = cus.CompanyName,
//        Country = cus.Country,
//        Region = cus.Region
//    });

//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Customer Country: {customer.Country} - Company Name: {customer.CustomerName} - Company Region: {customer.Region}");
//}

// --------------------------------------------------------------------------------------------------------------------------

// Country UK, USA, Mexico or France & Country order ascending & Region order descending --- Dönüş tipinde sadece CustomerId, CompanyName, Country, Region olacak
// QS
//var customers = from customer in context.Customers
//                where customer.Country == "UK" || customer.Country == "USA" || customer.Country == "Mexico" || customer.Country == "France"
//                orderby customer.Country ascending, customer.Region descending
//                // new diyip CustomerDTO tipinde dönmemiz şart değildi. Direkt burada da bir obj oluşturabiliriz
//                select new 
//                {
//                    CustomerID = customer.CustomerId,
//                    CustomerName = customer.CompanyName,
//                    Country = customer.Country,
//                    Region = customer.Region
//                };
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Customer Country: {customer.Country} - Company Name: {customer.CustomerName} - Company Region: {customer.Region}");
//}

//// MS
//var customers2 = context.Customers
//    .Where(cus => cus.Country == "UK" || cus.Country == "USA" || cus.Country == "Mexico" || cus.Country == "France")
//    .OrderBy(cus => cus.Country)
//    .ThenByDescending(cus => cus.Region)
//    .Select(cus => new 
//    {
//        CustomerID = cus.CustomerId,
//        CustomerName = cus.CompanyName,
//        Country = cus.Country,
//        Region = cus.Region
//    });

//foreach (var customer in customers)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Customer Country: {customer.Country} - Company Name: {customer.CustomerName} - Company Region: {customer.Region}");
//}

// --------------------------------------------------------------------------------------------------------------------------

// Contact bilgilerini tekrar etmeyen bir şekilde al --- Distinct
// QS
//var contactTitles = (from customer in context.Customers
//                select customer.ContactTitle).Distinct();

//foreach (var ct in contactTitles)
//{
//    Console.WriteLine(ct);
//}

// MS
//using NorthwindLinqSample.Models;
//using NorthwindLinqSample.NorthwindDTO;

//NorthwindContext context = new NorthwindContext(); // Instance almam db'ye bağlantı atacağım anlamına gelmiyor. Data çekeceğiim zaman bağlantı açar datayı çeker ve geri kapatır. Sql profiler'da gördük

//var contactTitles = context.Customers.Select(cust => cust.ContactTitle).Distinct();
//foreach (var ct in contactTitles)
//{
//    Console.WriteLine(ct);
//}

// --------------------------------------------------------------------------------------------------------------------------

// Bilgiyle bağlantılı olarak diğer tablolardan dataya ulaşmak
// İsminde A geçen müşterilerin şirket & sipariş bilgileri:
// QS
//using NorthwindLinqSample.Models;
//using NorthwindLinqSample.NorthwindDTO;
//NorthwindContext context = new NorthwindContext(); // Instance almam db'ye bağlantı atacağım anlamına gelmiyor. Data çekeceğiim zaman bağlantı açar datayı çeker ve geri kapatır. Sql profiler'da gördük
//var customersWithOrders = from customer in context.Customers
//                     where (customer.CompanyName.Contains("A"))
//                     select new
//                     {
//                         CustomerID = customer.CustomerId,
//                         CompanyName = customer.CompanyName,
//                         Orders = customer.Orders,
//                     };
//Console.WriteLine($"Records number: ({customersWithOrders.Count()})");
//foreach (var customer in customersWithOrders)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Company Name: {customer.CompanyName} ");
//    Console.WriteLine($"Customer Orders:");
//    foreach (var order in customer.Orders)
//    {
//        Console.WriteLine($"Order ID: {order.OrderId} - Order Date: {order.OrderDate}");
//    }
//    Console.WriteLine(new string('-', 60));
//}

// MS
// İsminde A geçen müşterilerin şirket & sipariş bilgileri:
//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//var customersWithOrders = context.Customers
//    .Where(cus => cus.CompanyName.Contains("A"))
//    .Select(cus => new
//    {
//        CustomerID = cus.CustomerId,
//        CompanyName = cus.CompanyName,
//        Orders = cus.Orders,
//    });

//Console.WriteLine($"Records number: ({customersWithOrders.Count()})");
//foreach (var customer in customersWithOrders)
//{
//    Console.WriteLine($"Customer ID: {customer.CustomerID} - Company Name: {customer.CompanyName} ");
//    Console.WriteLine($"Customer Orders:");
//    foreach (var order in customer.Orders)
//    {
//        Console.WriteLine($"Order ID: {order.OrderId} - Order Date: {order.OrderDate}");
//    }
//    Console.WriteLine(new string('-', 60));
//}

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//var orderQuantity = (from order in context.OrderDetails
//                    where order.ProductId == 30
//                    select order).Count();
//Console.WriteLine(orderQuantity);

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// 30 ID'li ürün ortalama kaç adet verilmiş:
//var orderProductCountAvg = (from order in context.OrderDetails
//                           where order.ProductId == 30
//                           select order).Average(order => order.Quantity);
//Console.WriteLine(orderProductCountAvg);

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// 30 ID'li ürün ortalama satış fiyatı:
//var orderPriceAvg = (from order in context.OrderDetails
//                    where order.Product.ProductName == "Konbu"
//                    select order.UnitPrice * order.Quantity).Average();
//Console.WriteLine(orderPriceAvg);

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// Kategoriye göre ürün listesi
//var productListByCategory = from product in context.Products
//                            where product.Category.CategoryName == "Seafood"
//                            select product;
//foreach (var product in productListByCategory)
//{
//    Console.WriteLine($"Product ID: {product.ProductId} - Product Name: {product.ProductName} - Stock: {product.UnitsInStock}");
//}

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// 10'dan fazla sipariş veren müşteriler
//var customers = from customer in context.Customers
//                where customer.Orders.Count >= 10
//                select new
//                {
//                    CustomerName = customer.CompanyName,
//                };
//foreach (var cus in customers)
//{
//    Console.WriteLine($"Customer Name: {cus.CustomerName}");
//}

// ----------------------------------------------------------------------------------------------------------------------

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// Bir customer için toplam ciro
//var customerTotal = (from orderTotal in context.OrderDetails
//                    where orderTotal.Order.Customer.CompanyName == "Eastern Connection"
//                    select orderTotal.Quantity * orderTotal.UnitPrice).Sum();
//Console.WriteLine(customerTotal);

// ----------------------------------------------------------------------------------------------------------------------

// Linq Join Yapısı

//using NorthwindLinqSample.Models;
//NorthwindContext context = new NorthwindContext();

//// QS
//var productsByCategory = from product in context.Products // bu tablonun
//                         join category in context.Categories // bu tabloyla ilişkili olarak join edilmesi
//                         on product.CategoryId equals category.CategoryId // ne üzerine ilişkili oldukları
//                         orderby category.CategoryId ascending, product.ProductId ascending
//                         select new
//                         {
//                             CategoryID = category.CategoryId,
//                             CategoryName = category.CategoryName,
//                             ProductID = product.ProductId,
//                             ProductName = product.ProductName,
//                         };
//foreach (var product in productsByCategory)
//{
//    Console.WriteLine($"Category ID: {product.CategoryID} - Category Name: {product.CategoryName} - Product ID: {product.ProductID} - Product Name: {product.ProductName}");
//}

// Linq Join Yapısı
using NorthwindLinqSample.Models;
NorthwindContext context = new NorthwindContext();

// MS
var productsByCategory = context.Products
    .Join(context.Categories, // ilişkili olan tablo
    product => product.CategoryId, // ilişkili olan kolon
    category => category.CategoryId, // ilişkili olan kolon
    (product, category) => new
    {
        // hangi tablodan hangi kolonları alacağım
        CategoryID = category.CategoryId,
        CategoryName = category.CategoryName,
        ProductID = product.ProductId,
        ProductName = product.ProductName,
    }) 
    .OrderBy(prod => prod.CategoryID)
    .ThenBy(prod => prod.ProductID);

foreach (var product in productsByCategory)
{
    Console.WriteLine($"Category ID: {product.CategoryID} - Category Name: {product.CategoryName} - Product ID: {product.ProductID} - Product Name: {product.ProductName}");
}