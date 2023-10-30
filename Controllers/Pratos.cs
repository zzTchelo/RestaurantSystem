using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Controllers
{
    internal class Pratos
    {
        private List<Models.Pratos> pratos;
        public Pratos() {
            this.pratos = new List<Models.Pratos>();

            List<string> ingredientesFeijoada = new List<string>();
            ingredientesFeijoada.Add("Carne seca");
            ingredientesFeijoada.Add("Paio");
            ingredientesFeijoada.Add("Linguiça");
            ingredientesFeijoada.Add("Feijão");
            ingredientesFeijoada.Add("Louro");
            ingredientesFeijoada.Add("Alho");
            Models.Pratos pratoFeijoada = new Models.Pratos(
                    1, "Feijoada", 3, 3, 3, 30.0, ingredientesFeijoada
                );
            pratos.Add(pratoFeijoada);

            List<string> ingredientesChurrasco = new List<string>();
            ingredientesChurrasco.Add("Carne");
            ingredientesChurrasco.Add("Pão de Alho");
            ingredientesChurrasco.Add("Linguiça");
            ingredientesChurrasco.Add("Abacaxi");
            ingredientesChurrasco.Add("Cebola");
            ingredientesChurrasco.Add("Queijo Coalho");
            Models.Pratos pratoChurrasco = new Models.Pratos(
                    2, "Porção de churrasco completo", 3, 3, 5, 47.0, ingredientesChurrasco
                );
            pratos.Add(pratoChurrasco);
        }

        public List<Models.Pratos> getAllPratos()
        {
            return this.pratos;
        }

        public List<Models.Pratos> getPratosByRestaurantByCategory(int idRestaurant, int idCategory)
        {
            return this.pratos;
        }

    }
}
