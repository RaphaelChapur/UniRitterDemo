using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRitter.Demo.DomainModel;
using UniRitter.Demo.DataAccessLogic;

namespace UniRitter.Demo.BusinessLogic
{
    internal class LivroBO : BusinessObject<Livro>
    {
        public LivroBO(IRepository<Livro> repo)
            : base(repo)
        {
        }

        public override IEnumerable<Livro> BuscarTodos()
        {
            return Repo.Buscar("Autor", "Genero");
        }

        public override Livro BuscarPorId(int id)
        {
            // buscando o livro com o Id determinado
            var q = from livro in Repo.Buscar("Autor", "Genero")
                    where livro.Id == id
                    select livro;

            // Single or default retorna a única entrada encontrada
            // ou nulo se nada foi achado. Em caso de múltiplas entradas,
            // lança uma exceção.
            return q.SingleOrDefault();
        }
    }
}
