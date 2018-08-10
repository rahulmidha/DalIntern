/// <reference path="jquery-1.10.2.js" />
var GoogleAPIkey = "AIzaSyBS0815MnJT8QlEvqs-Rku-9JbjU7M9ubk";

$(document).ready(function () {

    $('#rating').barrating({
        theme: 'fontawesome-stars'
    });


    $('#searchButton').click(function () {

        var searchString = $('#searchstring')[0].value;

        $('.row>div').show();
        if (searchString == null || searchString === '')
            return;


        $('.row>div.col-sm-6').each(function () {
            if ($(this)[0].innerText.toLowerCase().indexOf(searchString.toLowerCase()) == -1)
            {
                $(this).hide();
            }

        });

    });
});

function GetQueryParameterValue(paramName) {
    var currentUrl = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var counter = 0; counter < currentUrl.length; counter++) {
        var urlparam = currentUrl[counter].split('=');
        if (urlparam[0] == paramName) {
            var valueParam = urlparam[1];
            return valueParam;
        }
    }
}

// Accessing GeoLocation API

function Call() {
    var isSupported = navigator.geolocation;
    if (isSupported) {
        navigator.geolocation.getCurrentPosition(DisplayPosition, HandleError);
    } else {
        alert("Browser does not support Location API.");
    }
}

function DisplayPosition(position) {
   
    //Update the Latitude and Longitude Value
    $("#Lat").val(position.coords.latitude);
    $("#Long").val(position.coords.longitude);

    $('#mapImage').attr('src', getMapUrl(position.coords.latitude, position.coords.longitude));
}

function HandleError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            alert("User discarded geolocation request.");
            break;
        case error.POSITION_UNAVAILABLE:
            alert("Location information is not available now.");
            break;
        case error.TIMEOUT:
            alert("Location information timed-out.");
            break;
        case error.UNKNOWN_ERROR:
        alert("Unknown Error occured");
            break;
    }
}


function getMapUrl(lat, long) {
    return "https://maps.googleapis.com/maps/api/staticmap?center="
+ lat + "," + long + "&zoom=14&size=400x300&key="+GoogleAPIkey;
    
}