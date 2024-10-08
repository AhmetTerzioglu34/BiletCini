﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class SessionTicketConfiguration : BaseConfiguration<SessionTicket>
    {
        public override void Configure(EntityTypeBuilder<SessionTicket> builder)
        {
            base.Configure(builder);
            builder.Ignore(x=> x.ID);
            builder.HasKey(x => new
            {
                x.SessionID,
                x.TicketID
            });
        }
    }
}
