using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HetKoudeFrietjeCafeteria.Model
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal BasePrice { get; set; }
    }
}
