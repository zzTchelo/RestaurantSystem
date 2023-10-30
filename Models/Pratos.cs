using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Models
{
    internal class Pratos
    {
        private string nome;
        private int idCategory;
        private int idRestaurant;
        private double valor;
        private List<string> ingredientes;
        private int rating;
        public Pratos() {
            this.Nome = string.Empty;
            this.IdCategory = 0;
            this.IdRestaurant = 0;
            this.Rating = 0;
            this.Valor = 0;
            this.Ingredientes = new List<string>().ToArray();
        }
        public Pratos(string nome, int idCategory, int idRestaurant, int rating, double valor, List<string> ingredientes)
        {
            this.Nome = nome;
            this.IdCategory = idCategory;
            this.IdRestaurant = idRestaurant;
            this.Rating = rating;
            this.Valor = valor;
            this.Ingredientes = ingredientes.ToArray();
        }

        public string Nome { get => nome; set => nome = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdRestaurant { get => idRestaurant; set => idRestaurant = value; }
        public double Valor { get => valor; set => valor = value; }
        public string[] Ingredientes { get; }
        public int Rating { get => rating; set => rating = value; }
    }
}
