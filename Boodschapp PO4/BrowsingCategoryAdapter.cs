using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Boodschapp_PO4
{
    //----------------------------------------------------------------------
    // Adapter for the categories
    //----------------------------------------------------------------------
    public class BrowsingCategoryAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int>  ItemClick;
        public ProductList              mProductList;
        int radius;


        public BrowsingCategoryAdapter(ProductList productList)
        {
            mProductList            = productList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView           = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CategoryCardView, parent, false);
            BrowsingViewHolder vh   = new BrowsingViewHolder(itemView, OnClick);
            //return vh;

            itemView.LayoutParameters.Height = parent.Height/5;
            radius = itemView.LayoutParameters.Height;

            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BrowsingViewHolder vh   = holder as BrowsingViewHolder;
            //vh.Category.Text        = mProductList[position].category.ToString();
            vh.BrowseImage.SetImageResource(mProductList[position].image);
            vh.CategoryView.Radius = radius / 2.2f;
            
           



            //vh.Group.Text         = mProductList[position].GroupName;
            //vh.Category.Typeface    = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/BubbleboddyNeue-BoldTrial.ttf");
        }

        public override int ItemCount
        {
            get { return mProductList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }
}