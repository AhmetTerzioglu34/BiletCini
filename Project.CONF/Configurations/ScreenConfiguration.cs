﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class ScreenConfiguration : BaseConfiguration<Screen>
    {
        public override void Configure(EntityTypeBuilder<Screen> builder)
        {
            base.Configure(builder);
        }
    }
}
