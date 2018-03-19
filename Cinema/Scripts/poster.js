

function OnPosterGrayWithBorder(event) {
    event.find('.posterimg').find('img')
        .css('filter', 'grayscale(100%)')
        .css('border', '2px solid');
}



function OffPosterGrayWithBorder(event) {
    event.find('.posterimg').find('img')
        .css('filter', 'grayscale(0%)')
        .css('border', '0px');
}

function OnPosterBottomDetails(event) {
    event.find('.overlaydetails')
        .stop().animate({
            bottom: "78px"
        }, 200).fadeTo('fast', 1);
}

function OffPosterBottomDetails(event) {
    event.find('.overlaydetails')
        .stop().animate({
            bottom: "0px"
        }, 400).fadeTo('slow', 0.7);
}

function OnPosterTextColorChange(event) {
    event.find('.postertitle p')
        .css("color", "red");
}

function OffPosterTextColorChange(event) {
    event.find('.postertitle p')
        .css("color", "white");
}

function OnPosterPlayIcon(event) {
    event.find('.overlayplayicon')
        .stop().animate({
            left: "0px"
        }, 200).fadeTo('fast', 1).click(function() {
            player.loadVideoById(linkToTrailerPlay);
        });
}

function OffPosterPlayIcon(event) {
    event.find('.overlayplayicon')
        .stop().animate({
            left: "-150px"
        }, 400).fadeTo('slow', 0.25);
}