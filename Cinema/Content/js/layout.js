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
                    location.reload();
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

    //$('[data-toggle="popover"]').on('shown.bs.popover', function () {
    //    $("#myCarousel").carousel("pause");
    //});

    //$('[data-toggle="popover"]').on('hidden.bs.popover', function () {
    //    $("#myCarousel").carousel("cycle");
    //});