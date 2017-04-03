// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SampleProject
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIProgressView DownloadProgressCtrl { get; set; }

		[Outlet]
		UIKit.UILabel LblDownloadedSize { get; set; }

		[Outlet]
		UIKit.UILabel LblPercentage { get; set; }

		[Outlet]
		UIKit.UILabel LblTotalSize { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblPercentage != null) {
				LblPercentage.Dispose ();
				LblPercentage = null;
			}

			if (DownloadProgressCtrl != null) {
				DownloadProgressCtrl.Dispose ();
				DownloadProgressCtrl = null;
			}

			if (LblDownloadedSize != null) {
				LblDownloadedSize.Dispose ();
				LblDownloadedSize = null;
			}

			if (LblTotalSize != null) {
				LblTotalSize.Dispose ();
				LblTotalSize = null;
			}
		}
	}
}
