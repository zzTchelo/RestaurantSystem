using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Controllers.Pratos controllerPrato = new Controllers.Pratos();
            Controllers.Categoria controllerCategoria = new Controllers.Categoria();
            Controllers.Restaurantes controllerRestaurante = new Controllers.Restaurantes();
            while (true)
            {
                // Ordenando Categorias
                List<Models.Categorias> categorias = controllerCategoria.getAllCategories();
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
                            Models.Categorias categoria = new Models.Categorias();
                            categoria.Id = Functions.Ordenacao.ProximoIDDisponivel(controllerCategoria.getAllCategoryIds());
                            Console.Write("Digite o nome da Categoria: ");
                            categoria.Nome = Functions.Formatacao.CapitalizeFirstLetter(Console.ReadLine());
                            controllerCategoria.addCategory(categoria);
                            break;

                        case 98:
                            Console.Write("Digite o ID da Categoria a ser excluída: ");
                            int idCategoria = int.Parse(Console.ReadLine());
                            controllerCategoria.RemoveCategoryAndAssociatedItems(idCategoria, controllerRestaurante, controllerPrato);
                            break;

                        default:
                            // Verifica se o número inserido pelo usuário corresponde a um ID de categoria.
                            Models.Categorias categoriaSelecionada = categorias.FirstOrDefault(categoria => categoria.Id == opcaoCategoria);
                            if (categoriaSelecionada != null)
                            {
                                bool isRunningRestaurantPart = true;
                                while (isRunningRestaurantPart)
                                {
                                    //Filtra restaurantes pela Categoria/ Ordena Restaurantes 
                                    List<Models.Restaurantes> restaurantes = controllerRestaurante.getRestaurantByCategory(categoriaSelecionada.Id);
                                    Console.Clear();
                                    Console.WriteLine($"Você escolheu a categoria: {categoriaSelecionada.Nome}");
                                    Console.WriteLine("Restaurantes disponíveis: ");
                                    Console.WriteLine();
                                    restaurantes.ForEach(restaurante =>
                                        Console.WriteLine($"{restaurante.Id} - {restaurante.Nome}, Rating: {restaurante.Rating} estrelas")
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
                                            Models.Restaurantes restaurante = new Models.Restaurantes();
                                            restaurante.IdCategoria = categoriaSelecionada.Id;
                                            restaurante.Id = Functions.Ordenacao.ProximoIDDisponivel(controllerRestaurante.getAllIdRestaurantByCategory(categoriaSelecionada.Id));
                                            Console.Write("Digite o nome do Restaurante: ");
                                            restaurante.Nome = Console.ReadLine();
                                            Console.Write("Digite o Endereço do Restaurante: ");
                                            restaurante.Endereco = Console.ReadLine();
                                            Console.Write("Avaliação do Restaurante (1 a 5): ");
                                            restaurante.Rating = int.Parse(Console.ReadLine());
                                            if (restaurante.Rating > 5 || restaurante.Rating < 1)
                                            {
                                                Console.WriteLine("Digite uma avaliação válida!");
                                                break;
                                            }
                                            controllerRestaurante.addRestaurant(restaurante);
                                            break;

                                        case 98:
                                            Console.Write("Digite o ID do Restaurante a ser excluída: ");
                                            int idRestaurante = int.Parse(Console.ReadLine());
                                            controllerRestaurante.RemoveRestaurantAndAssociatedItems(idRestaurante, controllerPrato);
                                            break;

                                        default:
                                            // Pratos
                                            Models.Restaurantes restaurantSelecionado = restaurantes.FirstOrDefault(restaurante => restaurante.Id == opcaoRestaurante);
                                            if (categoriaSelecionada != null)
                                            {
                                                bool isRunningPratosPart = true;
                                                while (isRunningPratosPart)
                                                {
                                                    List<Models.Pratos> pratosRestaurantes =
                                                    controllerPrato.getPratosByRestaurantByCategory(restaurantSelecionado.Id, restaurantSelecionado.IdCategoria);
                                                    Console.Clear();
                                                    Console.WriteLine($"Você escolheu o restaurante: {restaurantSelecionado.Nome}");
                                                    Console.WriteLine("Pratos disponíveis: ");
                                                    Console.WriteLine();
                                                    pratosRestaurantes.ForEach(pratos =>
                                                    {
                                                        Console.WriteLine($"{pratos.Id} - {pratos.Nome}, R$ {pratos.Valor:N2}, Rating: {pratos.Rating} estrelas");
                                                        Console.WriteLine($"Ingredientes: {string.Join(", ", pratos.Ingredientes)}");
                                                        Console.WriteLine();
                                                    });
                                                    Console.WriteLine("98 - Remover prato existente");
                                                    Console.WriteLine("99 - Adicionar novo prato");
                                                    Console.WriteLine("00 - Voltar");
                                                    Console.WriteLine("");
                                                    Console.Write("Opção: ");

                                                    int opcaoPrato = int.Parse(Console.ReadLine());
                                                    switch (opcaoPrato)
                                                    {
                                                        case 0:
                                                            isRunningPratosPart = false;
                                                            break;

                                                        case 99:
                                                            Models.Pratos prato = new Models.Pratos();
                                                            prato.Id = Functions.Ordenacao.ProximoIDDisponivel(
                                                                controllerPrato.getAllIdPratosByRestaurantByCategory(restaurantSelecionado.Id, restaurantSelecionado.IdCategoria));
                                                            prato.IdRestaurant = restaurantSelecionado.Id;
                                                            prato.IdCategory = restaurantSelecionado.IdCategoria;
                                                            Console.Write("Digite o nome do prato: ");
                                                            prato.Nome = Console.ReadLine();
                                                            Console.WriteLine("Digite os ingredientes (digite 'XD' para finalizar): ");
                                                            string ingredientes;
                                                            do
                                                            {
                                                                ingredientes = Console.ReadLine();
                                                                if (ingredientes != "XD")
                                                                {
                                                                    prato.Ingredientes.Add(ingredientes);
                                                                }
                                                            } while (ingredientes != "XD");
                                                            controllerPrato.addPrato(prato);
                                                            break;

                                                        case 98:
                                                            Console.Write("Digite o ID do prato que deseja remover: ");
                                                            int idPrato = int.Parse(Console.ReadLine());
                                                            controllerPrato.removePrato(idPrato);
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
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, digite um valor válido.");
                            }
                            break;
                    }
                    // Ver melhor forma de clocar o clearscreen
                    Console.Clear();
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