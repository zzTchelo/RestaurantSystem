using EdTrabahoParcial2.Models;
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

            List<string> ingredientesBolinhoArroz = new List<string>();
            ingredientesBolinhoArroz.Add("Arroz");
            ingredientesBolinhoArroz.Add("Leite");
            ingredientesBolinhoArroz.Add("Farinha de Trigo");
            ingredientesBolinhoArroz.Add("Ovo");
            ingredientesBolinhoArroz.Add("Queijo");
            ingredientesBolinhoArroz.Add("Temperos verdes");
            Models.Pratos pratoBolinhoArroz = new Models.Pratos(
                    3, "Bolinho de Arroz", 2, 1, 4, 15.0, ingredientesBolinhoArroz
                );
            pratos.Add(pratoBolinhoArroz);
        }
        public List<int> getAllIdPratosByRestaurantByCategory(int idRestaurant, int idCategory)
        {
            List<int> ids = new List<int>();
            foreach (Models.Pratos prato in this.pratos)
            {
                if (prato.IdRestaurant == idRestaurant && prato.IdCategory == idCategory)
                {
                    ids.Add(prato.Id);
                }
            }
            return ids;
        }
        public List<Models.Pratos> getPratosByRestaurantByCategory(int idRestaurant, int idCategory)
        {
            List<Models.Pratos> pratos = new List<Models.Pratos>();
            foreach (Models.Pratos prato in this.pratos)
            {
                if (prato.IdRestaurant == idRestaurant && prato.IdCategory == idCategory)
                {
                    pratos.Add(prato);
                }
            }
            pratos.Sort((compare1, compare2) => compare1.Id.CompareTo(compare2.Id));
            return pratos;
        }
        public List<Models.Pratos> getPratosByCategory(int idCategory)
        {
            List<Models.Pratos> pratos = new List<Models.Pratos>();
            foreach (Models.Pratos prato in this.pratos)
            {
                if (prato.IdCategory == idCategory)
                {
                    pratos.Add(prato);
                }
            }
            pratos.Sort((compare1, compare2) => compare1.Id.CompareTo(compare2.Id));
            return pratos;
        }
        public List<Models.Pratos> getPratosByRestaurant(int idCategory)
        {
            List<Models.Pratos> pratos = new List<Models.Pratos>();
            foreach (Models.Pratos prato in this.pratos)
            {
                if (prato.IdCategory == idCategory)
                {
                    pratos.Add(prato);
                }
            }
            pratos.Sort((compare1, compare2) => compare1.Id.CompareTo(compare2.Id));
            return pratos;
        }
        public List<Models.Pratos> getPratosOrdenedByRating(int opcaoOrdenacao)
        {
            List<Models.Pratos> pratos = this.pratos;
            if (opcaoOrdenacao == 1)
                pratos.Sort((prato1, prato2) => prato1.Id.CompareTo(prato2.Id));
            else if (opcaoOrdenacao == 2)
                pratos.Sort((prato1, prato2) => prato2.Id.CompareTo(prato1.Id));

            return pratos;
        }
        public void addPrato(Models.Pratos novoPrato)
        {
            this.pratos.Add(novoPrato);
        }
        public void removePrato(int idPrato)
        {
            Models.Pratos pratoToRemove = this.pratos.FirstOrDefault(prato => prato.Id == idPrato);
            if (pratoToRemove != null)
            {
                this.pratos.Remove(pratoToRemove);
            }
        }
    }
}