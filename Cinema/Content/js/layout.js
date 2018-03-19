$(function () {
    $('[data-toggle="popover"]').popover({
        html: true,
        container: 'body',
        title: 'Wybór kina',
        content: function () {
            return $('#popover-content').html();
        }
    });
});
$(document).ready(function () {
    OnPosterHover();
    $(function () {
        $(document).on("keydown.autocomplete", "#searchCinema", function (e) {
            $(this).autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/NavigationBar/AutocompleteCinema",
                        type: "POST",
                        dataType: "json",
                        data: { keyword: request.term },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.FullName, value: item.FullName };
                            }))
                        },
                    })
                },
                select: function (event, ui) {
                    var cinemaFullName = ui.item.label;
                    $.ajax({
                        url: "/Home/ChangeCinemaLocationSession",
                        type: "POST",
                        dataType: "json",
                        data: { CinemaFullName: cinemaFullName },
                    })
                    setTimeout(function () {
                        location.reload()
                    }, 100); 
                },
                response: function (event, ui) {
                    if (!ui.content.length) {
                        var noResult = { value: "", label: "Nie znaleziono" };
                        ui.content.push(noResult);
                    }
                },
                minLength: 2
            });
            $(".ui-helper-hidden-accessible").hide(); //with this site's elements blink
        });
    });
    $(function () {
        $(document).on("keydown.autocomplete", "#generalSearch", function (e) {
            $(this).autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/NavigationBar/AutocompleteMovieSearch",
                        type: "POST",
                        dataType: "json",
                        data: { keyword: request.term },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.FullName, value: item.Id };
                            }))
                        },
                    })
                },
                select: function (event, ui) {
                    var movieid = ui.item.value;
                    var url = "/MovieDetails/ShowMovieDetails/" + movieid;
                    window.location.href = url;
                },
                response: function (event, ui) {
                    if (!ui.content.length) {
                        var noResult = { value: "", label: "Nie znaleziono" };
                        ui.content.push(noResult);
                    }
                },
                minLength: 2
            });
            $(".ui-helper-hidden-accessible").hide(); //with this site's elements blink
        });
    });
    $(function () {
        $(document).on('change', '#findLocation', function () {
            var currentLatLng;
            if (navigator.geolocation) {
                var markers = [];
                $.ajax({
                    type: 'POST',
                    url: 'CinemaPlaces/CinemasForGoogleMarks',
                    datatype: "Json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $.each(data, function (i, item) {
                            var marker = new google.maps.Marker({
                                'position': new google.maps.LatLng(item.Latitude, item.Longitude),
                                'title': item.FullName
                            })
                            markers.push(marker);
                        });

                    }
                });
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                    var myMarker = new google.maps.Marker({
                        position: pos
                    });
                        var cinemaFullName = ClosestMarker(markers, myMarker).title;
                        $.ajax({
                            url: "/Home/ChangeCinemaLocationSession",
                            type: "POST",
                            dataType: "json",
                            data: { CinemaFullName: cinemaFullName },
                        })
                        setTimeout(function () {
                            location.reload()
                        }, 100); 

                }, showError);

                
            }
            else { $("#message").html("Geolocation is not supported by this browser."); }
        })
    })
    $(document).on('hidden.bs.modal', '.modal', function () {
        player.stopVideo();
    });
});

    function OnPosterHover() {

        $(document).on('mouseover', '.poster', function () {
            var linkToTrailerPlay = $(this).attr('data-poster-trailer');
            OnPosterGrayWithBorder($(this));
            OnPosterBottomDetails($(this));
            OnPosterTextColorChange($(this));
            OnPosterPlayIcon($(this));
        });
        $(document).on('mouseleave', '.poster', function () {
            OffPosterGrayWithBorder($(this));
            OffPosterBottomDetails($(this));
            OffPosterTextColorChange($(this));
            OffPosterPlayIcon($(this));
        });
    }
function showPosition(position) {
    alert("Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude);
    }
function showError(error) {
    if (error.code == 1) {
        alert("User denied the request for Geolocation.");
    }
    else if (error.code == 2) {
        alert("Location information is unavailable.");
    }
    else if (error.code == 3) {
        alert("The request to get user location timed out.");
    }
    else {
        alert("An unknown error occurred.");
    }
}
function ClosestMarker(markers, myMarker) {
       return markers.reduce(function (prev, curr) {

            var cpos = google.maps.geometry.spherical.computeDistanceBetween(myMarker.position, curr.position);
            var ppos = google.maps.geometry.spherical.computeDistanceBetween(myMarker.position, prev.position);

            return cpos < ppos ? curr : prev;

    })
}
    //$('[data-toggle="popover"]').on('shown.bs.popover', function () {
    //    $("#myCarousel").carousel("pause");
    //});

    //$('[data-toggle="popover"]').on('hidden.bs.popover', function () {
    //    $("#myCarousel").carousel("cycle");
    //});