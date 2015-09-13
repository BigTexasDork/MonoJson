using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ConsoleApp;

namespace ConsoleApp.Migrations
{
    [DbContext(typeof(PricebookContext))]
    partial class PricebookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540");

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BotanicalName");

                    b.Property<string>("CompEase");

                    b.Property<DateTime>("CostDate");

                    b.Property<string>("Description");

                    b.Property<string>("Division");

                    b.Property<string>("ItemNumber");

                    b.Property<double>("LaborHours");

                    b.Property<double>("MaterialCost");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<double>("RoundedPrice");

                    b.Property<string>("Size");

                    b.Property<bool>("Taxable");

                    b.Property<bool>("Warranty");

                    b.Key("ItemId");
                });
        }
    }
}
