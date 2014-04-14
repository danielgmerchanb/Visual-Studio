using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://publicar.publicar.com/paomi");

            Console.WriteLine(uri.Host);
            Console.Read();
        }
    }
}
