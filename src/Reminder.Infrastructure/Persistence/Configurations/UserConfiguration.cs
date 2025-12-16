using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reminder.Domain.Entities;

namespace Reminder.Infrastructure.Persistence;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users")
            .HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(new UserIdConverter())
            .ValueGeneratedNever();

        builder.Property(u => u.FullName)
            .HasConversion(new UserNameConverter())
            .HasMaxLength(255)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(u => u.Email)
            .HasConversion(new UserEmailConverter())
            .HasMaxLength(50)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(u => u.PasswordHash)
            .HasConversion(new PasswordHashConverter())
            .HasMaxLength(255)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(u => u.CreatedAt)
            .HasConversion(new UserCreatedAtConverter())
            .IsRequired()
            .ValueGeneratedNever();
    }
}
