// JavaScript Document
function DoCheck(obj, flag)// 全选 flag=1 反选 flag=0，obj是需要检查的控件ID
{
    var inputs = document.getElementById(obj);
    var chks = inputs.getElementsByTagName("input");
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].type == 'checkbox') {
            if (flag == 1) chks[i].checked = true;
            else chks[i].checked = !chks[i].checked;
        }
    }
}

function CheckDelete(obj)    //检查删除复选框,obj是需要检查的控件ID
{
    var inputs = document.getElementById(obj);
    var chks = inputs.getElementsByTagName("input");
    var select = false;
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].type == 'checkbox') {
            if (chks[i].checked == true) select = true;
        }
    }
    if (select == true)
        return (confirm("您真的要删除这些信息吗？"));
    else
        alert("对不起，您还没有选择任何信息！");
    return false;
}

function Check(obj)    //检查删除复选框,obj是需要检查的控件ID
{
    var inputs = document.getElementById(obj);
    var chks = inputs.getElementsByTagName("input");
    var select = false;
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].type == 'checkbox') {
            if (chks[i].checked == true) select = true;
        }
    }
    if (select == true)
        return true;
    else
        alert("对不起，您还没有选择任何信息！");
    return false;
}

function shownormal() //弹出带参数的窗口
{

    window.open('web/Role/List.aspx');

}

function show(href, id, width, height, top, left) //弹出小窗口
{
    if (id == 0)
        window.open(href, '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left + ',resizable=no');
    else {
        window.open(href + '?id=' + id, '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left + ',resizable=no');
    }
}

function showa(href, id, width, height, top, left) //弹出小窗口
{
    if (id == 0)
        window.open(href, '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left + ',resizable=no');
    else {
        window.open(href + '/' + id, '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left + ',resizable=no');
    }
}
function CheckListDel(obj) {
    var list = document.getElementById(obj);
    //var list=inputs.getElementsByTagName("option");
    var select = false;
    for (var i = 0; i < list.options.length; i++) {
        if (list.options[i].selected == true) select = true;
    }
    if (select == true)
        return (confirm("您真的要删除这些信息吗？"));
    else
        alert("对不起，您还没有选择任何信息！");
    return false;
}


function CheckList(obj) {
    var list = document.getElementById(obj);
    var select = false;
    for (var i = 0; i < list.options.length; i++) {
        if (list.options[i].selected == true) select = true;
    }
    if (select == true)
        return true;
    else
        alert("对不起，您还没有选择任何信息！");
    return false;
}