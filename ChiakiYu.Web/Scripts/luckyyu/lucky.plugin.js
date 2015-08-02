jQuery(function ($) {
    $(function () {
        //dialog弹层
        $("body").on("click", "[plugin='dialog']", function () {
            var url = $(this).data("href");
            var title = $(this).attr("title");
            var dialogLoading = $.Yu.loading();
            $.get(url, function (data) {
                dialogLoading.close().remove();
                var dialogForm = dialog({
                    id: "dialogForm",
                    backdropOpacity: 0.3,
                    title: title,
                    content: data,
                    padding: 0
                }).showModal();
            });
        });

        //Ajax分页PagingButtonForAjax
        $("body").on("click", "[plugin='ajaxPagingButton'] a", function (e) {
            e.preventDefault();
            var updateTargetId = $(this).parents("nav").data("updatetargetid");
            $.get($(this).attr("href"), function (html) {
                $("#" + updateTargetId).replaceWith(html);
            });
            return false;
        });

        //异步提交表单
        $("body").on("click", "[plugin='ajaxSubmit']", function (e) {
            e.preventDefault();
            var form = $(this).parents("form");
            var url = form.attr("action");
            $.Yu.ajaxSubmitForm(url, form.serialize());
        });

    });
    $.Yu = {
        ///ajax提交表单
        ajaxSubmitForm: function (url, data) {

            var dialogLoading = $.Yu.loading();

            $.ajax({
                type: "POST",
                url: url,
                data: data,
                dataType: "json",
                success: function (data) {

                    dialogLoading.close().remove();

                    if (data.MessageType === 1) {
                        dialog.get("dialogForm").close().remove();
                    }
                    $.Yu.tips(data.MessageContent, data.MessageType);
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    dialogLoading.close().remove();
                    $.Yu.tips("抱歉，系统出现错误，错误码：" + xmlHttpRequest.status, -1, 3000);
                }
            });
        },
        //加载中
        loading: function () {
            var dialogLoading = dialog({
                id: "dialogLoading",
                width: 50,
                height: 50
            }).show();

            return dialogLoading;
        },
        //提示
        tips: function (message, type, seconds) {
            var iconStr = "";
            if (type === 1) {
                iconStr = "<i class='fa fa-check fa-color-green fa-2x'></i>";
            }
            else if (type === 0) {
                iconStr = "<i class='fa fa fa-warning fa-color-yellow fa-2x'></i> ";
            }
            else if (type === -1) {
                iconStr = "<i class='fa fa-times fa-color-red fa-2x'></i> ";
            }
            if (!seconds)
                seconds = 2000;
            var dialogTips = dialog({
                content: iconStr + message
            }).show();
            setTimeout(function () {
                dialogTips.close().remove();
            }, seconds);
        }
    };

});