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

        public SortedList<int, String> Recipe;
        public int option;
        int ingredientNum;

        public void Menu() {


        Console.WriteLine();
            try { option = Convert.ToInt32(Console.ReadLine()); }
            catch { option = 0; }

            while (option != 6) {

                switch (option)
                {

                    //Enter a new Recipe
                    case 1:





                        Console.WriteLine("Enter the number of Ingredients");
                        try { ingredientNum = Convert.ToInt32(Console.ReadLine()); }
                        catch { ingredientNum = 0; }
                        while (ingredientNum <= 0)
                        {
                            Console.WriteLine("Enter the number of Ingredients");
                            try { ingredientNum = Convert.ToInt32(Console.ReadLine()); }
                            catch { ingredientNum = 0; }
                        }


                        break;
                    
                    //Search For Recipe
                    case 2:

                    break;

                    //Scale Recipe
                    case 3:

                    break;

                    //UnScale A Recipe
                    case 4:

                    break;
                    
                    //Print Recipes
                    case 5:

                    break;
                    
                    //Exit Application
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

        public void AddIngredient()
        {
            double amount = 0;
            int calorieCount = 0;

            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            while (name.Equals("") == true)
            {
                Console.WriteLine("Enter the name of your ingredient again please: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Measurement Type: ");
            string measurementType = Console.ReadLine();

            while (measurementType.Equals("") == true)
            {
                Console.WriteLine("Enter the type of ingredient again please: ");
                measurementType = Console.ReadLine();
            }

            while (amount == 0)
            {
                try { Console.WriteLine("Amount: ");
                    amount = double.Parse(Console.ReadLine());
                }
                catch { amount = 0; }
            }

            while (calorieCount == 0)
            {
                try
                {
                    Console.WriteLine("Calorie Count: ");
                    calorieCount = int.Parse(Console.ReadLine());
                }
                catch {
                    calorieCount = 0;
                }
            }

            Ingredient newIngredient = new Ingredient(name, measurementType, amount, calorieCount);
            Ingredients.Add(newIngredient);

            Console.WriteLine("New ingredient added");
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
