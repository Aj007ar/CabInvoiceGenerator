using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, Dictionary<string, string>> userIdMap = new Dictionary<string, Dictionary<string, string>>();
        CalculateInvoice calculateNormal = new CalculateInvoice(CalculateInvoice.RideType.Normal);
        CalculateInvoice calculatePremium = new CalculateInvoice(CalculateInvoice.RideType.Premium);
        public void AddToDictionary(string userId, Ride[] rides)
        {
            string totalFareForNormal = calculateNormal.InvoiceSummary(rides);
            string totalFareForPremium = calculatePremium.InvoiceSummary(rides);
            List<string> listNormal = new List<string>();
            listNormal.Add(totalFareForNormal);
            Dictionary<string, string> typesofrides = new Dictionary<string, string>();
            typesofrides.Add("Normal", totalFareForNormal);
            typesofrides.Add("Premium", totalFareForPremium);
            if (!userIdMap.ContainsKey(userId))
            {
                userIdMap.Add(userId, typesofrides);
            }
            else
            {
                Console.WriteLine("Exist");
            }
        }
        public string Search(string user)
        {
            string result = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> keyValue in userIdMap)
            {
                if (keyValue.Key == user)
                {
                    Console.WriteLine(keyValue.Key);
                    foreach (KeyValuePair<string, string> kvp in keyValue.Value)
                    {
                        result += "\n" + kvp.Key + kvp.Value;

                    }
                    return result;
                }
                else
                {
                    result = "Not found";
                }
            }
            return result;
        }
    }
}
