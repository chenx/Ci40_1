
function show_progress(itemName) {
    $.ajax({
        url: 'HandlerComp.ashx',
        data: { cmd: 'progress', item: itemName },
        dataType: 'html',
        success: function (data, textStatus, jqXHR) {
            var arr = data.split('/');
            if (arr.length == 2) {
                $("#lblTotalCt").html('Total Count: ' + arr[1]);
                $("#lblCurrentCt").html('Current Count: ' + arr[0]);
                getProgress(arr[1], arr[0]);
                if (arr[0] !== arr[1]) {
                    setTimeout(function () { show_progress(itemName); }, 1000);
                }
                else {
                    setTimeout(function () { 
                        window.location = window.location.href;
                    }, 3000); // use 3sec, to allow enough time to finish drawing the progress bar.
                }
            }
            else {
                msg = 'show_progress() Error: ' + data
                $("#lblErrorMsg").html(msg);
            }
        },
        cache: false
    });
}

function getProgress(total_ct, current_ct) {
    var progress = (total_ct == 0) ? 0 : Math.floor((current_ct * 1.0 / total_ct) * 100);
    $("#lblProgress").html('Progress: ' + progress + '%');
    showProgressMeter(progress);
}

function showProgressMeter(percentage) {
    $('#meter1').css('width', percentage + '%');
    $(".meter > span").each(function () {
        $(this)
        .data("origWidth", $(this).width())
        .width(0)
        .animate({
            width: $(this).data("origWidth") // or + "%" if fluid
        }, 1200);
    });
}

function calc(itemName, itemCount, lblMsg) {
    var msg;
    $.ajax({
        url: 'HandlerComp.ashx',
        data: { cmd: 'comp', item: itemName, count: itemCount },
        dataType: 'html',
        success: function (data, textStatus, jqXHR) {
            if (data == 'ok') {
                msg = 'Computation is started.'
            }
            else {
                msg = 'Error: ' + data
            }
            lblMsg.html(msg);
        },
        error: function (request, textStatus, error) {
            lblMsg.html(error);
        }
    });
}

$(document).ready(function () {
    $("#btnComp").click(function () {
        document.getElementById('divTask').style.display = 'none';
        document.getElementById('lblMsg').innerHTML = '<font color="green">Please wait ...</font><br/><br/>';
        var name = $('#dlItemName').val();
        var count = $('#dlItemCount').val();
        calc(name, count, $("#lblMsg"));
        setTimeout(function () { window.location = window.location.href; }, 2000);
        return false; // prevent post back.
    });
});

