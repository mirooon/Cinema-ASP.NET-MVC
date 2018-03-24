var selectedCinemaID = $("#CinemaID :selected").val();
var selectedMovieID = $("#MovieID :selected").val();
var selectedMovieTypeID = $("#TypeID :selected").val();
var selectedDate;
var session;
$(document).ready(function () {
    $("#Reservation").hide().removeClass("hidden");
    // OnStart();
 
    session = $('#chooseCinemaLocation').attr('data-session');
    if (session != '') {
        $('#CinemaID option:contains(' + session + ')').prop({ selected: true });
        OnCinemaChoose();
    }
    $("#CinemaID").change(function () {
        OnCinemaChoose();
    });
    $("#MovieID").change(function () {
        OnMovieChoose();
    });
    $("#TypeID").change(function () {
        OnMovieTypeChoose();
    });

    $('#Datepicker').datepicker({
        autoclose: true,
        todayBtn: true,
        todayHighlight: true,
        dateFormat: 'dd-mm-yy',
        onSelect: function () {
            $("#MovieID").prop("disabled", false);
            $("#TypeID").prop("disabled", false);
            var date = $(this).val();
            selectedDate = date;
            OnCinemaChoose();
        }
    }).datepicker("setDate", new Date());
    selectedDate = $('#Datepicker').val();

});
function OnCinemaChoose() {
    $('#Reservation').slideUp("fast");
    $("#MovieID").prop("disabled", false);
    $("#Datepicker").prop("disabled", false);

    selectedCinemaID = $("#CinemaID :selected").val();
    $('#MovieID').empty();
    $("#TypeID").prop("disabled", true);
    $('#TypeID').empty();
    $('#TypeID').append('<option value="' + 0 + '"> --- WYBIERZ TYP ---</option>');
    if (selectedCinemaID == 0) {
        $('#MovieID').append('<option value="' + 0 + '"> --- WYBIERZ FILM ---</option>');
        $("#Datepicker").prop("disabled", true);
    }
    else {
        $('#Reservation').slideUp("fast", function () {

            TableFilterWhenCinemaSelected();
        });
        $('#Reservation').slideDown("fast");
        $.ajax({
            type: 'POST',
            data: { cinemaid: selectedCinemaID },
            url: '/Home/GetMovieByCinemaId',
            datatype: "Json",
            success: function (data) {
                $('#MovieID').append('<option value="' + 0 + '"> --- WYBIERZ FILM ---</option>');
                $.each(data, function (index, value) {
                    $('#MovieID').append('<option value="' + value.Value + '">' + value.Text + '</option>');
                });
            }
        });


    }
};
function TableFilterWhenCinemaSelected() {
    var reservationtablebody = $("#ReservationTable").find('tbody');
    reservationtablebody.empty();
    selectedCinemaID = $("#CinemaID :selected").val();
    var whichMovieIdNow = 0;
    $.ajax({
        type: 'POST',
        data: { cinemaid: selectedCinemaID, currentdate: selectedDate },
        url: '/Home/GetMoviesByIdToTable',
        datatype: "json",
        success: function (data) {
            $.each(data, function (index, value) {
                var ROOT = "~/";
                reservationtablebody.append('<tr id="HoursOnMovie' + whichMovieIdNow + '"><td><p>' + value.MovieTitle + '</p ></td><td><img src="' + value.AgeRestrictionImagePath.substring(2) + '"></td><td><p>' + value.MovieDuration + ' minut</p></td></tr>');
                SetHoursLine(reservationtablebody, whichMovieIdNow);
                for (var i = 0; i < value.DateTimeWithMovieType.length; i++) {
                    var date = ToJavaScriptDate(value.DateTimeWithMovieType[i].DateTime);
                    var a = date.charAt(0) + date.charAt(1);
                    var findHourId = "#" + a;
                    var findMovieId = "#HoursOnMovie" + whichMovieIdNow;
                    reservationtablebody.find(findMovieId).find(findHourId).append('<p>' + date + '</p><p>' + value.DateTimeWithMovieType[i].MovieType);
                }
                whichMovieIdNow++;

            });
            if (whichMovieIdNow == 0) {
                reservationtablebody.empty();
                reservationtablebody.append('<p> Brak wyników </p>');
                $("#MovieID").prop("disabled", true);
            }
        },
        error: function () {
            alert('failure');
        }
    });
}
function SetHoursLine(reservationtablebody, whichMovieIdNow) {
    var findMovieId = "#HoursOnMovie" + whichMovieIdNow;
    for (var i = 10; i <= 22; i++) {
        reservationtablebody.find(findMovieId).append('<td id="' + i + '"</td>');
    }
}
function ToJavaScriptDate(date) {
    var value = new Date(parseInt(date.substr(6)));
    var ret = value.getHours() + ":";
    if (value.getMinutes() == 0) {
        ret += "00";
    }

    else if (value.getMinutes() < 10) {
        ret += "0" + value.getMinutes();
    }
    else ret += value.getMinutes();
    return ret;
}
function OnMovieChoose() {
    $("#TypeID").prop("disabled", false);
    selectedMovieID = $("#MovieID :selected").val();
    selectedCinemaID = $("#CinemaID :selected").val();
    $('#TypeID').empty();
    if (selectedMovieID == 0) {
        $('#TypeID').empty();
        $('#TypeID').append('<option value="' + 0 + '"> --- WYBIERZ TYP ---</option>');
    }
    else {
        $('#Reservation').slideUp("fast", function () {

            TableFilterWhenMovieSelected();
        });
        $('#Reservation').slideDown("fast");
        $.ajax({
            type: 'POST',
            data: { movieid: selectedMovieID, cinemaid: selectedCinemaID },
            url: '/Home/GetMovieTypeById',
            datatype: "Json",
            success: function (data) {
                $('#TypeID').append('<option value="' + 0 + '"> --- WYBIERZ TYP ---</option>');
                $.each(data, function (index, value) {
                    $('#TypeID').append('<option value="' + value.Value + '">' + value.Text + '</option>');
                });
            }
        });
    }
};
function TableFilterWhenMovieSelected() {
    var reservationtablebody = $("#ReservationTable").find('tbody')
    reservationtablebody.empty();
    selectedCinemaID = $("#CinemaID :selected").val();
    selectedMovieID = $("#MovieID :selected").val();
    var whichMovieIdNow = 0;
    $.ajax({
        type: 'POST',
        data: { movieid: selectedMovieID, cinemaid: selectedCinemaID, currentdate: selectedDate },
        url: '/Home/GetMovieByMovieIdToTable',
        datatype: "json",
        success: function (data) {
            reservationtablebody.append('<tr id="HoursOnMovie0"><td><p>' + data.MovieTitle + '</p ></td><td><img src="' + data.AgeRestrictionImagePath.substring(2) + '"></td><td><p>' + data.MovieDuration + ' minut</p></td></tr>');
            SetHoursLine(reservationtablebody, whichMovieIdNow);
            for (var i = 0; i < data.DateTimeWithMovieType.length; i++) {
                var date = ToJavaScriptDate(data.DateTimeWithMovieType[i].DateTime);
                var a = date.charAt(0) + date.charAt(1);
                var findHourId = "#" + a;
                var findMovieId = "#HoursOnMovie0";
                reservationtablebody.find(findMovieId).find(findHourId).append('<p>' + date + '</p><p>' + data.DateTimeWithMovieType[i].MovieType);
            }
        },
        error: function () {
            alert('failure');
        }
    });
}
function OnMovieTypeChoose() {
    $('#Reservation').slideUp("fast", function () {
        TableFilterWhenMovieTypeIsSelected();

    });
    $('#Reservation').slideDown("fast");
};
function TableFilterWhenMovieTypeIsSelected() {
    var reservationtablebody = $("#ReservationTable").find('tbody');
    reservationtablebody.empty();
    selectedCinemaID = $("#CinemaID :selected").val();
    selectedMovieID = $("#MovieID :selected").val();
    selectedMovieTypeID = $("#TypeID :selected").val();
    var whichMovieIdNow = 0;
    $.ajax({
        type: 'POST',
        data: { movieid: selectedMovieID, cinemaid: selectedCinemaID, movietypeid: selectedMovieTypeID, currentdate: selectedDate },
        url: '/Home/GetMovieTypeByIdToTable',
        datatype: "json",
        success: function (data) {
            reservationtablebody.append('<tr id="HoursOnMovie0"><td><p>' + data.MovieTitle + '</p ></td><td><img src="' + data.AgeRestrictionImagePath.substring(2) + '"></td><td><p>' + data.MovieDuration + ' minut</p></td></tr>');
            SetHoursLine(reservationtablebody, whichMovieIdNow);
            for (var i = 0; i < data.DateTimeWithMovieType.length; i++) {
                var date = ToJavaScriptDate(data.DateTimeWithMovieType[i].DateTime);
                var a = date.charAt(0) + date.charAt(1);
                var findHourId = "#" + a;
                var findMovieId = "#HoursOnMovie0";
                reservationtablebody.find(findMovieId).find(findHourId).append('<p>' + date + '</p><p>' + data.DateTimeWithMovieType[i].MovieType);
            }
        },
        error: function () {
            alert('failure');
        }
    });
}
function ShowGenre(GenreID) {
    var posters = $('#Posters').find('div');
    var amountOfPosters = 0;
    $.ajax({
        type: 'POST',
        data: { id: GenreID },
        url: '/Home/ShowGenre',
        datatype: "json",
        success: function (data) {
            posters.empty();
            $.each(data, function (index, value) {
                var indexerOfVideoId = value.TrailerLinkYoutube.lastIndexOf('v=');
                amountOfPosters++;
                posters.append('<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12"><div class="poster" data-poster-id="' + value.Id + '" data-poster-trailer="' + value.TrailerLinkYoutube.substring(indexerOfVideoId + 2) + '"><div class="image"><div class="posterimg"><img src="' + value.ImagePath.substring(1) + '" width="220" height="324"></div><div class="overlaydetails"><div class="categoriesbuttons"><button name="button" style="margin-top:10px;" class="btn btn-default btn-responsive">SZCZEGÓŁY</button></div></div><div class="overlayplayicon"><img src="/Content/images/playicon.png" alt="Zobacz zapowiedź" data-toggle="modal" data-target="#trailerModal"></div><div class="postertitle"><p>' + value.Title + '</p></div></div></div>')
            });
            if (amountOfPosters == 0) {
                posters.append('<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12"><h1 style="color:white;">Brak</h1></div>');
            }
        },
        error: function () {
            alert('failure');
        }
    });
}