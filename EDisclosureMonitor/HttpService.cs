using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDisclosureMonitor
{
	public class HttpService
	{
		public static string ResultOk = "true";

		public CookieContainer CookiesContainer { get; set; } = new CookieContainer();
		string downloadsPath = Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\downloads").FullName;

		private Action<string, string> ErrorHandler;

		public class SiteResponse
		{
			public HttpStatusCode StatusCode { get; set; }
			public string RedirectTo { get; set; }
			public string FileLink { get; set; } = string.Empty;

			public string Status { get; set; } = string.Empty;
		}

		public HttpService(Action<string, string> errorHandler)
		{
			ErrorHandler = errorHandler;
		}

		public async Task<SiteResponse> ProcessWebPageAsync(string url, string regexpPattern)
		{
			SiteResponse result = new SiteResponse();

			try
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

				int tryCount = 0;

				do
				{
					tryCount++;
					result = await GetSiteResultAsync(url, regexpPattern);
				}
				while (result.StatusCode != HttpStatusCode.OK && tryCount < 5);
			}
			catch (Exception ex)
			{
				result.Status = ex.Message;
				ErrorHandler(ex.Message, url);
			}

			return result;
		}


		public async Task<SiteResponse> GetSiteResultAsync(string url, string regexpPattern)
		{
			SiteResponse resp = new SiteResponse();

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.KeepAlive = true;
			request.UserAgent = @"Mozilla/5.0 (Linux; Android 5.1.1; Nexus 5 Build/LMY48B; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/43.0.2357.65 Mobile Safari/537.36";
			request.Accept = "*/*";
			request.AllowAutoRedirect = false;
			request.CookieContainer = CookiesContainer;

			using (var response = await request.GetResponseAsync())
			{
				resp.RedirectTo = ((HttpWebResponse)response).GetResponseHeader("Location");
				resp.StatusCode = ((HttpWebResponse)response).StatusCode;
				resp.Status = resp.StatusCode.ToString();

				using (Stream stream = response.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						var html = reader.ReadToEnd();
						string fileLink = string.Empty;

						if (CheckMatch(html, regexpPattern, out fileLink))
						{
							resp.FileLink = fileLink;
						}
					}
				}
			}

			return resp;
		}


		public async Task<string> DownloadFile(string url)
		{
			var fullFileName = string.Empty;

			try
			{
				string fileName = Regex.Match(url, @"\d+").Value;

				var fileDirName = downloadsPath + "\\" + Regex.Match(url, @"\d+").Value;

				if (!Directory.Exists(fileDirName))
				{
					Directory.CreateDirectory(fileDirName);
				}

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.KeepAlive = true;
				request.UserAgent = @"Mozilla/5.0 (Linux; Android 5.1.1; Nexus 5 Build/LMY48B; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/43.0.2357.65 Mobile Safari/537.36";
				request.Accept = "*/*";
				request.AllowAutoRedirect = false;
				request.CookieContainer = CookiesContainer;

				request.Headers.Add("Cache-Control", "no-cache");
				request.Headers.Add("Cache-Control", "no-store");
				request.Headers.Add("Cache-Control", "max-age=1");
				request.Headers.Add("Cache-Control", "s-maxage=1");
				request.Headers.Add("Pragma", "no-cache");
				request.Headers.Add("Expires", "-1");

				using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
				{
					string path = response.Headers["Content-Disposition"];
					if (string.IsNullOrWhiteSpace(path))
					{
						var uri = new Uri(url);
						fileName = Path.GetFileName(uri.LocalPath);
					}
					else
					{
						ContentDisposition contentDisposition = new ContentDisposition(path);
						fileName = contentDisposition.FileName;
					}

					fullFileName = Path.Combine(fileDirName, fileName);

					using (Stream responseStream = response.GetResponseStream())
					using (FileStream fileStream = File.Create(fullFileName))
					{
						byte[] buffer = new byte[1024 * 1024];

						int size = responseStream.Read(buffer, 0, buffer.Length);
						while (size > 0)
						{
							fileStream.Write(buffer, 0, size);
							size = responseStream.Read(buffer, 0, buffer.Length);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorHandler(ex.Message, url);
			}

			return fullFileName;
		}

		private bool CheckMatch(string text, string pattern, out string fileLink)
		{
			fileLink = string.Empty;
			try
			{
				AppDomain domain = AppDomain.CurrentDomain;
				domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(5));

				Hashtable links = new Hashtable();

				string CurrentRegPattern = pattern;
				Regex reg = new Regex(CurrentRegPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);

				if (!reg.IsMatch(text))
				{
					return false;
				}
				MatchCollection mcol = reg.Matches(text);
				if (mcol.Count > 0)
				{
					//also get the link to file
					Regex regFile = new Regex(CurrentRegPattern + ".+?(http.+?)\"", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);

					if (regFile.IsMatch(text))
					{
						fileLink = regFile.Match(text).Groups[2].Value.ToLower();
					}

					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
