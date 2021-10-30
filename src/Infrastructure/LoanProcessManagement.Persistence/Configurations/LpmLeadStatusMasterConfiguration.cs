using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmLeadStatusMasterConfiguration : IEntityTypeConfiguration<LpmLeadStatusMaster>
    {
        public void Configure(EntityTypeBuilder<LpmLeadStatusMaster> builder)
        {
            ////Not necessary if relationship conventions are followed in model(Cascade is the default behaviour)
            //builder
            //    .HasOne(b => b.)
            //    .WithMany(b => b.LpmUserMasters)
            //    .HasForeignKey(b => b.UserRoleId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasOne(b => b.Branch)
            //    .WithMany(b => b.LpmUserMasters)
            //    .HasForeignKey(b => b.BranchId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
