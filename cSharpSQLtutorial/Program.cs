using PRSLibrary;
using PRSLibrary.Controllers;
using PRSLibrary.Models;

Console.WriteLine("Hello, SQL!");

Connection connection = new();
connection.Connect();

UsersController userCtrl = new(connection);
VendorsController vendorCtrl = new(connection);
ProductsController productCtrl = new(connection);

User? u = userCtrl.Login("JIM124", "PASSWORDS");
if (u != null)
    Console.WriteLine($"{u.Id} | {u.Username} | {u.Password} | {u.Firstname} | {u.Lastname}");
else
    Console.WriteLine("User not found; contact support and complain that they messed up not you.");
/*
IEnumerable<Product> products = productCtrl.GetAll();
foreach(Product prod in products) {
    Console.WriteLine($"{product.PartNbr, -15} | {product.Name, -30} | {product.Price,10:C} | {product.Vendor.Name, -25}");
}
*/
/*
Product? product = productCtrl.GetByPk(3);
if(p is not null)
    Console.WriteLine($"{product.PartNbr,-15} | {product.Name,-30} | {product.Price,10:C} | {product.Vendor.Name,-25}");
*/

connection.Disconnect();

