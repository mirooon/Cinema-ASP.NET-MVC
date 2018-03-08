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
                        url: "/CinemaNavigationBar/Autocomplete",
                        type: "POST",
                        dataType: "json",
                        data: { keyword: request.term },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item, value: item };
                            }))

                        }
                    })
                },
                messages: {
                    noResults: "", results: ""
                }
            });
            $(".ui-helper-hidden-accessible").hide(); //with this site's elements blink
        });
    });
    $(function () {
        $(document).on("keydown.autocomplete", "#generalSearch", function (e) {
            $(this).autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/CinemaNavigationBar/Autocomplete",
                        type: "POST",
                        dataType: "json",
                        data: { keyword: request.term },
                        create: function (e) {
                            e.target.parentElement.removeChild(e.target.parentElement.querySelector(".ui-helper-hidden-accessible"));
                        },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: "", value: "d" };
                            }))

                        }
                    })
                },
                messages: {
                    noResults: "", results: ""
                }
            });
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