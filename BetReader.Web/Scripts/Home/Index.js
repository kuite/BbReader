$(document).ready(function () {
    init();
});

var init = function () {
    initTables();
    initDetailsView();
    
    $('#toPlayBtn').click(refreshToPlayTable);
    $('#inProgressBtn').click(refreshInPlayTable);
    $('#summaryBtn').click(refreshSummaryTable);
    
    $('#toPlayContainer tbody').on('click', 'tr', selectToPlay);
    $('#inPlayContainer tbody').on('click', 'tr', selectInPlay);
    
}

var refreshToPlayTable = function () {
    //$('#toPlayContainer').DataTable().ajax.reload();
    //initToPlayTable();
    //feed toplayTable with data from  ajax 'http://localhost:51740/api/Bet/GetCouponsToPlay'
}

var refreshInPlayTable = function () {
    $('#inPlayContainer').DataTable().ajax.reload();
}

var refreshSummaryTable = function () {
    $('#summaryContainer').DataTable().ajax.reload();
}

var initToPlayTable = function (data) {
    $('#toPlayContainer').DataTable({
        data: data,
        paging: true,
        sAjaxDataProp: "",
        oLanguage: {
            sInfo: "_START_ to _END_ from _TOTAL_ coupons.",
            oPaginate: {
                sNext: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Next</button>",
                sPrevious: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Previous</button>"
            }
        },
        sDom: 'rtip',
        pagingType: 'simple',
        aoColumns: [
        {
            mData: 'AddedTime',
            mRender: function (data, type, full) {
                return formatDate(data);
            }
        },
        {
            mData: 'Odds',
            mRender: function (data, type, full) {
                return formatOdds(data);
            }
        },
        {
            sWidth: '25%',
            mData: 'AuthorsPicksCount'
        },
        {
            mData: 'AuthorsYield'
        }]
    });
}

var initTables = function () {
    var authorization = "Bearer " + localStorage.getItem('token').slice(1, -1);
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51740/api/Bet/GetCouponsToPlay',
        headers: {
            authorization: authorization
        },
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            initToPlayTable(response);
        },
        error: function (xhr, status, error) {

        }
    });


//    $('#inPlayContainer').DataTable({
//        ajax: "http://localhost:51740/api/Bet/GetCouponsInPlay",
//        paging: true,
//        sAjaxDataProp: "",
//        oLanguage: {
//            sInfo: "_START_ to _END_ from _TOTAL_ coupons.",
//            oPaginate: {
//                sNext: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Next</button>",
//                sPrevious: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Previous</button>"
//            }
//        },
//        sDom: 'rtip',
//        pagingType: 'simple',
//        aoColumns: [
//        {
//            mData: 'AddedTime',
//            mRender: function (data, type, full) {
//                return formatDate(data);
//            }
//        },
//        {
//            mData: 'Odds'
//        },
//        {
//            sWidth: '25%',
//            mData: 'AuthorsPicksCount'
//        },
//        {
//            mData: 'AuthorsYield'
//        }]
//    });
//
//
//    $('#summaryContainer').DataTable({
//        ajax: "http://localhost:51740/api/Bet/GetCouponsToPlay",
//        paging: true,
//        sAjaxDataProp: "",
//        oLanguage: {
//            sInfo: "_START_ to _END_ from _TOTAL_ coupons.",
//            oPaginate: {
//                sNext: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Next</button>",
//                sPrevious: "<button type='button' style='width: 100%; height:100%;' class='btn btn-info'>Previous</button>"
//            }
//        },
//        sDom: 'rtip',
//        pagingType: 'simple',
//        fnRowCallback: function( nRow, aData, iDisplayIndex, iDisplayIndexFull ) {
//            if ( aData.IsWon )
//            {
//                $('td', nRow).css('background-color', '#7ccc7c');
//            }
//            else
//            {
//                $('td', nRow).css('background-color', '#e87471');
//            }
//        },
//        aoColumns: [
//        {
//            mData: 'AddedTime',
//            mRender: function (data, type, full) {
//                return formatDate(data);
//            }
//        },
//        {
//            mData: 'Odds',
//            mRender: function (data, type, full) {
//                return formatOdds(data);
//            }
//        },
//        {
//            sWidth: '25%',
//            mData: 'AuthorsPicksCount'
//        },
//        {
//            mData: 'AuthorsYield'
//        }]
//    });

}

var initDetailsView = function() {
    $('#dismissCoupon').click(dismissCoupons);
    $('#playCouponBtn').click(setAsPlayed);
    $(window).scroll(setDetailsPosition);
}

var setDetailsPosition = function() {
    $('#couponDetailsContainer').css('padding-top', self.pageYOffset);
}

var selectToPlay = function () {
    var tableId = $(this).parents('table').attr('id');
    var deselect = $(this).hasClass('selected');
    //when deselecting selected item
    if (deselect) {
        $(this).removeClass('selected');
        hideDetailsTable();
        hideDetailsActionButtons();
    }
    //normal click, when selecting another row
    if (event.ctrlKey === false && deselect === false) {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
        showDetailedCoupon($(this), tableId);
        showDetailsActionButtons();
    }
    //multiselect, when selecting new rows with control
    if (event.ctrlKey && deselect === false) {
        $(this).addClass('selected');
        hideDetailsTable();
        hideDetailsActionButtons();
    }
}

var selectInPlay = function () {
    var tableId = $(this).parents('table').attr('id');
    var deselect = $(this).hasClass('selected');
    //when deselecting selected item
    if (deselect) {
        $(this).removeClass('selected');
        hideDetailsTable();
    }
    //normal click, when selecting another row
    if (event.ctrlKey === false && deselect === false) {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
        showDetailedCoupon($(this), tableId);
        hideDetailsActionButtons();
    }
    //multiselect, when selecting new rows with control
    if (event.ctrlKey && deselect === false) {
        $(this).addClass('selected');
        hideDetailsTable();
    }
}

var dismissCoupons = function () {
    var couponIds = [];
    var couponsToRemove = $('#toPlayContainer').DataTable().rows('.selected');
    var couponsToRemoveData = couponsToRemove.data();
    for (var i = 0; i < couponsToRemoveData.length; i++) {
        couponIds.push(couponsToRemoveData[i].Id);
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:51740/api/Bet/DismissCoupons',
        data: JSON.stringify(couponIds),
        contentType: 'application/json; charset=utf-8',
        success: function () {
            couponsToRemove.remove().draw(false);
            hideDetailsTable();
        },
        error: function (xhr, status, error) {

        }
    });
}

var hideDetailsTable = function () {
    $('#couponDetailsContainer').css('display', 'none');
}

var showDetailedCoupon = function (selectedRow, tableId) {
    $('#couponDetailsContainer').css({
        'display': '',
        'padding-top': self.pageYOffset
    });
    var rowData = $('#' + tableId).DataTable().row(selectedRow).data();

    $('#authorsPickCountId').html(rowData.AuthorsPicksCount);
    $('#authorsYieldId').html(rowData.AuthorsYield);
    $('#couponUrlId a').attr('href', rowData.CouponUrl);
    $('#descriptionId').html(rowData.Description);
    $('#OddsId').html(rowData.Odds);

    $('#picksDetails').html('');
    for (i = 0; i < rowData.Picks.length; i++) {
        $('#picksDetails').append(
        '<li class="list-group-item pickList"><b>Pick:</b> <span class="glyphicon glyphicon-chevron-up"></span>' +
            '<ul class="list-group">' +
                '<li class="list-group-item"><b>Event:</b> ' + rowData.Picks[i].Event + '</li>' +
                '<li class="list-group-item"><b>Odds:</b> ' + rowData.Picks[i].Odds + '</li>' +
                '<li class="list-group-item"><b>Selection:</b> ' + rowData.Picks[i].Selection + '</li>' +
                '<li class="list-group-item"><b>SportType:</b> ' + rowData.Picks[i].SportType + '</li>' +
                '<li class="list-group-item"><b>Kick Off:</b> ' + formatDate(rowData.Picks[i].KickOff) + '</li>' +
            '</ul>' +
        '</li>'
        );
    }
    togglePicks();
}

var showDetailsActionButtons = function () {
    $('#detailsActionButtons').css("display", "block");
}

var hideDetailsActionButtons = function () {
    $('#detailsActionButtons').css("display", "none");
}

var togglePicks = function() {
    $('.pickList').click(function () {
        $(this).children('ul').slideToggle(500);
        var arrowIsDown = $(this).children('span').hasClass('glyphicon-chevron-down');
        if (arrowIsDown) {
            $(this).children('span').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
        } else {
            $(this).children('span').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
        }
    });
}

var setAsPlayed = function () {
    var couponIds = [];
    var playedCoupons = $('#toPlayContainer').DataTable().rows('.selected');
    var playedCouponsData = playedCoupons.data();
    for (var i = 0; i < playedCouponsData.length; i++) {
        couponIds.push(playedCouponsData[i].Id);
    }

    if (couponIds.length != 0) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:51740/api/Bet/SetCouponsInProgress',
            data: JSON.stringify(couponIds),
            headers: {
                authorization: "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluQHdwLnBsIiwibmJmIjoxNDk2MzM4MDUwLCJleHAiOjE0OTYzNTk2NTAsImlhdCI6MTQ5NjMzODA1MH0.mBoYDP5mtxqiVJ6fIxwEPEidFboFYBP2nmJer5GiYbY"
            },
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                playedCoupons.remove().draw();
                var rows = $('#inPlayContainer').DataTable().rows.add(playedCouponsData).draw();
                rows.nodes().to$().addClass('selected');
                hideDetailsActionButtons();
            },
            error: function (xhr, status, error) {

            }
        });
    }
}

var formatDate = function (date) {
    if (date != null) {
        date = date.substring(0, 16).replace("T", " ");
        var year = date.substring(0, 4);
        var month = date.substring(5, 7);
        var day = date.substring(8, 10);
        var hour = date.substring(11, 16);
        var formattedDate = hour.concat(" " + day).concat("-" + month).concat("-" + year);
        return formattedDate;
    }
    return null;
}

var formatOdds = function (odds) {
    if (odds != null) {
        return odds;
    }
    return null;
}