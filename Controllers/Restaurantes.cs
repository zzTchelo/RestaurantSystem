using EdTrabahoParcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Controllers
{
    internal class Restaurantes
    {
        private List<Models.Restaurantes> restaurantes;
        public Restaurantes() {
            this.restaurantes = new List<Models.Restaurantes>();
            // Add Restaurante Chinês
            Models.Restaurantes restauranteChines = new Models.Restaurantes("Avenida Centro, 123", "Restaurante Chinês Genérico", 1, 2, 4);
            this.restaurantes.Add(restauranteChines);
            // Add Restaurante Thailandês
            Models.Restaurantes restauranteThailandes = new Models.Restaurantes("Avenida dos Burgueses, 456", "Restaurante Thailandês Genérico", 2, 1, 2);
            this.restaurantes.Add(restauranteThailandes);
            // Add Restaurante Brasileiro
            Models.Restaurantes restauranteBrasileiro = new Models.Restaurantes("Rua dos Santos, 789", "Restaurante Brasileiro Genérico", 3, 3, 5);
            this.restaurantes.Add(restauranteBrasileiro);
        }
        public List<Models.Restaurantes> getRestaurantByCategory(int category)
        {
            List<Models.Restaurantes> restaurantes = new List<Models.Restaurantes>();

            foreach (Models.Restaurantes restaurante in this.restaurantes)
            {
                if (restaurante.IdCategoria == category)
                {
                    restaurantes.Add(restaurante);
                }
            }
            restaurantes.Sort((compare1, compare2) => compare1.Id.CompareTo(compare2.Id));
            return restaurantes;
        }
        public List<int> getAllIdRestaurantByCategory(int category)
        {
            List<int> restaurantes = new List<int>();

            foreach (var restaurante in this.restaurantes)
            {
                if (restaurante.IdCategoria == category)
                {
                    restaurantes.Add(restaurante.Id);
                }
            }
            return restaurantes;
        }
        public List<Models.Restaurantes> getAllRestaurantByCategory(int category)
        {
            List<Models.Restaurantes> restaurantes = new List<Models.Restaurantes>();

            foreach (var restaurante in this.restaurantes)
            {
                if (restaurante.IdCategoria == category)
                {
                    restaurantes.Add(restaurante);
                }
            }
            return restaurantes;
        }
        public void removeRestaurantById(int restauranteId)
        {
            Models.Restaurantes restaurantToRemove = this.restaurantes.FirstOrDefault(restaurantes => restaurantes.Id == restauranteId);
            if (restaurantToRemove != null)
            {
                this.restaurantes.Remove(restaurantToRemove);
            }
        }
        public void addRestaurant(Models.Restaurantes novoRestaurante)
        {
            this.restaurantes.Add(novoRestaurante);
        }
        public void RemoveRestaurantAndAssociatedItems(int restaurantID, Controllers.Pratos controllerPratos)   
        {
            Models.Restaurantes restaurantToRemove = this.restaurantes.FirstOrDefault(restaurantes => restaurantes.Id == restaurantID);
            if (restaurantToRemove != null)
            {
                List<Models.Pratos> pratosWithCategory = controllerPratos.getPratosByRestaurant(restaurantID);
                foreach (Models.Pratos prato in pratosWithCategory)
                {
                    controllerPratos.removePrato(prato.Id);
                }
                this.restaurantes.Remove(restaurantToRemove);
                Console.WriteLine("O Restaurante foi removido com sucesso, juntamente com os pratos associados.");
            }
            else
            {
                Console.WriteLine("Restaurante não encontrada.");
            }
        }
    }
}
