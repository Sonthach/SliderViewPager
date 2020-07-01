using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.View;
using System.Collections.Generic;
using Java.Lang;
using Android.Support.V4.Content;
using Android.Views;

namespace SlidePicture
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ViewPager.IOnPageChangeListener
    {
        private ViewPager viewPager;
        private SliderPictureAdapter adapter;
        private System.Timers.Timer timer;
        private List<Picture> pictures = new List<Picture>();
        private int current_position = 0;
        private LinearLayout dotsLayout;
        private int custom_position = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            dotsLayout = FindViewById<LinearLayout>(Resource.Id.dotsContainer); 
            pictures.Add(new Picture(Resource.Drawable.p0));
            pictures.Add(new Picture(Resource.Drawable.p3));
            pictures.Add(new Picture(Resource.Drawable.p4));
            pictures.Add(new Picture(Resource.Drawable.p5));
            pictures.Add(new Picture(Resource.Drawable.p8));
            adapter = new SliderPictureAdapter(this,pictures);
            viewPager.Adapter = adapter;
            PrepareDots(custom_position++);
            CreateSlideShow();

            viewPager.AddOnPageChangeListener(this);
        }

        void CreateSlideShow()
        {
            Handler handle = new Handler();
            Runnable runnable = new Runnable(() =>
            {
                if(current_position==Integer.MaxValue)
                {
                    current_position = 0;
                }
                else
                {
                    viewPager.SetCurrentItem(current_position++, true);
                }
            });

            timer = new System.Timers.Timer();
            timer.Interval = 1500;
            timer.Enabled = true;
            timer.Elapsed += (s, e) =>
            {
                RunOnUiThread(() =>
                {
                    handle.Post(runnable);
                });
            };
        }

        void PrepareDots(int currentSlidePosition)
        {
            if(dotsLayout.ChildCount > 0)
            {
                dotsLayout.RemoveAllViews();
            }

            ImageView[] dots = new ImageView[5];

            for(int i = 0; i < 5; i++)
            {
                dots[i] = new ImageView(this);
                if(i == currentSlidePosition)
                {
                    dots[i].SetImageDrawable(ContextCompat.GetDrawable(this, Resource.Drawable.active_dot));
                }
                else
                {
                    dots[i].SetImageDrawable(ContextCompat.GetDrawable(this, Resource.Drawable.inactive_dot));
                }

                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                layoutParams.SetMargins(4, 0, 4, 0);
                dotsLayout.AddView(dots[i], layoutParams);
            }
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageSelected(int position)
        {
            if(custom_position > 4)
            {
                custom_position = 0;
            }
            else
            {
                PrepareDots(custom_position++);
            }
        }
    }
}