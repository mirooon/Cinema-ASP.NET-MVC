    $(document).ready(function () {
        Initialize();
    });
    // Where all the fun happens
    function Initialize() {

        // Google has tweaked their interface somewhat - this tells the api to use that new UI
        google.maps.visualRefresh = true;
    var PolandCenter = new google.maps.LatLng(52.255761, 19.103203);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 6.5,
    center: PolandCenter,
    mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);


    // a sample list of JSON encoded data of places to visit
    // you can either make up a JSON list server side, or call it from a controller using JSONResult
    $.ajax({
    type: 'POST',
    url: 'CinemaPlaces/CinemasForGoogleMarks',
    datatype: "Json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        $.each(data, function (i, item) {
            var marker = new google.maps.Marker({
                'position': new google.maps.LatLng(item.Latitude, item.Longitude),
                'map': map,
                'title': item.FullName
            })
            var infowindow = new google.maps.InfoWindow({
                content: "<div class='infoDiv'><h3>" + item.FullName + "</h3><div><h4>Adres: </div><div>" + item.Street + " " + item.Number + "</div>" + "<div>" + item.PostCode + " " + item.City + "</div></h4></div></div>"
            });
            AddMarkerListener(marker, map, infowindow);
            markers.push(marker);
        });
    }
    });
    // Using the JQuery "each" selector to iterate through the JSON list and drop marker pins


    // put in some information about each json object - in this case, the opening hours.

    function AddMarkerListener(marker,map,infowindow){
        // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked!
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
    };
    }