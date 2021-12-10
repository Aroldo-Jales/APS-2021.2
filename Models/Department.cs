using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Projeto.Models;

namespace Projeto.Models
{
    public class Department
    {
        [Key()]
        public int Id {get; set;}

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        public List<Seller> Sellers { get; set; }
    }
}