<!DOCTYPE html>

<head>
    <title>岡山榮家資訊系統</title>
    <script src="js/jquery-3.3.1.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>--%>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/mydesign.css" rel="stylesheet" />
    <link href="css/jquery-confirm.min.css" rel="stylesheet" />
    <script src="js/jquery-confirm.min.js"></script>
    <link href="css/fontawesome-all.min.css" rel="stylesheet" />
    <link href="DataTables/DataTables-1.10.16/css/dataTables.jqueryui.min.css" rel="stylesheet" />
    <script src="DataTables/DataTables-1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="DatetimePicker/js/bootstrap-datetimepicker.js"></script>
    <link href="DatetimePicker/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="DatetimePicker/js/locales/bootstrap-datetimepicker.zh-TW.js"></script>
    <%--    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>--%>
    <%--sweetalert主題--%>
    <script src="Scripts/sweetalert.min.js"></script>
    <link href="Content/sweetalert.css" rel="stylesheet" />
    <script src="charts/data.js"></script>
    <script src="charts/drilldown.js"></script>
    <script src="charts/highcharts.js"></script>
    <link href="DataTables/Responsive-2.2.1/css/responsive.bootstrap.css" rel="stylesheet" />
    <script src="DataTables/Responsive-2.2.1/js/dataTables.responsive.min.js"></script>
    <script src="DataTables/Responsive-2.2.1/js/responsive.bootstrap.min.js"></script>
    <script src="DataTables/Responsive-2.2.1/js/dataTables.responsive.js"></script>


    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/main.css">
    <script src="js/vendor/modernizr-2.6.2.min.js"></script>
</head>

<body>
    <div id="loader-wrapper">
        <div id="loader"></div>
        <div class="loader-section section-left">
        </div>
        <div class="loader-section section-right">
        </div>
    </div>
    <div class="wrapper">
        <!-- Sidebar Holder -->
        <nav id="sidebar">
            <div class="sidebar-header text-center">
                <h3>岡山榮家資訊系統</h3>
            </div>
            <ul class="list-unstyled components">
                <li>
                    <a href="#Secretary_Submenu" class="text-center " style="font-size: 17px;" data-toggle="collapse" aria-expanded="false"><b>秘書室</b></a>
                    <ul class="collapse list-unstyled" id="Secretary_Submenu">
                        <%--權限在這邊append--%>
                        <li>
                            <a id="new_Ss" onclick="Ss_Cconfirm()" href="#"><i class="fas fa-chevron-right"></i>新增每月工作管制表</a>
                        </li>
                        <li><a data-toggle="modal" data-target="#new_Ss_viewer_Modal" href="#"><i class="fas fa-chevron-right"></i>查詢工作管制表</a></li>
                        <li><a data-toggle="modal" data-target="#MessageBoard_Modal" href="#"><i class="fas fa-chevron-right"></i>留言板</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#IT_Submenu" class="text-center" style="font-size: 17px;" data-toggle="collapse" aria-expanded="false"><b>資訊室</b></a>
                    <ul class="collapse list-unstyled" id="IT_Submenu">
                        <li><a data-toggle="modal" data-target="#IT_Modal" href="#"><i class="fas fa-chevron-right"></i>報修資訊設備</a></li>
                        <li><a href="#" data-toggle="modal" data-target="#IT_DataTable_Modal" id="IT_search"><i class="fas fa-chevron-right"></i>查詢維修進度</a></li>
                        <%--<li><a href="#">預約資訊設備</a></li>--%>
                    </ul>
                </li>
                <li>
                    <a href="#plumber_Submenu" class="text-center" style="font-size: 17px;" data-toggle="collapse" aria-expanded="false"><b>水電班</b></a>
                    <ul class="collapse list-unstyled" id="plumber_Submenu">
                        <li><a data-toggle="modal" data-target="#plumber_Modal" href="#"><i class="fas fa-chevron-right"></i>填寫派修單</a></li>
                        <li><a href="#" data-toggle="modal" data-target="#Pulmber_DataTable_Modal" id="Plumber_search"><i class="fas fa-chevron-right"></i>水電班維修進度查詢</a></li>
                    </ul>
                </li>
                <li id="management"></li>
                <%--<li>
                <a href="#">Portfolio</a>
            </li>
            <li>
                <a href="#">Contact</a>
            </li>--%>
            </ul>

            <ul class="list-unstyled CTAs">
                <li><a id="Admin_Login" href="#" class="download" data-toggle="modal" data-target="#Login_page">Admin Login</a></li>
                <%--<li><a class="article">Back to article</a></li>--%>
            </ul>
            <br>
            <br>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><span style="font-size: 10px;">岡山榮家資訊室出版</span></div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><span style="font-size: 10px;">分機:316</span> </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><span style="font-size: 10px;">08:00 - 17:00 (一 ~ 五)</span> </div>
                <div class="col-md-2"></div>
            </div>
            <br>
            <br>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><span style="font-size: 10px;">Copyright © 2018 by NATHAN HUANG. All rights reserved.  <a href="#"><i class="fas fa-user-secret"></i></a></span></div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><span style="font-size: 10px;">Gangshan Veterans Home Only</span> </div>
                <div class="col-md-2"></div>
            </div>
        </nav>
        <!-- Page Content Holder -->
        <div id="content" style="width: 100%">
            <%--;background-color:#ffffff--%>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" id="sidebarCollapse" class="btn btn-info navbar-btn">
                            <i class="glyphicon glyphicon-align-left"></i>
                            <span>隱藏工具列</span>
                        </button>
                        <button type="button" class="btn btn-success navbar-btn" data-toggle="modal" data-target="#Announce_Modal">
                            <span>資訊室公告</span>
                        </button>

                    </div>
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <button id="Login_btn" class="btn btn-warning navbar-btn" type="button" data-toggle="modal" data-target="#Login_page">Login</button></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-md-9">
                    <%-- <div class="navbar navbar-default">
                        <div class="card">
                            <div class="card-header" id="headingOne">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" id="Ss_btn" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseTwo">正副首長 行程表 #1</button>
                                </h5>
                            </div>
                            <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                                <div class="card-body">
                                </div>
                            </div>
                            <div class="line"></div>
                        </div>
                    </div>--%>
                    <div class="navbar navbar-default">
                        <h2 class="text-center">正副首長行程表</h2>
                        <br>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-4" style="text-align: right">
                                <div class="text-center input-group date" id="Index_viewer_picker" data-date="">
                                    <input class="form-control" id="Index_date_picker_input" placeholder="請選擇查詢日期" size="16" type="text" value="" readonly>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                            <div class="col-md-4" style="text-align: left">
                                <button type="button" id="Index_newSs_searchWeek" class="btn btn-danger">顯示(當週)行程</button>
                                <button type="button" id="Index_newSs_searchToday" class="btn btn-default">顯示今日行程</button>
                            </div>
                        </div>
                        <table id="Leader_S_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                            <thead>
                                <tr style="text-align: left;">
                                    <th>時間</th>
                                    <th>工作項目</th>
                                    <th>地點</th>
                                    <th>主持人</th>
                                    <th>參加人員</th>
                                    <th>承辦人</th>
                                </tr>
                            </thead>

                        </table>
                    </div>
                    <%--<div class="line"></div>--%>
                    <div class="navbar navbar-default">
                        <h2 class="text-center">各組室（堂隊）會議、活動</h2>
                        <table id="group_S_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                            <thead>
                                <tr style="text-align: left;">
                                    <th>時間</th>
                                    <th>工作項目</th>
                                    <th>地點</th>
                                    <th>主持人</th>
                                    <th>參加人員</th>
                                    <th>承辦人</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <%--<div class="line"></div>--%>
                    <%--員工部外開會、講習、受訓--%>
                    <div class="navbar navbar-default">
                        <h2 class="text-center">員工部外開會、講習、受訓</h2>
                        <table id="group_Sout_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                            <thead>
                                <tr style="text-align: left;">
                                    <th>時間</th>
                                    <th>受訓(開會)項目</th>
                                    <th>地點</th>
                                    <th>主持人</th>
                                    <th>參訓人員</th>
                                    <th>承辦人</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <%--<div class="line"></div>--%>
                    <div class="navbar navbar-default">
                        <h2 class="text-center">組室主管、堂隊長出勤狀況</h2>
                        <table id="PR_Leaving_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                            <thead>
                                <tr style="text-align: left;">
                                    <th>時間</th>
                                    <th>人員</th>
                                    <th>假由</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="navbar navbar-default">
                        <h2 class="text-center">相關連結</h2>
                        <br>
                        <p>
                            <a href="https://www.vac.gov.tw/vac_home/gangshan/mp-213.html"><i class="fas fa-globe"></i>岡山榮家官方網站</a><br>
                            <a href="https://www.vghks.gov.tw/"><i class="fas fa-globe"></i>高雄榮總官網</a><br>
                            <a href="https://zh-tw.libreoffice.org/"><i class="fas fa-globe"></i>LibreOffice官方網站</a><br>
                            <a href="https://www.facebook.com/%E5%B2%A1%E5%B1%B1%E6%A6%AE%E8%AD%BD%E5%9C%8B%E6%B0%91%E4%B9%8B%E5%AE%B6-394369230738698/"><i class="fab fa-facebook-square"></i>岡山榮家臉書粉絲團</a><br>
                            <a href="http://service.vac.gov.tw:210/"><i class="fas fa-file-alt"></i>行政網</a><br>
                            <a href="http://dms.hq.vac.gov.tw/odis_vacc/"><i class="fas fa-file-alt"></i>文檔資訊系統</a><br>
                            <a href="http://caretest.vac.gov.tw/wevac3/auth/login?targetUri=%2F"><i class="fas fa-file-alt"></i>榮家安養養護管理資訊系統</a><br>
                            <a href="http://caretest.vac.gov.tw/wevac3/auth/login?targetUri=%2F"><i class="fas fa-file-alt"></i>(測試版)榮家安養養護管理資訊系統</a><br>
                            <a href="https://ecpa.dgpa.gov.tw/"><i class="fas fa-file-alt"></i>人事服務網</a><br>
                            <a href="https://elearn.hrd.gov.tw/mooc/index.php"><i class="fas fa-graduation-cap"></i>E等公務員學習平台</a><br>
                            <a href="https://www.ndc.gov.tw/cp.aspx?n=32A75A78342B669D"><i class="fas fa-graduation-cap"></i>國發會ODF文件應用工具</a><br>
                            <a href="https://www.google.com.tw/"><i class="fab fa-google"></i>Google</a><br>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <%--oncontextmenu="return false" 鎖右鍵--%>

    <script>
        var global_user;
        $(document).ready(function () {
            $('#Login_submit').on('click', function () {
                $.ajax({
                    url: "Login_ajax.asmx/Login_admin",
                    method: "post",
                    dataType: "json",
                    data: { account: $('#Loign_Account').val(), psw: $('#Login_psw').val() },
                    success: function (data) {
                        global_user = data[0].user;
                        account_user = data[0].user;
                        account_authority = data[0].authority;

                        switch (data[0].authority) {
                            case "s":
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text('SuperAdmin');
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text('SuperAdmin');
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                $(management).append(
                                    '<a href="#management_Submenu" class="text-center" style="font-size:17px;" data-toggle="collapse" aria-expanded="false"><b>管理頁面</b></a>' +
                                    '<ul class="collapse list-unstyled text-center" id="management_Submenu">' +
                                    '<li><a data-toggle="modal" data-target="#Secretary_management_Modal" id="Secretary_management" href="#"><i class="fas fa-lock-open"></i>  秘書室管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#IT_management_Modal" id ="IT_management" href="#"><i class="fas fa-lock-open"></i>  資訊室管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#Pulmber_management_Modal" id="Plumber_management" href="#"><i class="fas fa-lock-open"></i>  水電班管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#PersonnelRoom_management_Modal" id="PersonnelRoom_management" href="#"><i class="fas fa-lock-open"></i>  人事室管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#Account_management_Modal" id="Account_management" href="#"><i class="fas fa-lock-open"></i>  使用者管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#IT_Announcement_management_Modal" id="IT_Announcement_management" href="#"><i class="fas fa-lock-open"></i>  公告板管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#Databse_statistic_Modal" onclick="charts()" id="Databse_statistic" href="#"><i class="fas fa-chart-bar"></i>  資料庫統計</a></li>' +
                                    '</ul>'
                                );
                                Load_Secretary_ManageDatatable();
                                Load_IT_ManageDatetable();
                                Load_Pulmber_ManageDatatable();
                                Load_PR_Datatable();
                                Load_Account_ManageDatatable();
                                Load_ITAnnounce_ManageDatatable();
                                break;
                            case "1"://水電
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text('水電班(' + data[0].user + ')');
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text('水電班(' + data[0].user + ')');
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                $(management).append(
                                    '<a href="#management_Submenu" class="text-center" data-toggle="collapse" aria-expanded="false">管理頁面</a>' +
                                    '<ul class="collapse list-unstyled" id="management_Submenu">' +
                                    '<li><a data-toggle="modal" data-target="#Pulmber_management_Modal" id="Plumber_management" href="#"><i class="fas fa-lock-open"></i>  水電班管理</a></li>' +
                                    '</ul>'
                                );
                                Load_Pulmber_ManageDatatable();
                                break;
                            case "2"://秘書
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text('秘書室(' + data[0].user + ')');
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text('秘書室(' + data[0].user + ')');
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                $(management).append(
                                    '<a href="#management_Submenu" class="text-center" data-toggle="collapse" aria-expanded="false">管理頁面</a>' +
                                    '<ul class="collapse list-unstyled" id="management_Submenu">' +
                                    '<li><a data-toggle="modal" data-target="#Secretary_management_Modal" id="Secretary_management" href="#"><i class="fas fa-lock-open"></i>  秘書室管理</a></li>' +
                                    '</ul>'
                                );
                                Load_Secretary_ManageDatatable();
                                break;
                            case "3"://資訊室(非超級管理者)
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text('資訊室(' + data[0].user + ')');
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text('資訊室(' + data[0].user + ')');
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                $(management).append(
                                    '<a href="#management_Submenu" class="text-center" data-toggle="collapse" aria-expanded="false">管理頁面</a>' +
                                    '<ul class="collapse list-unstyled" id="management_Submenu">' +
                                    '<li><a data-toggle="modal" data-target="#Secretary_management_Modal" id="Secretary_management" href="#"><i class="fas fa-lock-open"></i>  秘書室管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#IT_management_Modal" id ="IT_management" href="#"><i class="fas fa-lock-open"></i>  資訊室管理</a></li>' +
                                    '<li><a data-toggle="modal" data-target="#Pulmber_management_Modal" id="Plumber_management" href="#"><i class="fas fa-lock-open"></i>  水電班管理</a></li>' +
                                    '</ul>'
                                );
                                Load_Secretary_ManageDatatable();
                                Load_IT_ManageDatetable();
                                Load_Pulmber_ManageDatatable();
                                break;
                            case "4"://堂隊
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text(data[0].user);
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text(data[0].user);
                                $(plumber_Submenu).append(
                                    '<li><a data-toggle="modal" data-target="#Plumber_Acceptance_Modal" id="Plumber_Acceptance" onclick="" href="#"><i class="fas fa-clipboard-check"></i>  水電維修確認</a></li>'
                                );
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                Load_Acceptance_DataTable();
                                break;
                            case "5"://人事室
                                $(Admin_Login).removeAttr('href data-target');
                                $(Admin_Login).text(data[0].user);
                                $(Login_btn).attr('disabled', true);
                                $(Login_btn).text(data[0].user);
                                $(plumber_Submenu).append(
                                    '<li><a data-toggle="modal" data-target="#Plumber_Acceptance_Modal" id="Plumber_Acceptance" onclick="" href="#"><i class="fas fa-clipboard-check"></i>  水電維修確認</a></li>'
                                );
                                $(management).append(
                                    '<a href="#management_Submenu" class="text-center" data-toggle="collapse" aria-expanded="false">管理頁面</a>' +
                                    '<ul class="collapse list-unstyled" id="management_Submenu">' +
                                    '<li><a data-toggle="modal" data-target="#PersonnelRoom_management_Modal" id="PersonnelRoom_management" href="#"><i class="fas fa-lock-open"></i>  人事室管理</a></li>' +
                                    '</ul>'
                                );
                                console.log("權限: " + data[0].authority);
                                $('#Login_page').modal('hide');
                                Load_PR_Datatable();
                                Load_Acceptance_DataTable();
                                break;

                        }
                    },
                    error: function (err) { },

                });

            });
        });
    </script>
    <script>             
        function Ss_Cconfirm() {
            $.confirm({
                title: '',
                icon: 'fas fa-minus-circle',
                content:
                '<div style="text-align: center;">' +
                '<h3 style="text-align: center;">新增每月工作管制表<h3>' +
                '<h3>使用條款<h3>' +
                '</div>' +
                '<div style="text-align: left;">' +
                '<h5>一、使用對象:公務員<br><h5>' +
                '<h5 >二、使用目的:新增工作管制表行程<br><h5>' +
                '<h5 style="text-align: center;"> (含 員工部外開會、講習、受訓)<br><h5>' +
                '<h5>三、非以上條件者請勿操作，如發現惡作劇或是冒名須接受最嚴厲之處分。<h5>' +
                '<h5 style="text-align: center;">(所有操作都將記錄在資訊室伺服器內)<h5>' +
                '</div>',
                type: 'orange',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: '確定',
                        btnClass: 'btn-green',
                        action: function () {
                            $(new_Ss_Modal).modal('show');
                            initial_datetimepicker_input();
                        }
                    },
                    close: {
                        text: '取消',
                        btnClass: 'btn-red',
                    }
                }
            });
        };
    </script>

    <!--每月工作表 Modal -->
    <div class="modal fade" id="new_Ss_Modal" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="new_Ss_Modal_cancel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="fas fa-cube"></span>新增每月工作預定表</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="label_repairs">時間:</label>
                                <div class="input-group date" id="new_Ss_datetimepicker">
                                    <input id="new_Ss_dateAndtime_input" type="text" class="form-control" placeholder="*必填" disabled />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="label_time">預計結束時間:</label>
                                <div class='input-group date' id='datetimepicker_Hi'>
                                    <input id="datetimepicker_Hi_input" type='text' class="form-control" placeholder="選填" disabled />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-time"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="dropdown">
                                <label for="label_repairs" class="col-lg-2">工作項目:</label>
                                <div class="col-sm-12">
                                    <textarea class="form-control" id="new_Ss_Modal_Work" placeholder="*必填 例如:XX辦法及相關規定講習"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_local" class="col-sm-2">地點:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="new_Ss_Modal_local" placeholder="*必填 例如:松柏廳">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_host" class="col-sm-2">主持人:</label>
                                <div class="col-sm-12" id="host_div">
                                    <select id="Host_select" class="form-control" onclick="Selected_host(this)" name="category">
                                        <option value="0">請選擇主持人</option>
                                        <option value="1">家主任</option>
                                        <option value="2">副主任</option>
                                        <option value="3">秘書主任</option>
                                        <option value="4">人事主任</option>
                                        <option value="5">主計主任</option>
                                        <option value="6">政風主任</option>
                                        <option value="7">輔導組長</option>
                                        <option value="8">保健組長</option>
                                        <option value="9">其他主持人(自填)</option>
                                    </select>
                                    <br>
                                    <input type="text" class="form-control" id="new_Ss_Modal_host" placeholder="*其他主持人(自填)" disabled>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="form-control-label col-sm-2">參加人員:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="new_Ss_Participants" placeholder="*必填 例如:家主任、副主任(兩個以上人員請用 頓號、 或是 空一格 分開)">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_host" class="col-sm-2">承辦人:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="new_Ss_Modal_duty" placeholder="*必填 例如:堂長">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4  text-center">
                        <button type="submit" id="new_Ss_Modal_submit" class="btn btn-warning">送出</button>
                    </div>
                    <div class="col-sm-4"></div>
                </div>

            </div>
        </div>
    </div>

    <script>
        var Ss_Msg_Board;
        $(document).ready(function () {
            Ss_Msg_Board = $('#Ss_MessageBoard_table').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": true,
                "responsive": true,
                "pageLength": 5,
                "fixedColumns": {
                    leftColumns: 2
                },
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "MsgBoard.asmx/get_Message",
                    "type": "GET",
                    "datatype": "json",
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;

                        return json.data;
                    },
                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無任何留言",
                    "sInfo": "留言總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何留言",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    {
                        "data": "commenter", "name": "commenter",
                        "render": function (data) {
                            return '<div  class="text-center" >' + data + '</div>';
                        }
                    },
                    {
                        "data": "insert_date", "name": "insert_date",
                        "render": function (data) {
                            return '<div  class="text-center" >' + data + '</div>';
                        }
                    },
                    {
                        "data": "feedback", "name": "feedback",
                        "render": function (data) {
                            if (data.length != 0)
                                return '<i  class="fas fa-check"></i>';
                            else
                                return '<i  class="fas fa-times"></i>';
                        }
                    },
                    {
                        "data": "strId", "name": "strId",
                        "render": function (data) {
                            return '<a href="#" class="text-center" onclick="feedback_Msg(\'' + data + '\')"><i class="fas fa-search">回覆</i></a>';
                        }
                    },
                ],
                "columnDefs": [
                    {
                        "className": "dt-center", "targets": "_all",
                    }],
            });
        });
        function feedback_Msg(ID) {
            $.ajax({
                url: "MsgBoard.asmx/Msg_SearchByID",
                method: "post",
                dataType: "json",
                data: {
                    ID: ID,
                },
                success: function (data) {
                    $.confirm({
                        icon: 'far fa-user',
                        title: '詳情',
                        content:
                        '<form action="" class="formName">' +
                        '<div class="form-group">' +
                        '<label>留言人:</label>' +
                        '<input type="text" readonly class="edit_MessageDetail_Commenter form-control" value="' + data[0].commenter + '">' +
                        '</div>' +
                        '<form action="" class="formName">' +
                        '<div class="form-group">' +
                        '<label>分機:</label>' +
                        '<input type="text" readonly class="edit_MessageDetail_Phone form-control" value="' + data[0].phone + '">' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>留言時間:</label>' +
                        '<input type="text" readonly class="edit_MessageDetail_InsertTime form-control" value="' + data[0].insert_date + '">' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>留言內容:</label>' +
                        '<textarea rows="5" readonly class="edit_MessageDetail_Info form-control" >' + data[0].message + '</textarea>' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>回覆:</label>' +
                        '<textarea rows="5" class="edit_MessageDetail_Feedback form-control" >' + data[0].feedback + '</textarea>' +
                        '</div>' +
                        '</form>',

                        type: 'yellow',
                        typeAnimated: true,
                        buttons: {
                            submit: {
                                text: '回覆',
                                btnClass: 'btn-blue',
                                action: function () {
                                    var ID = data[0].strId;
                                    var Feedback = this.$content.find('.edit_MessageDetail_Feedback').val();
                                    $.ajax({
                                        url: "MsgBoard.asmx/Msg_updateFeedback",
                                        method: "post",
                                        dataType: "json",
                                        data: {
                                            ID: ID,
                                            info: Feedback
                                        },
                                        success: function (data) {
                                            Ss_Msg_Board.ajax.reload();
                                            $.confirm({
                                                icon: 'fas fa-check',
                                                title: '成功',
                                                content: '回覆成功',
                                                type: 'orange',
                                                typeAnimated: true,
                                                buttons: {
                                                    tryAgain: {
                                                        text: '返回',
                                                        btnClass: 'btn-green',
                                                        action: function () {
                                                        }
                                                    },
                                                }
                                            });
                                        },
                                        error: function (err) {

                                        },

                                    });
                                }
                            },
                            back: {
                                text: '返回',
                                btnClass: 'btn-red',
                            },
                        },
                        //onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                        //    // bind to events
                        //    var jc = this;
                        //    this.$content.find('form').on('submit', function (e) {
                        //        // if the user submits the form by pressing enter in the field.
                        //        e.preventDefault();
                        //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                        //    });
                        //}
                    });
                },
                error: function (err) { }

            });

        }

    </script>

    <%--行程表管理--%>
    <div id="Secretary_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="Secretary_management_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="glyphicon glyphicon-copy"></span>工作預定表管理</h4>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3" style="text-align: center">
                        <button type="button" id="Feedback_MsgBoard" class="btn btn-info" data-toggle="modal" data-target="#Ss_MessageBoard_Modal">查看留言</button>
                        <button type="button" id="Download_Form" class="btn btn-primary" data-toggle="modal" data-target="#Ss_DownloadForm_Modal">下載表格</button>
                    </div>
                    <div class="col-md-6">
                        <div class="text-center input-group date" id="Secretary_management_picker" data-date="">
                            <input class="form-control" id="SM_date_picker_input" placeholder="請選擇查詢日期" size="16" type="text" value="" readonly>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <button type="button" id="SM_newSs_search" class="btn btn-success">搜尋</button>
                    </div>
                </div>
                <div class="modal-body">
                    <table id="Secretary_management_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>行程時間</th>
                                <th>工作項目</th>
                                <th>地點</th>
                                <th>主持人</th>
                                <th>參加人員</th>
                                <th>承辦人</th>
                                <th>分類</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>行程時間</th>
                                <th>工作項目</th>
                                <th>地點</th>
                                <th>主持人</th>
                                <th>參加人員</th>
                                <th>承辦人</th>
                                <th>分類</th>
                                <th>操作</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <br />
            </div>
        </div>
    </div>
    <!--管理每月工作表 Modal -->
    <script>
        $(document).ready(function () {

            setTimeout(function () {
                $('body').addClass('loaded');
                $('h1').css('color', '#222222');
                $(Announce_Modal).modal('show');
            }, 3000);


        });
    </script>
    <%--    <script>
        $(document).ready(function () {
            $(Announce_Modal).modal('show');
        });

    </script>--%>
    <div id="Announce_Modal" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #5cb85c;">
                    <button type="button" id="Announce_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #5cb85c;"><span class="glyphicon glyphicon-copy"></span>資訊室公告</h4>
                </div>
                <br />
                <div class="modal-body">
                    <table id="IT_announcements" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>


    <div id="MessageBoard_Modal" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="MessageBoard_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="glyphicon glyphicon-copy"></span>留言板</h4>
                </div>
                <br />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4 text-left">
                            <button type="button" id="new_Message" class="btn btn-warning">新增留言</button>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                    </div>
                    <br />
                    <table id="MessageBoard_table" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr>
                                <th style="text-align: center;">留言人</th>
                                <th style="text-align: center;">留言時間</th>
                                <th style="text-align: center;">是否回覆</th>
                                <th style="text-align: center;">詳情</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="Ss_MessageBoard_Modal" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="Ss_MessageBoard_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="glyphicon glyphicon-copy"></span>留言板回覆</h4>
                </div>
                <br />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                    </div>
                    <br />
                    <table id="Ss_MessageBoard_table" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr>
                                <th style="text-align: center;">留言人</th>
                                <th style="text-align: center;">留言時間</th>
                                <th style="text-align: center;">是否回覆</th>
                                <th style="text-align: center;">回覆</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="Secretary_management_schedule_Modal" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="Secretary_management_cancel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="fas fa-cube"></span>管理模式</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>資料庫ID:</label>
                                <input id="Sms_Increment" type="text" disabled class="form-control" readonly>
                                <small id="Sms_ip" class="form-text text-muted"></small>
                            </div>
                            <div class="col-md-6">
                                <label>建檔時間:</label>
                                <input id="File_time" type="text" disabled class="form-control" readonly>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="label_repairs">時間:</label>
                                <div class="input-group date" id="Secretary_management_datetimepicker">
                                    <input id="Secretary_management_datetimepicker_input" type="text" class="form-control" disabled />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="label_time">預計結束時間:</label>
                                <div class='input-group date' id='Secretary_management_end'>
                                    <input id="Secretary_management_end_input" type='text' class="form-control" disabled />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-time"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dropdown">
                                <label for="label_repairs" class="col-lg-2">工作項目:</label>
                                <div class="col-sm-12">
                                    <textarea class="form-control" id="Sms_Modal_Work"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_local" class="col-sm-2">地點:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="Sms_Modal_local">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_host" class="col-sm-2">主持人:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="Sms_Modal_host">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="form-control-label col-sm-2">參加人員:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="Sms_Participants">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_host" class="col-sm-2">承辦人:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="Sms_Modal_duty">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_Sms_select" class="col-sm-2">審核:</label>
                                <div class="col-sm-12 select_status">
                                    <select id="Sms_select" class="form-control" name="category">
                                        <option value="未審核">未審核</option>
                                        <option value="正副首長行程">正副首長行程</option>
                                        <option value="各組室(堂隊)會議、活動">各組室(堂隊)會議、活動</option>
                                        <option value="員工部外開會、講習、受訓">員工部外開會、講習、受訓</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4  text-center">
                        <button type="submit" id="Sms_Modal_submit" class="btn btn-warning">送出</button>
                    </div>
                    <div class="col-sm-4"></div>
                </div>
            </div>
        </div>
    </div>

    <script>   //管理    
        var Ss_management;
        var Management_Ss_info = "";
        function Load_Secretary_ManageDatatable() {
            $(document).ready(function () {
                Ss_management = $('#Secretary_management_DataTable').DataTable({
                    "serverSide": true,
                    "searching": false,
                    "responsive": true,
                    "pageLength": 5,
                    //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                    "ajax": {
                        "url": "SearchNew_schedule.asmx/DateTime_search",
                        "type": "GET",
                        "datatype": "json",
                        "data": function (d) {
                            //d.search = $('#SM_date_picker_input').val();
                            if ($('#SM_date_picker_input').val().length > 0) {
                                d.search = $('#SM_date_picker_input').val() + ",0";//秘書這裡沒有每週月功能 直接放0
                            }
                            else {
                                d.search = "";
                            }
                        },
                        "dataSrc": function (json) {
                            json.draw = json.data.draw;
                            json.recordsTotal = json.data.iTotalRecords;
                            json.recordsFiltered = json.data.iTotalDisplayRecords;
                            return json.data;
                        }

                    },

                    "oLanguage": {
                        "sProcessing": "處理中...",
                        "sLengthMenu": "顯示 _MENU_ 筆記錄",
                        "sZeroRecords": "無符合資料",
                        "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                        "sInfoEmpty": "無任何資料",
                        "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                        "sInfoPostFix": "",
                        "sSearch": "搜尋",
                        "sUrl": "",
                        "oPaginate": {
                            "sFirst": "首頁",
                            "sPrevious": "上頁",
                            "sNext": "下頁",
                            "sLast": "末頁"
                        }
                    },
                    "columns": [//Secretary_management_DataTable
                        {
                            "data": "S_time", "name": "S_time", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "Work_item", "name": "Work_item", "autoWidth": true,
                            "render": function (data, type) {
                                if (type === 'display') {
                                    if (data.length > 13) {
                                        return '<div class="text-center" title="' + data + '">' + data.substr(0, 12) + '...</div>';
                                    } else {
                                        return '<div class="text-center" title="' + data + '">' + data + '</div>';
                                    }
                                }
                                return data;
                            }
                        },
                        {
                            "data": "Local", "name": "Local", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "S_host", "name": "S_host", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "Participants", "name": "Participants", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "Duty", "name": "Duty", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "Status", "name": "Status", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center" >' + data + "</div>";
                            }
                        },
                        {
                            "data": "Id.Increment", "name": "Id.Increment", "autoWidth": true,
                            "render": function (data) {
                                return '<div class="text-center"><a data-toggle="modal" data-target="#Secretary_management_schedule_Modal" href="#" onclick="AddEditID_Schedule(' + data + ')"><i class="fas fa-edit"></i></a>     ' +
                                    '<a style="width:80px" href="#" id="Delete_Schedule" onclick="Delete_schedule(' + data + ')"><i class="fas fa-trash-alt"></i></a>'
                                    + "</div>";
                            }
                        },
                    ],
                    "columnDefs": [
                        {
                            "className": "dt-center", "targets": "_all",
                        },
                    ],
                });
            });
        }
        function Delete_schedule(data) {
            $.confirm({
                icon: 'fas fa-minus-circle',
                title: '確認刪除',
                content: '刪除行程表 ' + data,
                type: 'red',
                typeAnimated: true,
                buttons: {
                    Submit: {
                        text: '刪除',
                        btnClass: 'btn-red',
                        action: function () {
                            $.ajax({
                                url: "SearchNew_schedule.asmx/delete",
                                method: "post",
                                dataType: "json",
                                data: {
                                    ID: data,
                                },
                                success: function (data) {
                                    swal({
                                        title: "成功刪除!",
                                        text: data,
                                        type: "success",
                                        showCancelButton: true,
                                        confirmButtonClass: "btn-success",
                                        confirmButtonText: "確定",
                                        cancelButtonText: "取消",
                                        closeOnConfirm: false
                                    });
                                    Ss_management.ajax.reload();
                                },
                                error: function (err) { }
                            })
                        }
                    },
                    Cannel: {
                        text: '取消',
                        btnClass: 'btn-green',
                    },
                }
            });

        }
        var temp_begin_time;
        var temp_end;
        function AddEditID_Schedule(data) {
            $.ajax({
                url: "SearchNew_schedule.asmx/Schedule_searchByID",
                method: "post",
                dataType: "json",
                data: {
                    ID: data,
                },
                success: function (data) {
                    //$(Secretary_management_Modal).modal('hide');
                    //Ss_management.ajax.reload();
                    $(Sms_Increment).val(data[0].Increment);
                    $(Sms_Modal_Work).text(data[0].Work_item);
                    $(Sms_Modal_local).val(data[0].Local);
                    $(Sms_Modal_host).val(data[0].S_host);
                    $(Sms_Participants).val(data[0].Participants);
                    $(Sms_Modal_duty).val(data[0].Duty);
                    $(Secretary_management_end_input).val(data[0].S_end_time);
                    $(Secretary_management_datetimepicker_input).val(data[0].S_time);
                    $(File_time).val(data[0].Insert_time);
                    $(Sms_ip).text(data[0].Ip);
                    temp_begin_time = data[0].S_time;
                    temp_end = data[0].S_end_time;
                    switch (data[0].Status) {
                        case "未審核":
                            $("#Sms_select").val("未審核");
                            break;
                        case "正副首長行程":
                            $("#Sms_select").val("正副首長行程");
                            break;
                        case "各組室(堂隊)會議、活動":
                            $("#Sms_select").val("各組室(堂隊)會議、活動");
                            break;
                        case "員工部外開會、講習、受訓":
                            $("#Sms_select").val("員工部外開會、講習、受訓");
                            break;

                    }
                    //設定管理模式 資料
                },
                error: function (err) {

                },

            });
        }
        $('#SM_newSs_search').on('click', function () {
            Ss_management.ajax.reload();
        });
        $(document).ready(function () {
            $(document).on('click', '#Sms_Modal_submit', function () {
                check_Ss();
                if (Management_Ss_info.length == 0) {
                    console.log("temp = " + temp_begin_time + "," + temp_end + " 改變後 = " + $(Secretary_management_datetimepicker_input).val() + "," + $(Secretary_management_end_input).val());
                    if (temp_begin_time != $(Secretary_management_datetimepicker_input).val() || temp_end != $(Secretary_management_end_input).val()) {
                        Secretary_Check_Director_host(0);
                    }
                    else {
                        console.log("else");
                        update_Secretary_management_schedule();
                    }
                }
                else {
                    $.confirm({
                        icon: 'fas fa-minus-circle',
                        title: '錯誤',
                        content: Management_Ss_info,
                        type: 'red',
                        typeAnimated: true,
                        buttons: {
                            tryAgain: {
                                text: '返回',
                                btnClass: 'btn-red',
                                action: function () {
                                }
                            },
                        }
                    });
                    console.log("格式驗證  失敗 " + Management_Ss_info);
                }
            });
        });

        function Secretary_Check_Director_host(interval) {
            console.log("進入 Check_Director_host");
            $.ajax({
                url: "SearchNew_schedule.asmx/Check_Director_host_ajax",
                method: "post",
                dataType: "json",
                data: {
                    host_postition: $(Sms_Modal_host).val(),
                    S_Begin_time: $(Secretary_management_datetimepicker_input).val(),
                    S_End_time: $(Secretary_management_end_input).val(),
                    interval_time: interval
                },
                success: function (data) {
                    //console.log("[Check_Director_host ]" + data);

                    if (data[0].Time_TorF == false) {
                        $.confirm({
                            title: '更改 ' + $(Sms_Modal_host).val() + ' 行程存在重複風險',
                            content: '<span style="font-weight:bold;color:blue;">' + "您所更改時段為:</span><br>" + $(Secretary_management_datetimepicker_input).val() + " - " + $(Secretary_management_end_input).val() + "<br>" + '<small class="form-text text-muted" >' + "[ID:" + $(Sms_Increment).val() + "]" + '</small>'
                            + '<br><br><span style="font-weight:bold;color:red;">' + $(Sms_Modal_host).val() + ' 已安排行程時間:</span><br>' + data[0].Not_Advice_Time
                            + '<br><span style="font-weight:bold;color:green;">' + $(Sms_Modal_host).val() + ' 未排行程時間:</span><br>' + data[0].Advice_Time,
                            type: 'red',
                            typeAnimated: true,
                            buttons: {
                                submit: {
                                    text: '確定',
                                    btnClass: 'btn-red',
                                    action: function () {
                                        update_Secretary_management_schedule();
                                    }
                                },
                                tryAgain: {
                                    text: '返回',
                                    btnClass: 'btn-green',
                                },
                            }
                        });
                    }
                    else {
                        update_Secretary_management_schedule();
                    }
                },
                error: function (err) {
                    console.log("[Check_Director_host 執行失敗]" + JSON.stringify(err) + "overtime = " + JSON.stringify(over_time));
                }
            });
        }
        function update_Secretary_management_schedule() {
            $.ajax({
                url: "SearchNew_schedule.asmx/Schedule_update",
                method: "post",
                dataType: "json",
                data: {
                    ID: $(Sms_Increment).val(),
                    time: $(Secretary_management_datetimepicker_input).val(),
                    end_time: $(Secretary_management_end_input).val(),
                    Work_item: $(Sms_Modal_Work).val(),
                    local: $(Sms_Modal_local).val(),
                    host: $(Sms_Modal_host).val(),
                    Participants: $(Sms_Participants).val(),
                    Duty: $(Sms_Modal_duty).val(),
                    status: $(Sms_select).val()
                },
                success: function (data) {
                    console.log("送出按鈕" + data);
                    $('#Secretary_management_schedule_Modal').modal('hide');
                    Ss_management.ajax.reload();
                    new_Ss.ajax.reload();
                    console.log("格式驗證 成功 " + Management_Ss_info.length);
                    swal("系統訊息", data, "success");
                },
                error: function (err) { }
            });



        }
    </script>


    <div id="new_Ss_viewer_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #f0ad4e;">
                    <button type="button" id="new_Ss_viewer_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #f0ad4e;"><span class="glyphicon glyphicon-copy"></span>工作預定表查詢</h4>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-5" style="text-align: right">
                        <div class="text-center input-group date" id="new_Ss_viewer_picker" data-date="">
                            <input class="form-control" id="date_picker_input" placeholder="請選擇查詢日期再按每(日)(週)或(月)按鈕" size="16" type="text" value="" readonly>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: left">
                        <button type="button" id="newSs_search" class="btn btn-success">每(日)</button>
                        <button type="button" id="newSs_searchWeek" class="btn btn-primary">每(週)</button>
                        <button type="button" id="newSs_searchMonth" class="btn btn-info">每(月)</button>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>
                <div class="modal-body">
                    <table id="new_Ss_viewer_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>時間</th>
                                <th>工作項目</th>
                                <th>地點</th>
                                <th>主持人</th>
                                <th>參加人員</th>
                                <th>承辦人</th>
                                <th>狀態</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>時間</th>
                                <th>工作項目</th>
                                <th>地點</th>
                                <th>主持人</th>
                                <th>參加人員</th>
                                <th>承辦人</th>
                                <th>狀態</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script> 

</script>
    <script>        
        var new_Ss;
        var status = 0;
        $(document).ready(function () {
            var ss = $('#new_Ss_viewer_DataTable_filter input').val();
            new_Ss = $('#new_Ss_viewer_DataTable').DataTable({
                "responsive": true,
                "serverSide": true,
                "searching": false,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "SearchNew_schedule.asmx/DateTime_search",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        if ($('#date_picker_input').val().length > 0) {
                            d.search = $('#date_picker_input').val() + "," + status;
                            //status:0 = Day, 1 = Week, 2 = Month
                        }
                        else {
                            d.search = "";
                        }
                        //$('#new_Ss_viewer_DataTable_filter input').val(); 
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;
                        return json.data;
                    }

                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無符合資料",
                    "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何資料",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [ //new_Ss
                    {
                        "data": "S_time", "name": "S_time", "autoWidth": true,
                        "render": function (data) {
                            return '<div class="text-center">' + data + "</div>";
                        }
                    },
                    {
                        "data": "Work_item", "name": "Work_item", "autoWidth": true,
                        "render": function (data, type) {
                            if (type === 'display') {
                                if (data.length > 13) {
                                    return '<div class="text-center" title="' + data + '">' + data.substr(0, 12) + '...</div>';
                                } else {
                                    return '<div class="text-center" title="' + data + '">' + data + '</div>';
                                }
                            }
                            return data;
                        }
                    },
                    {
                        "data": "Local", "name": "Local", "autoWidth": true,
                        "render": function (data) {
                            return '<div class="text-center">' + data + "</div>";
                        }
                    },
                    {
                        "data": "S_host", "name": "S_host", "autoWidth": true,
                        "render": function (data) {
                            return '<div class="text-center">' + data + "</div>";
                        }
                    },
                    {
                        "data": "Participants", "name": "Participants",
                        "render": function (data) {
                            if (data.length >= 10 && data.indexOf("<br>") == -1) {
                                return '<div class="text-center" title="' + data + '">' + data.substr(0, 7) + '...</div>';
                            } else {
                                return '<div class="text-center" title="' + data + '">' + data + '</div>';
                            }
                            //return '<div class="text-center">' + data + "</div>";
                        }
                    },
                    {
                        "data": "Duty", "name": "Duty", "autoWidth": true,
                        "render": function (data) {
                            return '<div class="text-center">' + data + "</div>";
                        }
                    },
                    {
                        "data": "Status", "name": "Status", "autoWidth": true,
                        "render": function (data) {
                            return '<div class="text-center">' + data + "</div>";
                        }
                    },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });
        //0 = Day, 1 = Week, 2 = Month
        $('#newSs_search').on('click', function () {
            $('#date_picker_input').val();
            status = 0;
            new_Ss.ajax.reload();
        });

        $('#newSs_searchWeek').on('click', function () {
            status = 1;
            new_Ss.ajax.reload();
        });

        $('#newSs_searchMonth').on('click', function () {
            status = 2;
            new_Ss.ajax.reload();
        });

        $('#Index_newSs_searchWeek').on('click', function () {
            LSD.ajax.reload();
            GSD.ajax.reload();
            GSoutD.ajax.reload();
            PRLD.ajax.reload();
        });

        $('#Index_newSs_searchToday').on('click', function () {
            $('#Index_date_picker_input').val("");
            LSD.ajax.reload();
            GSD.ajax.reload();
            GSoutD.ajax.reload();
            PRLD.ajax.reload();
        });

    </script>

    <script>    
        function charts() {
            $.ajax({
                url: "Database_Statistic.asmx/GetDatabase_info",
                method: "post",
                dataType: "json",
                success: function (data) {
                    data = JSON.parse(data);
                    var db_total = data[0].objects + data[1].objects + data[2].objects + data[3].objects + data[4].objects;
                    console.log(data);
                    Highcharts.chart('Highcharts_container', {
                        chart: {
                            type: 'column'
                        },
                        title: {
                            text: '各資料庫使用比例'
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            type: 'category'
                        },
                        yAxis: {
                            title: {
                                text: '占用比例'
                            }

                        },
                        legend: {
                            enabled: false
                        },
                        plotOptions: {
                            series: {
                                borderWidth: 0,
                                dataLabels: {
                                    enabled: true,
                                    format: '{point.y:.1f}%'
                                }
                            }
                        },

                        tooltip: {
                            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                            pointFormat: '<span style="color:{point.color}"></span>總共: <b>{point.total}筆 (佔全部{point.y:.2f}%)</b><br/>已使用空間: <b>{point.dataSize} MB</b><br/>平均每筆: <b>{point.avgObjSize:.2f} Bytes</b><br/>'
                        },

                        "series": [
                            {
                                "name": "詳細",
                                "colorByPoint": true,
                                "data": [
                                    {
                                        "name": "資訊室報修",
                                        "y": data[0].objects / db_total * 100,
                                        "total": data[0].objects,
                                        "dataSize": data[0].dataSize / 1000000,
                                        "avgObjSize": data[0].avgObjSize,
                                    },
                                    {
                                        "name": "水電班報修",
                                        "y": data[1].objects / db_total * 100,
                                        "total": data[1].objects,
                                        "dataSize": data[1].dataSize / 1000000,
                                        "avgObjSize": data[1].avgObjSize,
                                    },
                                    {
                                        "name": "首長、各組室行程表",
                                        "y": data[2].objects / db_total * 100,
                                        "total": data[2].objects,
                                        "dataSize": data[2].dataSize / 1000000,
                                        "avgObjSize": data[2].avgObjSize,
                                    },
                                    {
                                        "name": "公告",
                                        "y": data[3].objects / db_total * 100,
                                        "total": data[3].objects,
                                        "dataSize": data[3].dataSize / 1000000,
                                        "avgObjSize": data[3].avgObjSize,
                                    },
                                    {
                                        "name": "使用者帳號",
                                        "y": data[4].objects / db_total * 100,
                                        "total": data[4].objects,
                                        "dataSize": data[4].dataSize / 1000000,
                                        "avgObjSize": data[4].avgObjSize,
                                    },
                                ]
                            }
                        ],
                    });



                },
                error: function (err) { }
            });

        }

    </script>
    <div id="Databse_statistic_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="Databse_statistic_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><i class="fas fa-chart-bar"></i>資料庫統計</h4>
                </div>
                <div class="modal-body">
                    <div id="Highcharts_container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
                </div>
            </div>
        </div>
    </div>
    <div id="IT_Announcement_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="IT_Announcement_management_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><span class="glyphicon glyphicon-copy"></span>公告管理</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4 text-left">
                            <button type="button" id="new_Announcement" class="btn btn-warning">新增公告</button>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                    </div>
                    <br />
                    <table id="IT_Announcement_management_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>建檔時間</th>
                                <th>事項</th>
                                <th>詳情</th>
                                <th>刪除</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script>
        var IT_Am;
        var IT_announcement_board;
        var MegBoard;
        $(document).ready(function () {
            MegBoard = $('#MessageBoard_table').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": true,
                "responsive": true,
                "pageLength": 5,
                "fixedColumns": {
                    leftColumns: 2
                },
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "MsgBoard.asmx/get_Message",
                    "type": "GET",
                    "datatype": "json",
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;

                        return json.data;
                    },
                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無任何留言",
                    "sInfo": "留言總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何留言",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    {
                        "data": "commenter", "name": "commenter",
                        "render": function (data) {
                            return '<div  class="text-center" >' + data + '</div>';
                        }
                    },
                    {
                        "data": "insert_date", "name": "insert_date",
                        "render": function (data) {
                            return '<div  class="text-center" >' + data + '</div>';
                        }
                    },
                    {
                        "data": "feedback", "name": "feedback",
                        "render": function (data) {
                            if (data.length != 0)
                                return '<i  class="fas fa-check"></i>';
                            else
                                return '<i  class="fas fa-times"></i>';
                        }
                    },
                    {
                        "data": "strId", "name": "strId",
                        "render": function (data) {
                            return '<a href="#" class="text-center" onclick="show_MessageDetail(\'' + data + '\')"><i class="fas fa-search">查看詳情</i></a>';
                        }
                    },
                ],
                "columnDefs": [
                    {
                        "className": "dt-center", "targets": "_all",
                    }],
            });
        });
        function show_MessageDetail(ID) {
            $.ajax({
                url: "MsgBoard.asmx/Msg_SearchByID",
                method: "post",
                dataType: "json",
                data: {
                    ID: ID,
                },
                success: function (data) {
                    var Message_result;
                    if (data[0].feedback != 0)
                        Message_result = data[0].message + "\r\n\r\n" + "[回覆]\r\n" + data[0].feedback;
                    else
                        Message_result = data[0].message;
                    $.confirm({
                        icon: 'far fa-user',
                        title: '詳情',
                        content:
                        '<form action="" class="formName">' +
                        '<div class="form-group">' +
                        '<label>留言人:</label>' +
                        '<input type="text" readonly class="form-control" value="' + data[0].commenter + '">' +
                        '</div>' +
                        '<form action="" class="formName">' +
                        '<div class="form-group">' +
                        '<label>分機:</label>' +
                        '<input type="text" readonly class="form-control" value="' + data[0].phone + '">' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>留言時間:</label>' +
                        '<input type="text" readonly class="form-control" value="' + data[0].insert_date + '">' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>留言內容:</label>' +
                        '<textarea rows="5" readonly class="form-control" >' + Message_result + '</textarea>' +
                        '</div>' +
                        '</form>',

                        type: 'green',
                        typeAnimated: true,
                        buttons: {
                            tryAgain: {
                                text: '返回',
                                btnClass: 'btn-green',
                                action: function () {
                                }
                            },
                        },
                        //onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                        //    // bind to events
                        //    var jc = this;
                        //    this.$content.find('form').on('submit', function (e) {
                        //        // if the user submits the form by pressing enter in the field.
                        //        e.preventDefault();
                        //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                        //    });
                        //}
                    });
                },
                error: function (err) { }

            });
        }


        $(document).ready(function () {
            IT_announcement_board = $('#IT_announcements').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": true,
                "responsive": true,
                "pageLength": 5,
                "fixedColumns": {
                    leftColumns: 2
                },
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "Announcement.asmx/Get_Info",
                    "type": "GET",
                    "datatype": "json",
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;

                        return json.data;
                    },
                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無符合公告",
                    "sInfo": "公告總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何公告",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    {
                        "data": "Title", "name": "Title",
                        "render": function (data) {
                            return '<div style="width: 200px">' + data + '</div>';
                        }
                    },
                    {
                        "data": "Increment", "name": "Increment",
                        "render": function (data) {
                            return '<a  href="#" style="width: 5px" onclick="show_announcement(' + data + ')"><i class="fas fa-search">查看</i></a>';
                        }
                    },
                ],
                "columnDefs": [
                    {
                        "targets": 1,
                        "className": "text-center",
                    }],
            });
        });

        function show_announcement(ID) {
            $.ajax({
                url: "Announcement.asmx/SearchById",
                method: "post",
                dataType: "json",
                data: {
                    ID: ID,
                },
                success: function (data) {
                    $.confirm({
                        icon: 'far fa-user',
                        title: '資訊室公告',
                        content:
                        '<form action="" class="formName">' +
                        '<div class="form-group">' +
                        '<label>事項:</label>' +
                        '<input type="text" readonly class="edit_Announcement_Title form-control" value="' + data[0].Title + '">' +
                        '</div>' +
                        '<div class="form-group">' +
                        '<label>詳情:</label>' +
                        '<textarea rows="7" readonly class="edit_Announcement_Info form-control" >' + data[0].Info + '</textarea>' +
                        '</div>' +
                        '</form>',

                        type: 'green',
                        typeAnimated: true,
                        buttons: {
                            tryAgain: {
                                text: '返回',
                                btnClass: 'btn-green',
                                action: function () {
                                }
                            },
                        },
                        //onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                        //    // bind to events
                        //    var jc = this;
                        //    this.$content.find('form').on('submit', function (e) {
                        //        // if the user submits the form by pressing enter in the field.
                        //        e.preventDefault();
                        //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                        //    });
                        //}
                    });
                },
                error: function (err) { }

            });
        }
        function Load_ITAnnounce_ManageDatatable() {
            $(document).ready(function () {
                IT_Am = $('#IT_Announcement_management_DataTable').DataTable({
                    "serverSide": true,
                    "searching": false,
                    "lengthChange": false,
                    "bPaginate": true,
                    "responsive": true,
                    "pageLength": 5,
                    //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                    "ajax": {
                        "url": "Announcement.asmx/Get_Info",
                        "type": "GET",
                        "datatype": "json",
                        "dataSrc": function (json) {
                            json.draw = json.data.draw;
                            json.recordsTotal = json.data.iTotalRecords;
                            json.recordsFiltered = json.data.iTotalDisplayRecords;

                            return json.data;
                        },
                    },

                    "oLanguage": {
                        "sProcessing": "處理中...",
                        "sLengthMenu": "顯示 _MENU_ 筆記錄",
                        "sZeroRecords": "無符合公告",
                        "sInfo": "公告總筆數：_TOTAL_",
                        "sInfoEmpty": "無任何公告",
                        "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                        "sInfoPostFix": "",
                        "sSearch": "搜尋",
                        "sUrl": "",
                        "oPaginate": {
                            "sFirst": "首頁",
                            "sPrevious": "上頁",
                            "sNext": "下頁",
                            "sLast": "末頁"
                        }
                    },
                    "columns": [
                        { "data": "Date", "name": "Date", "autoWidth": true },
                        {
                            "data": "Title", "name": "Title", "autoWidth": true,
                            //"render": function (data, type) {
                            //    if (type === 'display') {
                            //        if (data.length > 21) {
                            //            return '<div class="text-center" title="' + data + '">' + data.substr(0, 21) + '...</div>';
                            //        } else {
                            //            return '<div class="text-center" title="' + data + '">' + data + '</div>';
                            //        }
                            //    }
                            //    return data;
                            //}
                        },
                        { "data": "Info", "name": "Info", "autoWidth": true },
                        {
                            "data": "Increment", "name": "Increment", "autoWidth": true,
                            "render": function (data) {
                                return '<a style="width:80px" href="#" id="Edit_info" onclick="Delete_announcement(' + data + ')"><i class="fas fa-trash-alt"></i></a>'
                            }
                        },
                    ],
                    "columnDefs": [
                        { "className": "dt-center", "targets": "_all" }
                    ],
                });
            });
        }
        function Delete_announcement(data) {
            $.ajax({
                url: "Announcement.asmx/delete",
                method: "post",
                dataType: "json",
                data: {
                    ID: data,
                },
                success: function (data) {
                    IT_announcement_board.ajax.reload();
                    IT_Am.ajax.reload();
                    swal({
                        title: "成功刪除!",
                        text: data + " 已刪除",
                        type: "success",
                        showCancelButton: true,
                        confirmButtonClass: "btn-danger",
                        confirmButtonText: "確定",
                        cancelButtonText: "取消",
                        closeOnConfirm: false
                    });

                },
                error: function (err) { }
            })
        }
        var LSD;
        $(document).ready(function () {
            LSD = $('#Leader_S_DataTable').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": false,
                "responsive": true,
                "pageLength": 100,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "SearchNew_schedule.asmx/Leader_viewer",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        if ($('#Index_date_picker_input').val().length > 0) {
                            d.search = $('#Index_date_picker_input').val();
                        }
                        else {
                            d.search = "";
                        }
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;
                        return json.data;
                    },
                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無任何行程",
                    "sInfo": "今日行程總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何行程",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    { "data": "S_time", "name": "S_time", "autoWidth": true },
                    {
                        "data": "Work_item", "name": "Work_item", "autoWidth": true,
                        "render": function (data, type) {
                            if (type === 'display') {
                                if (data.length > 13) {
                                    return '<div class="text-center" title="' + data + '">' + data.substr(0, 12) + '...</div>';
                                } else {
                                    return '<div class="text-center" title="' + data + '">' + data + '</div>';
                                }
                            }
                            return data;
                        }
                    },
                    { "data": "Local", "name": "Local", "autoWidth": true },
                    { "data": "S_host", "name": "S_host", "autoWidth": true },
                    { "data": "Participants", "name": "Participants", "autoWidth": true, "orderable": true },
                    { "data": "Duty", "name": "Duty", "autoWidth": true },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });

        $(document).on('click', '#new_Announcement', function () {
            $.confirm({
                icon: 'far fa-user',
                title: '新增公告',
                content:
                '<form action="" class="formName">' +
                '<div class="form-group">' +
                '<label>事項:</label>' +
                '<input type="text" maxlength="30" class="edit_Announcement_Title form-control">' +
                '</div>' +
                '<div class="form-group">' +
                '<label>詳情:</label>' +
                '<textarea rows="7" class="edit_Announcement_Info form-control" placeholder="">' + '</textarea>' +
                '</div>' +
                '</form>',

                type: 'dark',
                typeAnimated: true,
                buttons: {
                    formSubmit: {
                        text: '確定',
                        btnClass: 'btn-blue',
                        action: function () {
                            var edit_Announcement_Title = this.$content.find('.edit_Announcement_Title').val();
                            var edit_Announcement_Info = this.$content.find('.edit_Announcement_Info').val();
                            if (edit_Announcement_Title.length != 0 && edit_Announcement_Info.length != 0) {
                                $.ajax({
                                    url: "Announcement.asmx/New_Info",
                                    method: "post",
                                    dataType: "json",
                                    data: {
                                        Title: edit_Announcement_Title,
                                        Info: edit_Announcement_Info,
                                    },
                                    success: function (data) {
                                        IT_announcement_board.ajax.reload();
                                        IT_Am.ajax.reload();
                                    },
                                    error: function (err) { }

                                });

                            }
                            else {
                                //顯示錯誤訊息
                                $.alert("空白");
                                return false;
                            }

                        }
                    },
                    tryAgain: {
                        text: '取消',
                        btnClass: 'btn-dark',
                        action: function () {
                        }
                    },
                },
                onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                    // bind to events
                    var jc = this;
                    this.$content.find('form').on('submit', function (e) {
                        // if the user submits the form by pressing enter in the field.
                        e.preventDefault();
                        jc.$$formSubmit.trigger('click'); // reference the button and click it
                    });
                }
            });
        });


        $(document).on('click', '#new_Message', function () {
            $.confirm({
                icon: 'far fa-user',
                title: '我要留言',
                content:
                '<form action="" class="formName">' +
                '<div class="form-group">' +
                '<label>留言人:</label>' +
                '<input type="text" maxlength="30" class="edit_Message_commenter form-control">' +
                '</div>' +
                '<label>分機:</label>' +
                '<input type="text" maxlength="30" class="edit_Message_phone form-control">' +
                '</div>' +
                '<div class="form-group">' +
                '<label>內容:</label>' +
                '<textarea rows="7" class="edit_Message_Info form-control" placeholder="">' + '</textarea>' +
                '</div>' +
                '</form>',

                type: 'dark',
                typeAnimated: true,
                buttons: {
                    formSubmit: {
                        text: '確定',
                        btnClass: 'btn-blue',
                        action: function () {
                            var edit_Message_commenter = this.$content.find('.edit_Message_commenter').val();
                            var edit_Message_phone = this.$content.find('.edit_Message_phone').val();
                            var edit_Message_info = this.$content.find('.edit_Message_Info').val();
                            if (edit_Message_commenter.length != 0 && edit_Message_phone.length != 0 && edit_Message_info != 0) {
                                $.ajax({
                                    url: "MsgBoard.asmx/New_Message",
                                    method: "post",
                                    dataType: "json",
                                    data: {
                                        Commenter: edit_Message_commenter,
                                        Phone: edit_Message_phone,
                                        Message: edit_Message_info,
                                    },
                                    success: function (data) {
                                        MegBoard.ajax.reload();
                                    },
                                    error: function (err) { }

                                });

                            }
                            else {
                                //顯示錯誤訊息
                                $.alert("欄位空白");
                                return false;
                            }

                        }
                    },
                    tryAgain: {
                        text: '取消',
                        btnClass: 'btn-dark',
                        action: function () {
                        }
                    },
                },
                onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                    // bind to events
                    var jc = this;
                    this.$content.find('form').on('submit', function (e) {
                        // if the user submits the form by pressing enter in the field.
                        e.preventDefault();
                        jc.$$formSubmit.trigger('click'); // reference the button and click it
                    });
                }
            });
        });





    </script>


    <%----%>
    <script>
             var GSoutD;
             $(document).ready(function () {
                 GSoutD = $('#group_Sout_DataTable').DataTable({
                     "serverSide": true,
                     "searching": false,
                     "lengthChange": false,
                     "bPaginate": false,
                     "responsive": true,
                     "pageLength": 100,
                     //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                     "ajax": {
                         "url": "SearchNew_schedule.asmx/Group_Sout_viewer",
                         "type": "GET",
                         "datatype": "json",
                         "data": function (d) {
                             if ($('#Index_date_picker_input').val().length > 0) {
                                 d.search = $('#Index_date_picker_input').val();
                             }
                             else {
                                 d.search = "";
                             }
                         },
                         "dataSrc": function (json) {
                             json.draw = json.data.draw;
                             json.recordsTotal = json.data.iTotalRecords;
                             json.recordsFiltered = json.data.iTotalDisplayRecords;
                             return json.data;
                         },
                     },

                     "oLanguage": {
                         "sProcessing": "處理中...",
                         "sLengthMenu": "顯示 _MENU_ 筆記錄",
                         "sZeroRecords": "無任何行程",
                         "sInfo": "今日行程總筆數：_TOTAL_",
                         "sInfoEmpty": "無任何行程",
                         "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                         "sInfoPostFix": "",
                         "sSearch": "搜尋",
                         "sUrl": "",
                         "oPaginate": {
                             "sFirst": "首頁",
                             "sPrevious": "上頁",
                             "sNext": "下頁",
                             "sLast": "末頁"
                         }
                     },
                     "columns": [
                         { "data": "S_time", "name": "S_time", "autoWidth": true },
                         {
                             "data": "Work_item", "name": "Work_item", "autoWidth": true,
                             "render": function (data, type) {
                                 if (type === 'display') {
                                     if (data.length > 13) {
                                         return '<div class="text-center" title="' + data + '">' + data.substr(0, 12) + '...</div>';
                                     } else {
                                         return '<div class="text-center" title="' + data + '">' + data + '</div>';
                                     }
                                 }
                                 return data;
                             }
                         },
                         { "data": "Local", "name": "Local", "autoWidth": true },
                         { "data": "S_host", "name": "S_host", "autoWidth": true },
                         { "data": "Participants", "name": "Participants", "autoWidth": true, "orderable": true },
                         { "data": "Duty", "name": "Duty", "autoWidth": true },
                     ],
                     "columnDefs": [
                         { "className": "dt-center", "targets": "_all" }
                     ],
                 });
             });
    </script>
    <script>
        var GSD;
        $(document).ready(function () {
            GSD = $('#group_S_DataTable').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": false,
                "responsive": true,
                "pageLength": 100,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "SearchNew_schedule.asmx/Group_viewer",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        if ($('#Index_date_picker_input').val().length > 0) {
                            d.search = $('#Index_date_picker_input').val();
                        }
                        else {
                            d.search = "";
                        }
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;

                        return json.data;
                    },
                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無任何行程",
                    "sInfo": "今日行程總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何行程",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    { "data": "S_time", "name": "S_time", "autoWidth": true },
                    {
                        "data": "Work_item", "name": "Work_item", "autoWidth": true,
                        "render": function (data, type) {
                            if (type === 'display') {
                                if (data.length > 13) {
                                    return '<div class="text-center" title="' + data + '">' + data.substr(0, 12) + '...</div>';
                                } else {
                                    return '<div class="text-center" title="' + data + '">' + data + '</div>';
                                }
                            }
                            return data;
                        }
                    },
                    { "data": "Local", "name": "Local", "autoWidth": true },
                    { "data": "S_host", "name": "S_host", "autoWidth": true },
                    { "data": "Participants", "name": "Participants", "autoWidth": true, "orderable": true },
                    { "data": "Duty", "name": "Duty", "autoWidth": true },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });
    </script>
    <script>    
        var PRLD;
        $(document).ready(function () {
            PRLD = $('#PR_Leaving_DataTable').DataTable({
                "serverSide": true,
                "searching": false,
                "lengthChange": false,
                "bPaginate": false,
                "responsive": true,
                "pageLength": 100,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "PersonnelRoom.asmx/PR_SearchToday",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        if ($('#Index_date_picker_input').val().length > 0) {
                            d.search = $('#Index_date_picker_input').val();
                        }
                        else {
                            d.search = "";
                        }
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;
                        return json.data;
                    },

                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無符合資料",
                    "sInfo": "出勤狀況筆數：_TOTAL_",
                    "sInfoEmpty": "無任何資料",
                    "sInfoFiltered": "(過濾總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    { "data": "Date", "name": "Date", "autoWidth": true },
                    { "data": "Staff", "name": "Staff", "autoWidth": true },
                    { "data": "Reason", "name": "Reason", "autoWidth": true },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });

    </script>
    <script>
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
        $(document).ready(function () {
            $('#Ss_btn').on('click', function () {
                $('#Ss_btn').text();
            });
        });
    </script>

    <%-- 以上為側邊攔side bar --%>



    <!--資訊室維修單 Modal -->
    <div class="modal fade" id="IT_Modal" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #5bc0de;">
                    <button type="button" id="IT_Modal_cancel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #5bc0de;"><span class="fas fa-cube"></span>資訊設備報修單</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="dropdown">
                                <label for="label_repairs" class="col-lg-2">申請單位:</label>
                                <div class="col-lg-12">
                                    <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton_group" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        請點擊我選擇單位<span class="caret"></span>
                                    </button>
                                    <ul id="group_list" class="dropdown-menu">
                                        <li><a href="#">秘書室</a></li>
                                        <li><a href="#">保健組</a></li>
                                        <li><a href="#">輔導室</a></li>
                                        <li><a href="#">人事室</a></li>
                                        <li><a href="#">主計室</a></li>
                                        <li><a href="#">政風室</a></li>
                                        <li><a href="#">育樂堂(一隊)</a></li>
                                        <li><a href="#">育豐堂(二隊)</a></li>
                                        <li><a href="#">育興堂(三隊)</a></li>
                                        <li><a href="#">育善堂(四隊)</a></li>
                                        <li><a href="#">育愛堂(五隊)</a></li>
                                        <li><a href="#">育智堂(六隊)</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dropdown">
                                <label for="label_repairs" class="col-lg-2">報修項目:</label>
                                <div class="col-lg-12">
                                    <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton_item" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        請點擊我選擇項目<span class="caret"></span>
                                    </button>
                                    <ul id="device_items" class="dropdown-menu">
                                        <li><a href="#">電腦主機</a></li>
                                        <li><a href="#">電腦螢幕</a></li>
                                        <li><a href="#">滑鼠</a></li>
                                        <li><a href="#">鍵盤</a></li>
                                        <li><a href="#">讀卡機</a></li>
                                        <li><a href="#">印表機</a></li>
                                        <li><a href="#">網路</a></li>
                                        <li><a href="#">光碟燒錄</a></li>
                                        <li><a href="#">公文系統</a></li>
                                        <li><a href="#">安養系統</a></li>
                                        <li><a href="#">行政網</a></li>
                                        <li><a href="#">岡榮官網</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_repairs" class="col-sm-2">報修人:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="IT_reporter" placeholder="*必填 請輸入中文姓名 (勿輸入數字或符號)">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="label_phone" class="col-sm-2">分機:</label>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control" id="IT_phone" placeholder="*必填 請輸入分機號碼 (格式如:316)">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="form-control-label col-sm-2">說明:</label>
                                <div class="col-sm-12">
                                    <textarea runat="server" class="form-control" id="IT_text" placeholder="故障簡述"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4  text-center">
                        <button type="submit" id="IT_submit" class="btn btn-info">送出</button>
                    </div>
                    <div class="col-sm-4"></div>
                </div>

            </div>
        </div>
    </div>
    <script>
        var count_ajax = 0;
        var IT_table
        $(document).ready(function () {
            var ss = $('#IT_DataTable_filter input').val();
            IT_table = $('#IT_DataTable').DataTable({
                "serverSide": true,
                "searching": true,
                "responsive": true,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "IT_table_viewer.asmx/IT_table",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        d.search = $('#IT_DataTable_filter input').val();
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;

                        return json.data;
                    }

                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無符合資料",
                    "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何資料",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    { "data": "unit", "name": "unit", "autoWidth": true },
                    { "data": "report_item", "name": "report_item", "autoWidth": true },
                    { "data": "reporter", "name": "reporter", "autoWidth": true },
                    {
                        "data": "strid", "name": "strid", "autoWidth": true,
                        "render": function (data) {
                            return '<a href="#" onclick="IT_remark(\'' + data + '\')"><i class="fas fa-search">查看</i></a>';
                        }
                    },
                    { "data": "date", "name": "date", "autoWidth": true, "orderable": true },
                    { "data": "status", "name": "status", "autoWidth": true },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });


    </script>
    <script>
        function IT_remark(data) {
            $.ajax({
                url: "IT_table_viewer.asmx/IT_table_Search",
                method: "post",
                dataType: "json",
                data: {
                    ID: data,
                },
                success: function (data) {
                    $.confirm({
                        icon: 'far fa-check-circle',
                        title: '備註',
                        content: '<div>' + data[0].remark + '</div>',
                        type: 'green',
                        typeAnimated: true,
                        buttons: {
                            close: {
                                text: '確定',
                                btnClass: 'btn-green',
                                action: function () {

                                }
                            },
                        }
                    });
                },
                error: function (err) { }
            })
        }
    </script>
    <div id="IT_DataTable_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #5bc0de;">
                    <button type="button" id="IT_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #5bc0de;"><span class="glyphicon glyphicon-copy"></span>資訊室維修進度查詢</h4>
                </div>
                <div class="modal-body">
                    <table id="IT_DataTable" class="table table-striped table-hover dt-responsive" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="Pulmber_DataTable_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="Pulmber_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><span class="glyphicon glyphicon-copy"></span>水電班維修進度查詢</h4>
                </div>
                <div class="modal-body">
                    <table id="Pulmber_DataTable" class="display responsive nowrap dataTable no-footer dtr-inline collapsed" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>單位維修確認</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>單位維修確認</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script>
        var count_ajax = 0;
        var PDTV;
        $(document).ready(function () {
            PDTV = $('#Pulmber_DataTable').DataTable({
                "serverSide": true, //serverSide打開
                "searching": true,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "ajax": {
                    "url": "Plumber_table_viewer.asmx/Plumber_table",
                    "type": "GET",
                    "datatype": "json",
                    "data": function (d) {
                        d.search = $('#Pulmber_DataTable_filter input').val();
                    },
                    "dataSrc": function (json) {
                        json.draw = json.data.draw;
                        json.recordsTotal = json.data.iTotalRecords;
                        json.recordsFiltered = json.data.iTotalDisplayRecords;
                        return json.data;
                    }

                },

                "oLanguage": {
                    "sProcessing": "處理中...",
                    "sLengthMenu": "顯示 _MENU_ 筆記錄",
                    "sZeroRecords": "無符合資料",
                    "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                    "sInfoEmpty": "無任何資料",
                    "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                    "sInfoPostFix": "",
                    "sSearch": "堂隊(單位)搜尋",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "首頁",
                        "sPrevious": "上頁",
                        "sNext": "下頁",
                        "sLast": "末頁"
                    }
                },
                "columns": [
                    { "data": "Unit", "name": "Unit", "autoWidth": true },
                    { "data": "reporter", "name": "reporter", "autoWidth": true },
                    { "data": "fix_item", "name": "fix_item", "autoWidth": true },
                    { "data": "location", "name": "location", "autoWidth": true },
                    {
                        "data": "strid", "name": "strid", "autoWidth": true,
                        "render": function (data) {
                            return '<a href="#" onclick="Pulmber_remark(\'' + data + '\')"><i class="fas fa-search">查看</i></a>';
                        }
                    },
                    { "data": "time", "name": "time", "autoWidth": true, "orderable": true },
                    { "data": "status", "name": "status", "autoWidth": true, "targets": [6] },
                    {
                        "data": "Acceptance", "name": "Acceptance", "autoWidth": true,
                        "render": function (data, type, row, meta) {
                            if (row.status == "已修繕完畢" && data == "已確認") {
                                return '<i title="已修繕、堂隊確認完畢" class="fas fa-check"></i>';
                            }
                            else if (row.status == "已修繕完畢" && data == "尚未確認") {
                                return '<i title="已修繕完畢、堂隊尚未確認" class="fas fa-times"></i>';
                            }
                            else {
                                return '<i title="尚未修繕、尚未確認" class="fas fa-minus-circle"></i>';
                            }
                        }
                    },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": "_all" }
                ],
            });
        });
        function Pulmber_remark(data) {
            $.ajax({
                url: "Plumber_table_viewer.asmx/Plumber_Search",
                method: "post",
                dataType: "json",
                data: {
                    ID: data,
                },
                success: function (data) {
                    $.confirm({
                        icon: 'far fa-check-circle',
                        title: '備註',
                        content: '<div>' + data[0].remark + '</div>',
                        type: 'green',
                        typeAnimated: true,
                        buttons: {
                            close: {
                                text: '確定',
                                btnClass: 'btn-green',
                                action: function () {

                                }
                            },
                        }
                    });
                },
                error: function (err) { }
            })
        }

    </script>
    <script>
        var IT_info = "";
        $(document).on('click', '#IT_submit', function () {
            if (check()) {
                //表格有資料
                console.log("(" + $('#IT_reporter').val() + ")" + "(" + $('#IT_reporter').text() + ")" + Regex_check($('#IT_reporter').val(), /^[\u4e00-\u9fa5]{2,9}$/));
                $.ajax({
                    url: "IT_Table.asmx/IT_table_insert",
                    method: "post",
                    dataType: "json",
                    data: {
                        unit: $("#dropdownMenuButton_group").text(),
                        report_item: $("#dropdownMenuButton_item").text(),
                        reporter: $('#IT_reporter').val(),
                        phone: $('#IT_phone').val(),
                        remark: $('#IT_text').val(),
                    },
                    success: function (data) {
                        //ITMDB.ajax.reload();
                        IT_table.ajax.reload();
                        $('#IT_Modal').modal('hide');
                        initial_IT_Modal();
                        swal({
                            title: "系統訊息",
                            text: '報修成功 ' + data,
                            type: "success",
                            confirmButtonClass: "btn-success",
                            confirmButtonText: "確定",
                        });
                        //swal("系統訊息", data, "success");

                        //$.confirm({
                        //    icon: 'far fa-check-circle',
                        //    title: '成功',
                        //    content: '報修成功' + data,
                        //    type: 'green',
                        //    typeAnimated: true,
                        //    buttons: {
                        //        close: {
                        //            text: '確定',
                        //            btnClass: 'btn-green',
                        //            action: function () {
                        //                $('#IT_Modal').modal('hide');
                        //                initial_IT_Modal();
                        //            }
                        //        },
                        //    }
                        //});
                    },
                    error: function (err) { console.log(err) },

                });
            }
            else {
                //表格無資料
                fail_check();
                $.confirm({
                    icon: 'fas fa-minus-circle',
                    title: '錯誤',
                    content: IT_info,
                    type: 'red',
                    typeAnimated: true,
                    buttons: {
                        tryAgain: {
                            text: '返回',
                            btnClass: 'btn-red',
                            action: function () {
                            }
                        },
                    }
                });
            }
        });
    </script>
    <script>
        var new_Ss_fail = "";
        var new_Ss_info = "";
        var over_time;
        $(document).on('click', '#new_Ss_Modal_submit', function () {
            if (new_Ss_check()) {//需要檢查行程的結束時間 然後各個行程 間隔不要太擠
                $.confirm({
                    title: '資料確認',
                    icon: 'far fa-check-circle',
                    content: new_Ss_info,
                    type: 'green',
                    buttons: {
                        omg: {
                            text: '送出',
                            btnClass: 'btn-green',
                            action: function () {
                                console.log("進入送出按鈕");
                                if ($("#Host_select option:selected").text() == "家主任" || $("#Host_select option:selected").text() == "副主任") {
                                    //檢查家主任 副主任行程
                                    Check_Director_host(25);//行程間隔(30分鐘 - 5分鐘)

                                }
                                else {
                                    insert_schedule();
                                }
                            }
                        },
                        close:
                        {
                            text: '返回',
                            action: function () { }
                        }
                    }
                });
            }
            else {
                new_Ss_fail_check();
                $.confirm({
                    icon: 'fas fa-minus-circle',
                    title: '錯誤',
                    content: new_Ss_fail,
                    type: 'red',
                    typeAnimated: true,
                    buttons: {
                        tryAgain: {
                            text: '返回',
                            btnClass: 'btn-red',
                            action: function () {
                            }
                        },
                    }
                });
            }
        });
        function Check_Director_host(interval) {
            console.log("進入 Check_Director_host");
            $.ajax({
                url: "SearchNew_schedule.asmx/Check_Director_host_ajax",
                method: "post",
                dataType: "json",
                data: {
                    host_postition: $("#Host_select option:selected").text(),
                    S_Begin_time: $(new_Ss_dateAndtime_input).val(),
                    S_End_time: over_time,
                    interval_time: interval
                },
                success: function (data) {
                    console.log("[Check_Director_host ]" + data);
                    //console.log("[Check_Director_host ]" + JSON.stringify(data));
                    if (data[0].Time_TorF == false) {
                        $.confirm({
                            title: $("#Host_select option:selected").text() + ' 此時段已安排行程',
                            content: '<span style="font-weight:bold;color:blue;">' + "您所新增時段為:</span><br>" + $(new_Ss_dateAndtime_input).val() + " - " + over_time + "<br><br>"
                            + '<span style="font-weight:bold;color:red;">' + $("#Host_select option:selected").text() + ' 已安排行程時間:</span><br>' + data[0].Not_Advice_Time
                            + '<br><span style="font-weight:bold;color:green;">' + $("#Host_select option:selected").text() + ' 未排行程時間:</span><br>' + data[0].Advice_Time,
                            type: 'red',
                            typeAnimated: true,
                            buttons: {
                                tryAgain: {
                                    text: '返回更改時段',
                                    btnClass: 'btn-red',
                                },
                            }
                        });
                    }
                    else {
                        insert_schedule();
                    }
                },
                error: function (err) {
                    console.log("[Check_Director_host 執行失敗]" + JSON.stringify(err));
                }
            });
        }
        function insert_schedule() {//行程寫入AJAX
            $.ajax({
                url: "Schedule.asmx/Schedule_table_insert",
                method: "post",
                dataType: "json",
                data: {
                    S_time: $(new_Ss_dateAndtime_input).val(),
                    S_end_time: over_time,
                    Work_item: $(new_Ss_Modal_Work).val(),
                    Local: $(new_Ss_Modal_local).val(),
                    S_host: $(Host_select).val() == 9 ? $(new_Ss_Modal_host).val() : $("#Host_select option:selected").text(),
                    Participants: $(new_Ss_Participants).val(),
                    Duty: $(new_Ss_Modal_duty).val(),
                },
                success: function (data) {
                    switch (data[0].outcase) {
                        case 1:
                            console.log('進入case1');
                            $.confirm({
                                icon: 'far fa-check-circle',
                                title: '成功',
                                content:
                                '<div style="text-align: center; font-weight:bold;">' +
                                data[0].date + ' 已新增行程成功<br><br >' +
                                '</div>' +
                                '<div style="text-align: center; font-weight:bold;"><i class="fas fa-exclamation-circle">警告</i><br></div>' +
                                '<div style="text-align: center;">因為新增行程時間距離行程時間太近<br></div>' +
                                '<div style="text-align: center;">為了避免行程沒有被審核，遵照以下:<br></div>' +
                                '<div style="text-align: center; font-weight:bold;">' +
                                '1.立即通知 <span style="text-align: center; text-decoration:underline;">秘書</span> 告知行程必須立即審核<br>' +
                                '2.或者在留言板上告知行程必須立即審核<br></div>' +
                                '<div style="text-align: center; font-weight:underline;">忽略警告者，行程漏掉顯示在行程表上，均不負責</div>',
                                type: 'green',
                                typeAnimated: true,
                                buttons: {
                                    close: {
                                        text: '確定',
                                        btnClass: 'btn-green',
                                        action: function () {
                                            $('#new_Ss_Modal').modal('hide');
                                            new_Ss.ajax.reload();
                                        }
                                    },
                                }
                            });
                            break;

                        case 2:
                            console.log('進入case2');
                            $.confirm({
                                icon: 'far fa-check-circle',
                                title: '成功',
                                content: data[0].date + ' 新增行程成功',
                                type: 'green',
                                typeAnimated: true,
                                buttons: {
                                    close: {
                                        text: '確定',
                                        btnClass: 'btn-green',
                                        action: function () {
                                            $('#new_Ss_Modal').modal('hide');
                                            new_Ss.ajax.reload();
                                        }
                                    },
                                }
                            });
                            break;
                    }

                },
                error: function (err) { }
            });
        }
    </script>

    <script>
        $(document).on('click', '#IT_Modal_cancel', function () {//IT_Modal取消回復初始化
            initial_IT_Modal();
        });

        $(document).on('click', '#plumber_group_list a', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_group_plumber").text($(this).text());
        });

        $(document).on('click', '#plumber_device_items1 li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item_plumber1").text($(this).text());
        });
        $(document).on('click', '#plumber_device_items2 li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item_plumber2").text($(this).text());
        });

        $(document).on('click', '#plumber_device_items3 li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item_plumber3").text($(this).text());
        });

        $(document).on('click', '#plumber_device_items4 li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item_plumber4").text($(this).text());
        });

        $(document).on('click', '#plumber_device_items5 li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item_plumber5").text($(this).text());
        });
        $(document).on('click', '#device_items li', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_item").text($(this).text());
        });
        $(document).on('click', '#group_list a', function () {
            console.log("抓資料 : " + $(this).text());
            $("#dropdownMenuButton_group").text($(this).text());
        });
    </script>
    <script>    
        $(function () {
            $('#new_Ss_datetimepicker').datetimepicker({
                defaultDate: new Date(),
                format: "yyyy-mm-dd DD hh:ii",
                language: "zh-TW",
                startDate: new Date(),
            });
        });
        $(function () {
            $('#datetimepicker_Hi').datetimepicker({
                language: "zh-TW",
                format: "hh:ii",
                autoclose: 1,
                todayHighlight: 1,
                startView: 1,
                minView: 0,
                maxView: 1,
                forceParse: 0,
            });
        });
        $(function () {
            $('#Secretary_management_datetimepicker').datetimepicker({
                defaultDate: new Date(),
                format: "yyyy-mm-dd DD hh:ii",
                language: "zh-TW",
                startDate: new Date(),
            });
        });
        $(function () {
            $('#Secretary_management_end').datetimepicker({
                language: "zh-TW",
                format: "hh:ii",
                autoclose: 1,
                todayHighlight: 1,
                startView: 1,
                minView: 0,
                maxView: 1,
                forceParse: 0,
            });
        });
    </script>
    <script>
        $('#new_Ss_viewer_picker').datetimepicker({
            language: 'zh-TW',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: "yyyy-mm-dd DD ",
        });
    </script>
    <script>
        $('#Index_viewer_picker').datetimepicker({
            language: 'zh-TW',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: "yyyy-mm-dd DD ",
        });
    </script>
    <script>
        $('#Secretary_management_picker').datetimepicker({
            language: 'zh-TW',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            //startView: 2,
            minView: 2,
            forceParse: 0,
            format: "yyyy-mm-dd DD ",
        });
    </script>


    <style>
        .modal-header-login, h4, .close {
            background-color: #5cb85c;
            color: white !important;
            align: center;
            ont-size: 30px;
        }


        .modal foote {
            background-co #f9f9f9;
        }
        /* EN
    </style>

    <div class="container">
        <!--Login Modal -->
        <div class="modal fade" id="Login_page" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
            <div class="modal-dialog">
                <!--Login Modal content-->
                <div class="modal-content">
                    <div class="modal-header-login" style="padding: 35px 50px;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4><span class="glyphicon glyphicon-lock"></span>Login</h4>
                    </div>
                    <div class="modal-body" style="padding: 40px 50px;">
                        <form role="form">
                            <div class="form-group">
                                <label for="account"><span class="glyphicon glyphicon-user"></span>Account</label>
                                <input type="text" class="form-control" value="" id="Loign_Account" placeholder="Enter Account">
                            </div>
                            <div class="form-group">
                                <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>Password</label>
                                <input type="Password" class="form-control" id="Login_psw" value="" placeholder="Enter password">
                            </div>
                            <button type="button" id="Login_submit" class="btn btn-success btn-block"><span class="glyphicon glyphicon-off"></span>Login</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger btn-default pull-left" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
                        <p><a href="#">非系統管理指勿嘗試登入</a></p>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script>
        function check_Ss() {
            Management_Ss_info = "";
            if ($("#Secretary_management_datetimepicker_input").val().length == 0)
                Management_Ss_info += "[請檢查] 行程日期(時間)<br/>";
            if (Regex_check($("#Sms_Modal_Work").val(), /^[\u4e00-\u9fa5\s\、\-\「\」\『\』\(\)\1-9]{2,}$/) != true)
                Management_Ss_info += "[請檢查] 工作項目<br/>";
            if (Regex_check($("#Sms_Modal_local").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                Management_Ss_info += "[請檢查] 地點<br/>";
            if (Regex_check($("#Sms_Modal_host").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                Management_Ss_info += "[請檢查] 主持人<br/>";
            if (Regex_check($("#Sms_Participants").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                Management_Ss_info += "[請檢查] 參加人員<br/>";
            if (Regex_check($("#Sms_Modal_duty").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                Management_Ss_info += "[請檢查] 承辦人<br/>";
            if ($("#Secretary_management_end_input").val().length != 0 && $("#Secretary_management_datetimepicker_input").val().length != 0)
                Management_Ss_info += check_time_picker($("#Secretary_management_datetimepicker_input").val(), $("#Secretary_management_end_input").val());

        }
        function new_Ss_check() {
            if ($("#new_Ss_dateAndtime_input").val().length != 0
                && Regex_check($("#new_Ss_Modal_Work").val(), /^[\u4e00-\u9fa5\s\、\-\「\」\『\』\(\)\1-9]{2,}$/) == true
                && Regex_check($("#new_Ss_Modal_local").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) == true
                && bool_check_host_select() == true
                && Regex_check($("#new_Ss_Participants").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) == true
                && Regex_check($("#new_Ss_Modal_duty").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) == true
            ) {
                if ($("#datetimepicker_Hi_input").val().length > 0 && bool_check_time_picker($("#new_Ss_dateAndtime_input").val(), $("#datetimepicker_Hi_input").val()) == true || $("#datetimepicker_Hi_input").val().length == 0) {
                    new_Ss_dateInfo(); return true;
                }
            }
            else
                return false;
        }
        function new_Ss_fail_check() {
            new_Ss_fail = "";
            if ($("#new_Ss_dateAndtime_input").val().length == 0)
                new_Ss_fail += "[請檢查] 行程日期(時間)<br/>";
            if (Regex_check($("#new_Ss_Modal_Work").val(), /^[\u4e00-\u9fa5\s\、\-\「\」\『\』\(\)\1-9]{2,}$/) != true)
                new_Ss_fail += "[請檢查] 工作項目<br/>";
            if (Regex_check($("#new_Ss_Modal_local").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                new_Ss_fail += "[請檢查] 地點<br/>";
            if (Regex_check($(Host_select).val() == 9 ? $(new_Ss_Modal_host).val() : $("#Host_select option:selected").text(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true || $(Host_select).val() == 0)
                new_Ss_fail += "[請檢查] 主持人<br/>";
            if (Regex_check($("#new_Ss_Participants").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                new_Ss_fail += "[請檢查] 參加人員<br/>";
            if (Regex_check($("#new_Ss_Modal_duty").val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/) != true)
                new_Ss_fail += "[請檢查] 承辦人<br/>";
            if ($("#new_Ss_dateAndtime_input").val().length != 0 && $("#datetimepicker_Hi_input").val().length != 0)
                new_Ss_fail += check_time_picker($("#new_Ss_dateAndtime_input").val(), $("#datetimepicker_Hi_input").val());
        }
        function check_time_picker(picker_input, end_input) {
            var split_datepicker = picker_input.split(' ');
            var split_end_input = end_input.split(':');
            var datepicker = split_datepicker[2].split(':');
            var picker_hour = datepicker[0];
            var pciker_min = datepicker[1];
            var end_hour = split_end_input[0];
            var end_min = split_end_input[1];
            if (end_hour < picker_hour)
                return "[請檢查] 預計結束時間 (不能小於開始時間)<br/>"
            if (end_hour == picker_hour && end_min <= pciker_min)
                return "[請檢查] 預計結束時間 (不能小於或等於開始時間)<br/>"
            return "";
        }
        function bool_check_time_picker(picker_input, end_input) {
            var split_datepicker = picker_input.split(' ');
            var split_end_input = end_input.split(':');
            var datepicker = split_datepicker[2].split(':');
            var picker_hour = datepicker[0];
            var pciker_min = datepicker[1];
            var end_hour = split_end_input[0];
            var end_min = split_end_input[1];
            if (end_hour < picker_hour)
                return false;
            if (end_hour == picker_hour && end_min <= pciker_min)
                return false;
            return true;
        }
        function bool_check_host_select() {
            if ($(Host_select).val() == 9 && Regex_check($(new_Ss_Modal_host).val(), /^[\u4e00-\u9fa5\s\、\-\(\)\1-9]{2,}$/)) {
                return true;
            }
            else if ($(Host_select).val() > 0 && $(Host_select).val() != 9) {
                return true;
            }
            else {
                return false;
            }

        }
        function new_Ss_dateInfo() {
            var host_selected = $(Host_select).val() == 9 ? $(new_Ss_Modal_host).val() : $("#Host_select option:selected").text();
            over_time = "";
            if ($(datetimepicker_Hi_input).val() != "") {
                //console.log("有預計結束時間"); 
                over_time = $(datetimepicker_Hi_input).val();
            }
            else {
                var substring = new Array();
                split = $(new_Ss_dateAndtime_input).val().split(" ");
                over_time = (parseInt(split[2].substring(0, split[2].indexOf(":"))) + 1).toString() + split[2].substring(split[2].indexOf(":"), split[2].toString().length);

            }

            new_Ss_info = "<div>行程日期(時間): " + $(new_Ss_dateAndtime_input).val() + "</div><br>" +
                "<div>預計結束時間: " + over_time + "</div><br>" +
                "<div>工作項目: " + $(new_Ss_Modal_Work).val() + "</div><br>" +
                "<div>地點: " + $(new_Ss_Modal_local).val() + "</div><br>" +
                "<div>主持人: " + host_selected + "</div><br>" +
                "<div>參加人員: " + $(new_Ss_Participants).val() + "</div><br>" +
                "<div>承辦人: " + $(new_Ss_Modal_duty).val() + "</div>";
        }

        function check() {//檢測規則
            if ($("#dropdownMenuButton_group").text().indexOf("請點擊我選擇單位") == -1
                && $("#dropdownMenuButton_item").text().indexOf("請點擊我選擇項目") == -1
                && Regex_check($('#IT_reporter').val(), /^[\u4e00-\u9fa5]{2,9}$/) == true
                && Regex_check($('#IT_phone').val(), /^[0-9]{3}$/) == true) { return true; }
            else
                return false;
        }
        function fail_check() {
            IT_info = "";
            if ($("#dropdownMenuButton_group").text().indexOf("請點擊我選擇單位") != -1)
                IT_info += "[請檢查] 申請單位<br/>";
            if ($("#dropdownMenuButton_item").text().indexOf("請點擊我選擇項目") != -1)
                IT_info += "[請檢查] 報修項目<br/>";
            if (Regex_check($('#IT_reporter').val(), /^[\u4e00-\u9fa5]{2,9}$/) != true)
                IT_info += "[請檢查] 報修人 (只能輸入中文)<br/>";
            if (Regex_check($('#IT_phone').val(), /^[0-9]{3}$/) != true)
                IT_info += "[請檢查] 分機 (只能輸入數字)<br/>"

        }
        function Regex_check(date, rex) {//正規表達式規則
            var regex = new RegExp(rex);
            return regex.test(date);
        }
        function initial_IT_Modal() {
            $("#dropdownMenuButton_group").text("請點擊我選擇單位").append('<span class="caret"></span>');
            $("#dropdownMenuButton_item").text("請點擊我選擇項目").append('<span class="caret"></span>');
            $("#IT_reporter").val("");
            $("#IT_phone").val("");
            $("#IT_text").val("");
        }

        function initial_plumber_Modal() {
            $("#dropdownMenuButton_group_plumber").text("請選擇單位").append('<span class="caret"></span>');
            $("#plumber_reporter").val("");
            $("#plumber_reporter_phone").val("");

            $("#dropdownMenuButton_item_plumber1").text("請選擇項目").append('<span class="caret"></span>');
            $("#plumber_local1").val("");
            $("#remark1").val("");

            for (var i = 2; i <= count; i++) {
                $("#card_" + i).remove();
            }

            count = 1;

            $(del_item).attr('disabled', true);
            $(new_item).attr('disabled', false);

        }
        function initial_datetimepicker_input() {//初始化每日工作表
            $(datetimepicker_Hi_input).val("");
            $(new_Ss_dateAndtime_input).val("");
            $(new_Ss_Modal_Work).val("");
            $(new_Ss_Modal_local).val("");
            $(Host_select).val('0');
            $('#new_Ss_Modal_host').attr('disabled', 'disabled');
            $(new_Ss_Modal_host).val("");
            $(new_Ss_Participants).val("");
            $(new_Ss_Modal_duty).val("");
        }
    </script>

    <div id="PersonnelRoom_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #32b79c;">
                    <button type="button" id="PersonnelRoom_management_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #32b79c;"><span class="glyphicon glyphicon-copy"></span>組室主管、堂隊長出勤狀況</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4 text-left">
                            <button type="button" id="new_Leave" class="btn btn-warning">新增出勤狀況</button>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                    </div>
                    <br>
                    <table id="PersonnelRoom_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr style="text-align: center;">
                                <th>請假時間</th>
                                <th>人員</th>
                                <th>假由</th>
                                <th>建檔日期</th>
                                <th>編輯</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: center;">
                                <th>請假時間</th>
                                <th>人員</th>
                                <th>假由</th>
                                <th>建檔日期</th>
                                <th>編輯</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="NewPRLeave_Modal" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #32b79c;">
                    <button type="button" id="NewPRLeave_cancel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #32b79c;"><span class="fas fa-cube"></span>新增出勤狀況</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group">
                            <label for="label_phone" class="col-sm-2">請假日期:</label>
                            <div class="col-sm-12">
                                <div class="text-center input-group date" id="PR_management_picker">
                                    <input class="form-control" id="PR_date_picker_input" placeholder="請假日期" size="16" type="text" value="" readonly>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="form-group">
                            <label for="label_phone" class="col-sm-2">請假人員:</label>
                            <div class="col-sm-12">
                                <input type="text" maxlength="30" id="edit_PR_staff" class="form-control">
                            </div>
                        </div>
                        <br>
                        <div class="form-group">
                            <label for="message-text" class="form-control-label col-sm-2">假別:</label>
                            <div class="col-sm-12">
                                <input type="text" maxlength="30" id="edit_PR_leave" class="form-control">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4  text-center">
                        <button type="submit" id="NewPRLeave_submit" class="btn btn-info">送出</button>
                    </div>
                    <div class="col-sm-4"></div>
                </div>

            </div>
        </div>
    </div>


    <script>    
        $(document).on('click', '#new_Leave', function () {
            $(NewPRLeave_Modal).modal('show');
        });
        $(document).on('click', '#NewPRLeave_submit', function () {
            if ($('#PR_date_picker_input').val().length > 0 && $('#edit_PR_staff').val().length > 0 && $('#edit_PR_leave').val().length > 0) {
                $.ajax({
                    url: "PersonnelRoom.asmx/NewLeave",
                    method: "post",
                    dataType: "json",
                    data: {
                        Date: $('#PR_date_picker_input').val(),
                        Staff: $('#edit_PR_staff').val(),
                        Reason: $('#edit_PR_leave').val(),
                    },
                    success: function (data) {
                        PR_Datatable.ajax.reload();
                        $('#PR_date_picker_input').val("");
                        $('#edit_PR_staff').val("");
                        $('#edit_PR_leave').val("");
                        $(NewPRLeave_Modal).modal('hide');
                        swal({
                            title: "新增成功!",
                            text: data + " 已新增",
                            type: "success",
                            showCancelButton: true,
                            confirmButtonClass: "btn-danger",
                            confirmButtonText: "確定",
                            cancelButtonText: "取消",
                            closeOnConfirm: false
                        });

                    },
                    error: function (err) {
                    },
                });
            }
        });
    </script>
    <script>
        $('#PR_management_picker').datetimepicker({
            language: 'zh-TW',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            //startView: 2,
            minView: 2,
            forceParse: 0,
            format: "yyyy-mm-dd DD ",
        });

        var PR_Datatable;
        function Load_PR_Datatable() {
            $(document).ready(function () {
                PR_Datatable = $('#PersonnelRoom_DataTable').DataTable({
                    "serverSide": true,
                    "lengthChange": false,
                    "searching": false,
                    "pageLength": 5,
                    //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                    "ajax": {
                        "url": "PersonnelRoom.asmx/Show_leave",
                        "type": "GET",
                        "datatype": "json",
                        "data": function (d) {
                            //d.user = account_user;
                            //d.authority = account_authority;
                        },
                        "dataSrc": function (json) {
                            json.draw = json.data.draw;
                            json.recordsTotal = json.data.iTotalRecords;
                            json.recordsFiltered = json.data.iTotalDisplayRecords;
                            return json.data;
                        },

                    },

                    "oLanguage": {
                        "sProcessing": "處理中...",
                        "sLengthMenu": "顯示 _MENU_ 筆記錄",
                        "sZeroRecords": "無符合資料",
                        "sInfo": "帳號筆數：_TOTAL_",
                        "sInfoEmpty": "無任何資料",
                        "sInfoFiltered": "(過濾總筆數 _MAX_)",
                        "sInfoPostFix": "",
                        "sSearch": "搜尋",
                        "sUrl": "",
                        "oPaginate": {
                            "sFirst": "首頁",
                            "sPrevious": "上頁",
                            "sNext": "下頁",
                            "sLast": "末頁"
                        }
                    },
                    "columns": [
                        { "data": "Date", "name": "Date", "autoWidth": true },
                        { "data": "Staff", "name": "Staff", "autoWidth": true },
                        { "data": "Reason", "name": "Reason", "autoWidth": true },
                        { "data": "Create_time", "name": "Create_time", "autoWidth": true },
                        {
                            "data": "strId", "name": "strId", "autoWidth": true,
                            "render": function (data) {
                                return '<a style="width:80px" href="#" onclick="Delete_PRleave(\'' + data + '\')"><i class="fas fa-trash-alt"></i></a>'
                            }
                        },
                    ],
                    "columnDefs": [
                        { "className": "dt-center", "targets": "_all" }
                    ],
                });
            });
        }
        function Delete_PRleave(data) {
            $.confirm({
                icon: 'fas fa-minus-circle',
                title: '確認刪除',
                content: '刪除出勤資料 ' + data,
                type: 'red',
                typeAnimated: true,
                buttons: {
                    Submit: {
                        text: '刪除',
                        btnClass: 'btn-red',
                        action: function () {
                            $.ajax({
                                url: "PersonnelRoom.asmx/Delete_PR",
                                method: "post",
                                dataType: "json",
                                data: {
                                    ID: data,
                                },
                                success: function (data) {
                                    swal({
                                        title: "成功刪除!",
                                        text: data,
                                        type: "success",
                                        showCancelButton: true,
                                        confirmButtonClass: "btn-success",
                                        confirmButtonText: "確定",
                                        cancelButtonText: "取消",
                                        closeOnConfirm: false
                                    });
                                    PR_Datatable.ajax.reload();
                                },
                                error: function (err) { }
                            })
                        }
                    },
                    Cannel: {
                        text: '取消',
                        btnClass: 'btn-green',
                    },
                }
            });

        }



    </script>

    <div id="Plumber_Acceptance_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="Plumber_Acceptance_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><span class="glyphicon glyphicon-copy"></span>水電維修確認</h4>
                </div>
                <div class="modal-body">
                    <table id="Plumber_Acceptance_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>維修確認</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>維修確認</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script>

            // s超級 1水電班管理 4堂隊 
            var AA_Datatable;
            function Load_Acceptance_DataTable() {
                $(document).ready(function () {
                    AA_Datatable = $('#Plumber_Acceptance_DataTable').DataTable({
                        "serverSide": true,
                        "lengthChange": false,
                        "searching": false,
                        "pageLength": 10,
                        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                        "ajax": {
                            "url": "Plumber_table_viewer.asmx/Acceptance",
                            "type": "GET",
                            "datatype": "json",
                            "data": function (d) {
                                d.user = account_user;
                                d.authority = account_authority;
                            },
                            "dataSrc": function (json) {
                                json.draw = json.data.draw;
                                json.recordsTotal = json.data.iTotalRecords;
                                json.recordsFiltered = json.data.iTotalDisplayRecords;
                                return json.data;
                            },

                        },

                        "oLanguage": {
                            "sProcessing": "處理中...",
                            "sLengthMenu": "顯示 _MENU_ 筆記錄",
                            "sZeroRecords": "無符合資料",
                            "sInfo": "帳號筆數：_TOTAL_",
                            "sInfoEmpty": "無任何資料",
                            "sInfoFiltered": "(過濾總筆數 _MAX_)",
                            "sInfoPostFix": "",
                            "sSearch": "搜尋",
                            "sUrl": "",
                            "oPaginate": {
                                "sFirst": "首頁",
                                "sPrevious": "上頁",
                                "sNext": "下頁",
                                "sLast": "末頁"
                            }
                        },
                        "columns": [
                            { "data": "reporter", "name": "reporter", "autoWidth": true },
                            { "data": "fix_item", "name": "fix_item", "autoWidth": true },
                            { "data": "location", "name": "location", "autoWidth": true },
                            { "data": "time", "name": "time", "autoWidth": true },
                            { "data": "status", "name": "status", "autoWidth": true },
                            {
                                "data": "strid", "name": "strid", "autoWidth": true,
                                "render": function (data, type, row, meta) {
                                    return '<a style="width:80px" href="#" onclick="Update_Acceptance(\'' + data + '\')"><i class="fas fa-edit"></i></a>'
                                }
                            },
                        ],
                        "columnDefs": [
                            { "className": "dt-center", "targets": "_all" }
                        ],
                    });
                });
            }
            function Update_Acceptance(ID) {
                $.ajax({
                    url: "Plumber_table_viewer.asmx/Plumber_Search",
                    method: "post",
                    dataType: "json",
                    data: {
                        ID: ID,

                    },
                    success: function (data) {
                        $.confirm({
                            icon: 'fas fa-clipboard-list',
                            title: '審核',
                            type: 'dark',
                            typeAnimated: true,
                            content: '' +
                            '<form action="" class="formName">' +
                            '<div class="form-group">' +
                            '<label>報修項目:</label>' +
                            '<input type="text" disabled class="Item_Acceptance form-control" value="' + data[0].fix_item + '">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>地點:</label>' +
                            '<input type="text" disabled class="Local_Acceptance form-control" value="' + data[0].location + '">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>備註:</label>' +
                            '<textarea rows="4" disabled class="Remark_Acceptance form-control" placeholder="">' + data[0].remark + '</textarea>' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>審核:</label>' +
                            '<input type="text" disabled class="edit_AuthUser form-control" value="' + data[0].Acceptance + '">' +
                            '</div>' +
                            '</form>',
                            buttons: {
                                Submit: {
                                    text: '維修確認通過',
                                    btnClass: 'btn-green',
                                    action: function () {
                                        swal({
                                            title: "維修確認?",
                                            text: "",
                                            type: "warning",
                                            showCancelButton: true,
                                            confirmButtonClass: "btn-danger",
                                            confirmButtonText: "確定",
                                            cancelButtonText: "取消",
                                            closeOnConfirm: false
                                        },
                                            function () {
                                                $.ajax({
                                                    url: "Plumber_table_viewer.asmx/Plumber_updateAcceptance",
                                                    method: "post",
                                                    dataType: "json",
                                                    data: {
                                                        ID: data[0].Increment,
                                                    },
                                                    success: function (data) {
                                                        console.log("ajax update " + data);
                                                        AA_Datatable.ajax.reload();
                                                        PDTV.ajax.reload();
                                                        swal({
                                                            title: "確認成功!",
                                                            icon: "success",
                                                            button: "確定",
                                                        });
                                                    },
                                                    error: function (err) {
                                                    },

                                                });

                                            });
                                    }
                                },
                                Cancel: {
                                    text: '取消',
                                    btnClass: 'btn-red',
                                    action: function () {

                                    }
                                }
                            }

                        });
                    },
                    error: function (err) {
                    },

                });
            }
    </script>
    <script>
            var Am_DT;
            function Load_Account_ManageDatatable() {
                $(document).ready(function () {
                    Am_DT = $('#Account_management_DataTable').DataTable({
                        "serverSide": true,
                        "lengthChange": false,
                        "searching": false,
                        "pageLength": 10,
                        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                        "ajax": {
                            "url": "Login_ajax.asmx/Read_all",
                            "type": "GET",
                            "datatype": "json",
                            "dataSrc": function (json) {
                                json.draw = json.data.draw;
                                json.recordsTotal = json.data.iTotalRecords;
                                json.recordsFiltered = json.data.iTotalDisplayRecords;
                                return json.data;
                            },
                        },

                        "oLanguage": {
                            "sProcessing": "處理中...",
                            "sLengthMenu": "顯示 _MENU_ 筆記錄",
                            "sZeroRecords": "無符合資料",
                            "sInfo": "帳號筆數：_TOTAL_",
                            "sInfoEmpty": "無任何資料",
                            "sInfoFiltered": "(過濾總筆數 _MAX_)",
                            "sInfoPostFix": "",
                            "sSearch": "搜尋",
                            "sUrl": "",
                            "oPaginate": {
                                "sFirst": "首頁",
                                "sPrevious": "上頁",
                                "sNext": "下頁",
                                "sLast": "末頁"
                            }
                        },
                        "columns": [
                            { "data": "account", "name": "account", "autoWidth": true },
                            { "data": "psw", "name": "psw", "autoWidth": true },
                            { "data": "user", "name": "user", "autoWidth": true },
                            {
                                "data": "authority", "name": "authority", "autoWidth": true,
                                "render": function (data) {
                                    switch (data) {
                                        case "s":
                                            return '<div style="text-center" title="超級管理者">' + data + '</div>'
                                        case "1":
                                            return '<div style="text-center" title="水電班">' + data + '</div>'
                                        case "2":
                                            return '<div style="text-center" title="秘書行程表管理">' + data + '</div>'
                                        case "3":
                                            return '<div style="text-center" title="資訊室">' + data + '</div>'
                                        case "4":
                                            return '<div style="text-center" title="堂隊、各組室(水電維修確認審核)">' + data + '</div>'
                                        case "5":
                                            return '<div style="text-center" title="人事室出勤狀況管理、水電維修確認審核">' + data + '</div>'

                                    }


                                }
                            },
                            {
                                "data": "Increment", "name": "Increment", "autoWidth": true,
                                "render": function (data) {
                                    return '<a style="width:80px" href="#" id="Edit_info" onclick="AddEdit_authority(' + data + ')"><i class="fas fa-edit"></i></a>'
                                }
                            },

                        ],
                        "columnDefs": [
                            { "className": "dt-center", "targets": "_all" }
                        ],
                    });
                });
            }
            var account_info;
            $(document).on('click', '#new_account', function () {

                $.confirm({
                    icon: 'far fa-user',
                    title: '新增帳號',
                    content:
                    '<form action="" class="formName">' +
                    '<div class="form-group">' +
                    '<label>帳號:</label>' +
                    '<input id="new_account_input" type="text" class="edit_id form-control" maxlength="10" placeholder="6~10碼 至少一個英文和數字">' +
                    '<small id="account_Helper" class="form-text text-muted" >' + "" + '</small>' +
                    '</div>' +
                    '<div class="form-group">' +
                    '<label>密碼:</label>' +
                    '<input id="new_psw_input" type="text" class="edit_id form-control" value="' + '" placeholder="6~12碼 至少一個英文和數字" maxlength="12">' +
                    '<small id="psw_Helper" class="form-text text-muted" >' + "" + '</small>' +
                    '</div>' +
                    '<div class="form-group">' +
                    '<label>權限:</label>' +
                    '<select id="authority_select" class="form-control" onclick="authority_select_value(this)" name="category">' +
                    '<option value="0">請選擇權限</option>' +
                    '<option value="1" title="水電、工作、修繕班報修管理權限">水電班</option>' +
                    '<option value="2" title="行程表管理權限">秘書</option>' +
                    '<option value="3" title="資訊設備報修管理權限">資訊室</option>' +
                    '<option value="4" title="水電報修回報確認權限">堂隊或組室</option>' +
                    '<option value="5" title="請假公告權限">人事室</option>' +
                    '</select>' +
                    '</div>' +
                    '<div class="edit_authority_user form-group">' +
                    '<label id="label_user">使用者:</label>' +
                    '<input id="new_user" type="text" class="form-control" placeholder="輸入姓名或職稱" disabled>' +
                    '</div>' +
                    '<div class="form-group">' +
                    '<select id="group_select" class="form-control" name="category" disabled>' +
                    '<option value="0">請選擇堂隊或組室</option>' +
                    '<option value="1">育樂堂(一隊)</option>' +
                    '<option value="2">育豐堂(二隊)</option>' +
                    '<option value="3">育興堂(三隊)</option>' +
                    '<option value="4">育善堂(四隊)</option>' +
                    '<option value="5">育愛堂(五隊)</option>' +
                    '<option value="6">育智堂(六隊)</option>' +
                    '<option value="7" title="非行程表管理權限(水電班審核使用)">秘書室</option>' +
                    '<option value="8">保健組</option>' +
                    '<option value="9">輔導室</option>' +
                    '<option value="10">人事室</option>' +
                    '<option value="11">主計室</option>' +
                    '<option value="12">政風室</option>' +
                    '</select>' +
                    '</div>' +
                    '</form>',

                    type: 'dark',
                    typeAnimated: true,
                    buttons: {
                        formSubmit: {
                            text: '確定',
                            btnClass: 'btn-blue',
                            action: function () {
                                //檢查空白 跟規則
                                if (check_account()) {
                                    $.ajax({
                                        url: "Login_ajax.asmx/Insert_account",
                                        method: "post",
                                        dataType: "json",
                                        data: {
                                            account: $('#new_account_input').val(),
                                            psw: $('#new_psw_input').val(),
                                            authority: $('#authority_select').val(),
                                            user: $("#authority_select").val() == "4" ? $("#group_select option:selected").text() : $('#new_user').val(),
                                        },
                                        success: function (data) {
                                            if (data.indexOf("帳號新增成功") != -1) {
                                                Am_DT.ajax.reload();
                                                console.log($('#new_account_input').val() + " " + $('#new_psw_input').val() + " " + $('#authority_select').val() + " " + $('#new_user').val());
                                            }
                                            if (data.indexOf("帳號重複") != -1) {
                                                swal({
                                                    title: "帳號重複",
                                                    text: $('#new_account_input').val() + " 帳號重複 \n 請重新填寫",
                                                    type: "warning",
                                                    confirmButtonClass: "btn-danger",
                                                    confirmButtonText: "確定",
                                                    closeOnConfirm: false
                                                })
                                            }
                                        },
                                        error: function (err) { }

                                    });

                                }
                                else {
                                    $.alert(account_info);
                                    return false;
                                }

                            }
                        },
                        tryAgain: {
                            text: '取消',
                            btnClass: 'btn-dark',
                            action: function () {
                            }
                        },
                    },
                    onContentReady: function () {//這不加不會繼續跑ajax因為先被 return false住了
                        // bind to events
                        var jc = this;
                        this.$content.find('form').on('submit', function (e) {
                            // if the user submits the form by pressing enter in the field.
                            e.preventDefault();
                            jc.$$formSubmit.trigger('click'); // reference the button and click it
                        });
                    }
                });
            });
            function check_account() {
                account_info = "";
                if ($('#new_account_input').val().length == 0) {
                    account_info += "[空白欄位] 帳號 <br/>";
                }
                else if (Regex_check($('#new_account_input').val(), /^(?!.*[^a-zA-Z0-9])(?=.*\d)(?=.*[a-zA-Z]).{6,10}$/) != true) {
                    account_info += "[格式錯誤] 帳號(6~10)至少一個英文和數字<br/>";
                }
                if ($('#new_psw_input').val() == 0) {
                    account_info += "[空白欄位] 密碼 <br/>";
                }
                else if (Regex_check($('#new_psw_input').val(), /^(?!.*[^a-zA-Z0-9])(?=.*\d)(?=.*[a-zA-Z]).{6,12}$/) != true) {
                    account_info += "[格式錯誤] 密碼(6~12)至少一個英文和數字<br/>";
                }
                if ($('#new_account_input').val() == $('#new_psw_input').val()) {
                    account_info += "[格式錯誤] 帳號密碼相同<br/>";
                }
                if ($("#authority_select").val() == 0) {
                    account_info += "[空白欄位] 權限<br/>";
                }
                if ($("#authority_select").val() == "4" && $("#group_select option:selected").val() == 0) {
                    account_info += "[空白欄位] 堂隊或組室<br/>";
                }
                if ($("#authority_select").val() != "4" && $("#authority_select").val() != "0" && $('#new_user').val() == "") {
                    account_info += "[空白欄位] 使用者<br/>";
                }
                else if ($("#authority_select").val() != "4" && $("#authority_select").val() != "0" && Regex_check($('#new_user').val(), /^[\u4e00-\u9fa5]{2,9}$/) != true) {
                    account_info += "[格式錯誤] 使用者姓名或職稱(只允許中文)<br/>";
                }
                if (account_info.length != 0) {
                    return false;
                }
                else {
                    return true;
                }
            }
            //var edit_ID = this.$content.find('.edit_id').val();
            //var edit_update_status = this.$content.find('.edit_status_IT').val();
            function AddEdit_authority(id) {
                $.ajax({
                    url: "Login_ajax.asmx/Authority_SearchById",
                    method: "post",
                    dataType: "json",
                    data: {
                        ID: id,
                    },
                    success: function (data) {
                        $.confirm({
                            icon: 'fas fa-clipboard-list',
                            title: '編輯',
                            type: 'dark',
                            typeAnimated: true,
                            content: '' +
                            '<form action="" class="formName">' +
                            '<div class="form-group">' +
                            '<label>帳號:</label>' +
                            '<input type="text" disabled class="edit_AuthAcc form-control" value="' + data[0].account + '">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>密碼:</label>' +
                            '<input type="text" class="edit_AuthPsw form-control" value="' + data[0].psw + '">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>權限:</label>' +
                            '<input type="text" disabled class="edit_Auth form-control" value="' + data[0].authority + '">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>使用者:</label>' +
                            '<input type="text" disabled class="edit_AuthUser form-control" value="' + data[0].user + '">' +
                            '</div>' +

                            '</form>',
                            buttons: {
                                delete: {
                                    text: '刪除',
                                    btnClass: 'btn-red',
                                    action: function () {
                                        //這邊要檢測是不是 super 權限
                                        if (data[0].authority != "超級管理者 [權限:s]") {

                                            swal({
                                                title: "確定刪除" + data[0].account + "?",
                                                text: "帳號將不可回復",
                                                type: "warning",
                                                showCancelButton: true,
                                                confirmButtonClass: "btn-danger",
                                                confirmButtonText: "確定刪除",
                                                cancelButtonText: "取消",
                                                closeOnConfirm: false
                                            },
                                                function () {
                                                    $.ajax({
                                                        url: "Login_ajax.asmx/delete",
                                                        method: "post",
                                                        dataType: "json",
                                                        data: {
                                                            ID: data[0].Increment,
                                                        },
                                                        success: function (data) {
                                                            console.log("ajax update " + data);
                                                            Am_DT.ajax.reload();
                                                            swal({
                                                                title: "成功刪除!",
                                                                text: data + " 已刪除",
                                                                type: "success",
                                                                showCancelButton: true,
                                                                confirmButtonClass: "btn-danger",
                                                                confirmButtonText: "確定",
                                                                cancelButtonText: "取消",
                                                                closeOnConfirm: false
                                                            });
                                                        },
                                                        error: function (err) {
                                                        },

                                                    });

                                                });

                                        }
                                        else { swal("禁止刪除", "此權限為超級管理者", "error"); }


                                    }
                                },
                                formSubmit: {
                                    text: '更新',
                                    btnClass: 'btn-blue',
                                    action: function () {
                                        var psw = this.$content.find('.edit_AuthPsw').val();
                                        $.ajax({
                                            url: "Login_ajax.asmx/Update",
                                            method: "post",
                                            dataType: "json",
                                            data: {
                                                ID: data[0].Increment,
                                                psw: psw
                                            },
                                            success: function (data) {
                                                console.log("ajax update " + data);
                                                Am_DT.ajax.reload();
                                                swal("系統回傳", data, "success");
                                            },
                                            error: function (err) {

                                            },

                                        });
                                    }
                                },
                                cancel: {
                                    text: '取消',
                                    btnClass: 'btn-dark',
                                },
                            },
                            //onContentReady: function () {
                            //    // bind to events
                            //    var jc = this;
                            //    this.$content.find('form').on('submit', function (e) {
                            //        // if the user submits the form by pressing enter in the field.
                            //        e.preventDefault();
                            //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                            //    });
                            //}
                        });
                    },
                    error: function (err) {

                    },

                });

            }
            function authority_select_value(obj) {
                console.log("obj " + obj.options[obj.selectedIndex].text);
                if (obj.options[obj.selectedIndex].value == 4) {
                    $('#new_user').attr('disabled', 'disabled');
                    $('#group_select').removeAttr('disabled');
                    $('#new_user').val("");
                }
                else if (obj.options[obj.selectedIndex].value != 0) {
                    $('#group_select').attr('disabled', 'disabled');
                    $('#new_user').removeAttr('disabled');
                    $("#group_select").val(0);
                }
                else if (obj.options[obj.selectedIndex].value == 0) {
                    $('#group_select').attr('disabled', 'disabled');
                    $('#new_user').attr('disabled', 'disabled');
                    $('#new_user').val("");
                    $("#group_select").val(0);
                }
            }
            function Selected_host(obj) {
                if (obj.options[obj.selectedIndex].value == 9) {//選到 自填 主持人
                    $('#new_Ss_Modal_host').removeAttr('disabled');
                }
                else {
                    $('#new_Ss_Modal_host').attr('disabled', 'disabled');
                }

            }
    </script>



    <div id="Account_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #34495e;">
                    <button type="button" id="Account_management_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #34495e;"><span class="far fa-user"></span>使用者管理</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-md-4 text-left">
                            <button type="button" id="new_account" class="btn btn-warning">新增帳號</button>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                    </div>
                    <table id="Account_management_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>帳號</th>
                                <th>密碼</th>
                                <th>使用者</th>
                                <th>權限</th>
                                <th>編輯</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>帳號</th>
                                <th>密碼</th>
                                <th>使用者</th>
                                <th>權限</th>
                                <th>編輯</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script>  

</script>


    <!-- 派工單填寫 plumber_Modal-->
    <div id="plumber_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="plumber_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><span class="glyphicon glyphicon-copy"></span>工作班預約派工單</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="dropdown">
                                <label for="label_repairs" class="col-md-12">申請單位:</label>
                                <div class="col-md-12">
                                    <button class="btn btn-success dropdown-toggle" type="button" id="dropdownMenuButton_group_plumber" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        請選擇單位
                                        <span class="caret"></span>
                                    </button>
                                    <ul id="plumber_group_list" class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                        <li><a id="plumber_1">秘書室</a></li>
                                        <li><a id="plumber_2">保健組</a></li>
                                        <li><a id="plumber_3">輔導室</a></li>
                                        <li><a id="plumber_10">人事室</a></li>
                                        <li><a id="plumber_11">主計室</a></li>
                                        <li><a id="plumber_12">政風室</a></li>
                                        <li><a id="plumber_4">育樂堂(一隊)</a></li>
                                        <li><a id="plumber_5">育豐堂(二隊)</a></li>
                                        <li><a id="plumber_6">育興堂(三隊)</a></li>
                                        <li><a id="plumber_7">育善堂(四隊)</a></li>
                                        <li><a id="plumber_8">育愛堂(五隊)</a></li>
                                        <li><a id="plumber_9">育智堂(六隊)</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="label_repairs">報修人:</label>
                            <input type="text" class="form-control" id="plumber_reporter" placeholder="請輸入姓名 *必填">
                        </div>
                        <div class="col-md-3">
                            <label for="label_repairs">報修人分機:</label>
                            <input type="text" class="form-control" id="plumber_reporter_phone" placeholder="請輸入分機 *必填">
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-4 text-center">
                            <button id="new_item" type="button" class="btn btn-warning">新增項目</button>
                            <button id="del_item" type="button" class="btn btn-danger" disabled="true">刪除項目</button>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <br>
                    <div class="row" id="item_card">
                        <div class="col-md-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading text-center">維修項目1</div>
                                <div class="panel-body">
                                    <div class="col-md-2">
                                        <label for="label_repairs">報修項目:</label>
                                        <div class="dropdown ">
                                            <button class="btn btn-success dropdown-toggle" type="button" id="dropdownMenuButton_item_plumber1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                                請選擇項目 <span class="caret"></span>
                                            </button>
                                            <ul id="plumber_device_items1" class="dropdown-menu scrollable-menu" aria-labelledby="dropdownMenuButton_item">
                                                <span class="dropdown-header" style="background-color: rgb(220,220,220);">傢俱類</span>
                                                <li><a href="#">衣櫃</a></li>
                                                <li><a href="#">書桌</a></li>
                                                <li><a href="#">椅子</a></li>
                                                <li><a href="#">門</a></li>
                                                <li><a href="#">門鎖</a></li>
                                                <li><a href="#">床</a></li>
                                                <li><a href="#">窗戶</a></li>
                                                <span class="dropdown-header" style="background-color: rgb(220,220,220);">淋浴/廁所類</span>
                                                <li><a href="#">熱水</a></li>
                                                <li><a href="#">馬桶</a></li>
                                                <li><a href="#">水龍頭</a></li>
                                                <li><a href="#">蓮蓬頭</a></li>
                                                <span class="dropdown-header" style="background-color: rgb(220,220,220);">電器類</span>
                                                <li><a href="#">電燈</a></li>
                                                <li><a href="#">冷氣</a></li>
                                                <span class="dropdown-header" style="background-color: rgb(220,220,220);">公設類</span>
                                                <li><a href="#">監視器</a></li>
                                                <li><a href="#">電梯</a></li>
                                                <li><a href="#">呼叫鈴</a></li>
                                                <li><a href="#">飲水機</a></li>
                                                <span class="dropdown-header" style="background-color: rgb(220,220,220);">其他類</span>
                                                <li><a href="#">其他</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="label_number">報修地點或房號:</label>
                                        <input type="text" class="form-control col-sm-9" id="plumber_local1" placeholder="請輸入地點或房號 *必填">
                                    </div>
                                    <div class="col-md-6">
                                        <label for="message-text" class="form-control-label">說明:</label>
                                        <textarea class="form-control" placeholder="故障簡述" id="remark1"></textarea>
                                        <br>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4 container text-center">
                            <button type="submit" id="plumer_submit" class="btn btn-primary">送出</button>
                        </div>
                        <div class="col-md-4"></div>
                    </div>
                    <br>
                </div>
            </div>
        </div>
    </div>
    <%-- 新增刪除JQ --%>
    <script>
            var count = 1;
            var plumer_info = "";
            $(new_item).click(function () {
                count++;
                var new_item_str = '<div class="col-md-12" id="card_' + count + '">' +
                    '<div class="panel panel-primary ">' +
                    '<div class="panel-heading text-center">維修項目' + count + '</div>' +
                    '<div class="panel-body">' +
                    '<div class="col-md-2">' +
                    '<label for="label_repairs">報修項目:</label>' +
                    '<div class="dropdown ">' +
                    '<button class="btn btn-success dropdown-toggle" ' + 'type="button" id="dropdownMenuButton_item_plumber' + count + '" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">' +
                    '請選擇項目 <span class="caret"></span>' +
                    '</button>' +
                    '<ul id="plumber_device_items' + count + '" class="dropdown-menu ' + 'scrollable-menu" aria-labelledby="dropdownMenuButton_item">' +
                    '<span class="dropdown-header" style="background-color: rgb(220,220,220);">' +
                    '傢俱類' +
                    '</span>' +
                    '<li><a href="#">衣櫃</a></li>' +
                    '<li><a href="#">書桌</a></li>' +
                    '<li><a href="#">椅子</a></li>' +
                    '<li><a href="#">門</a></li>' +
                    '<li><a href="#">門鎖</a></li>' +
                    '<li><a href="#">床</a></li>' +
                    '<li><a href="#">窗戶</a></li>' +
                    '<span class="dropdown-header" style="background-color: rgb(220,220,220);">' +
                    '淋浴/廁所類' +
                    '</span>' +
                    '<li><a href="#">熱水</a></li>' +
                    '<li><a href="#">馬桶</a></li>' +
                    '<li><a href="#">水龍頭</a></li>' +
                    '<li><a href="#">蓮蓬頭</a></li>' +
                    '<span class="dropdown-header" style="background-color: rgb(220,220,220);">' +
                    '電器類' +
                    '</span>' +
                    '<li><a href="#">電燈</a></li>' +
                    '<li><a href="#">冷氣</a></li>' +
                    '<span class="dropdown-header" style="background-color: rgb(220,220,220);">' +
                    '公設類' +
                    '</span>' +
                    '<li><a href="#">監視器</a></li>' +
                    '<li><a href="#">電梯</a></li>' +
                    '<li><a href="#">呼叫鈴</a></li>' +
                    '<span class="dropdown-header" style="background-color: rgb(220,220,220);">其他類</span>' +
                    '<li><a href="#">其他</a></li>' +
                    '</ul>' +
                    '</div>' +
                    '</div>' +
                    '<div class="col-md-4">' +
                    '<label for="label_number">報修地點或房號:</label>' +
                    '<input type="text" class="form-control col-sm-9" id="plumber_local' + count + '" placeholder="請輸入地點或房號 *必填">' +
                    '</div>' +
                    '<div class="col-md-6">' +
                    '<label for="message-text" class="form-control-label">說明:</label>' +
                    '<textarea class="form-control" placeholder="故障簡述" id="remark' + count + '"></textarea>' +
                    '<br>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';


                $(item_card).append(new_item_str);
                if (count == 5) {
                    $(del_item).attr('disabled', false);
                    $(new_item).attr('disabled', true);
                }
                if (count == 2) {
                    $(del_item).attr('disabled', false);
                }

            });
            $(del_item).click(function () {
                if (count > 1) {
                    var id_div = "#card_" + count;
                    console.log("del: " + count + " empty: " + id_div);
                    $(del_item).attr('disabled', false);
                    $(id_div).remove();
                    count--;
                    if (count == 1) {
                        $(del_item).attr('disabled', true);
                        $(new_item).attr('disabled', false);
                    }
                }

                if (count < 5 && count > 1) {
                    $(new_item).attr('disabled', false);

                }
            });
            $(document).on('click', '#plumber_Modal_cannel', function () {//plumber_Modal取消回復初始化
                initial_plumber_Modal();
            });
            $(document).on('click', '#new_Ss_Modal_cancel', function () {//datepicker回復初始化
                initial_datetimepicker_input();
            });

            function plumer_check() {

                if ($("#dropdownMenuButton_group_plumber").text().indexOf("請選擇單位") != -1) {
                    plumer_info += "申請單位<br/>";
                }
                if (Regex_check($('#plumber_reporter').val(), /^[\u4e00-\u9fa5]{2,9}$/) != true) {
                    plumer_info += "報修人<br/>";
                }
                if (Regex_check($('#plumber_reporter_phone').val(), /^[0-9]{3}$/) != true) {
                    plumer_info += "報修人分機<br/>";
                }
                for (var i = 1; i <= count; i++) {
                    if (i >= 2) {
                        if ($("#dropdownMenuButton_item_plumber" + i).text().indexOf("請選擇項目") != -1) {
                            plumer_info += "※不使用的項目請刪除<br/>";
                            plumer_info += "[維修項目" + i + "] 報修項目<br />";
                        }
                        if ($("#plumber_local" + i).val().replace(" ", "") == "") {
                            plumer_info += "[維修項目" + i + "] 報修地點或房號<br/>";
                        }
                    }
                    else {
                        if ($("#dropdownMenuButton_item_plumber" + i).text().indexOf("請選擇項目") != -1) {
                            plumer_info += "[維修項目" + i + "] 報修項目<br/>";
                        }
                        if ($("#plumber_local" + i).val().replace(" ", "") == "") {
                            plumer_info += "[維修項目" + i + "] 報修地點或房號<br/>";
                        }
                    }
                }
                if (plumer_info.length > 0) {
                    return false;
                }
                else { return true; }

            }
    </script>
    <div id="IT_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #5bc0de;">
                    <button type="button" id="IT_management_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #5bc0de;"><span class="glyphicon glyphicon-copy"></span>資訊室維修進度查詢</h4>
                </div>
                <div class="modal-body">
                    <table id="IT_management_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>操作</th>
                                <%--<th>備註</th>--%>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>操作</th>
                                <%--<th>備註</th>--%>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script>
            var ITMDB;
            var count_ajax = 0;
            function Load_IT_ManageDatetable() {
                $(document).ready(function () {
                    ITMDB = $('#IT_management_DataTable').DataTable({
                        "serverSide": true, //serverSide打開
                        "searching": true,
                        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                        "ajax": {
                            "url": "IT_table_viewer.asmx/IT_table",
                            "type": "GET",
                            "datatype": "json",
                            "data": function (d) {
                                d.search = $('#IT_management_DataTable_filter input').val();
                            },
                            "dataSrc": function (json) {
                                json.draw = json.data.draw;
                                json.recordsTotal = json.data.iTotalRecords;
                                json.recordsFiltered = json.data.iTotalDisplayRecords;
                                return json.data;
                            }

                        },
                        "oLanguage": {
                            "sProcessing": "處理中...",
                            "sLengthMenu": "顯示 _MENU_ 筆記錄",
                            "sZeroRecords": "無符合資料",
                            "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                            "sInfoEmpty": "無任何資料",
                            "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                            "sInfoPostFix": "",
                            "sSearch": "搜尋",
                            "sUrl": "",
                            "oPaginate": {
                                "sFirst": "首頁",
                                "sPrevious": "上頁",
                                "sNext": "下頁",
                                "sLast": "末頁"
                            }
                        },
                        "columns": [
                            {
                                "data": "unit", "name": "unit", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="text-center width:80px">' + data + '</div>'
                                }
                            },
                            {
                                "data": "reporter", "name": "reporter", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="text-center width:80px">' + data + '</div>'
                                }
                            },
                            {
                                "data": "report_item", "name": "report_item", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="text-center width:100px">' + data + '</div>'
                                }
                            },
                            {
                                "data": "date", "name": "date", "autoWidth": true, "orderable": true,
                                "render": function (data) {
                                    return '<div style="text-center width:80px">' + data + '</div>'
                                }
                            },
                            {
                                "data": "status", "name": "status", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="text-center width:80px">' + data + '</div>'
                                }
                            },
                            {
                                "data": "strid", "name": "strid", "autoWidth": true,
                                "render": function (data) {
                                    return '<a style="width:80px" href="#" onclick="AddEditID_IT(\'' + data + '\')"><i class="fas fa-edit"></i></a>'
                                }

                            },
                            //{
                            //    "data": "remark", "name": "remark", "autoWidth": true,
                            //    "render": function (data) {
                            //        return '<div style="text-center width:100px">' + data +'</div>'
                            //    }
                            //},
                        ],
                        "columnDefs": [
                            { "className": "dt-center", "targets": "_all" }
                        ],
                    });
                });
            }
            function AddEditID_IT(data) {
                console.log("data = " + data);
                $.ajax({
                    url: "IT_table_viewer.asmx/IT_table_Search",
                    method: "post",
                    dataType: "json",
                    data: {
                        ID: data,
                    },
                    success: function (data) {
                        //var date = data[0].date;
                        console.log("ajax feedback " + data[0].date);
                        $.confirm({
                            icon: 'fas fa-clipboard-list',
                            title: '編輯',
                            type: 'purple',
                            typeAnimated: true,
                            content: '' +
                            '<form action="" class="formName">' +
                            '<div class="form-group">' +
                            '<label>資料庫ID:</label>' +
                            '<input type="text" disabled class="edit_id form-control" value="' + data[0].strid + '" placeholder="">' +
                            '<small id="emailHelp" class="form-text text-muted" >' + "[IP:" + data[0].IP + "]" + '</small>' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>回報狀態:</label>' +
                            '<select class="edit_status_IT form-control" name="category">' +
                            '<option>' + data[0].status + '</option>' +
                            '<option>處理完畢</option>' +
                            '<option>維修中</option>' +
                            '<option>已委託廠商處理中</option>' +
                            '</select>' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修單位:</label>' +
                            '<input type="text" disabled class="edit_Unit form-control" value="' + data[0].unit + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>時間:</label>' +
                            '<input type="text" disabled class="edit_date form-control" value="' + data[0].date + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修人:</label>' +
                            '<input type="text" disabled class="edit_reporter form-control" value="' + data[0].reporter + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>分機:</label>' +
                            '<input type="text" disabled class="edit_reporter_phone form-control" value="' + data[0].phone + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修項目:</label>' +
                            '<input type="text" disabled class="edit_report_item form-control" value="' + data[0].report_item + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>備註:</label>' +
                            '<textarea rows="4" disabled class="edit_remark form-control" placeholder="">' + data[0].remark + '</textarea>' +
                            '</div>' +
                            '</form>',
                            buttons: {
                                delete: {
                                    text: '刪除',
                                    btnClass: 'btn-red',
                                    action: function () {
                                        var edit_ID = this.$content.find('.edit_id').val();
                                        swal({
                                            title: "刪除確認",
                                            text: "時間:" + data[0].date + "\n報修單位:" + data[0].unit + "\n報修人:" + data[0].reporter + "\n報修項目:" + data[0].report_item,
                                            type: "warning",
                                            showCancelButton: true,
                                            confirmButtonClass: "btn-danger",
                                            cancelButtonText: "取消",
                                            confirmButtonText: "確定",
                                            closeOnConfirm: true
                                        },
                                            function () {
                                                $.ajax({
                                                    url: "IT_table_viewer.asmx/IT_Delete",
                                                    method: "post",
                                                    dataType: "json",
                                                    data: {
                                                        ID: edit_ID,
                                                    },
                                                    success: function (data) {
                                                        console.log("ajax update " + data);
                                                        ITMDB.ajax.reload();
                                                        IT_table.ajax.reload();
                                                    },
                                                    error: function (err) {

                                                    },
                                                });
                                            });
                                    },
                                },
                                formSubmit: {
                                    text: '更新',
                                    btnClass: 'btn-blue',
                                    action: function () {
                                        var edit_ID = this.$content.find('.edit_id').val();
                                        var edit_update_status = this.$content.find('.edit_status_IT').val();
                                        $.ajax({
                                            url: "IT_table_viewer.asmx/IT_update",
                                            method: "post",
                                            dataType: "json",
                                            data: {
                                                ID: edit_ID,
                                                update_status: edit_update_status
                                            },
                                            success: function (data) {
                                                console.log("ajax update " + data);
                                                ITMDB.ajax.reload();
                                                IT_table.ajax.reload();
                                            },
                                            error: function (err) {

                                            },

                                        });
                                    }
                                },
                                cancel: {
                                    text: '取消',
                                    action: function () {

                                        //close
                                    },
                                }
                            },
                            //onContentReady: function () {
                            //    // bind to events
                            //    var jc = this;
                            //    this.$content.find('form').on('submit', function (e) {
                            //        // if the user submits the form by pressing enter in the field.
                            //        e.preventDefault();
                            //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                            //    });
                            //}
                        });
                    },
                    error: function (err) {

                    },

                });
            }
    </script>
    <div id="Pulmber_management_Modal" class="modal fade bd-example-modal-lg" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="true" style="display: none;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div style="padding: 35px 50px; background-color: #337ab7;">
                    <button type="button" id="Pulmber_management_DataTable_Modal_cannel" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="background-color: #337ab7;"><span class="glyphicon glyphicon-copy"></span>水電班維修進度管理</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12" style="text-align: right">
                            <%--<button type="button" id="Generator_Form" class="btn btn-info" data-toggle="modal" data-target="#Plumber_DownloadForm_Modal">表格產生</button>--%>
                            <button type="button" id="Generator_Form" class="btn btn-info" onclick="Generator_FormOnClick()">表格產生</button>
                        </div>
                    </div>
                    <table id="Pulmber_management_DataTable" class="display" style="width: 100%">
                        <thead>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr style="text-align: left;">
                                <th>單位</th>
                                <th>報修人</th>
                                <th>報修項目</th>
                                <th>地點</th>
                                <th>備註</th>
                                <th>報修時間</th>
                                <th>受理狀態</th>
                                <th>操作</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script>
            var PMDB;
            var count_ajax = 0;
            function Load_Pulmber_ManageDatatable() {
                $(document).ready(function () {
                    PMDB = $('#Pulmber_management_DataTable').DataTable({
                        "serverSide": true, //serverSide打開
                        "searching": false,
                        //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                        "ajax": {
                            "url": "Plumber_table_viewer.asmx/Plumber_table",
                            "type": "GET",
                            "datatype": "json",
                            "data": function (d) {
                                //d.search = $('#Pulmber_management_DataTable_filter input').val();
                                d.search = "";
                            },
                            "dataSrc": function (json) {
                                json.draw = json.data.draw;
                                json.recordsTotal = json.data.iTotalRecords;
                                json.recordsFiltered = json.data.iTotalDisplayRecords;
                                return json.data;
                            }

                        },
                        "oLanguage": {
                            "sProcessing": "處理中...",
                            "sLengthMenu": "顯示 _MENU_ 筆記錄",
                            "sZeroRecords": "無符合資料",
                            "sInfo": "目前記錄：_START_ 至 _END_, 總筆數：_TOTAL_",
                            "sInfoEmpty": "無任何資料",
                            "sInfoFiltered": "(搜尋的總筆數 _MAX_)",
                            "sInfoPostFix": "",
                            "sSearch": "搜尋",
                            "sUrl": "",
                            "oPaginate": {
                                "sFirst": "首頁",
                                "sPrevious": "上頁",
                                "sNext": "下頁",
                                "sLast": "末頁"
                            }
                        },
                        "columns": [
                            {
                                "data": "Unit", "name": "Unit", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:90px;">' + data + "</div>";
                                }
                            },
                            {
                                "data": "reporter", "name": "reporter", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:60px;">' + data + "</div>";
                                }
                            },
                            {
                                "data": "fix_item", "name": "fix_item", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:80px;">' + data + "</div>";
                                }
                            },
                            {
                                "data": "location", "name": "location", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:100px;">' + data + "</div>";
                                }
                            },
                            {
                                "data": "remark", "name": "remark", "autoWidth": true,
                                "render": function (data, type) {

                                    if (type === 'display') {
                                        if (data.length > 5) {
                                            return '<div class="text-center" style="width:100px; title="' + data + '">' + data.substr(0, 4) + '...</div>';
                                        } else {
                                            return '<div class="text-center" style="width:100px; title="' + data + '">' + data + '</div>';
                                        }
                                    }
                                    return data;
                                    //return '<div style="width:100px;">' + data + "</div>";
                                }



                            },
                            {
                                "data": "time", "name": "time", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:80px;">' + data + "</div>";
                                }
                            },
                            {
                                "data": "status", "name": "status", "autoWidth": true,
                                "render": function (data) {
                                    return '<div style="width:80px;">' + data + "</div>";
                                }
                            },
                            {
                                //"data": "id.Increment", "name": "id.Increment", "autoWidth": true,
                                "data": "strid", "name": "strid", "autoWidth": true,
                                "render": function (data, type, row, meta) {
                                    return '<a href="#" style="width:50px;" onclick="AddEditID_Plumber(\'' + data + '\')"><i class="fas fa-edit"></i></a>  <input type="checkbox" name="checklist" value="' + data + '" />'

                                }

                            },
                        ],
                        "columnDefs": [
                            { "className": "dt-center", "targets": "_all" },
                        ],

                    });
                });
            }
            function Generator_FormOnClick() {
                var c = [];
                $("input[type=checkbox]:checked").each(function () {
                    c.push($(this).val());
                });
                //result = c.toString();
                if (c.length == 0) {
                    $.confirm({
                        icon: 'far fa-check-circle',
                        title: '錯誤',
                        content: '請勾選需要產生表格的資料!',
                        type: 'red',
                        typeAnimated: true,
                        buttons: {
                            close: {
                                text: '確定',
                                btnClass: 'btn-red',

                            },
                        }
                    });
                }
                else {
                    var ResultTable = jQuery('<div/>').append(jQuery('<table/>').append($('.hDivBox').find('thead').clone()).append($('.bDiv').find('tbody').clone()));
                    var list = [$(ResultTable).html()];
                    var jsonText = JSON.stringify({ list: list });
                    //檔案下載網址
                    var url = "/Download.ashx";

                    //產生 form
                    var form = document.createElement("form");
                    form.method = "POST";
                    form.action = url;

                    //如果想要另開視窗可加上target
                    //form.target = "_blank";
                    //index為要下載的檔案編號，存入hidden跟表單一起送出

                    var input = document.createElement("input");
                    input.type = "hidden";
                    input.name = "Parameter";
                    input.value = c;
                    form.appendChild(input);

                    //送出表單並移除 form
                    var body = document.getElementsByTagName("body")[0];
                    body.appendChild(form);
                    form.submit();
                    form.remove();
                    $("input[name='checklist']").each(function () {
                        $(this).prop("checked", false);
                    });
                }
            }
            function AddEditID_Plumber(data) {
                console.log("data = " + data);
                $.ajax({
                    url: "Plumber_table_viewer.asmx/Plumber_Search",
                    method: "post",
                    dataType: "json",
                    data: {
                        ID: data,
                    },
                    success: function (data) {
                        var time = data[0].time;
                        var id_userinfo = "[IP:" + data[0].PC_ip + "]";
                        console.log("ajax feedback " + data[0].time + "strid = " + data[0].strid);
                        $.confirm({
                            icon: 'fas fa-clipboard-list',
                            title: '編輯',
                            type: 'purple',
                            typeAnimated: true,
                            content: '' +
                            '<form action="" class="formName">' +
                            '<div class="form-group">' +
                            '<label>資料庫ID:</label>' +
                            //'<input type="text" disabled class="edit_id form-control" value="' + data[0].Increment + '" placeholder="">' +
                            '<input type="text" disabled class="edit_id form-control" value="' + data[0].strid + '" placeholder="">' +
                            '<small class="form-text text-muted" >' + id_userinfo + '</small>' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>回報狀態:</label>' +
                            '<select class="edit_status_Plumber form-control" name="category">' +
                            '<option>' + data[0].status + '</option>' +
                            '<option>已修繕完畢</option>' +
                            '<option>水電班處理中</option>' +
                            '<option>備料中</option>' +
                            '<option>已委託工作班處理中</option>' +
                            '<option>已委託修繕班處理中</option>' +
                            '<option>已委託廠商處理中</option>' +
                            '</select>' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修單位:</label>' +
                            '<input type="text" disabled class="edit_Unit form-control" value="' + data[0].Unit + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>時間:</label>' +
                            '<input type="text" disabled class="edit_time form-control" value="' + time + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修人:</label>' +
                            '<input type="text" disabled class="edit_reporter form-control" value="' + data[0].reporter + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修項目:</label>' +
                            '<input type="text" disabled class="edit_fix_item form-control" value="' + data[0].fix_item + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>報修地點:</label>' +
                            '<input type="text" disabled class="edit_location form-control" value="' + data[0].location + '" placeholder="">' +
                            '</div>' +
                            '<div class="form-group">' +
                            '<label>備註:</label>' +
                            '<textarea rows="5" class="edit_remark_manament form-control" placeholder="">' + data[0].remark + '</textarea>' +
                            '</div>' +
                            //'<label>回報狀態:</label>' +
                            //'<input type="text" class="edit_status form-control" value="' + data[0].status + '" placeholder="">' +

                            '</form>',
                            buttons: {
                                Delete: {
                                    text: '刪除',
                                    btnClass: 'btn-red',
                                    action: function () {
                                        var edit_ID = this.$content.find('.edit_id').val();
                                        swal({
                                            title: "刪除確認",
                                            text: "時間:" + time + "\n報修單位:" + data[0].Unit + "\n報修人:" + data[0].reporter + "\n報修項目:" + data[0].fix_item,
                                            type: "warning",
                                            showCancelButton: true,
                                            confirmButtonClass: "btn-danger",
                                            cancelButtonText: "取消",
                                            confirmButtonText: "確定",
                                            closeOnConfirm: true
                                        },
                                            function () {
                                                $.ajax({
                                                    url: "Plumber_table_viewer.asmx/Delete",
                                                    method: "post",
                                                    dataType: "json",
                                                    data: {
                                                        ID: edit_ID,
                                                    },
                                                    success: function (data) {
                                                        console.log("ajax update " + data);
                                                        PMDB.ajax.reload();
                                                        PDTV.ajax.reload();
                                                    },
                                                    error: function (err) {

                                                    },
                                                });
                                            });
                                    },
                                },
                                formSubmit: {
                                    text: '更新',
                                    btnClass: 'btn-blue',
                                    action: function () {
                                        var edit_ID = this.$content.find('.edit_id').val();
                                        var edit_update_status = this.$content.find('.edit_status_Plumber').val();
                                        var edit_update_remark = this.$content.find('.edit_remark_manament').val();
                                        $.ajax({
                                            url: "Plumber_table_viewer.asmx/Plumber_update",
                                            method: "post",
                                            dataType: "json",
                                            data: {
                                                ID: edit_ID,
                                                update_status: edit_update_status,
                                                remark: edit_update_remark
                                            },
                                            success: function (data) {
                                                console.log("ajax update " + data);
                                                PMDB.ajax.reload();
                                                PDTV.ajax.reload();
                                            },
                                            error: function (err) {

                                            },

                                        });
                                    }
                                },
                                cancel: {
                                    text: '取消',
                                    action: function () {

                                        //close
                                    },
                                }
                            },
                            //onContentReady: function () {
                            //    // bind to events
                            //    var jc = this;
                            //    this.$content.find('form').on('submit', function (e) {
                            //        // if the user submits the form by pressing enter in the field.
                            //        e.preventDefault();
                            //        jc.$$formSubmit.trigger('click'); // reference the button and click it
                            //    });
                            //}
                        });
                    },
                    error: function (err) {

                    },

                });
            }
            $(document).on('click', '#plumer_submit', function () {
                plumer_info = ""

                if (plumer_check() == true) {
                    var count_success = 0;
                    for (var i = 1; i <= count; i++) {
                        $.ajax({
                            url: "Plumber_Table.asmx/Plumber_Table_insert",
                            method: "post",
                            dataType: "json",
                            data: {
                                dmpgp: $("#dropdownMenuButton_group_plumber").text(),
                                plumber_reporter: $('#plumber_reporter').val(),
                                plumber_reporter_phone: $('#plumber_reporter_phone').val(),
                                dmpip: $("#dropdownMenuButton_item_plumber" + i).text(),
                                plumber_local: $("#plumber_local" + i).val(),
                                remark: $("#remark" + i).val()
                            },
                            success: function (data) {
                                count_success++;
                                if (count_success == count) {
                                    //PMDB.ajax.reload();
                                    PDTV.ajax.reload();
                                    $.confirm({
                                        icon: 'far fa-check-circle',
                                        title: '成功',
                                        content: '報修成功' + data,
                                        type: 'green',
                                        typeAnimated: true,
                                        buttons: {
                                            close: {
                                                text: '確定',
                                                btnClass: 'btn-green',
                                                action: function () {
                                                    $('#plumber_Modal').modal('hide');
                                                    initial_plumber_Modal();
                                                }
                                            },
                                        }
                                    });
                                }
                            },
                            error: function (data) {
                                if (count_success == count) {
                                    $.confirm({
                                        title: '報修失敗',
                                        content: '請再重新報修或是通知資訊室' + data,
                                        type: 'red',
                                        typeAnimated: true,
                                        buttons: {
                                            tryAgain: {
                                                text: '返回首頁',
                                                btnClass: 'btn-red',
                                                action: function () {
                                                    $('#plumber_Modal').modal('hide');
                                                    initial_plumber_Modal();
                                                }
                                            },
                                        }
                                    });
                                }
                            },

                        });
                    }

                }
                else {
                    $.confirm({
                        icon: 'fas fa-minus-circle',
                        title: '表格錯誤或空白',
                        content: plumer_info,
                        type: 'red',
                        typeAnimated: true,
                        buttons: {
                            tryAgain: {
                                text: '返回',
                                btnClass: 'btn-red',
                                action: function () {
                                }
                            },
                        }
                    });
                }


            });
    </script>

</body>
