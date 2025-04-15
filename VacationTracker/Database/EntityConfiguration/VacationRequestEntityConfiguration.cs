using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracker.Models;

namespace VacationTracker.Database.EntityConfiguration
{
    public class VacationRequestEntityConfiguration : IEntityTypeConfiguration<VacationRequest>
    {
        public void Configure(EntityTypeBuilder<VacationRequest> builder)
        {
            builder
                .HasOne(vr => vr.Employee)
                .WithMany(e => e.VacationRequests)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
