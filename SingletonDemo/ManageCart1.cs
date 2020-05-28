using System.Collections.Generic;

namespace SingletonDemo
{
    public class ManageCart1
    {
      public static void AddmoreItems()
      { 
          //try to create one more object of cart
          Cart cart2=Cart.getCart();

          cart2.Items.Add(new Item(){Name="SpiderMan kite",Price=9.99M});
      }
    }
}