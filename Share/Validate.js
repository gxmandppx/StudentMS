
var Validate = function(){}   
  
Validate.prototype =  {   
    // 验证字符串   
    IsNull: function(str) {   
        return str.replace(/^\s+|\s+$/g, "") == "";   
    },   
       
    // 验证整数   
    IsNumber: function(num) {   
        if (this.IsNull(num)) {   
            return false;   
        }   
        return /^[0-9]+$/.test(num);   
    },   
       
    // 验证浮点数   
    IsFloat: function(num) {   
        if (this.IsNull(num)) {   
            return false;   
        }   
        return /^\d+(\.)\d+$/.test(num);   
    },   
       
    // 验证日期(yyyy/MM/dd)   
    IsDate: function(date) {   
        if (this.IsNull(date)) {   
                return false;   
        }   
        var reg = /^[1-2]\d{3}\/(0?[1-9]|1[0-2])\/(0?[1-9]|[12][0-9]|3[0-1])$/;    
        return reg.test(date);   
    },   
       
    // 验证Email   
    IsEmail: function(email) {   
        if (this.IsNull(email)) {   
            return false;   
        }   
        var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;   
        return reg.test(email);   
    },   
       
    // 验证中文   
    IsChinese: function(str) {   
        if (this.IsNull(str)) {   
            return false;   
        }   
        return !/^[u4E00-u9FA5]+$/.test(str);   
    },
    
    //比较日期，不带时间 如 2011-1-2
    CompareDate: function(start,end)    { 
        var arr1=start.split("-"); 
        var arr2=end.split("-"); 
        var time1=new Date(arr1[0],arr1[1]-1,arr1[2]); 
        var time2=new Date(arr2[0],arr2[1]-1,arr2[2]);
        if (time1>time2) 
        {
            return false;
        }
        return true;
    }  
}  
