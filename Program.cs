// Program.cs
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class Program
    {
        public void Main(string[] args)
        {
            JArray o1 = JArray.Parse(File.ReadAllText(@"pricebook.json"));
            Console.WriteLine(" items read: {0}", o1.Count);
            using(var pricebook = new PricebookContext())
            {
                foreach(var item in o1.Children())
                {
                    var itemProperties = item.Children<JProperty>();
                    
                    Item priceItem = new Item {
                        Name = (string)itemProperties.FirstOrDefault(x => x.Name == "item").Value,
                        Division = (string)itemProperties.FirstOrDefault(x => x.Name == "division").Value,
                        Size = (string)itemProperties.FirstOrDefault(x => x.Name == "size").Value,
                        BotanicalName = (string)itemProperties.FirstOrDefault(x => x.Name == "botanicalName").Value,
                        ItemNumber = (string)itemProperties.FirstOrDefault(x => x.Name == "itemNumber").Value,
                        LaborHours = GetDouble((string)itemProperties.FirstOrDefault(x => x.Name == "laborHours").Value),
                        MaterialCost = GetDouble((string)itemProperties.FirstOrDefault(x => x.Name == "materialCost").Value),
                        CostDate = GetDate((string)itemProperties.FirstOrDefault(x => x.Name == "costDate").Value),
                        Taxable = GetBoolean((string)itemProperties.FirstOrDefault(x => x.Name == "taxable").Value),
                        Warranty = GetBoolean((string)itemProperties.FirstOrDefault(x => x.Name == "warranty").Value),
                        CompEase = (string)itemProperties.FirstOrDefault(x => x.Name == "compEase").Value,
                        Description = (string)itemProperties.FirstOrDefault(x => x.Name == "description").Value,
                        Price = GetDouble((string)itemProperties.FirstOrDefault(x => x.Name == "price").Value),
                        RoundedPrice = GetDouble((string)itemProperties.FirstOrDefault(x => x.Name == "roundedPrice").Value)
                    };
                    pricebook.Items.Add(priceItem);
                }
                var count = pricebook.SaveChanges();
                Console.WriteLine(" {0} records saved to database", count);
            }
        }
        
        private double GetDouble(string str )
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (System.Exception)
            {
                // maybe log which one blew up
                return 0.0;
            }
        }
        
        private Boolean GetBoolean(string str)
        {
            return "y".Equals(str, StringComparison.OrdinalIgnoreCase);
        }
        
        private DateTime GetDate(string str)
        {
            try
            {
                return DateTime.Parse(str);
            }
            catch (System.Exception)
            {
                return DateTime.Parse("01/01/1901");
            }
        }
    }
    
    // TODO: Remove. Will be unnecessary when bug #2357 fixed
    // See https://github.com/aspnet/EntityFramework/issues/2357
    public class Startup
    {
        public void Configure() { }
    }
}

