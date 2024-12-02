using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
    }
}
