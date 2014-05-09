using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SlidingPages.Bindings
{
    [BaseType (typeof(UITableViewController))]
    public partial interface TTUITableViewZoomController
    {
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

    [BaseType (typeof(UIView))]
    public partial interface TTBlackTriangle
    {
        [Export ("initWithFrame:color:")]
        IntPtr Constructor (RectangleF frame, UIColor sColor);
    }

    [BaseType (typeof(UIViewController))]
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
        ITTSlidingPagesDataSource DataSource { get; set; }

        [Export ("delegate", ArgumentSemantic.Assign)]
        ITTSliddingPageDelegate Delegate { get; set; }

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

        [Export ("titleScrollerBottomEdgeHeight", ArgumentSemantic.Retain)]
        int TitleScrollerBottomEdgeHeight { get; set; }

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

    [BaseType (typeof(UIView))]
    public partial interface TTScrollViewWrapper
    {
        [Export ("initWithFrame:andUIScrollView:")]
        IntPtr Constructor (RectangleF frame, UIScrollView scroll);
    }

    [Model, Protocol, BaseType (typeof(NSObject))]
    public partial interface TTSliddingPageDelegate
    {
        [Abstract]
        [Export ("didScrollToViewAtIndex:")]
        void DidScrollToViewAtIndex (uint index);
    }

    public interface ITTSliddingPageDelegate
    {

    }

    [BaseType (typeof(NSObject))]
    public partial interface TTSlidingPage
    {
        [Export ("initWithContentViewController:")]
        IntPtr Constructor (UIViewController contentViewController);

        [Export ("initWithContentView:")]
        IntPtr Constructor (UIView contentView);

        [Export ("contentViewController", ArgumentSemantic.Retain)]
        UIViewController ContentViewController { get; set; }

        [Export ("contentView", ArgumentSemantic.Retain)]
        UIView ContentView { get; set; }
    }

    [BaseType (typeof(NSObject))]
    public partial interface TTSlidingPageTitle
    {
        [Export ("initWithHeaderText:")]
        IntPtr Constructor (string headerText);

        [Export ("initWithHeaderImage:")]
        IntPtr Constructor (UIImage headerImage);

        [Export ("headerText", ArgumentSemantic.Retain)]
        string HeaderText { get; set; }

        [Export ("headerImage", ArgumentSemantic.Retain)]
        UIImage HeaderImage { get; set; }
    }

    [Model, Protocol, BaseType (typeof(NSObject))]
    public partial interface TTSlidingPagesDataSource
    {
        [Abstract]
        [Export ("numberOfPagesForSlidingPagesViewController:")]
        int NumberOfPagesForSlidingPagesViewController (TTScrollSlidingPagesController source);

        [Abstract]
        [Export ("pageForSlidingPagesViewController:atIndex:")]
        TTSlidingPage PageForSlidingPagesViewController (TTScrollSlidingPagesController source, int index);

        [Abstract]
        [Export ("titleForSlidingPagesViewController:atIndex:")]
        TTSlidingPageTitle TitleForSlidingPagesViewController (TTScrollSlidingPagesController source, int index);

        [Export ("widthForPageOnSlidingPagesViewController:atIndex:")]
        int WidthForPageOnSlidingPagesViewController (TTScrollSlidingPagesController source, int index);
    }

    public interface ITTSlidingPagesDataSource
    {

    }
}

