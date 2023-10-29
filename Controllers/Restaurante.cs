using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Controllers
{
    internal class Restaurante
    {
        private List<Models.Restaurantes> restaurantes;
        public Restaurante() {
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

            foreach (var restaurante in this.restaurantes)
            {
                if (restaurante.IdCategoria == category)
                {
                    restaurantes.Add(restaurante);
                }
            }
            return restaurantes;
        }

        public void removeRestaurantById(int id)
        {

        }

        public void addRestaurant(Models.Restaurantes restaurante)
        {

        }

    }
}
