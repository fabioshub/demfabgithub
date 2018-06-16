using System;
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


namespace Boodschapp_PO4
{
    [Activity(Label = "boodschapp", MainLauncher = false, Theme = "@style/AppTheme")]
    public class explainScreen : Activity
    {
        TextView Uitleg, browsescreen, list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.explainScreen);
            Uitleg = FindViewById<TextView>(Resource.Id.uitleg);
            browsescreen = FindViewById<TextView>(Resource.Id.button12);
            list = FindViewById<TextView>(Resource.Id.button22);
            browsescreen.Click += Browsescreen_Click;
            list.Click += List_Click;
        }

        void Browsescreen_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(BrowsingScreen1Activity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
        }

        void List_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(GrocerylistActivity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
        }

    }
}
