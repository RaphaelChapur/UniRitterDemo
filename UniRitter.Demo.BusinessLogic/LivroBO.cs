using System;
using UniRitter.Demo.BusinessLogic;
using UniRitter.Demo.DataAccessLogic;
using UniRitter.Demo.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace UniRitter.Demo.BusinessLogic
{
    internal class LivroBO : BusinessObject<Livro>
    {
        public LivroBO(IRepository<Livro> repo)
            : base(repo)
        {

        }

        public override Livro BuscarPorId(int id)
        {
           //var q = from Livro in Repo.Buscar("Autor", "Genero")
           //         where livro.Id == id
           //         select livro;

           // return q.SingleOrDefault();
            return null;
        }

        public override IEnumerable<Livro> BuscarTodos()
        {
            return Repo.Buscar("Autor", "Genero");
        }
    }
}




