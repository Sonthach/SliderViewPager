package crc642044eea4c3980544;


public class MainActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.OnPageChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onPageScrollStateChanged:(I)V:GetOnPageScrollStateChanged_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.ViewPager\n" +
			"n_onPageScrolled:(IFI)V:GetOnPageScrolled_IFIHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.ViewPager\n" +
			"n_onPageSelected:(I)V:GetOnPageSelected_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.ViewPager\n" +
			"";
		mono.android.Runtime.register ("SlidePicture.MainActivity, SlidePicture", MainActivity.class, __md_methods);
	}


	public MainActivity ()
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("SlidePicture.MainActivity, SlidePicture", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onPageScrollStateChanged (int p0)
	{
		n_onPageScrollStateChanged (p0);
	}

	private native void n_onPageScrollStateChanged (int p0);


	public void onPageScrolled (int p0, float p1, int p2)
	{
		n_onPageScrolled (p0, p1, p2);
	}

	private native void n_onPageScrolled (int p0, float p1, int p2);


	public void onPageSelected (int p0)
	{
		n_onPageSelected (p0);
	}

	private native void n_onPageSelected (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
