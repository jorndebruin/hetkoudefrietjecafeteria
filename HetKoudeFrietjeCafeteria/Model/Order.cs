using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HetKoudeFrietjeCafeteria.Model
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderID { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Placed { get; set; }
        [Required]
        public CustomerAddress Address { get; set; }
        public ICollection<OrderItem> Items {get;set;}
    }
}
