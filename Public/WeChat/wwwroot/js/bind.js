$(function () {
    $("#LoginSys").click(function () {
        LoginSys();
    });
    $("#dia-btn").click(function () {
        var dialog = document.querySelector("dialog");
        dialog.close();
    });
});
function LoginSys() {
    var dialog = document.querySelector("dialog");
    $("#FamilyCode").removeClass("input-validation-error");
    $("#FamilyName").removeClass("input-validation-error");
    if ($.trim($("#FamilyCode").val()) == "") {
        document.querySelector('#tip').innerHTML = "家长编号不能为空！"
        dialog.show();
        return;
    }
    if ($.trim($("#FamilyName").val()) == "") {
        document.querySelector('#tip').innerHTML = "家长编号不能为空！"
        dialog.show();
        return;
    }
    //---------------------------------------------------------------------
    $.post('/Bind', { familyCode: $("#FamilyCode").val(), familyName: $("#FamilyName").val()},
        function (data) {

            if (data.resultCode == "0") {
                    window.location = "/BindSuccess"
            } else {
                document.querySelector('#tip').innerHTML = data.resultMsg
                dialog.show();
            }
        }, "json");
    return false;
}