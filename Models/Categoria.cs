using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Models
{
    internal class Categoria
    {
        private int id;
        private string nome;
        
        public Categoria()
        {
            this.id = 0;
            this.nome = string.Empty;
        }

        public Categoria(int id, string name)
        {
            this.id = id;
            this.nome = name;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

    }
}
