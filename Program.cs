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
            MenuClass useMC = new MenuClass();

            useMC.Menu();
        }
    }

    public class MenuClass
    {
          public int option;
       
        public void Menu() {
            RecipeClassUser useRC = new RecipeClassUser();

            useRC.factorBy = 1;
        Console.WriteLine("(1) Enter a recipe\n(2) Search a recipe\n(3) Scale the recipe\n(4) Return Recipe to original Scale\n(5) Print Recipe\n(6) Clear Recipes\n(7)Exit");
            try { option = Convert.ToInt32(Console.ReadLine()); }
            catch { option = 0; }

            while (option != 7) {

                switch (option)
                {

                    //Enter a new Recipe
                    case 1:
                        useRC.addRecipe();
                    break;
                    
                    //Search For Recipe
                    case 2:
                        useRC.searchRecipe();
                    break;

                    //Scale Recipe
                    case 3:
                        double scaleFactor = 22;//not within parameters so while loop would run
                        while (scaleFactor != 0.5 && scaleFactor != 2 && scaleFactor != 3)
                        {
                            try
                            {
                                Console.WriteLine("Would you like the recipe scaled by a factor of 0.5, 2, or 3?");
                                scaleFactor = Convert.ToDouble(Console.ReadLine());
                            }
                            catch
                            {
                                scaleFactor = 0;
                            }
                        }
                        useRC.factorBy *= scaleFactor;
                    break;

                    //UnScale A Recipe
                    case 4:
                        useRC.factorBy = 1;
                    break;
                    
                    //Print Recipes
                    case 5:
                        useRC.printAllRecipes();
                    break;
                    
                    //Clear Arrays
                    case 6:
                        useRC.clearData();
                        Console.WriteLine("Data has been cleared from the arrays");
                    break;
                    
                    //ExitApplication
                    case 7:
                        Console.WriteLine("Thank you for using the application");
                    break;
                }
            
            }
        
        
        }




    }

    public class RecipeClassUser {
        private List<Recipe> recipesList;
        public double factorBy { get;set; }
        public RecipeClassUser(){
            recipesList = new List<Recipe>();
        }
    
        public void clearData()
        {

            recipesList.Clear();
        }

        public void addRecipe()
        {
            String stepsDesp;
            int stepNum = 0;
            int ingredientNum = 0;
            String name = null;
            Recipe recipe = new Recipe();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Enter the name of the recipe");
                name = Console.ReadLine();
            }

            recipe.Name = name;

            while (ingredientNum <= 0)
            {
                Console.WriteLine("Enter the number of Ingredients");
                try { ingredientNum = Convert.ToInt32(Console.ReadLine()); }
                catch { ingredientNum = 0; }
            }



            //adding ingredients
            for (int i = 0; i < ingredientNum; i++) {


                String Ingredname = "";
                String measurementType = "";
                double amount = 0;
                int calorieCount = 0;
                String foodGroup = "";

                Ingredient newIngredient = new Ingredient();

                while (Ingredname.Equals("") == true)
                {
                    Console.WriteLine("Enter the name of your ingredient please: ");
                    Ingredname = Console.ReadLine();
                }


                while (measurementType.Equals("") == true)
                {
                    Console.WriteLine("Enter the type of ingredient please: ");
                    measurementType = Console.ReadLine();
                }

                while (amount == 0)
                {
                    try
                    {
                        Console.WriteLine("Amount: ");
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
                    catch
                    {
                        calorieCount = 0;
                    }
                }

                while (foodGroup.Equals("") == true)
                {
                    Console.WriteLine("Enter the type of food group your ingredient belongs to please: ");
                    foodGroup = Console.ReadLine();
                }

                newIngredient.IngredName = name;
                newIngredient.IngredType = measurementType;
                newIngredient.IngredSize = amount;
                newIngredient.CalorieCount = calorieCount;
                newIngredient.FoodGroup = foodGroup;

                recipe.Ingredients.Add(newIngredient);

                Console.WriteLine("New ingredient added");

            }

            while (stepNum <= 0)
            {
                Console.WriteLine("Enter the number of steps:");
                try { stepNum = Convert.ToInt32(Console.ReadLine()); }
                catch { stepNum = 0; }
            }

            for(int i = 0; i < stepNum; i++)
            {

                stepNum++;
                Console.WriteLine("Enter the description of step " + stepNum);
                stepsDesp = Console.ReadLine();

                while (stepsDesp.Equals("") == true)
                {
                    Console.WriteLine("Enter the description of step " + stepNum);
                    stepsDesp = Console.ReadLine();
                }

                recipe.AddStep(i, stepsDesp);
                
            }

        }
        

        

        public void searchRecipe() {
            String searchname = "";
            Recipe.OrderRecipeNames(recipesList);
           

            while (searchname.Equals("")) { 
            Console.WriteLine("Enter the name of the recipe you want to search ");
            searchname = Console.ReadLine(); }



            Recipe recipe = recipesList.Find(r => r.Name.Equals(searchname, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("________________________________________________________________________________");
            Console.WriteLine("Recipe name:" + recipe.Name);
            Console.WriteLine("Ingredients:");

           

            foreach (Ingredient ingredient in recipe.Ingredients) {
                Console.WriteLine("Name of Ingredient:" + ingredient.IngredName);
                Console.WriteLine("Amount of ingredient :" + (factorBy*ingredient.IngredSize) + " " + ingredient.IngredType);
                Console.WriteLine("Calorie Count:" + ingredient.CalorieCount);
                Console.WriteLine("Name of Ingredient:" + ingredient.FoodGroup);


            }

            ICollection stepNum = recipe.Steps;

            foreach (String steps in recipe.Steps) {

                Console.WriteLine(stepNum + ": " + steps);
            }
          
        }

        public void printAllRecipes() { 
        
        foreach (Recipe recipe in recipesList) {

                Console.WriteLine("________________________________________________________________________________");
                Console.WriteLine("Recipe name:" + recipe.Name);
                Console.WriteLine("Ingredients:");

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine("Name of Ingredient:" + ingredient.IngredName);
                    Console.WriteLine("Amount of ingredient :" + (factorBy * ingredient.IngredSize) + " " + ingredient.IngredType);
                    Console.WriteLine("Calorie Count:" + ingredient.CalorieCount);
                    Console.WriteLine("Name of Ingredient:" + ingredient.FoodGroup);


                }

                ICollection stepNum = recipe.Steps;

                foreach (String steps in recipe.Steps)
                {

                    Console.WriteLine(stepNum + ": " + steps);
                }





            }
        
        }

    
    }


    public class Recipe {
        public string Name { get; set; }
        public SortedList<int, string> Steps { get; set; }
        public List<Ingredient> Ingredients { get; set; }


        public void AddStep(int stepNumber, string stepDescription)
        {
            Steps.Add(stepNumber, stepDescription);
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
        
        public string FoodGroup { get; set; }
       




    }



}
