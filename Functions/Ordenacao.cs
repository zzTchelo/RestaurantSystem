using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTrabahoParcial2.Functions
{
    internal class Ordenacao
    {
        public static int ProximoIDDisponivel(List<int> listaIDs)
        {
            if (listaIDs == null || listaIDs.Count == 0)
            {
                // Se a lista de IDs estiver vazia, retorne 1 como o próximo ID disponível.
                return 1;
            }

            listaIDs.Sort(); // Classifica a lista em ordem crescente.

            int proximoID = 1; // Comece com 1 como próximo ID disponível.

            foreach (int id in listaIDs)
            {
                if (id == proximoID)
                {
                    // Se o ID atual for igual ao próximo ID esperado, incremente o próximo ID.
                    proximoID++;
                }
                else if (id > proximoID)
                {
                    // Se o ID atual for maior que o próximo ID esperado, encontramos uma lacuna.
                    // O próximo ID disponível é a lacuna encontrada.
                    break;
                }
            }

            return proximoID;
        }
    }
}
