using System;
using Foundation;
using ObjCRuntime;

namespace DMDownloadManager
{

	// @interface DownloadModel : NSObject
	[BaseType(typeof(NSObject))]
	interface DownloadModel
	{
		// @property (nonatomic, strong) NSURLSessionDataTask * dataTask;
		[Export("dataTask", ArgumentSemantic.Strong)]
		NSUrlSessionDataTask DataTask { get; set; }

		// @property (nonatomic, strong) NSOutputStream * outputStream;
		[Export("outputStream", ArgumentSemantic.Strong)]
		NSOutputStream OutputStream { get; set; }

		// @property (nonatomic, strong) NSURL * URL;
		[Export("URL", ArgumentSemantic.Strong)]
		NSUrl URL { get; set; }

		// @property (assign, nonatomic) NSInteger totalLength;
		[Export("totalLength")]
		nint TotalLength { get; set; }

		// @property (copy, nonatomic) void (^state)(DownloadState);
		[Export("state", ArgumentSemantic.Copy)]
		Action<DownloadState> State { get; set; }

		// @property (copy, nonatomic) void (^progress)(NSInteger, NSInteger, CGFloat);
		[Export("progress", ArgumentSemantic.Copy)]
		Action<nint, nint, nfloat> Progress { get; set; }

		// @property (copy, nonatomic) void (^completion)(BOOL, NSString *, NSError *);
		[Export("completion", ArgumentSemantic.Copy)]
		Action<bool, NSString, NSError> Completion { get; set; }

		// -(void)openOutputStream;
		[Export("openOutputStream")]
		void OpenOutputStream();

		// -(void)closeOutputStream;
		[Export("closeOutputStream")]
		void CloseOutputStream();
	}

	// @interface DownloadManager : NSObject
	[BaseType(typeof(NSObject))]
	interface DownloadManager
	{
		// @property (copy, nonatomic) NSString * downloadedFilesDirectory;
		[Export("downloadedFilesDirectory")]
		string DownloadedFilesDirectory { get; set; }

		// +(instancetype)sharedManager;
		[Static]
		[Export("sharedManager")]
		DownloadManager SharedManager();

		// -(void)downloadFileOfURL:(NSURL *)URL state:(void (^)(DownloadState))state progress:(void (^)(NSInteger, NSInteger, CGFloat))progress completion:(void (^)(BOOL, NSString *, NSError *))completion;
		[Export("downloadFileOfURL:state:progress:completion:")]
		void DownloadFileOfURL(NSUrl URL, Action<DownloadState> state, Action<nint, nint, nfloat> progress, Action<bool, NSString, NSError> completion);

		// -(BOOL)isDownloadCompletedOfURL:(NSURL *)URL;
		[Export("isDownloadCompletedOfURL:")]
		bool IsDownloadCompletedOfURL(NSUrl URL);

		// -(NSString *)fileFullPathOfURL:(NSURL *)URL;
		[Export("fileFullPathOfURL:")]
		string FileFullPathOfURL(NSUrl URL);

		// -(CGFloat)fileHasDownloadedProgressOfURL:(NSURL *)URL;
		[Export("fileHasDownloadedProgressOfURL:")]
		nfloat FileHasDownloadedProgressOfURL(NSUrl URL);

		// -(void)deleteFileOfURL:(NSURL *)URL;
		[Export("deleteFileOfURL:")]
		void DeleteFileOfURL(NSUrl URL);

		// -(void)deleteAllFiles;
		[Export("deleteAllFiles")]
		void DeleteAllFiles();

		// -(void)suspendDownloadOfURL:(NSURL *)URL;
		[Export("suspendDownloadOfURL:")]
		void SuspendDownloadOfURL(NSUrl URL);

		// -(void)suspendAllDownloads;
		[Export("suspendAllDownloads")]
		void SuspendAllDownloads();

		// -(void)resumeDownloadOfURL:(NSURL *)URL;
		[Export("resumeDownloadOfURL:")]
		void ResumeDownloadOfURL(NSUrl URL);

		// -(void)resumeAllDownloads;
		[Export("resumeAllDownloads")]
		void ResumeAllDownloads();

		// -(void)cancelDownloadOfURL:(NSURL *)URL;
		[Export("cancelDownloadOfURL:")]
		void CancelDownloadOfURL(NSUrl URL);

		// -(void)cancelAllDownloads;
		[Export("cancelAllDownloads")]
		void CancelAllDownloads();
	}

}