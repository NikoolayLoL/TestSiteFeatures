namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category()
            {
                CategoryID = 1, Name = "BMW", Description = "Car"
            },
            new Category()
            {
                CategoryID = 2, Name = "Mercedes", Description = "Car"
            },
            new Category()
            { 
                CategoryID = 3, Name = "Range Rover", Description = "Suv"
            }
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(c => c.CategoryID);
            category.CategoryID = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryByID(int categotyId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryID == categotyId);
            if (category != null)
            {
                return new Category
                {
                    CategoryID = category.CategoryID,
                    Name = category.Name,
                    Description = category.Description
                };
            }

            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryID)
            {
                return;
            }

            var categoryToUpdate = GetCategoryByID(categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name= category.Name;
                categoryToUpdate.Description= category.Description;
            }
        }

        public static void DeleteCateforyById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
