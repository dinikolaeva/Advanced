using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public int CurrentAlcoholLevel { get => this.ingredients.Sum(i => i.Alcohol); }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!this.ingredients.Any(i => i.Name == ingredient.Name &&
                                           i.Quantity < this.Capacity &&
                                           i.Alcohol < this.MaxAlcoholLevel))
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ingredient = this.ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient == null)
            {
                return false;
            }
            else
            {
                this.ingredients.Remove(ingredient);
                return true;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredient = this.ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient == null)
            {
                return null;
            }
            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            var ingredient = this.ingredients
                                 .OrderByDescending(i => i.Alcohol)
                                 .FirstOrDefault();

            if (ingredient == null)
            {
                return null;
            }
            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
