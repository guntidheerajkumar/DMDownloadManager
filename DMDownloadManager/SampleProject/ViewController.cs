using System;
using Foundation;
using DMDownloadManager;
using UIKit;

namespace SampleProject
{
	public partial class ViewController : UIViewController
	{
		private const string Url1 = "http://baobab.wdjcdn.com/1442142801331138639111.mp4";

		protected ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.DownloadProgressCtrl.Progress = 0f;
			var progress = DownloadManager.SharedManager().FileHasDownloadedProgressOfURL(new NSUrl(Url1));
			this.DownloadProgressCtrl.Progress = (float)progress;
			this.NavigationController.ToolbarHidden = false;
			this.SetToolbarItems(new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.Play, (s,e) => {
					DownloadManager.SharedManager().DownloadFileOfURL(new NSUrl(Url1), (DownloadState obj) => {
						this.Title = obj.ToString();
					}, (receivedSize, expectedSize, prog) => {
						LblDownloadedSize.Text = $"{receivedSize / 1024 / 1024} MB";
						LblTotalSize.Text = $"{expectedSize / 1024 / 1024} MB";
						DownloadProgressCtrl.Progress = (float)progress;
						LblPercentage.Text = $"{Math.Round(prog * 100, 2)} %";
					}, (success, filePath, error) => {
						if (success) {
							Console.WriteLine($"FilePath: {filePath}");
						} else {
							Console.WriteLine($"Error: {error}");
						}
					});
				})
				, new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 }
				, new UIBarButtonItem(UIBarButtonSystemItem.Pause, (s,e) => {
					DownloadManager.SharedManager().SuspendDownloadOfURL(new NSUrl(Url1));
				})
				, new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 }
				, new UIBarButtonItem(UIBarButtonSystemItem.Reply, (s,e) => {
					DownloadManager.SharedManager().ResumeDownloadOfURL(new NSUrl(Url1));
				})
			}, false);

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			if (DownloadManager.SharedManager().IsDownloadCompletedOfURL(new NSUrl(Url1))) {
				Console.WriteLine(DownloadManager.SharedManager().FileFullPathOfURL(new NSUrl(Url1)));
			}
		}
	}
}
