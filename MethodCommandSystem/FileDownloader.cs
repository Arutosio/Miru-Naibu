using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Miru_Naibu.Library;
using static System.ConsoleColor;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class FileDownloader
    {
        public static void DoAGetRequest(string link, string nFileFix)
        {
            Uri uri = new Uri(link);

            // Construct HTTP request to get the file
            Console.Write("--- Dowloading: "); ColorLine.WriteLineC(Path.GetFileName(link), Yellow);
            using (WebClient client = new WebClient())
            {
                try
                {
                    // Specify that the DownloadFileCallback method gets called
                    // Specify a progress notification handler.
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                    // when the download completes.
                    //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
                    client.DownloadFileAsync(new Uri(link), nFileFix);
                }
                catch (Exception ex) { /* Program.pL.Percent = -1; */ColorLine.WriteLineC(" ### Error # \r\n" + ex.Message, Red); }
            }
        }
        public static bool CheckURLValid(string source)
        {
            bool res = false;
            Uri uriResult;
            if (Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
            {
                WebRequest request = WebRequest.Create(source);
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.  
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
                // Clean up the streams and the response.  
                reader.Close();
                response.Close();
            }
            res = true;
            return res;
        }
        public static bool IsURLExist(string url)
        {
            bool valid = false;
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                res.Close();
                valid = true;
            }
            catch (WebException ex)
            {
                Console.Write(" =====> "); ColorLine.WriteLineC(" ### " + ex.Message, Red);
            }
            return valid;
        }
        private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            //Program.pL.Percent = e.ProgressPercentage;
        }
        private static void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            ColorLine.WriteC(" DONE", Green); Console.WriteLine("!");
        }
    }
}

