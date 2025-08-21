using System;
using System.ComponentModel.DataAnnotations;

namespace BrinquedosAPI.Models
{
    public class Brinquedo
    {
        [Key]
        public int Id_brinquedo { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome_brinquedo { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Tipo_brinquedo { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Classificacao { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Tamanho { get; set; }
        
        [Required]
        public decimal Preco { get; set; }
    }
}