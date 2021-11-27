using System.Collections.Generic;

namespace Shop
{
    public class Category
    {
        public string Name { get; }

        public List<Product> Products { get; }

        public Category ParentCategory { get; }

        public List<Category> SubCategories { get; }

        public Category(string name, Category parentCategory)
        {
            Name = name;
            Products = new List<Product>();
            ParentCategory = parentCategory;
            SubCategories = new List<Category>();
            parentCategory?.SubCategories.Add(this);
        }

        public string CategoryHierarchy =>
            ParentCategory == null ? Name : $"{ParentCategory.CategoryHierarchy} > {Name}";
    }
}