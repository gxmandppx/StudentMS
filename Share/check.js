// JavaScript Document
function DoCheck(obj,flag)// ȫѡ flag=1 ��ѡ flag=0��obj����Ҫ���Ŀؼ�ID
{
        var inputs = document.getElementById(obj);
        var chks=inputs.getElementsByTagName("input");
        for (var i=0; i < chks.length; i++)
        {
            if (chks[i].type == 'checkbox')
            {
                if (flag==1) chks[i].checked=true;
                else chks[i].checked=!chks[i].checked;
            }
        }
}

function CheckDelete(obj)    //���ɾ����ѡ��,obj����Ҫ���Ŀؼ�ID
{ 
        var inputs = document.getElementById(obj);
        var chks=inputs.getElementsByTagName("input");
        var select=false;
        for (var i=0; i < chks.length; i++)
        {
            if (chks[i].type == 'checkbox')
            {
                if (chks[i].checked==true) select=true;
            }
        }
        if (select==true)
        return (confirm("�����Ҫɾ����Щ��Ϣ��"));
        else 
        alert("�Բ�������û��ѡ���κ���Ϣ��");
        return false;
} 

function Check(obj)    //���ɾ����ѡ��,obj����Ҫ���Ŀؼ�ID
{ 
        var inputs = document.getElementById(obj);
        var chks=inputs.getElementsByTagName("input");
        var select=false;
        for (var i=0; i < chks.length; i++)
        {
            if (chks[i].type == 'checkbox')
            {
                if (chks[i].checked==true) select=true;
            }
        }
        if (select==true)
        return true;
        else 
        alert("�Բ�������û��ѡ���κ���Ϣ��");
        return false;
} 

function shownormal() //�����������Ĵ���
{ 

      window.open('web/Role/List.aspx');

}

function show(href,id,width,height,top,left) //����С����
{ 
      if (id==0)
      window.open(href,'_blank','toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width='+width+',height='+height+',top='+top+',left='+left+',resizable=no');
      else
      {
      window.open(href+'?id='+id,'_blank','toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width='+width+',height='+height+',top='+top+',left='+left+',resizable=no');
      }
} 

function showa(href,id,width,height,top,left) //����С����
{ 
      if (id==0)
      window.open(href,'_blank','toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width='+width+',height='+height+',top='+top+',left='+left+',resizable=no');
      else
      {
      window.open(href+'/'+id,'_blank','toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,width='+width+',height='+height+',top='+top+',left='+left+',resizable=no');
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
        return (confirm("�����Ҫɾ����Щ��Ϣ��"));
    else
        alert("�Բ�������û��ѡ���κ���Ϣ��");
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
        alert("�Բ�������û��ѡ���κ���Ϣ��");
    return false;
}