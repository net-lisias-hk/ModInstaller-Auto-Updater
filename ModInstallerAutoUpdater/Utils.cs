using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

using ICSharpCode.SharpZipLib.Zip;

namespace ModInstallerAutoUpdater
{
	internal static class Util
	{
		static Util()
		{
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		}

		internal static void DownloadFile(Uri uri, string path, DownloadProgressChangedEventHandler progressChanged, AsyncCompletedEventHandler completed)
		{
			using(WebClient dl = new WebClient())
			{
				dl.DownloadProgressChanged += progressChanged;
				dl.DownloadFileCompleted += completed;
				dl.DownloadFileAsync(uri, path);
			}
		}

		internal static void Execute(string dir, string file)
		{
			Process process = new Process
			{
				StartInfo =
				{
					FileName = Path.Combine(dir, file)
				}
			};
			process.Start();
		}

		internal static void Open(string path)
		{
			Process.Start(path);
		}

		internal static void Unzip(string pathname, string target)
		{
			FastZip zipFile = new FastZip();
			zipFile.ExtractZip(pathname, target, "*");
		}
	}
}
