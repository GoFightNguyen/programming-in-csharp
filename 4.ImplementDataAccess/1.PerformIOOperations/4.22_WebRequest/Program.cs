﻿using System;
using System.IO;
using System.Net;

namespace _4._22_WebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            WebResponse response = request.GetResponse();

            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();

            Console.WriteLine(responseText);
            response.Close();
            Console.ReadLine();
        }
    }
}
