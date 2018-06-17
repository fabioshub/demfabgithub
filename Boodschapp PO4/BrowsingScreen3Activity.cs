﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Boodschapp_PO4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class BrowsingScreen3Activity : AppCompatActivity
    {
        RecyclerView                mRecyclerView;
        RecyclerView.LayoutManager  mLayoutManager;
        BrowsingProductAdapter      mAdapter;
        ProductList                 mProductList;
        Button                      button;
        Button                      AddButton;
        ProductCategory             CategoryID;
        ProductGroup                GroupID;
        int                         waiter = 0;
        List<string>                ListOfProducts  = new List<string>();
        List<string>                ClickedProducts = new List<string>();


        string fullPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
             "Grocerylist.txt");
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate           (bundle);
            SetContentView          (Resource.Layout.BrowsingLayout2);
            mRecyclerView           = FindViewById<RecyclerView>(Resource.Id.ThirdActivityRecycler);



            if (this.Intent.Extras != null)
            {
                var category        = (ProductCategory)Intent.Extras.GetInt("CategoryID");
                var group           = (ProductGroup)Intent.Extras.GetInt("GroupID");
                //var productlist     = Intent.Extras.GetStringArray("lijst");

                CategoryID          = category;
                GroupID             = group;
                //ListOfProducts      = productlist.ToList();
            }

            mProductList    = new ProductList(CategoryID, GroupID);

            button          = FindViewById<Button>(Resource.Id.ListButton);
            AddButton       = FindViewById<Button>(Resource.Id.addbutton);


            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up
            //----------------------------------------------------------------------------------------

            mLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);


            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            //----------------------------------------------------------------------------------------

            mAdapter = new BrowsingProductAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;

            button.Click    += Button_Click;
            AddButton.Click += OnItemAdd;

            mRecyclerView.SetAdapter(mAdapter);

            //----------------------------------------------------------------------------------------
            // Try and catch Set-up
            //----------------------------------------------------------------------------------------

            try
            {
                var storedjson1 = File.ReadAllText(fullPath);
                var newinstance1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(storedjson1);
                if (newinstance1.Any())
                {
                    foreach (var v in newinstance1)
                    {
                        Console.WriteLine(v);
                        ListOfProducts.Add(v);
                    }
                    Console.WriteLine(ListOfProducts);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("error: empty list" + e);
                //Toast.MakeText(this,  "exeption", ToastLength.Short).Show();

            }

        }

        void OnItemClick(object sender, int position)
        {
            int Counter;
            Counter = 0;
            


            for(int i = 0; i < ClickedProducts.Count; i++)
            {
                if (ClickedProducts[i] != mProductList[position].name.ToString())
                {
                    Counter += 1;
                }
            }

            if(Counter == ClickedProducts.Count)
            {
                ClickedProducts.Add(mProductList[position].name.ToString());
                //Toast.MakeText(this, mProductList[position].name + " selected", ToastLength.Short).Show();
            }
            else
            {
                ClickedProducts.Remove(mProductList[position].name.ToString());
                //Toast.MakeText(this, mProductList[position].name + " deselected", ToastLength.Short).Show();
            }

            Counter = 0;
            
        }


        void OnItemAdd(object sender, EventArgs e)
        {
            for (int i = 0; i < ClickedProducts.Count; i++)
            {
                ListOfProducts.Add(ClickedProducts[i]);
            }
            string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(ListOfProducts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fullPath, jsonoutput);
        }


        async void Button_Click(object sender, EventArgs e)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(GrocerylistActivity));

                intent.PutExtra("lijst", ListOfProducts.ToArray());
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }
    }
}