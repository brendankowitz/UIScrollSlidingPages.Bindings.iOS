using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SlidingPages.Bindings
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//

	[BaseType (typeof (UITableViewController))]
	public partial interface TTUITableViewZoomController {

		[Export ("cellZoomXScaleFactor", ArgumentSemantic.Retain)]
		NSNumber CellZoomXScaleFactor { get; set; }

		[Export ("cellZoomYScaleFactor", ArgumentSemantic.Retain)]
		NSNumber CellZoomYScaleFactor { get; set; }

		[Export ("cellZoomInitialAlpha", ArgumentSemantic.Retain)]
		NSNumber CellZoomInitialAlpha { get; set; }

		[Export ("cellZoomAnimationDuration", ArgumentSemantic.Retain)]
		NSNumber CellZoomAnimationDuration { get; set; }

		[Export ("resetViewedCells")]
		void ResetViewedCells ();
	}

	[BaseType (typeof (UIView))]
	public partial interface TTBlackTriangle {

		[Export ("initWithFrame:color:")]
		IntPtr Constructor (RectangleF frame, UIColor sColor);
	}

	[BaseType (typeof (UIViewController))]
	public partial interface TTScrollSlidingPagesController //: UIScrollViewDelegate 
	{
		[Export ("didRotate")]
		void DidRotate ();

		[Export ("reloadPages")]
		void ReloadPages ();

		[Export ("scrollToPage:animated:")]
		void ScrollToPage (int page, bool animated);

		[Export ("getCurrentDisplayedPage")] //, Verify ("ObjC method massaged into getter property")]
		int GetCurrentDisplayedPage { get; }

		[Export ("getXPositionOfPage:")]
		int GetXPositionOfPage (int page);

		[Export ("dataSource", ArgumentSemantic.Assign)]
		TTSlidingPagesDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		TTSliddingPageDelegate Delegate { get; set; }

		[Export ("titleScrollerHidden")]
		bool TitleScrollerHidden { get; set; }

		[Export ("titleScrollerHeight")]
		int TitleScrollerHeight { get; set; }

		[Export ("titleScrollerItemWidth")]
		int TitleScrollerItemWidth { get; set; }

		[Export ("titleScrollerBackgroundColour", ArgumentSemantic.Retain)]
		UIColor TitleScrollerBackgroundColour { get; set; }

		[Export ("titleScrollerTextColour", ArgumentSemantic.Retain)]
		UIColor TitleScrollerTextColour { get; set; }

        [Export ("titleScrollerInActiveTextColour", ArgumentSemantic.Retain)]
        UIColor TitleScrollerInActiveTextColour { get; set; }

        [Export ("titleScrollerTextDropShadowColour", ArgumentSemantic.Retain)]
        UIColor TitleScrollerTextDropShadowColour { get; set; }

        [Export ("titleScrollerTextFont", ArgumentSemantic.Retain)]
        UIFont TitleScrollerTextFont { get; set; }

		[Export ("triangleBackgroundColour", ArgumentSemantic.Retain)]
		UIColor TriangleBackgroundColour { get; set; }

        [Export ("titleScrollerBottomEdgeColour", ArgumentSemantic.Retain)]
        UIColor TitleScrollerBottomEdgeColour { get; set; }

		[Export ("disableTitleScrollerShadow")]
		bool DisableTitleScrollerShadow { get; set; }

		[Export ("disableUIPageControl")]
		bool DisableUIPageControl { get; set; }

		[Export ("initialPageNumber")]
		int InitialPageNumber { get; set; }

		[Export ("pagingEnabled")]
		bool PagingEnabled { get; set; }

		[Export ("zoomOutAnimationDisabled")]
		bool ZoomOutAnimationDisabled { get; set; }

		[Export ("hideStatusBarWhenScrolling")]
		bool HideStatusBarWhenScrolling { get; set; }
	}

	[BaseType (typeof (UIView))]
	public partial interface TTScrollViewWrapper {

		[Export ("initWithFrame:andUIScrollView:")]
		IntPtr Constructor (RectangleF frame, UIScrollView scroll);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface TTSliddingPageDelegate {

		[Export ("didScrollToViewAtIndex:")]
		void DidScrollToViewAtIndex(uint index);
	}

	[BaseType (typeof (NSObject))]
	public partial interface TTSlidingPage {

		[Export ("initWithContentViewController:")]
		IntPtr Constructor (UIViewController contentViewController);

		[Export ("initWithContentView:")]
		IntPtr Constructor (UIView contentView);

		[Export ("contentViewController", ArgumentSemantic.Retain)]
		UIViewController ContentViewController { get; set; }

		[Export ("contentView", ArgumentSemantic.Retain)]
		UIView ContentView { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface TTSlidingPageTitle {

		[Export ("initWithHeaderText:")]
		IntPtr Constructor (string headerText);

		[Export ("initWithHeaderImage:")]
		IntPtr Constructor (UIImage headerImage);

		[Export ("headerText", ArgumentSemantic.Retain)]
		string HeaderText { get; set; }

		[Export ("headerImage", ArgumentSemantic.Retain)]
		UIImage HeaderImage { get; set; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface TTSlidingPagesDataSource {

		[Export ("numberOfPagesForSlidingPagesViewController:")]
		int NumberOfPagesForSlidingPagesViewController (TTScrollSlidingPagesController source);

		[Export ("pageForSlidingPagesViewController:atIndex:")]
		TTSlidingPage PageForSlidingPagesViewController (TTScrollSlidingPagesController source, int index);

		[Export ("titleForSlidingPagesViewController:atIndex:")]
		TTSlidingPageTitle TitleForSlidingPagesViewController (TTScrollSlidingPagesController source, int index);

		[Export ("widthForPageOnSlidingPagesViewController:atIndex:")]
		int WidthForPageOnSlidingPagesViewController (TTScrollSlidingPagesController source, int index);
	}
}

