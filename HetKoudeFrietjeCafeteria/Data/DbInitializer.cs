using HetKoudeFrietjeCafeteria.Model;
using System;
using System.Linq;

namespace HetKoudeFrietjeCafeteria.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Food.Any())
            {

                foreach (var food in new Food[]
                {
                new Food{ Name = "Patat met mayo", BasePrice = 2.0M, Description = "Korte beschrijving"},
                new Food{ Name = "Patat oorlog", BasePrice = 2.5M, Description = "Korte beschrijving"},
                new Food{ Name = "kroket", BasePrice = 1.75M, Description = "Korte beschrijving"},
                new Food{ Name = "Gehaktbal", BasePrice = 2.25M, Description = "Korte beschrijving"},
                new Food{ Name = "Gehaktbal 2", BasePrice = 2.25M, Description = "Korte beschrijving"},
                })
                {
                    context.Food.Add(food);
                }
                context.SaveChanges();
            }


            if (!context.CustomerAddress.Any())
            {

                foreach (var item in new CustomerAddress[]
                {
                new CustomerAddress{ Name="Piet", Address = "Steenslaan 24", Email = "piet@test.nl", City = "Groningen"},
                new CustomerAddress{ Name="Henk", Address = "Ruyterslaan 15", Email = "henk@test.nl", City = "Amsterdam"},
                new CustomerAddress{ Name="Kees", Address = "Hopperstraat 4", Email = "kees@test.nl", City = "Heerenveen"},
                })
                {
                    context.CustomerAddress.Add(item);
                }
                context.SaveChanges();
            }


            if (!context.Order.Any())
            {

                foreach (var item in new Order[]
                {
                    new Order{  Address = context.CustomerAddress.Where(a=>a.Name=="Piet").First(), Created = DateTimeOffset.Now.AddDays(-1), Placed = DateTimeOffset.Now.AddDays(-1), },
                    new Order{  Address = context.CustomerAddress.Where(a=>a.Name=="Henk").First(), Created = DateTimeOffset.Now.AddHours(-2), Placed = DateTimeOffset.Now, },
                    new Order{  Address = context.CustomerAddress.Where(a=>a.Name=="Kees").First(), Created = DateTimeOffset.Now.AddHours(-1), Placed = DateTimeOffset.Now.AddHours(-1), },
                })
                {
                    context.Order.Add(item);
                }
                context.SaveChanges();
            }


            if (!context.OrderItem.Any())
            {

                foreach (var item in new OrderItem[]
                {
                new OrderItem{ FoodItem =  context.Food.First() , OrderPrice = 2.1M, Quantity = 5, Order = context.Order.First()},
                new OrderItem{ FoodItem =  context.Food.Where(s=>s.Name=="Gehaktbal").First() , OrderPrice = 2.2M, Quantity = 3, Order = context.Order.Where(o=>o.OrderID==1).First()},
                new OrderItem{ FoodItem =  context.Food.Where(s=>s.Name=="Gehaktbal").First() , OrderPrice = 2.2M, Quantity = 3, Order = context.Order.Where(o=>o.OrderID==2).First()},
                new OrderItem{ FoodItem =  context.Food.Where(s=>s.Name=="kroket").First() , OrderPrice = 1M, Quantity = 3, Order = context.Order.Where(o=>o.OrderID==3).First()},
                new OrderItem{ FoodItem =  context.Food.Where(s=>s.Name=="Gehaktbal").First() , OrderPrice = 2.2M, Quantity = 3, Order = context.Order.Where(o=>o.OrderID==3).First()},
                })
                {
                    context.OrderItem.Add(item);
                }
                context.SaveChanges();
            }


        }
    }
}
