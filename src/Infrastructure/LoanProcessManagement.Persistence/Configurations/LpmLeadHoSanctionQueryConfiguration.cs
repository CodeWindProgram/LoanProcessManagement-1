using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLeadHoSanctionQueryConfiguration : IEntityTypeConfiguration<LpmLeadHoSanctionQuery>
    {
        public void Configure(EntityTypeBuilder<LpmLeadHoSanctionQuery> builder)
        {
            builder
              .HasOne(b => b.lead)
              .WithMany(b => b.hoLeadQuery)
              .HasForeignKey(b => b.lead_Id)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
