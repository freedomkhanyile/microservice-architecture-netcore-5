using Account.Microservice.Core.Domain.Entities;
using Account.Microservice.Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using System;

namespace Account.Microservice.Helpers.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedRoles();           
        }

        public static void SeedRoles(this ModelBuilder builder)
        {
            builder
                .Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        RoleName = RoleConstants.Admin,
                        Description = "An administrator role normaly does everything",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1,
                    },
                    new Role
                    {
                        Id = 2,
                        RoleName = RoleConstants.Student,
                        Description = "An student role makes applications to ITS 4.0",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1
                    },
                    new Role
                    {
                        Id = 3,
                        RoleName = RoleConstants.Clerk,
                        Description =
                            "A clerk is responsible for creating subject and modifying the subjects based on their Faculty Subject Aps requirements",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1
                    }
                );
        }

    }
}
