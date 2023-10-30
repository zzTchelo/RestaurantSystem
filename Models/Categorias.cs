using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Models
{
    internal class Categorias
    {
        private int id;
        private string nome;
        
        public Categorias()
        {
            this.id = 0;
            this.nome = string.Empty;
        }

        public Categorias(int id, string name)
        {
            this.id = id;
            this.nome = name;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

    }
}
