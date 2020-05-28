using System.Collections.Generic;

namespace SingletonDemo
{
    //try to add items in cart
    public class ManageCart2
    {
       public static void AddmoreItems()
       {
           //get cart instance
           Cart cart3=Cart.getCart();
           cart3.Items.Add(new Item(){Name="Plain Yogurt",Price=3.00M});
       }
    }
}