using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ChiakiYu.Core.Data;

namespace ChiakiYu.Common.Extensions.Html
{
    /// <summary>
    ///     分页按钮控件
    /// </summary>
    public static class HtmlHelperPaginationExtensions
    {
        /// <summary>
        ///     呈现普通分页按钮
        /// </summary>
        /// <param name="paginationMode">分页按钮显示模式</param>
        /// <param name="html">被扩展的HtmlHelper</param>
        /// <param name="pagingList">数据集</param>
        /// <param name="numericPagingButtonCount">数字分页按钮显示个数</param>
        /// <returns>分页按钮html代码</returns>
        public static MvcHtmlString PagingButton
            (this HtmlHelper html,
                IPagingList pagingList,
                PaginationMode paginationMode = PaginationMode.NumericNextPrevious,
                int numericPagingButtonCount = 7)
        {
            return PagingButton(html, pagingList, false, null, paginationMode, numericPagingButtonCount);
        }

        /// <summary>
        ///     呈现异步分页按钮
        /// </summary>
        /// <param name="paginationMode">分页按钮显示模式</param>
        /// <param name="html">被扩展的HtmlHelper</param>
        /// <param name="pagingList">数据集</param>
        /// <param name="updateTargetId">异步分页时，被更新的目标元素Id</param>
        /// <param name="numericPagingButtonCount">数字分页按钮显示个数</param>
        /// <param name="ajaxUrl"></param>
        /// <returns>分页按钮html代码</returns>
        public static MvcHtmlString PagingButtonForAjax
            (this HtmlHelper html,
                IPagingList pagingList,
                string updateTargetId,
                PaginationMode paginationMode = PaginationMode.NumericNextPrevious,
                int numericPagingButtonCount = 7,
                string ajaxUrl = null)
        {
            return PagingButton(html, pagingList, true, updateTargetId, paginationMode, numericPagingButtonCount,
                ajaxUrl);
        }

        /// <summary>
        ///     呈现分页按钮
        /// </summary>
        /// <param name="html">被扩展的HtmlHelper</param>
        /// <param name="pagingList">数据集</param>
        /// <param name="enableAjax">是否使用ajax分页</param>
        /// <param name="updateTargetId">异步分页时，被更新的目标元素Id</param>
        /// <param name="paginationMode">分页按钮显示模式</param>
        /// <param name="numericPagingButtonCount">数字分页按钮显示个数</param>
        /// <param name="ajaxUrl"></param>
        /// <returns>分页按钮html代码</returns>
        private static MvcHtmlString PagingButton
            (this HtmlHelper html,
                IPagingList pagingList,
                bool enableAjax, string updateTargetId,
                PaginationMode paginationMode = PaginationMode.NumericNextPrevious,
                int numericPagingButtonCount = 7,
                string ajaxUrl = null)
        {
            if (pagingList == null)
                return MvcHtmlString.Empty;
            if (pagingList.TotalCount == 0 || pagingList.PageSize == 0)
                return MvcHtmlString.Empty;

            //计算总页数
            //var totalPages = (int) (pagingList.TotalCount/pagingList.PageSize);
            //if ((pagingList.TotalCount%pagingList.PageSize) > 0)
            //    totalPages++;
            var totalPages = pagingList.TotalPages;

            //未超过一页时不显示分页按钮
            if (totalPages <= 1)
                return MvcHtmlString.Empty;

            var showFirst = paginationMode == PaginationMode.NextPreviousFirstLast || paginationMode == PaginationMode.NumericNextPreviousFirstLast;

            var showLast = paginationMode == PaginationMode.NextPreviousFirstLast || paginationMode == PaginationMode.NumericNextPreviousFirstLast;

            var showPrevious = true;
            var showNext = true;

            var showNumeric = paginationMode == PaginationMode.NumericNextPrevious || paginationMode == PaginationMode.NumericNextPreviousFirstLast;

            //显示多少个数字分页按钮
            //int numericPageButtonCount = 10;

            //对pageIndex进行修正
            if ((pagingList.PageIndex < 1) || (pagingList.PageIndex > totalPages))
                pagingList.PageIndex = 1;

            var pagingContainer = new StringBuilder();
            pagingContainer.Append("<nav");
            //string pagingContainer = "<div class=\"tn-pagination-btn\"";
            if (enableAjax)
                pagingContainer.Append(" plugin=\"ajaxPagingButton\" data-updatetargetid=\"" + updateTargetId + "\"");
            pagingContainer.Append("><ul class=\"pager\">");

            var pagingButtonsHtml = new StringBuilder(pagingContainer.ToString());

            //构建 "首页"
            if (showFirst)
            {
                pagingButtonsHtml.AppendLine();

                if (pagingList.PageIndex == 1)
                    pagingButtonsHtml.Append("<li class=\"disabled\"><span>首页</span></li>");
                else
                    pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>首页</span></a></li>",
                        GetPagingNavigateUrl(html, 1, ajaxUrl));
            }

            //构建 "上一页"
            pagingButtonsHtml.AppendLine();
            if (pagingList.PageIndex == 1)
                pagingButtonsHtml.Append("<li class=\"disabled\"><span>上一页</span></li>");
            else
                pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>上一页</span></a></li>",
                    GetPagingNavigateUrl(html, pagingList.PageIndex - 1, ajaxUrl));
            //构建 数字分页部分
            if (showNumeric)
            {
                int startNumericPageIndex;
                if (numericPagingButtonCount > totalPages || pagingList.PageIndex - (numericPagingButtonCount / 2) <= 0)
                    startNumericPageIndex = 1;
                else if (pagingList.PageIndex + (numericPagingButtonCount / 2) > totalPages)
                    startNumericPageIndex = totalPages - numericPagingButtonCount + 1;
                else
                    startNumericPageIndex = pagingList.PageIndex - (numericPagingButtonCount / 2);

                if (startNumericPageIndex < 1)
                    startNumericPageIndex = 1;

                var lastNumericPageIndex = startNumericPageIndex + numericPagingButtonCount - 1;
                if (lastNumericPageIndex > totalPages)
                    lastNumericPageIndex = totalPages;

                if (startNumericPageIndex > 1)
                {
                    for (var i = 1; i < startNumericPageIndex; i++)
                    {
                        pagingButtonsHtml.AppendLine();

                        if (i > 3)
                            break;
                        if (i == 3)
                            pagingButtonsHtml.Append("<li><span>...</span></li>");
                        else
                        {
                            if (pagingList.PageIndex == i)
                                pagingButtonsHtml.AppendFormat("<li class=\"active\"><span>{0}</span></li>", i);
                            else
                                pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>{1}</span></a></li>",
                                    GetPagingNavigateUrl(html, i, ajaxUrl), i);
                        }
                    }
                }

                for (var i = startNumericPageIndex; i <= lastNumericPageIndex; i++)
                {
                    pagingButtonsHtml.AppendLine();
                    if (pagingList.PageIndex == i)
                        pagingButtonsHtml.AppendFormat("<li class=\"active\"><span>{0}</span></li>", i);
                    else
                        pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>{1}</span></a></li>",
                            GetPagingNavigateUrl(html, i, ajaxUrl), i);
                }

                if (lastNumericPageIndex < totalPages)
                {
                    var lastStart = lastNumericPageIndex + 1;
                    if (totalPages - lastStart > 2)
                        lastStart = totalPages - 2;

                    for (var i = lastStart; i <= totalPages; i++)
                    {
                        pagingButtonsHtml.AppendLine();
                        if ((i == lastStart) && (totalPages - lastNumericPageIndex > 3))
                        {
                            pagingButtonsHtml.AppendLine();
                            pagingButtonsHtml.Append("<li><span>...</span></li>");
                            continue;
                        }

                        if (pagingList.PageIndex == i)
                            pagingButtonsHtml.AppendFormat("<li class=\"active\"><span>{0}</span></li>", i);
                        else
                            pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>{1}</span></a></li>",
                                GetPagingNavigateUrl(html, i, ajaxUrl), i);
                    }
                }
            }
            //构建 "下一页"
            pagingButtonsHtml.AppendLine();
            if (pagingList.PageIndex == totalPages)
                pagingButtonsHtml.Append("<li class=\"disabled\"><span>下一页</span></li>");
            else
                pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>下一页</span></a></li>",
                    GetPagingNavigateUrl(html, pagingList.PageIndex + 1, ajaxUrl));
            //构建 "末页"
            if (showLast)
            {
                pagingButtonsHtml.AppendLine();
                if (pagingList.PageIndex == totalPages)
                    pagingButtonsHtml.Append("<li class=\"disabled\"><span>末页</span></li>");
                else
                    pagingButtonsHtml.AppendFormat("<li><a href=\"{0}\"><span>末页</span></a></li>",
                        GetPagingNavigateUrl(html, totalPages, ajaxUrl));
            }
            pagingButtonsHtml.Append("</ul></nav>");
            return MvcHtmlString.Create(pagingButtonsHtml.ToString());
        }

        /// <summary>
        ///     构建分页按钮的链接
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns>分页按钮的url字符串</returns>
        public static string GetPagingNavigateUrl(this HtmlHelper htmlHelper, int pageIndex, string currentUrl = null)
        {
            object pageIndexObj;
            if (htmlHelper.ViewContext.RouteData.Values.TryGetValue("pageIndex", out pageIndexObj))
            {
                htmlHelper.ViewContext.RouteData.Values["pageIndex"] = pageIndex;

                return UrlHelper.GenerateUrl(null, null, null, htmlHelper.ViewContext.RouteData.Values,
                    RouteTable.Routes, htmlHelper.ViewContext.RequestContext, true);
            }

            if (string.IsNullOrEmpty(currentUrl))
                currentUrl = HttpUtility.HtmlEncode(htmlHelper.ViewContext.HttpContext.Request.RawUrl);

            if (currentUrl.IndexOf("?", StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                return currentUrl + string.Format("?pageIndex={0}", pageIndex);
            }
            if (currentUrl.IndexOf("pageIndex=", StringComparison.InvariantCultureIgnoreCase) == -1)
                return currentUrl + string.Format("&pageIndex={0}", pageIndex);
            return Regex.Replace(currentUrl, @"pageIndex=(\d+\.?\d*|\.\d+)", "pageIndex=" + pageIndex,
                RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
    }

    /// <summary>
    ///     分页按钮显示模式
    /// </summary>
    public enum PaginationMode
    {
        /// <summary>
        ///     上一页/下一页 模式
        /// </summary>
        NextPrevious,

        /// <summary>
        ///     首页上一页/下一页/末页/ 模式
        /// </summary>
        NextPreviousFirstLast,

        /// <summary>
        ///     上一页/下一页 + 数字 模式，例如： 上一页 1 2 3 4 5 下一页
        /// </summary>
        NumericNextPrevious,

        /// <summary>
        ///     首页/上一页/下一页/末页 + 数字 模式，例如：首页 上一页 1 2 3 4 5 下一页 末页
        /// </summary>
        NumericNextPreviousFirstLast
    }
}