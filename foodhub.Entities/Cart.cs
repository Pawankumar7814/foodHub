using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodhub.Entities
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<CartItem> Items { get; private set; }
        public bool IsActive { get; set; }
    }
}
