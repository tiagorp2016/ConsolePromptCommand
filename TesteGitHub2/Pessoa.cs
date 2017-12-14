using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGitHub2
{
    public class Pessoa
    {
        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}
