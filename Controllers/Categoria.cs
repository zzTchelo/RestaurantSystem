using EdTrabahoParcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Controllers
{
    internal class Categoria
    {
        private List<Models.Categoria> categorias;

        public Categoria()
        {
            this.categorias = new List<Models.Categoria>();
            // Dor no coração por fazer isso
            // Add Catregoria padrão (Thailandesa)
            Models.Categoria thailandesa = new Models.Categoria(1, "Thailandesa");
            this.addCategory(thailandesa);
            // Add Catregoria padrão (Chinesa)
            Models.Categoria chinesa = new Models.Categoria(2, "Chinesa");
            this.addCategory(chinesa);
            // Add Catregoria padrão (Brasileira)
            Models.Categoria brasileira = new Models.Categoria(3, "Brasileira");
            this.addCategory(brasileira);
        }

        public List<Models.Categoria> getAllCategories()
        {
            return this.categorias;
        }

        public List<int> getAllCategoryIds()
        {
            List<int> categoryIds = new List<int>();
            foreach (var categoria in this.categorias)
            {
                categoryIds.Add(categoria.Id);
            }
            return categoryIds;
        }

        public void addCategory(Models.Categoria novaCategoria)
        {
            Models.Categoria categoria = new Models.Categoria();
            categoria.Id = novaCategoria.Id;
            categoria.Nome = novaCategoria.Nome;
            this.categorias.Add(categoria);
        }

        public void removeCategoryById(int categoryId)
        {

            Models.Categoria categoriaToRemove = this.categorias.FirstOrDefault(categoria => categoria.Id == categoryId);

            if (categoriaToRemove != null)
            {
                this.categorias.Remove(categoriaToRemove);
            }
        }

    }
}
