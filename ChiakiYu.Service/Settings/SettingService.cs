using ChiakiYu.Common.Data;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Settings;

namespace ChiakiYu.Service.Settings
{
    public class SettingService<T> : ISettingService<T> where T : class
    {
        private readonly IRepository<Setting, string> _settingRepository;

        public SettingService(IRepository<Setting, string> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        /// <summary>
        ///     获取设置
        /// </summary>
        /// <returns>settings</returns>
        public T Get()
        {
            var setting = _settingRepository.Get(typeof(T).FullName);
            return setting == null
                ? null
                : JsonHelper.FromJson<T>(setting.Settings);
        }

        /// <summary>
        ///     保存设置
        /// </summary>
        /// <param name="settings">settings</param>
        public void Save(T settings)
        {
            var setting = new Setting
            {
                Id = typeof(T).FullName,
                Settings = JsonHelper.ToJson(settings)
            };
            _settingRepository.InsertOrUpdate(setting);
        }
    }
}