using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.AppUserId).HasColumnName("UserId");
            builder.Property(r => r.Token).HasColumnName("Token");
            builder.Property(r => r.Expires).HasColumnName("Expires");
            builder.Property(r => r.CreatedDate).HasColumnName("Created");
            builder.Property(r => r.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(r => r.Revoked).HasColumnName("Revoked");
            builder.Property(r => r.RevokedByIp).HasColumnName("RevokedByIp");
            builder.Property(r => r.ReplacedByToken).HasColumnName("ReplacedByToken");
            builder.Property(r => r.ReasonRevoked).HasColumnName("ReasonRevoked");
            builder.HasOne(r => r.AppUser).WithMany(x => x.RefreshTokens).HasForeignKey(x => x.AppUserId);
        }
    }
}
