﻿using all_recipes1.Data.Models;
using all_recipes1.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace all_recipes1.Data.Services
{
    public class RecipesService
    { private AppDbContext _context;
        public RecipesService(AppDbContext context)
        {
            _context = context;
        }
    public void AddRecipe(RecipeVM recipe)
        {
            var _recipe = new Recipe()

            {
                Name = recipe.Name,
                Description = recipe.Description,
                IsCooked = recipe.IsCooked,
                DateCooked = recipe.IsCooked ? recipe.DateCooked.Value : null,
                Rate = recipe.IsCooked ? recipe.Rate.Value : null,
                Category = recipe.Category,
                CoverUrl = recipe.CoverUrl,
                CookingTime = recipe.CookingTime,
                DateAdded = System.DateTime.Now,
            };
            _context.Recipes.Add(_recipe);
            _context.SaveChanges();
        }
        public List<Recipe> GetAllRecipes() => _context.Recipes.ToList();
        public Recipe GetRecipeById(int recipeId) => _context.Recipes.FirstOrDefault(n => n.Id == recipeId);

        public Recipe UpdateRecipeById(int recipeId, RecipeVM recipe)
        {
            var _recipe = _context.Recipes.FirstOrDefault(n => n.Id == recipeId);
            if (_recipe != null)
            {

                _recipe.Name = recipe.Name;
                _recipe.Description = recipe.Description;
                _recipe.IsCooked = recipe.IsCooked;
                _recipe.DateCooked = recipe.IsCooked ? recipe.DateCooked.Value : null;
                _recipe.Rate = recipe.IsCooked ? recipe.Rate.Value : null;
                _recipe.Category = recipe.Category;
                _recipe.CoverUrl = recipe.CoverUrl;
                _recipe.CookingTime = recipe.CookingTime;
                _context.SaveChanges();
            }
            return _recipe;
        }

        public void DeleteRecipeById(int recipeId)
        {
            var _recipe = _context.Recipes.FirstOrDefault(n => n.Id == recipeId);
            if(_recipe != null )
            {
                _context.Recipes.Remove(_recipe);
                _context.SaveChanges();
            }
        }
    }
}
