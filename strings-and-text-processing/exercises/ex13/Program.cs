using System;
using System.Text.RegularExpressions;
namespace ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that parses an URL in following format:
            // [protocol]://[server]/[resource]
            // It should extract from the URL the protocol, server and resource parts. For example, when http://www.cnn.com/video is passed, the result is:
            // [protocol]="http"
            // [server]="www.cnn.com"
            // [resource]="/video"
            string url = "http://www.ftpx.com/ftpintro.aspx";
            string protocol = url.Substring(0, url.IndexOf("://"));
            int complicatedNumber = url.IndexOf("/", (url.IndexOf("://") + 3)) - protocol.Length - 3;


            string server = url.Substring(url.IndexOf("://") + 3, complicatedNumber);
            string resource = url.Substring(server.Length + protocol.Length + 3);

            Console.WriteLine($"Protocol: {protocol}");
            Console.WriteLine($"Server: {server}");
            Console.WriteLine($"Resource: {resource}");

        }


    }
}
