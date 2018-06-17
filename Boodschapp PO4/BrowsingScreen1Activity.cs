﻿using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Threading.Tasks;
using Android.Support.Transitions;

namespace Boodschapp_PO4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class BrowsingScreen1Activity : AppCompatActivity
    {
        RecyclerView                    mRecyclerView;
        RecyclerView.LayoutManager      mLayoutManager;
        BrowsingCategoryAdapter         mAdapter;
        ProductList                     mProductList;
        Button                          button;
        TextView                        ButtonGroceries;
        int                             waiter = 0;
        List<string>                    ListOfProducts = new List<string>();


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            mProductList = new ProductList();

            SetContentView(Resource.Layout.BrowsingLayout1);          
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            //if (this.Intent.Extras != null)
            //{
            //    var productlist = Intent.Extras.GetStringArray("lijst");
            //    ListOfProducts  = productlist.ToList();
            //}


            //button = FindViewById<Button>(Resource.Id.button1);
            ButtonGroceries = FindViewById<TextView>(Resource.Id.ListTextView);

            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager      = new GridLayoutManager(this, 1, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter                = new BrowsingCategoryAdapter(mProductList);
            mAdapter.ItemClick      += OnItemClick;
            //button.Click          += Button_Click;
            ButtonGroceries.Click   += TextViewGroceries_Click;
            mRecyclerView.SetAdapter(mAdapter);

        }

        async void OnItemClick(object sender, int position)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(BrowsingScreen2Activity));

                Bundle b = new Bundle();
                b.PutInt("CategoryID", (int)mProductList[position].category);
                b.PutStringArray("lijst", ListOfProducts.ToArray());
                intent.PutExtras(b);

                //Toast.MakeText(this, "This is in category " + mProductList[position].category, ToastLength.Short).Show();
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }

        }



        async void Button_Click(object sender, EventArgs e)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(GrocerylistActivity));

                //intent.PutExtra("lijst", ListOfProducts.ToArray());
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }

        async void TextViewGroceries_Click(object sender, EventArgs e)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(GrocerylistActivity));

                //intent.PutExtra("lijst", ListOfProducts.ToArray());
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }

    }
}
