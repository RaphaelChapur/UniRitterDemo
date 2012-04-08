using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UniRitter.Demo.DomainModel
{
    [Table("Livro")]
    public class Livro : IEntidade
    {
        [Column("LivroId")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength=1)]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Fonte { get; set; }

        public int AnoPublicacao { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Editora { get; set; }

        public Autor Autor { get; set; }

        public Genero Genero { get; set; }
    }
}
