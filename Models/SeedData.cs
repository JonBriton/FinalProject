using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Customer.Any())
                {
                    return;
                }

                List<Customer> customers = new List<Customer> {
                    new Customer {FirstName="Laurie", LastName="Cornfoot", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Conni", LastName="Spriggen", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Darsey", LastName="Pervoe", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Ninetta", LastName="Seccombe", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Sibilla", LastName="Louisot", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Harli", LastName="Jencken", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Lisa", LastName="Dorrian", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Cary", LastName="Witt", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Hallsy", LastName="Choppen", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Sanson", LastName="Feyer", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Stearn", LastName="Hutchason", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Hewet", LastName="Gamlen", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Sheffie", LastName="Dicte", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Dot", LastName="Ralton", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Drusi", LastName="MacGovern", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Izak", LastName="Rosenkranc", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Clarinda", LastName="Rolling", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Coleen", LastName="Forcade", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Gray", LastName="Madner", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Rowan", LastName="Bursnell", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Kipp", LastName="Kiddell", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Iosep", LastName="Morville", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Martyn", LastName="Bhar", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Antoinette", LastName="Hanhardt", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Thor", LastName="Candy", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Beryl", LastName="Spikings", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Margeaux", LastName="Sturzaker", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Horatio", LastName="Chessel", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Vasili", LastName="Dore", Age=21, Gender="Female" , State="Texas"},
                    new Customer {FirstName="Flemming", LastName="Magnay", Age=21, Gender="Female" , State="Texas"},
                };

                context.AddRange(customers);

                List<Firearm> firearms = new List<Firearm> {
                    new Firearm {Brand = "Walther", Model="PDP", Caliber="9mm", Type="Pistol"},
                    new Firearm {Brand = "Glock", Model="19", Caliber="9mm", Type="Pistol"},
                    new Firearm {Brand = "Smith & Wesson", Model="M&P", Caliber="10mm", Type="Pistol"},
                    new Firearm {Brand = "Colt", Model="1911", Caliber="45ACP", Type="Pistol"},
                    new Firearm {Brand = "HK", Model="VP9", Caliber="40S&W", Type="Pistol"},
                    new Firearm {Brand = "Sig Sauer", Model="P238", Caliber="380ACP", Type="Pistol"},
                    new Firearm {Brand = "CZ", Model="P-07", Caliber="9mm", Type="Pistol"},
                };
                context.AddRange(firearms);

                List<Order> purchase = new List<Order> {
                    new Order {FirearmID = 1, CustomerID = 1},
                    new Order {FirearmID = 1, CustomerID = 26},
                    new Order {FirearmID = 1, CustomerID = 5},
                    new Order {FirearmID = 1, CustomerID = 18},
                    new Order {FirearmID = 1, CustomerID = 2},
                    new Order {FirearmID = 1, CustomerID = 20},
                    new Order {FirearmID = 1, CustomerID = 25},
                    new Order {FirearmID = 1, CustomerID = 6},
                    new Order {FirearmID = 1, CustomerID = 27},

                    new Order {FirearmID = 2, CustomerID = 4},
                    new Order {FirearmID = 2, CustomerID = 2},
                    new Order {FirearmID = 2, CustomerID = 13},
                    new Order {FirearmID = 2, CustomerID = 11},
                    new Order {FirearmID = 2, CustomerID = 14},
                    new Order {FirearmID = 2, CustomerID = 10},
                    new Order {FirearmID = 2, CustomerID = 29},
                    new Order {FirearmID = 2, CustomerID = 7},
                    new Order {FirearmID = 2, CustomerID = 24},
                };
                context.AddRange(purchase);

                context.SaveChanges();
            }
        }
    }
}