$(function () {
    $("#LoginSys").click(function () {
        LoginSys();
    });
});
function LoginSys() {
    $("#mes").html("");
    $("#FamilyCode").removeClass("input-validation-error");
    $("#FamilyName").removeClass("input-validation-error");
    if ($.trim($("#FamilyCode").val()) == "") {
        $("#FamilyCode").addClass("input-validation-error").focus();
        $("#mes").html("家长编号不能为空！");
        return;
    }
    if ($.trim($("#FamilyName").val()) == "") {
        $("#FamilyName").addClass("input-validation-error").focus();
        $("#mes").html("家长姓名不能为空！");
        return;
    }
    $("#Loading").show();
    //---------------------------------------------------------------------
    $.post('/Bind', { familyCode: $("#FamilyCode").val(), familyName: $("#FamilyName").val()},
        function (data) {

            if (data.resultCode == "0") {
                    window.location = "/BindSuccess"
            } else {
                d = new Date();
                $("#mes").html(data.resultMsg);
            }
            $("#Loading").hide();
        }, "json");
    return false;
}