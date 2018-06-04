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
    // Adapter for the actual products
    //----------------------------------------------------------------------
    public class BrowsingProductAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int>  ItemClick;
        public ProductList              mProductList;


        public BrowsingProductAdapter(ProductList productlist)
        {
            mProductList            = productlist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView           = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ProductCardView, parent, false);
            BrowsingViewHolder vh   = new BrowsingViewHolder(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BrowsingViewHolder vh   = holder as BrowsingViewHolder;
            //vh.Category.Text      = mProductList[position].category.ToString();
            //vh.Group.Text         = mProductList[position].group.ToString();
            vh.Name.Text            = mProductList[position].name.ToString();
            vh.Name.Typeface        = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/BubbleboddyNeue-BoldTrial.ttf");
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