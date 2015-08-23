using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Model.Settings;

namespace ChiakiYu.EntityFramework.Mapping.Settings
{
    public class SettingMapping : EntityConfiguration<Setting, string>
    {
        public SettingMapping()
        {
            ToTable("Sys_Settings");
            HasKey(n => n.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}