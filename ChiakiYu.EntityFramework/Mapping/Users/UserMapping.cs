using ChiakiYu.Model.Users;

namespace ChiakiYu.EntityFramework.Mapping.Users
{
    public class UserMapping : EntityConfiguration<User, long>
    {
        public UserMapping()
        {
            ToTable("Sys_Users");
            //Property(n => n.IsActived).HasColumnType("int");
            //HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(n => n.UserName).IsRequired().HasMaxLength(256);
        }
    }
}