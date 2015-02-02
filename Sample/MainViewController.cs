using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SlidingPages.Bindings;
using System.Collections.Generic;

namespace Sample
{
    public partial class MainViewController : UIViewController, ITTSlidingPagesDataSource
    {
        List<UIViewController> views;

        public MainViewController () : base ("MainViewController", null)
        {
            views = new List<UIViewController> ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
            var slider = new TTScrollSlidingPagesController ();

            slider.TitleScrollerInActiveTextColour = UIColor.Gray;
            slider.TitleScrollerTextDropShadowColour = UIColor.Clear;
            slider.TitleScrollerTextFont = UIFont.BoldSystemFontOfSize (21);
            slider.TitleScrollerBottomEdgeHeight = 1;
            slider.TitleScrollerBottomEdgeColour = UIColor.Yellow;
            slider.DisableTitleShadow = true;

            slider.DataSource = this;
            slider.View.Frame = View.Frame;

            AddView (new SampleViewController () { Title = "Page 1" });
            AddView (new SampleViewController () { Title = "Page 2" });
            AddView (new SampleViewController () { Title = "Page 3" });

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

        public void AddView (UIViewController controller)
        {
            views.Add (controller);
        }

        int ITTSlidingPagesDataSource.NumberOfPagesForSlidingPagesViewController (TTScrollSlidingPagesController source)
        {
            return views.Count;
        }

        TTSlidingPageTitle ITTSlidingPagesDataSource.TitleForSlidingPagesViewController (TTScrollSlidingPagesController source, int index)
        {
            var view = views [index];
            return new TTSlidingPageTitle (view.Title);
        }

        TTSlidingPage ITTSlidingPagesDataSource.PageForSlidingPagesViewController (TTScrollSlidingPagesController source, int index)
        {
            return new TTSlidingPage (views [index]);
        }
    }
}

