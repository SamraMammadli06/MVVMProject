using MesengerApp.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.Add.Configs;
public class UserConfigurations :IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        // Name
        builder
            .Property<string>(user => user.Name)
            .HasMaxLength(50);

        // Surname
        builder
            .Property<string?>(user => user.Surname)
            .HasMaxLength(50);

        // Password
        builder
           .Property<string?>(user => user.Password)
           .HasMaxLength(20);

        // Email
        builder
           .Property<string>(user => user.Email)
           .HasMaxLength(50);

        // - Constraints
        builder
            .ToTable(b => b.HasCheckConstraint("CK_Users_Password", "LEN(Password)>=8"));
        builder
         .ToTable(b => b.HasCheckConstraint("CK_Users_Email", "Email like '%@%'"));
    }
}

