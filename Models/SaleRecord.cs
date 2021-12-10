using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class SaleRecord
    {
        [Key()]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("SellerForeignKey")]
        public int SellerForeignKey { get; set; }
        
        [Display(Name = "Vendedor")]
        public Seller Seller { get; set; }
        
        [Required]
        [Display(Name = "Data")]
        public string Date { get; set; }
        
        [Required]
        [Display(Name = "Valor")]
        public double Amount { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public SaleStatus Status { get; set; }
    }
}