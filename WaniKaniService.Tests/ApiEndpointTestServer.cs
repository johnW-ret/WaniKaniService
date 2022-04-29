using System;
using System.IO;
using System.Net;

namespace WaniKaniService.Tests
{
    public class ApiEndpointTestServer
    {
        public async static void RunListener(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }

            listener.Start();

            HttpListenerContext context = await listener.GetContextAsync();
            HttpListenerResponse response = context.Response;

            // Construct a response.
            string responseString = new StreamReader(@"user.json").ReadToEnd();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);

            output.Close();
            listener.Stop();
        }
    }
}