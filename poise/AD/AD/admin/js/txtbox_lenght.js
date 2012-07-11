$(document).ready(function () {
    $(".baiducss").keyup(function () {
        if ($(".baiducss").val().length > 50) {
            $(".baiducss").val($(".baiducss").val().substring(0, 50));
        }
        $(".word").text(50 - $(".baiducss").val().length);
        var num = $(".word").text();
        if (num == 0) {
            $(".word").text('只能输入50个字符');
            $(".baiducss").attr("disabled", true);
        } else {
            $(".baiducss").attr("disabled", false);
        }
    });
});
