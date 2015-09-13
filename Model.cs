// Model.cs
using System;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;

namespace ConsoleApp
{
	public class PricebookContext : DbContext
	{
        public DbSet<Item> Items {get; set;}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		{
            var appEnv = CallContextServiceLocator.Locator.ServiceProvider
                            .GetRequiredService<IApplicationEnvironment>();
            optionsBuilder.UseSqlite($"Data Source={ appEnv.ApplicationBasePath }/pricebook.db");
        }
	}
	
	public class Item
    {
        public int ItemId {get; set;}
        public string Name {get; set;}
        public string Division {get; set;}
        public string Size {get; set;}
        public string BotanicalName {get; set;}
        public string ItemNumber {get; set;}
        public double LaborHours {get; set;}
		public double MaterialCost {get; set;}
		public DateTime CostDate {get; set;}
		public Boolean Taxable {get; set;}
        public Boolean Warranty {get; set;}
        public string CompEase {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
        public double RoundedPrice {get; set;}
    }
}