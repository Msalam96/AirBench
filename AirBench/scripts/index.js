(async () => {
    const baseUrl = "http://localhost:52346/api/map";

    async function getBenches() {
        return await fetch(baseUrl);
    };

    const response = await getBenches();
    const benchInfo = await response.json();
   
    console.log(benchInfo);

    const map = new ol.Map({
        target: 'map',
        layers: [
          new ol.layer.Tile({
              source: new ol.source.OSM()
          })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([-74.006, 40.71277]),
            zoom: 17
        })
    });

    const markers = [];

    async function setMarker(benchInfo){
        const marker = new ol.Feature({
            geometry: new ol.geom.Point(
                ol.proj.fromLonLat([benchInfo.Latitude, benchInfo.Longitude])
                )
        });
        markers.push(marker);
    }

    benchInfo.forEach(setMarker);

    const vectorSource = new ol.source.Vector({
        features: markers
    });

    const markerVectorLayer = new ol.layer.Vector({
        source: vectorSource,
    });

    map.addLayer(markerVectorLayer);

    let latitude;
    let longitude;

    map.on('singleclick', async function (event) {
        console.log(event.coordinate);
        event.coordinate = ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326')
        latitude = event.coordinate[0];
        longitude = event.coordinate[1];
        window.location.href = "/Bench/Create?Lat=" + latitude + "&Lon=" + longitude;
    });

    async function print(){
        console.log(latitude);
        console.log(longitude);
    }

   
})();

