using System.Collections.Generic;
using pokemon.Model;

namespace pokemon.Controllers
{
    public static class CalNumberFights
    {
        private static void getPositionsList(string[] Pokefight_result, ref List<int> positions)
        {
            int pokeId = 0;
            List<int> tmpList = new List<int>();
            List<int> sortTmpList = new List<int>();
            foreach (string pokemon in Pokefight_result)
            {
                pokeId = Pokemons.getId(pokemon);
                //Falta colocar la lista con numeros consecutivos
                tmpList.Add(pokeId);
                sortTmpList.Add(pokeId);
            }
            sortTmpList.Sort();
            foreach (int i in tmpList)
            {
                //Falta colocar la lista con numeros consecutivos
                positions.Add(sortTmpList.FindIndex(x => x.Equals(i)));
            }
        }

        private static int countFights(List<int> posList)
        {
            int nuPosInLine = 0;
            int nuMoves = 0;
            int totalPokemons = posList.Count;
            foreach (int position in posList)
            {
                nuPosInLine++;
                if (position - nuPosInLine > 2)
                {
                    throw new System.ApplicationException("Result is not possible according to the rules.");
                }
                
                for (int i = nuPosInLine; i < totalPokemons; i++)
                {
                    if (position > posList[i])
                    {
                        nuMoves++;
                    }
                }
            } 
            return nuMoves;
        }

        public static int calculateFights(string[] Pokefight_result)
        {
            List<int> positionList = new List<int>();
            
            getPositionsList(Pokefight_result, ref positionList);

            return countFights(positionList);
        }
    }
}
