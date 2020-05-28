using System;
using System.Collections;
using System.Collections.Generic;

namespace SingletonDemo
{
    //Singleton Pattern:
    //Only one intsance will be used throught application lifecycle in 1 session 

    //sealed will stop any other extension sub classes.No one can inherit Cart.
    public sealed class Cart
    {
        //properties
        public List<Item> Items { get; set; }
        public decimal AmountToPay { get; set; }

        public decimal Total { get; set; }
        /*Way2:  private decimal _total;
          public decimal Total{
              get{return _total;}
              private set{_total=getTotal();}
          }
          */


        //Implement Singleton
        static Cart cart;

        //stop from creating instance of class
        private Cart()
        {
            Items = new List<Item>();
        }

        //give only one instance when getCart called
        public static Cart getCart()
        {
            if (cart == null)//it will be null only if object is not created yet i.e. at the start of app 
            {
                cart = new Cart();
            }
            Console.WriteLine($"from getCart:Count of Items{cart.Items.Count}");
            return cart;
        }

        /*Way2:public static decimal getTotal()
        {   Cart Tcart=Cart.getCart(); 
            decimal sumtotal=0.00M;
            foreach(Item item in Tcart.Items)
            {
             sumtotal+=item.Price;
            }
            Console.WriteLine($"from getTotal:Count of Items{Tcart.Items.Count}");            
            return sumtotal;
        }*/


    }
}