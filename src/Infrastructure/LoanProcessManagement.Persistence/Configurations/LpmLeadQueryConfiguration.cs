using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmLeadQueryConfiguration : IEntityTypeConfiguration<LpmLeadQuery>
    {
        public void Configure(EntityTypeBuilder<LpmLeadQuery> builder)
        {
            builder
            .HasOne(s => s.lead)
            .WithMany(s => s.leadquery)
            .HasForeignKey(s => s.lead_Id);
        }
    }
}
