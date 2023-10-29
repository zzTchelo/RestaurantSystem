using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Controllers.Categoria controllerCategoria = new Controllers.Categoria();
            Controllers.Restaurante controllerRestaurante = new Controllers.Restaurante();
            while (true)
            {
                // Ordenando Categorias
                List<Models.Categoria> categorias = controllerCategoria.getAllCategories();
                categorias.Sort((categoria1, categoria2) => categoria1.Id.CompareTo(categoria2.Id));

                Console.WriteLine("##############################################");
                Console.WriteLine("    Selecione uma das categorias a seguir:");
                Console.WriteLine("##############################################");
                Console.WriteLine("");
                categorias.ForEach(categoria =>
                    Console.WriteLine($"{categoria.Id} - {categoria.Nome}")
                );
                Console.WriteLine("");
                Console.WriteLine("98 - Remover Categoria existente");
                Console.WriteLine("99 - Adicionar nova Categoria");
                Console.WriteLine("00 - Sair");
                Console.WriteLine("");
                Console.Write("Opção: ");
                
                try
                {
                    int opcaoCategoria = int.Parse(Console.ReadLine());
                    switch (opcaoCategoria)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;

                        case 99:
                            Models.Categoria categoria = new Models.Categoria();
                            categoria.Id = Functions.Ordenacao.ProximoIDDisponivel(controllerCategoria.getAllCategoryIds());
                            Console.Write("Digite o nome da Categoria: ");
                            categoria.Nome = Functions.Formatacao.CapitalizeFirstLetter(Console.ReadLine());
                            controllerCategoria.addCategory(categoria);
                            break;

                        case 98:
                            Console.Write("Digite o ID da Categoria a ser excluída: ");
                            int id = int.Parse(Console.ReadLine());
                            controllerCategoria.removeCategoryById(id);
                            break;

                        default:
                            // Verifica se o número inserido pelo usuário corresponde a um ID de categoria.
                            Models.Categoria categoriaSelecionada = categorias.FirstOrDefault(categoria => categoria.Id == opcaoCategoria);
                            if (categoriaSelecionada != null)
                            {
                                //Filtra restaurantes pela Categoria/ Ordena Restaurantes 
                                List<Models.Restaurantes> restaurantes = controllerRestaurante.getRestaurantByCategory(categoriaSelecionada.Id);
                                restaurantes.Sort((restaurante1, restaurante2) => restaurante1.Id.CompareTo(restaurante2.Id));

                                bool isRunningRestaurantPart = true;
                                while (isRunningRestaurantPart)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Você escolheu a categoria: {categoriaSelecionada.Nome}");
                                    Console.WriteLine("Restaurantes disponíveis: ");
                                    Console.WriteLine();
                                    restaurantes.ForEach(restaurante =>
                                        Console.WriteLine($"{restaurante.Id} - {restaurante.Nome}, Rating: {restaurante.Rating}")
                                    );
                                    Console.WriteLine("");
                                    Console.WriteLine("98 - Remover Restaurante existente");
                                    Console.WriteLine("99 - Adicionar novo Restaurante");
                                    Console.WriteLine("00 - Voltar");
                                    Console.WriteLine("");
                                    Console.Write("Opção: ");

                                    int opcaoRestaurante = int.Parse(Console.ReadLine());
                                    switch(opcaoRestaurante)
                                    {
                                        case 0:
                                            isRunningRestaurantPart = false;
                                            break;

                                        case 99:
                                            // Add Codigo
                                            break;

                                        case 98:
                                            // Add Codigo
                                            break;
                                    }    
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, digite um valor válido.");
                            }
                            break;
                    }
                    ClearScreen();
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Entrada inválida. Por favor, digite valores válidos. \n -> Retornando ao Menu.");
                    ClearScreen();
                }
            }
        }

        static void ClearScreen()
        {
                Console.WriteLine("");
                Console.WriteLine("Pressione uma tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
        }
    }
}