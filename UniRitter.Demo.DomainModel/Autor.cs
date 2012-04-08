using System.ComponentModel.DataAnnotations;
namespace UniRitter.Demo.DomainModel
{
    [Table("Autor")]
    public class Autor : IEntidade
    {
        [Column("AutorId")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength=2)]
        public string Nome { get; set; }
    }
}
