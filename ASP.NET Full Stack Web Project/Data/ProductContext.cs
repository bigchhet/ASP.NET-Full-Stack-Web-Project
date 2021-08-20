using ASP.NET_Full_Stack_Web_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Full_Stack_Web_Project.Data
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Tsurikawa> Kawa { get; set; } //maps to a table called Kawa in db
        public DbSet<AirFreshner> Freshner { get; set; }
        public int ID { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product
            modelBuilder.Entity<Tsurikawa>().HasData
            (
                //item 01
                new Tsurikawa
                {
                    Name = "Akatsuki Tsurikawa",
                    Color = "Red",
                    Price = 15.00,
                    ID = 3,
                    Description = "Red Akatsuki Tsurikawa that will dampen the most lethal blows."
                },
                //item 02
                new Tsurikawa
                {
                    Name = "Broken Hearts Tsurikawa",
                    Color = "Black",
                    Price = 15.00,
                    ID = 4,
                    Description = "Black Broken Hearts Tsurikawa that will dampen the most lethal blows."
                },
                //item 03
                new Tsurikawa
                {
                    Name = "Sharingan Tsurikawa",
                    Color = "White",
                    Price = 15.00,
                    ID = 5,
                    Description = "White Sharingan Tsurikawa that will dampen the most lethal blows."
                }
                 );

            modelBuilder.Entity<AirFreshner>().HasData
            (

                             new AirFreshner
                             {
                                 Name = "ScarFace AirFreshner",
                                 Scent = "Rosemary",
                                 Price = 9.99,
                                 ID = 1,
                                 Description = "ScarFace AirFreshner that has a beautiful rosemary scent that will attract all your desired attention."
                             },

                             new AirFreshner
                             {
                                 Name = "Astro AirFreshner",
                                 Scent = "Cotton Candy",
                                 Price = 9.99,
                                 ID = 2,
                                 Description = "Astronaut AirFreshner that has a beautiful cotton candy scent that is out of this world."
                             },

                             new AirFreshner
                             {
                                 Name = "Eazy E AirFreshner",
                                 Scent = "Chocolate",
                                 Price = 9.99,
                                 ID = 3,
                                 Description = "Eazy E AirFreshner that has a chocolate scented aroma that is designed to cheer you up on your toughest days."
                             }
            );

            
            #endregion
        }

    }
}

