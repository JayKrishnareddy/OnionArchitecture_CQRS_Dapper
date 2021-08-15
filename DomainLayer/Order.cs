using System;

namespace DomainLayer
{
   public class Order
    {
       public int OrderId { get; set;}
       public string OrderDetails { get; set; }
       public bool IsActive { get; set; }
       public DateTime OrderedDate { get; set; }
    }
}
