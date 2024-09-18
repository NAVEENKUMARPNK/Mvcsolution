using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
   public  class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public decimal OfferPrice { get; set; }
        [Required]
        public decimal Netweight { get; set; }
        [Required]
        public DateTime Expirydate { get; set; }
        [Required]

        public DateTime Manufacturedate { get; set; }
    }
}
