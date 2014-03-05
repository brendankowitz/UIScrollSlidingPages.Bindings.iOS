UIScrollSlidingPages.Bindings.iOS
=================================

Xamarin/iOS bindings for the awesome UIScrollSlidingPages control (as seen [here](http://github.com/TomThorpe/UIScrollSlidingPages))

Example
---
####It's Pretty

![Screenshot](https://raw.github.com/TomThorpe/UIScrollSlidingPages/master/Screenshots/uiscrollslidingpages.gif)

####Code

```  csharp

    public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var slider = new TTScrollSlidingPagesController ();
			var dataSource = new MainScrollViewDataSource ();

			slider.DataSource = dataSource;
			slider.View.Frame = View.Frame;

			dataSource.AddView (new SampleViewController () {Title = "Page 1" });
			dataSource.AddView (new SampleViewController () {Title = "Page 2" });
			dataSource.AddView (new SampleViewController () {Title = "Page 3" });

			View.AddSubview (slider.View);
			AddChildViewController (slider);
		}

```
