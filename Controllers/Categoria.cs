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
        private List<Models.Categorias> categorias;

        public Categoria()
        {
            this.categorias = new List<Models.Categorias>();
            // Dor no coração por fazer isso
            // Add Catregoria padrão (Thailandesa)
            Models.Categorias thailandesa = new Models.Categorias(1, "Thailandesa");
            this.addCategory(thailandesa);
            // Add Catregoria padrão (Chinesa)
            Models.Categorias chinesa = new Models.Categorias(2, "Chinesa");
            this.addCategory(chinesa);
            // Add Catregoria padrão (Brasileira)
            Models.Categorias brasileira = new Models.Categorias(3, "Brasileira");
            this.addCategory(brasileira);
        }

        public List<Models.Categorias> getAllCategories()
        {
            this.categorias.Sort((categoria1, categoria2) => categoria1.Id.CompareTo(categoria2.Id));
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

        public void addCategory(Models.Categorias novaCategoria)
        {
            //Models.Categoria categoria = new Models.Categoria();
            //categoria.Id = novaCategoria.Id;
            //categoria.Nome = novaCategoria.Nome;
            this.categorias.Add(novaCategoria);
        }

        public void removeCategoryById(int categoryId)
        {
            Models.Categorias categoriaToRemove = this.categorias.FirstOrDefault(categoria => categoria.Id == categoryId);
            if (categoriaToRemove != null)
            {
                this.categorias.Remove(categoriaToRemove);
            }
        }

    }
}
