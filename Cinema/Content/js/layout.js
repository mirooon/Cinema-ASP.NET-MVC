$(function () {
    var title = 'Wybór kina';

    $('[data-toggle="popover"]').popover({
        html: true,
        container: 'body',
        title: 'Wybór kina',
        content: function () {
            return $('#popover-content').html();
        }
    });
})
    $(document).ready(function () {
        OnPosterHover();
    $(document).on('hidden.bs.modal', '.modal', function() {
        player.stopVideo();
    });
    });

    function OnPosterHover() {

        $(document).on('mouseover', '.poster', function () {
            var linkToTrailer = $(this).attr('data-poster-trailer');
            linkToTrailerPlay = linkToTrailer;
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
function peep(e) {
    alert(e.text);
    jQuery(e).on("click", function () {
        alert(e.text);
        $('[data-toggle="popover"]').popover("hide"); // hide all popovers when clicked on body
    });
    alert(e.text);
}