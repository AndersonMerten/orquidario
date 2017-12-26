namespace ControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsereUsuarios : DbMigration
    {
        public override void Up()
        {
                  Sql(@"
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'52e70b9f-1ad0-489e-82bc-2797b7f01c5f', N'andersonmerten@gmail.com', 0, N'AATY7ruIqI3hru4DBmFSMbt/y7D+tyB5Iw7PW7Hh9xpxVCSuJ+Xf/bacPxrXM2GXcQ==', N'bb42cbf7-1770-472b-bc50-0f059ba2dc35', NULL, 0, 0, NULL, 1, 0, N'andersonmerten@gmail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa6cf65a-9d32-4f50-a5dc-ad9beece00b7', N'user@user.com', 0, N'ADe4koA/DZKBX0pnXitD/F9JJMFwwOJSSOpRARhv6e2f4u2CLA8cHVX3AE/3JFffgQ==', N'df79c466-502a-4837-a95c-03082b405c1b', NULL, 0, 0, NULL, 1, 0, N'user@user.com')                       
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0b9009ba-9cb3-438c-ae57-a665f12c48be', N'CanManageCustomers')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'52e70b9f-1ad0-489e-82bc-2797b7f01c5f', N'0b9009ba-9cb3-438c-ae57-a665f12c48be')
                  ");
            }
        
        public override void Down()
        {
        }
    }
}
