using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Models
{
    public class AddCartItemModel
    {
        public int UserId { get; set; }
        public CartItemModel CartItemModel { get; set; }
    }
}
