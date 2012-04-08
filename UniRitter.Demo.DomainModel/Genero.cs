using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UniRitter.Demo.DomainModel
{
    [Table("Genero")]
    public class Genero : IEntidade
    {
        [Key]
        [Column("GeneroId")]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength=4)]
        public string Nome { get; set; }
    }
}
