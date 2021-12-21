using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmThirdPartyCheckDetailsConfiguration : IEntityTypeConfiguration<LpmThirdPartyCheckDetails>
    {
        public void Configure(EntityTypeBuilder<LpmThirdPartyCheckDetails> builder)
        {
            builder
               .HasOne(b => b.lead)
               .WithOne(b => b.ThirdPartyCheck)
               .HasForeignKey<LpmThirdPartyCheckDetails>(b => b.lead_Id)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(b => b.ValuerAgency)
               .WithMany(b => b.ValuerAgencies)
               .HasForeignKey(b => b.valuerAgencyId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(b => b.legalAgency)
               .WithMany(b => b.LegalAgencies)
               .HasForeignKey(b => b.legalAgencyId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(b => b.fiAgency)
               .WithMany(b => b.FiAgencies)
               .HasForeignKey(b => b.fiAgencyId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
