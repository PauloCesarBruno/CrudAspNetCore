using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspCore.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public String Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Required]
        [Range(1, 99999.99)] // Valor Mínimo ao Máximo
        [DataType(DataType.Currency)]
        [Display(Name = "Credito")]
        public Decimal Credito { get; set; }
    }
}
