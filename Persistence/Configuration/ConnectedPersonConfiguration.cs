using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConnectedPersonConfiguration : IEntityTypeConfiguration<ConnectedPerson>
    {

        public void Configure(EntityTypeBuilder<ConnectedPerson> builder)
        {
            builder.Property(x => x.ConnectType)
                .IsRequired();

            builder.Property(x => x.ConnectedPersonId)
                .IsRequired();

            builder.Property(x => x.PersonId)
                .IsRequired();

            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasOne(x => x.Person)
                 .WithMany(x => x.ConnectedPersons)
                 .HasForeignKey(x => x.ConnectedPersonId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
