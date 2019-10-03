(async () => {
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

    const marker = new ol.Feature({
        geometry: new ol.geom.Point(
            ol.proj.fromLonLat([-74.006, 40.7127])
        )
    });

    const vectorSource = new ol.source.Vector({
        features: [marker]
    });

    const markerVectorLayer = new ol.layer.Vector({
        source: vectorSource,
    });

    map.addLayer(markerVectorLayer);

    map.on('singleclick', async function (event) {
        console.log(event.coordinate);
        console.log(ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326'));
    })
})();

