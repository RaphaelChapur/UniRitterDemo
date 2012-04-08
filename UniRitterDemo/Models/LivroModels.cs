﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniRitterDemo.Models
{
    public class LivroIndexModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string GeneroNome { get; set; }

        public string AutorNome { get; set; }

        public string Fonte { get; set; }

        public string Editora { get; set; }
    }

    public class LivroEditModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string GeneroNome { get; set; }

        public string AutorNome { get; set; }

        public string Fonte { get; set; }

        public string Editora { get; set; }
    }

}