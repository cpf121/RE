//闭包（避免全局污染）
//加上分号（防止压缩出错）
;
(function (window, jQuery, undefined) {
    var config = {};
    var pageIndex = 1;
    var isAsc = 0;
    //自定义封装方法
    var custMethods = {
        //查询
        SearchResult: function (index) {
            index = index || pageIndex;
            var params = {
                SubjectCode: $('#hidSubjectCode').val(),
                UserName: $('#txtName').val(),
                Satus: $('#ddlSatus').val(),
                Terminal: $('#ddlTerminal').val(),
                BeginTime: $('#txtFromDate').val(),
                EndTime: $('#txtToDate').val(),
                CurrentPage: index
            };
            var url = basePath + "/SaasLog/SaaSLoginLogResultList";
            eLoading.show();
            $.post(url, params, function (data) {
                $("#dataResult").empty().append(data);
                $(".tips").eTip();
                pageIndex = index;
                var pager = new PagerView('pagerId');
                pager.index = index;
                pager.size = 10;
                pager.itemCount = $("#hidRecordCount").val();
                pager.onclick = function (i) {
                    custMethods.SearchResult(i);
                };
                pager.render();
                eLoading.hide();
            });
        }
    };

    //事件类
    var events = {
        //查询事件
        SearchEvent: function () {
            custMethods.SearchResult(1);
        },
      
    };

    //初始化类
    var page = {
        //初始化
        Init: function (fig) {
            config = fig;
            page.InitEvents();

        },
        //初始化事件
        InitEvents: function () {
            $("#btnSearch").click(events.SearchEvent);


        },
    };

    page.Init();

    //放出查询方法
    window.SearchResult = custMethods.SearchResult;

})(window, jQuery)