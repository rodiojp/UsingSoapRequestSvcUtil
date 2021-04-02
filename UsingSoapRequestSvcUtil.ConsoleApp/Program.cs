using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingSoapRequestSvcUtil.CountryInfoService;

namespace UsingSoapRequestSvcUtil.ConsoleApp
{
    class Program
    {
        private static IList<string> ListOfContinentsByName()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            //There are two endpoints in the configuration. Call one of them by its name
            var client = new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            ListOfContinentsByNameResponse response = client.ListOfContinentsByName(new ListOfContinentsByNameRequest(new ListOfContinentsByNameRequestBody())); // call of webmethod
            List<string> list = response.Body.ListOfContinentsByNameResult.Select(x=>x.sName).ToList();
            return list;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("List of continents:");
            IList<string> list = ListOfContinentsByName();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
