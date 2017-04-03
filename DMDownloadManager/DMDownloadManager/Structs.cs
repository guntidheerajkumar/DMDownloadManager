using System;
using ObjCRuntime;

namespace DMDownloadManager
{
	public enum DownloadState : int
	{
		Running = 0,
		Suspended,
		Canceled,
		Completed,
		Failed
	}
}
