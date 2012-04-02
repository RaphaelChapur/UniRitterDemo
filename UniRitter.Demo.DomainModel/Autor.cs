using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniRitter.Demo.DomainModel
{
    [Table("Autor")]
    public class Autor : IEntidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
