using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Models
{
    internal class Restaurantes
    {
        private string endereco;
        private string nome;
        private int id;
        private int idCategoria;

        public Restaurantes() { 
            this.endereco = string.Empty;
            this.nome = string.Empty;
            this.id = 0;
            this.idCategoria = 0;
        }

        public Restaurantes(string endereco, string nome, int id, int idCategoria, int rating)
        {
            this.endereco = endereco;
            this.nome = nome;
            this.id = id;
            this.idCategoria = idCategoria;
        }

        public string Endereco { get => endereco; set => endereco = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    }
}
