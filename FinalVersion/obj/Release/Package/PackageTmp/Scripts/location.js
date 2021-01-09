var locations = [];
var map = null;

$(".coordinates").each(function () {
    var longitude = $(".longitude", this).text().trim();
    var latitude = $(".latitude", this).text().trim();
    var description = $(".description", this).text().trim();

    var point = {
        "latitude": latitude,
        "longitude": longitude,
        "description": description
    };

    locations.push(point);
});

var data = [];

for (i = 0; i < locations.length; i++) {
    var feature = {
        "type": "Feature",
        "properties": {
            "description": locations[i].description,
            "icon": "star"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [locations[i].longitude, locations[i].latitude]
        }
    };
    data.push(feature);
}


mapboxgl.accessToken = "pk.eyJ1IjoicmFqZGVlcGNoMCIsImEiOiJjam1pZ3cyeGswNHh2M3lwa2YwejFpZjhoIn0.iXTAgOvRV3y5KkjBorgjiw";

map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    zoom: 11,
    center: [locations[0].longitude, locations[0].latitude]
});

var directions = new MapboxDirections({
    accessToken: mapboxgl.accessToken,
    unit: 'metric'
});

map.on('load', function () {
    map.loadImage('https://i.imgur.com/MK4NUzI.png', function (error, image) {
        if (error) throw error;
        map.addImage("custom-marker", image);
        map.addLayer({
            "id": "places",
            "type": "symbol",
            "source": {
                "type": "geojson",
                "data": {
                    "type": "FeatureCollection",
                    "features": data
                }
            },
            "layout": {
                "icon-image": "custom-marker",
                "icon-allow-overlap": false,
                "icon-size": 0.60
            }

        });
    });

    map.addControl(new MapboxGeocoder({
        accessToken: mapboxgl.accessToken
    }));

    map.addControl(directions, 'top-left');

    map.addControl(new mapboxgl.NavigationControl());

    directions.addWaypoint


    map.on('click', 'places', function (e) {
        var coordinates = e.features[0].geometry.coordinates.slice();
        var description = e.features[0].properties.description;


        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }

        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML(description)
            .addTo(map);
    });

    map.on('mouseenter', 'places', function () {
        map.getCanvas().style.cursor = 'pointer';
    });

    map.on('mouseleave', 'places', function () {
        map.getCanvas().style.cursor = '';
    });


});

