window.onload = function () {
   
    $.ajax({
        type: "POST",
        url: "ashx/Depart.ashx?action=Search",
        dataType: "json",
        data: "",
        success: function (data) { 
            dt.arraylist = data;
            var totalCount = dt.arraylist.length, showCount = 10, limit = 10;
            $('#callBackPager').extendPagination({ 
                totalCount: totalCount, 
                showCount: showCount, 
                limit: limit, 
                callback: function (curr, limit, totalCount) { 
                    createTable(curr, limit, totalCount); 
                } 
            });
        }
    });
}

 

function createTable(currPage, limit, total) {  
   
}