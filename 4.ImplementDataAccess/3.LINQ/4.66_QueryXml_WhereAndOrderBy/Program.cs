using System;
using System.Linq;
using System.Xml.Linq;

namespace _4._66_QueryXml_WhereAndOrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <people>
                                <person firstName=""john"" lastName=""doe"">
                                    <contactDetails>
                                        <emailAddress>john@microsoft.com</emailAddress>
                                    </contactDetails>
                                </person>
                                <person firstName=""jane"" lastName=""doe"">
                                    <contactDetails>
                                        <emailAddress>john@microsoft.com</emailAddress>
                                        <phoneNumber>1234567890</phoneNumber>
                                    </contactDetails>
                                </person>
                            </people>";

            XDocument doc = XDocument.Parse(xml);
            var namesWithAPhoneNumber = from p in doc.Descendants("person")
                                         where p.Descendants("phoneNumber").Any()
                                         let name = (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName")
                                         orderby name
                                         select name;

            foreach (var name in namesWithAPhoneNumber)
                Console.WriteLine(name);

            Console.ReadLine();
        }
    }
}
