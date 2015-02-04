using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using MonoTouch.Dialog;

namespace Sample
{
	public partial class SampleViewController : DialogViewController
	{
		public SampleViewController () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("SampleViewController") {
				new Section ("First Section") {
					new StringElement ("Hello", () => {
						new UIAlertView ("Hola", "Thanks for tapping!", null, "Continue").Show (); 
					}),
					new EntryElement ("Name", "Enter your name", String.Empty)
				},
				new Section ("Second Section") {
				},
			};
		}
	}
}
