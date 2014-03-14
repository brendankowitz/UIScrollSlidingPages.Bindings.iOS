using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SlidingPages.Bindings;
using System.Collections.Generic;

namespace Sample
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController () : base ("MainViewController", null)
		{
			// Custom initialization
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var slider = new TTScrollSlidingPagesController ();
			var dataSource = new MainScrollViewDataSource ();

            slider.TitleScrollerNonActiveTextColour = UIColor.Gray;
            slider.TitleScrollerTextDropShadowColour = UIColor.Clear;
            slider.TitleScrollerTextFont = UIFont.BoldSystemFontOfSize (21);

			slider.DataSource = dataSource;
			slider.View.Frame = View.Frame;

			dataSource.AddView (new SampleViewController () {Title = "Page 1" });
			dataSource.AddView (new SampleViewController () {Title = "Page 2" });
			dataSource.AddView (new SampleViewController () {Title = "Page 3" });

			View.AddSubview (slider.View);
			AddChildViewController (slider);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		partial void showInfo (NSObject sender)
		{

		}
	}

	public class MainScrollViewDataSource : TTSlidingPagesDataSource
	{
		List<UIViewController> views;

		public MainScrollViewDataSource(){
			views = new List<UIViewController> ();
		}

		public void AddView(UIViewController controller)
		{
			views.Add (controller);
		}

		public override int NumberOfPagesForSlidingPagesViewController (TTScrollSlidingPagesController source)
		{
			return views.Count;
		}

		public override TTSlidingPageTitle TitleForSlidingPagesViewController (TTScrollSlidingPagesController source, int index)
		{
			var view = views [index];
			return new TTSlidingPageTitle (view.Title);
		}

		public override TTSlidingPage PageForSlidingPagesViewController (TTScrollSlidingPagesController source, int index)
		{
			return new TTSlidingPage (views [index]);
		}
			
	}
}

