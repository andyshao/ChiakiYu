using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ChiakiYu.Common.Extensions.Html;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Settings
{
    [Serializable]
    public class SiteSetting : Entity<string>
    {
        public SiteSetting()
        {
            Id = Guid.NewGuid().ToString("N");
            KeepRecordScript = string.Empty;
            StatScript = string.Empty;
            Links = string.Empty;
            SiteKey = Guid.NewGuid().ToString("N");
            SiteName = "幸运鱼";
            SiteDescription = "基于asp.net mvc 最强大软件";
            MetaDescription = "“幸运鱼”是一款业内领先的软件。";
            MetaKeyWords = "幸运鱼,xingyunyu,LuckyYu,ChiakiYu," +
                           "asp.net,mvc,EF,Entity Framework," +
                           "开源,网络学习空间,开源博客系统";
            MetaGenerator = "ChiakiYu v1.0";
            MetaAuthor = "ChiakiYu";
            MainSiteRootUrl = @"http://localhost";
            ShareToThirdIsEnabled = true;
            ShareToThirdDisplayType = ShareDisplayType.Sidebar;
            ShareDisplayIconSize = ShareDisplayIconSize.Middle;
        }

        [StringLength(32)]
        public override string Id { get; set; }

        /// <summary>
        /// 备案信息
        /// </summary>
        [AllowHtml]
        [DataType(DataType.Html)]
        public string KeepRecordScript { get; set; }

        /// <summary>
        /// 页脚统计脚本
        /// </summary>
        [AllowHtml]
        [DataType(DataType.Html)]
        public string StatScript { get; set; }

        /// <summary>
        /// 页脚链接
        /// </summary>
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Links { get; set; }

        /// <summary>
        /// 站点唯一标识
        /// </summary>
        public string SiteKey { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        [Required(ErrorMessage = "站点名称不能为空")]
        [StringLength(20,ErrorMessage="站点名称不能超过20个字符")]
        public string SiteName { get; set; }

        /// <summary>
        /// 站点描述
        /// </summary>
        [Required(ErrorMessage = "站点描述不能为空")]
        public string SiteDescription { get; set; }

        /// <summary>
        /// 页面头信息的description
        /// </summary>
        [Required(ErrorMessage = "MetaDescription不能为空")]
        public string MetaDescription { get; set; }

        /// <summary>
        /// 页面头信息的KeyWord
        /// </summary>
        [Required(ErrorMessage = "MetaKeyWords不能为空")]
        public string MetaKeyWords { get; set; }

        /// <summary>
        /// 页面头信息的Generator
        /// </summary>
        public string MetaGenerator { get; set; }

        /// <summary>
        /// 页面头信息的Author
        /// </summary>
        public string MetaAuthor { get; set; }

        /// <summary>
        /// 主站URL
        /// </summary>
        /// <remarks>
        /// 安装程序（或者首次启动时）需要自动保存该地址
        /// </remarks>
        [AllowHtml]
        [DataType(DataType.Html)]
        public string MainSiteRootUrl { get; set; }

        /// <summary>
        /// 分享是否启用
        /// </summary>
        public bool ShareToThirdIsEnabled { get; set; }

        /// <summary>
        /// 分享展示类型
        /// </summary>
        public ShareDisplayType ShareToThirdDisplayType { get; set; }

        /// <summary>
        /// 分享图标形式展示大小
        /// </summary>
        public ShareDisplayIconSize ShareDisplayIconSize { get; set; }

    }
}