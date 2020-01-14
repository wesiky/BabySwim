$(function () {
    $("#LoginSys").click(function () {
        LoginSys();
    });
});
function LoginSys() {
    var dialog = document.querySelector("dialog");
    $("#FamilyCode").removeClass("input-validation-error");
    $("#FamilyName").removeClass("input-validation-error");
    if ($.trim($("#FamilyCode").val()) == "") {
        $("#mes").html("家长编号不能为空！");
        return;
    }
    if ($.trim($("#FamilyName").val()) == "") {
        $("#mes").html("家长姓名不能为空！");
        return;
    }
    //---------------------------------------------------------------------
    $.post('/Bind', { familyCode: $("#FamilyCode").val(), familyName: $("#FamilyName").val()},
        function (data) {

            if (data.resultCode == "0") {
                    window.location = "/BindSuccess"
            } else {
                $("#mes").html(data.resultMsg);
            }
        }, "json");
    return false;
}