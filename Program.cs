using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poe_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MenuClass
    {
        public int option;
        public void Menu() {


        Console.WriteLine();
            try { option = Convert.ToInt32(Console.ReadLine()); }
            catch { option = 0; }

            while (option != 6) {

                switch (option)
                {
                    case 0:

                    break;
                    case 1:

                    break;

                    case 2:

                    break;

                    case 3:

                    break;

                    case 4:

                    break;

                    case 5:

                    break;
                    case 6:

                    break;

                }
            
            }
        
        
        }




    }
    
    public class Recipe {
        public string Name { get; set; }
        public SortedList<int, string> Steps { get; set; }
        public ArrayList Ingredients { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Steps = new SortedList<int, string>();
            Ingredients = new ArrayList();
        }

        public void AddStep(int stepNumber, string stepDescription)
        {
            Steps.Add(stepNumber, stepDescription);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }


        public static List<string> OrderRecipeNames(List<Recipe> recipes)
        {
            List<string> sortedNames = new List<string>();

            foreach (Recipe recipe in recipes)
            {
                sortedNames.Add(recipe.Name);
            }

            sortedNames.Sort(StringComparer.OrdinalIgnoreCase);

            return sortedNames;
        }
    }



    public class Ingredient {

        public string IngredName { get; set; }
        public string IngredType { get; set; }
        public double IngredSize { get; set; }
        public int CalorieCount { get; set; }

        public Ingredient(string name, string measurementType, double amount, int calorieCount)
        {
            IngredName = name;
            IngredType = measurementType;
            IngredSize = amount;
            CalorieCount = calorieCount;
        }

    }



}
