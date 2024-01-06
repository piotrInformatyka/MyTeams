using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teams.Domain.Entities;
using Teams.Domain.ValueObjects;

namespace Teams.Infrastructure.DAL.Configurations;

internal sealed class MemberDbConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasConversion(x => x.Value, x => new Name(x));
        builder.Property(x => x.Email)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Email(x));
        builder.Property(x => x.PhoneNumber).HasConversion(x => x.Value, x => new PhoneNumber(x));
    }
}
