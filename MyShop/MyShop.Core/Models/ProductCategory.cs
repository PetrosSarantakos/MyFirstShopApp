using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductCategory:BaseEntity
    {
        [DisplayName("Category")]
        public string Category { get; set; }
    }
}
