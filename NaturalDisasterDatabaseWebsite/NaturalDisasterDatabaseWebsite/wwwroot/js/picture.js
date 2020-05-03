$(function () {
    $("#upload").click(function () {
        var fileUpload = $("#files").get(0);//获得第一个files的名称和值
        var files = fileUpload.files;//获取文件信息
        var data = new FormData();//通过FormData构造函数创建一个空对象
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);//通过append方法追加数据
        }
        var s = document.form1.files.value;
        if (s == "") {
            alert("请选择文件");
            document.form1.files.focus();
            return;
        }
        $.ajax({
            type: "post",
            url: "/Home/UploadFiles",
            contentType: false,//不要去设置Content-Type请求头
            processData: false,//不要去处理发送的数据
            data: data,
            success: function (data) {
                document.getElementById('textfield').value = data.fName;
                alert(data.message);
            },
            error: function () {
                alert("上传文件出现错误！");
            }
        });
    });
})