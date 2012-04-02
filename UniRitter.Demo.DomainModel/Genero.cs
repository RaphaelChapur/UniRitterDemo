namespace UniRitter.Demo.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Table("Genero")]
    public class Genero : IEntidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
