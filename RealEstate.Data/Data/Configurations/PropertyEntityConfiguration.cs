﻿namespace RealEstate.Data.Data.Configurations
{
    using System;
    using NetTopologySuite.Geometries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static GlobalConstants.ApplicationConstants;

    public class PropertyEntityConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasOne(p => p.City)
                .WithMany(c => c.Properties)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.Property(x => x.Location).HasDefaultValue(new Point(0, 0) { SRID = DEFAULT_SRID });

            builder.HasData(SeedProperties());
        }

        private IEnumerable<Property> SeedProperties()
        {
            List<Property> properties = new List<Property>()
           {
               new Property()
               {
                   Id = Guid.Parse("A3447384-56EA-485D-98D7-0020AD5DC217"),
                   CityId = 1,
                   BathRoomsCount = 2,
                   BedRoomsCount = 3,
                   Address = "квартал Витоша",
                   Name = "Тристаен Апартамент",
                   SaleCategoryId = 1,
                   Price = 900,
                   PropertyCategoryId =  2,
                   SquareMeters = 104,
                   FloorNumber = 2,
                   Location = new Point(23.270974910391605, 42.71034632312068){SRID = DEFAULT_SRID}, //X : longitude Y : lattitude
                   Description = "Тристаен апартамент в новострояща се сграда разположен е на втори жилищен етаж. Състои се от: коридор, всекидневна с кухненски бокс и тераса,   две спални, едната с гардеробна и собствена баня с тоалетна,   баня с тоалетна и тераса. Жилището се издава  на шпакловка и замазка, с външни врати с многоточково заключване, ВиК до тапа, електрозахранване по проект. Сградата ще бъде присъединена към Газификационна мрежа.",
                   OwnerId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254")
               }
           };
            return properties;
        }
    }
}
