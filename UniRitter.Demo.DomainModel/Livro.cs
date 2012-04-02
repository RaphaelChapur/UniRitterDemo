﻿using System;
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
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Fonte { get; set; }

        public int AnoPublicacao { get; set; }

        public string Editora { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Genero Genero { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
    }
}
