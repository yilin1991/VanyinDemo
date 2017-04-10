/// <reference path="jquery-1.11.1.min.js" />

(function ($) {

    $.extend({
        leadinUpload: function (options) {
            var opts = $.extend({}, defaults, options);

            if (opts.uploadtype == "add") {

                //����ϴ��ؼ���ťͼƬ
                var strHtml = "<div class=\"UploadAdd\"><img src=\"/img/AddImgBtn.png\" /></div><input type=\"file\" name=\"imgFile\"  id=\"imgFile\" class=\"UploadFiled\" />";
                $("." + opts.uploadBoxClass).html(strHtml);
            }
            //����file�ؼ������ͼƬ�����ļ�ѡ����
            $(".UploadAdd").click(function () {
                $("." + opts.uploadBoxClass).find("#imgFile").click();
            })
            $("#imgFile").bind("change", function () { UploadChange(opts); });
            $(document).on("click", ".delImg", function () {
                UploadDel($(this), opts);
            })
           
        }
    })

    var defaults = {
        uploadBoxClass: "uploadBox",//�ϴ��ؼ�����
        FormId: "myform",//form��ID
        UploadFiled: "/Tools/imgFile.ashx",//�ϴ������ļ�
        DeleteFiled: "/Tools/DeleteUpoadFile.ashx",//ɾ�������ļ�
        HidFileStore: "hidImgList",//�ļ����洢input[type=hidden]�ؼ�ID
        UploadMultiple:false,//�Ƿ����ѡ�����ͼƬtrue����ѡ�����ͼƬ
        delType: "1",
        uploadtype:"add"
    }

    //ѡ��ͼƬ������
    function UploadChange(opts) {
       
        $("#" + opts.FormId).ajaxSubmit({
            beforeSubmit: function (formData, jqForm, options) {
            },
            success: function (data) {
                uploadSuccess(data, opts);
            },
            error: function (data, status, e) {
                alert("�ϴ�ʧ��");
            },
            url: opts.UploadFiled,
            type: "post",
            dataType: "json",
            timeout: 60000
        });
        
    }

    //�ϴ��ɹ�������
    function uploadSuccess(data, opts) {
        if (data.error == 0) {

            var imgpath = data.url;

            if (opts.UploadMultiple) {
                var htmlImg = "<div class=\"UploadImg\"><img src=\"" + data.url + "\" /><div class=\"delImg\"><img src=\"/img/delImgico.png\" /><input type=\"hidden\" name=\"imgPath\" value='" + data.url + "'/></div></div>";
                $(".UploadAdd").before(htmlImg);
                $("#" + opts.HidFileStore).val($("#" + opts.HidFileStore).val() + imgpath + ",");
            }
            else {
               
                $(".UploadImg").each(function () {
                    var $this = $(this);
                    var strurl = $this.find("input[name=imgPath]").val();
                    UploadDelMethod(strurl, $this, opts);  
                })
                var htmlImg = "<div class=\"UploadImg\"><img src=\"" + imgpath + "\" /><div class=\"delImg\"><img src=\"/img/delImgico.png\" /><input type=\"hidden\" name=\"imgPath\" value='" + imgpath + "'/></div></div>";
                $(".UploadAdd").before(htmlImg);
                $("#" + opts.HidFileStore).val(imgpath);
            }
        }
        else {
            alert(data.message);
        }
    }


    //ɾ���ϴ�ͼƬ
    function UploadDel($this,opts) {

        var strurl = $this.find("input[name=imgPath]").val();
        var node = $this.parents(".UploadImg");
        UploadDelMethod(strurl, node, opts);

    }



    function UploadDelMethod(strurl, node, opts) {
        $.ajax({
            type: "post",
            url: opts.DeleteFiled,
            data: {
                delfile: function () {
                    return strurl;
                }
            },
            dataType: "json",
            success: function (data, textStatus) {
                if (opts.UploadMultiple) {
                    $("#" + opts.HidFileStore).val($("#" + opts.HidFileStore).val().replace(strurl + ",", ""));
                }
                else {
                    //$("#" + opts.HidFileStore).val("");
                    $("#" + opts.HidFileStore).val($("#" + opts.HidFileStore).val().replace(strurl, ""));
                }
                node.remove();
            },
            error: function (data, status, e) {
                alert("ɾ���ļ�ʧ��:" + e);
            }
        });
    }






})(jQuery)

