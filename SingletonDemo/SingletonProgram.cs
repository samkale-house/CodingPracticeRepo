using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Singleton Pattern demo: got the instance of Cart in different classes
/// tried to add products to cart from different classes
/// Still the list at the end shows all products
/// </summary>
/// Product:Dove Bar Price:2.25
/// Product:Cane Sugar Price:3.25
/// Product:Canola Food Oil Price:4.25
/// Product:SpiderMan kite Price:9.99
/// Product:Plain Yogurt Price:3.00
/// Total:22.74

///faults in Singleton:If Cart cart3=null; and Cart.getCart() will create one new object.previous object for GC. 

namespace SingletonDemo
{
    class SingletonProgram
    {
        static void Main(string[] args)
        {
            //always done 1st and only ones..if repeated again,behaviour of cart won't affect
            //it's like services.AddSingleton(<Cart>)
            Cart cart1 = Cart.getCart();


            //add items to cart
            cart1.Items.Add(new Item() { Name = "Dove Bar", Price = 2.25M });
            cart1.Items.Add(new Item() { Name = "Cane Sugar", Price = 3.25M });
            cart1.Items.Add(new Item() { Name = "Canola Food Oil", Price = 4.25M });

            //add from another class
            ManageCart1.AddmoreItems();

            //add from another class
            ManageCart2.AddmoreItems();

            //print results
            foreach (Item item in cart1.Items)
            {
                Console.WriteLine($"Product:{item.Name} Price:{item.Price}");
            }
            //Way2: Console.WriteLine("way2 total:"+cart1.Total);
            Console.WriteLine("Total:" + getTotal());

            
        }

        private static decimal getTotal()
        {
            Cart Tcart = Cart.getCart();
            decimal sumtotal = 0.00M;
            foreach (Item item in Tcart.Items)
            {
                sumtotal += item.Price;
            }
            Console.WriteLine($"from getTotal:Count of Items{Tcart.Items.Count}");
            return sumtotal;
        }



    }

}
