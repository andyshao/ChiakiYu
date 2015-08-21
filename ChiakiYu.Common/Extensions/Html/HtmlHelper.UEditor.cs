using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ChiakiYu.Common.Data;
using Newtonsoft.Json;

namespace ChiakiYu.Common.Extensions.Html
{
    /// <summary>
    /// UEditor的HtmlHelper输出方法
    /// </summary>
    public static class HtmlHelperUEditorExtensions
    {
        /// <summary>
        /// 输出UEditor编辑器
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString UEditor(this HtmlHelper htmlHelper, string name, string value = null, Dictionary<string, object> htmlAttributes = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return MvcHtmlString.Empty;
            }

            var builder = new TagBuilder("span");
            var htmlAttrs = new Dictionary<string, object>();
            if (htmlAttributes != null)
                htmlAttrs = new Dictionary<string, object>(htmlAttributes);
            var data = new Dictionary<string, object>();
            htmlAttrs.Add("data",JsonHelper.ToJson(data));
            builder.InnerHtml = htmlHelper.TextArea(name, value ?? string.Empty, htmlAttrs).ToString();
            return MvcHtmlString.Create(builder.ToString());
        }

        /// <summary>
        /// 利用ViewModel输出UEditor编辑器
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <param name="tenantTypeId"></param>
        /// <param name="associateId"></param>
        /// <param name="value"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString UEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string tenantTypeId, long associateId = 0, Dictionary<string, object> htmlAttributes = null)
        {

            TagBuilder builder = new TagBuilder("span");
            Dictionary<string, object> htmlAttrs = new Dictionary<string, object>();
            if (htmlAttributes != null)
                htmlAttrs = new Dictionary<string, object>(htmlAttributes);
            var data = new Dictionary<string, object>();
            data.Add("tenantTypeId", tenantTypeId);
            data.Add("associateId", associateId);
            htmlAttrs.Add("data", JsonHelper.ToJson(data));
            htmlAttrs.Add("plugin", "ueditor");
            builder.InnerHtml = htmlHelper.TextAreaFor(expression, htmlAttrs).ToString();
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
