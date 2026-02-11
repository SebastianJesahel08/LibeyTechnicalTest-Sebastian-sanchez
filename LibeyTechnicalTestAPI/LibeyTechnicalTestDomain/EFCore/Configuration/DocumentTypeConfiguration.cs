using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType");
            builder.HasKey(x => x.DocumentTypeId);

            builder.Property(x => x.DocumentTypeId).HasColumnName("DocumentTypeId");
            builder.Property(x => x.DocumentTypeDescription).HasColumnName("DocumentTypeDescription");
        }
    }
}
