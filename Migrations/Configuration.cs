using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using WlBhcApp.Models;

namespace WlBhcApp.Migrations
{
    internal sealed class Configuration:DbMigrationsConfiguration<WlBhcApp.Models.WlBhcDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WlBhcDB context)
        {
            //base.Seed(context);
            context.Products.AddRange(new Product[] {
                new Product{ProdName="iPhone XR", Price=899.99d, ProdDescription="iPhone XR Samrt Phone", ProdAttributes="Gold, 64GB" },
                new Product{ProdName="iPhone Xs", Price=1099.99d, ProdDescription="iPhone XS Samrt Phone", ProdAttributes="Silver, 128GB"},
                new Product{ProdName="iPhoneX", Price=799.99d, ProdDescription="iPhone XS Samrt Phone", ProdAttributes="Silver, 32GB"},
                new Product{ProdName="Samsung Galaxy 8", Price=999.99d, ProdDescription="Samsung Galaxy 8 Smart Phone", ProdAttributes="Sky Blue, 128GB"},
                new Product{ProdName="Samsung Note 7", Price=999.99d, ProdDescription="Samsung Note 7 Smart Phone", ProdAttributes="Red, 64GB"},
                new Product{ProdName="Google Pixel 3XL", Price=899.99d, ProdDescription="Google Pixel 3XL Smart Phone", ProdAttributes="Black, 128GB"},
                new Product{ProdName="Google Pixel 3A", Price=799.99d, ProdDescription="Google Pixel 3A Smart Phone", ProdAttributes="Pink, 128GB"},
                new Product{ProdName="Kinston SD Card", Price=19.99d, ProdDescription="Kinston SD Memory Card", ProdAttributes="Regualr, 32GB"},
                new Product{ProdName="Boss HeadPhone", Price=219.99d, ProdDescription="Boss Wireless HeadPhone", ProdAttributes="Silver"}
            }); ;
            context.SaveChanges();
        }
    }
}