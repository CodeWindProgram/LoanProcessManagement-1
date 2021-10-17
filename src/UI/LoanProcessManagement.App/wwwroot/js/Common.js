function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

$("#modalButton").click(function () {
    alert("hi");
});

function ShowDialog(message, height, width, title, padding, icon, showOkButton, link) {
    $("#modalMessage").html(message);

    $('#myModal').modal();

    if (showOkButton == false) {
        $("#closemodalbutton").show();
        $("#redirectbutton").hide();
    }
    else {
        if (link != '')
            $("#redirectbutton").attr("href", link);
        $("#closemodalbutton").hide();
        $("#redirectbutton").show();
    }

    //$.Dialog({
    //    overlay: true,
    //    shadow: true,
    //    flat: true,
    //    title: title,
    //    icon: icon,
    //    content: '',
    //    width: width,
    //    padding: padding,
    //    height: height,//600,400
    //    onShow: function (_dialog) {
    //        var content = _dialog.children('.content');
    //        content.html(message);
    //        $.Metro.initInputs();
    //    }
    //});
}


function ShowDialogUpdate(message, height, width, title, padding, icon, showOkButton, link) {
    $("#modalMessage").html(message);


    $('#myModal').modal();

    if (showOkButton == false) {
        $("#closemodalbutton").show();
        $("#redirectbutton").hide();
    }
    else {
        if (link != '')
            $("#redirectbutton").attr("href", window.location.href);
        //alert(window.location.href);
        $("#closemodalbutton").hide();
        $("#redirectbutton").show();
    }

    //$.Dialog({
    //    overlay: true,
    //    shadow: true,
    //    flat: true,
    //    title: title,
    //    icon: icon,
    //    content: '',
    //    width: width,
    //    padding: padding,
    //    height: height,//600,400
    //    onShow: function (_dialog) {
    //        var content = _dialog.children('.content');
    //        content.html(message);
    //        $.Metro.initInputs();
    //    }
    //});
}


window.PCBConstants = {
    object: 'object',
    functions: 'function',
    monthList: ['january', 'feburary', 'march', 'april', 'may', 'june', 'july', 'august', 'september', 'october', 'november', 'december'],
    operationResult: {
        success: 'success',
        failure: 'failure',
        error: 'error'
    }
};

window.PCBCommon = {
    showLoaderQueuedRequest: [],

    showPCBLoader: function () {
        $('<section class="spinner-wrapper">').appendTo('body');
    },

    hidePCBLoader: function () {
        $('.spinner-wrapper').remove();
    },
    ajaxDefaults: {
        cache: false,
        requestType: "POST",
        contentType: "application/json",
        dataType: "json",
        timeout: 300000,
    },

    getCurrentMonth: function () {
        var date = new Date();
        var currentMonth = date.getMonth();
        return window.PCBConstants.monthList[currentMonth];
    },
    getCurrentYear: function () {
        var date = new Date();
        return date.getFullYear();
    },
    getColors: function () {
        return (["#dbc6d5", "#a16599", "#7ec6de", "#0496c7", "#08ab70", "#0496c7"])
    },
    isNumber: function (val) {
        return !isNaN(Number(val));
    },
    sendAjaxCall: function (options, callingContext) {
        var context = this,
            ajaxRequest = $.ajax({
                cache: options.cache === undefined || options.cache === null ? context.ajaxDefaults.cache : options.cache,
                type: options.requestType ? options.requestType : context.ajaxDefaults.requestType,
                url: options.url,
                contentType: options.contentType ? options.contentType : context.ajaxDefaults.contentType,
                dataType: options.dataType ? options.dataType : context.ajaxDefaults.dataType,
                data: options.data,
                timeout: (options.timeout && typeof options.timeout !== "undefined") ? options.timeout : context.ajaxDefaults.timeout,
                beforeSend: function () {
                    if (options.beforeSend && typeof (options.beforeSend) === window.PCBConstants.functions) {
                        options.beforeSend();
                    }
                    context.showPCBLoader();

                },
                success: function (result) {
                    options.success(result, callingContext);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //if (exception === 'timeout')
                    //{
                    //    alert('Time out error.');
                    //}

                    if (options.error && typeof (options.error) === window.PCBConstants.functions) {
                        options.error(jqXHR, textStatus, errorThrown, callingContext);
                    }
                },
                complete: function (xmlHttpRequest, textStatus) {
                    if (options.requestCompleted && typeof (options.requestCompleted) === window.PCBConstants.functions) {
                        options.requestCompleted(xmlHttpRequest, textStatus, callingContext);
                    }
                    context.hidePCBLoader();
                }
            });

        return ajaxRequest;
    },

    getValueFromObject: function (list, propertyName, propertyValue, getProperty) {
        for (var i = 0; i < list.length; i++) {
            if (list[i][propertyName].toLowerCase() == propertyValue.toLowerCase()) {
                return list[i][getProperty];
            }
        }
    }
};


$(document).ready(function () {
    //tabing();
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    
    var today = dd + '/' + mm + '/' + yyyy;
    var firstDay = '01/' + mm + '/' + yyyy;
    $("#dtStartDate").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        defaultDate: firstDay
    });
    $("#dtStartDate").val(firstDay);
    $("#dtEndDate").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        defaultDate: today
    });
    $("#dtEndDate").val(today);

});


//innerContentSlide


function sortDropDownListByText() {

    var selectedValue = $("#DDLBranch").val();
    // Loop for each select element on the page.
    $("#DDLBranch").each(function () {
        // Keep track of the selected option.
        // Sort all the options by text. I could easily sort these by val.
        $(this).html($("option", $(this)).sort(function (a, b) {
            if (a.text.toUpperCase() != 'select') {
                return a.text.toUpperCase() == b.text.toUpperCase() ? 0 : a.text.toUpperCase() < b.text.toUpperCase() ? -1 : 1
            }
        }));


    });
    $("#DDLBranch").prepend('<option value="-1">Select</option>');
    // Select one option.
    $("#DDLBranch").val(selectedValue);
}

function testalert() {
    alert('Pass');
}