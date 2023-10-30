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
        private int id;
        private string nome;
        private int idCategory;
        private int idRestaurant;
        private double valor;
        private List<string> ingredientes;
        private int rating;
        public Pratos() {
            this.id = 0;
            this.Nome = string.Empty;
            this.IdCategory = 0;
            this.IdRestaurant = 0;
            this.Rating = 0;
            this.Valor = 0;
            this.ingredientes = new List<string>();
        }
        public Pratos(int id, string nome, int idCategory, int idRestaurant, int rating, double valor, List<string> ingredientes)
        {
            this.id = id;
            this.Nome = nome;
            this.IdCategory = idCategory;
            this.IdRestaurant = idRestaurant;
            this.Rating = rating;
            this.Valor = valor;
            this.ingredientes= this.ingredientes = new List<string>(ingredientes);
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdRestaurant { get => idRestaurant; set => idRestaurant = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Rating { get => rating; set => rating = value; }
        public List<string> Ingredientes { get => ingredientes; set => ingredientes = value; }
    }
}
