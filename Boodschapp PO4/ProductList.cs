using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Boodschapp_PO4
{
    public class Product
    {
        public ProductCategory category { get; }

        public ProductGroup group { get; }

        public string name { get; }

        public int image { get; }

        public Product(ProductCategory category = ProductCategory.Other, ProductGroup group = ProductGroup.Other, string name = "Default", int image = 0)
        {
            this.category   = category;
            this.group      = group;
            this.name       = name;
            this.image      = image;
        }
    }

    public class ProductList
    {

        private static Product[] mConfirmedProducts =
            {
            new Product( category: ProductCategory.Food,
                        group: ProductGroup.Fruits,
                        name: "Strawberries"),
            new Product( category: ProductCategory.Food,
                        group: ProductGroup.Grains,
                        name: "Bread"),
            new Product( category: ProductCategory.Food,
                        group: ProductGroup.Meat,
                        name: "Chicken"),
            new Product( category: ProductCategory.Food,
                        group: ProductGroup.Confections ),
            new Product( category: ProductCategory.Food,
                        group: ProductGroup.Vegtables ),

            new Product( category: ProductCategory.Drinks,
                        group: ProductGroup.Alcohol,
                        image: Resource.Drawable.DrinkItemsAsset),
            new Product( category: ProductCategory.Drinks,
                        group: ProductGroup.Dairy,
                        image: Resource.Drawable.DrinkItemsAsset),
            new Product( category: ProductCategory.Drinks,
                        group: ProductGroup.Caffinated,
                        image: Resource.Drawable.DrinkItemsAsset),
            new Product( category: ProductCategory.Drinks,
                        group: ProductGroup.Soda,
                        image: Resource.Drawable.DrinkItemsAsset),

            new Product( category: ProductCategory.Dishes,
                        group: ProductGroup.Pancakes,
                        image: Resource.Drawable.DishItemsAsset),
            new Product( category: ProductCategory.Dishes,
                        group: ProductGroup.Waffles,
                        image: Resource.Drawable.DishItemsAsset),
            new Product( category: ProductCategory.Dishes,
                        group: ProductGroup.Pizza,
                        image: Resource.Drawable.DishItemsAsset),
            new Product( category: ProductCategory.Dishes,
                        group: ProductGroup.Omelet,
                        image: Resource.Drawable.DishItemsAsset),

            new Product( category: ProductCategory.Nonfood,
                        group: ProductGroup.Cosmetics,
                        image: Resource.Drawable.BathroomItemsAsset),
            new Product( category: ProductCategory.Nonfood,
                        group: ProductGroup.Bathroom,
                        image: Resource.Drawable.BathroomItemsAsset),
            };


        private List<Product> mProducts;


        public ProductList()
        {
            mProducts = new List<Product>();
            mProducts.Add(new Product(ProductCategory.Food));
            int counter;

            counter = 0;

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                for (int j = 0; j < mProducts.Count; j++)
                {
                    if (mProducts[j].category != mConfirmedProducts[i].category)
                    {
                        counter += 1;
                    }

                    if (counter == mProducts.Count)
                    {
                        mProducts.Add(mConfirmedProducts[i]);
                    }
                }

                counter = 0;
            }
        }


        public ProductList(ProductCategory CategoryID)
        {
            mProducts = new List<Product>();

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                if (mConfirmedProducts[i].category == CategoryID)
                {
                    mProducts.Add(mConfirmedProducts[i]);
                }
            }
        }

        public ProductList(ProductCategory CategoryID, ProductGroup GroupID)
        {
            mProducts = new List<Product>();

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                if (mConfirmedProducts[i].group == GroupID)
                {
                    mProducts.Add(mConfirmedProducts[i]);
                }
            }
        }

        public int NumProducts
        {
            get { return mProducts.Count; }
        }

        public Product this[int i]
        {
            get { return mProducts[i]; }
        }

    }
}