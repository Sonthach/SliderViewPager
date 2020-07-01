using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SlidePicture
{
    class SliderPictureAdapter : PagerAdapter
    {
        Context context;
        List<Picture> pictures;
        private LayoutInflater inflater;
        private int custom_position = 0;
        private int MAX_VALUE = Integer.MaxValue;
        public SliderPictureAdapter(Context context,List<Picture>pictures)
        {
            this.context = context;
            this.pictures = pictures;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count => MAX_VALUE;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return (view == (LinearLayout)@object);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            if (custom_position > 4)
            {
                custom_position = 0;
            }
            Picture picture = pictures[custom_position];
            custom_position++;
            View view = inflater.Inflate(Resource.Layout.swipe_layout, container, false);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView);
            imageView.SetImageResource(picture.image);
            container.AddView(view);
            return view;
        }
        
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((LinearLayout)@object);
        }
    }
}