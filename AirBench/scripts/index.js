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
        console.log(benchInfo.Id);
        marker.setId(benchInfo.Id)
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
        let flag = true;
        map.forEachFeatureAtPixel(event.pixel, function (feature,layer){
            console.log(feature.getId());
            window.location.href = "/Bench/Index/" + feature.getId();
            flag = false;
        })
        if (flag){
            console.log(event.coordinate);
            event.coordinate = ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326')
            latitude = event.coordinate[0];
            longitude = event.coordinate[1];
            window.location.href = "/Bench/Create?Lat=" + latitude + "&Lon=" + longitude;
        }
    });

    // let createFilteredTable = function () {
    //     const myTableDiv = document.getElementById("benches");
    //     //Table
    //     const table = document.createElement('TABLE');
    //     table.id = 'table';
    //     //THead
    //     const tableHead = document.createElement('THEAD');
    //     tableHead.className = 'thead-dark';
    //     table.appendChild(tableHead);
    //     //THead > TR
    //     const tableHeadRow = document.createElement('TR');
    //     tableHead.appendChild(tableHeadRow);
    //     //THead > TR > TH
    //     const tableHeadRowElement1 = document.createElement('TH');
    //     tableHeadRowElement1.innerHTML = 'Bench No';
    //     tableHeadRow.appendChild(tableHeadRowElement1);
    //     const tableHeadRowElement2 = document.createElement('TH');
    //     tableHeadRowElement2.innerHTML = 'Rating';
    //     tableHeadRow.appendChild(tableHeadRowElement2);
    //     const tableHeadRowElement3 = document.createElement('TH');
    //     tableHeadRowElement3.innerHTML = 'Description';
    //     tableHeadRow.appendChild(tableHeadRowElement3);
    //     const tableHeadRowElement4 = document.createElement('TH');
    //     tableHeadRowElement4.innerHTML = 'Seats';
    //     tableHeadRow4.appendChild(tableHeadRowElement4);
    //     //TBody
    //     var tableBody = document.createElement('TBODY');
    //     table.appendChild(tableBody);
    //     for (var i = 0; i < 3; i++) {
    //         var tr = document.createElement('TR');
    //         tableBody.appendChild(tr);
    //         for (var j = 0; j < 4; j++) {
    //             var td = document.createElement('TD');
    //             td.appendChild(document.createTextNode("Cell " + i + "," + j));
    //             tr.appendChild(td);
    //         }
    //     }
    //     myTableDiv.appendChild(table);
    // };

    function filterBenches(){
        let min = parseInt(document.getElementById('min').value, 10);
        let max = parseInt(document.getElementById('max').value, 10);
        const tableInfo = document.getElementById('benches');
        let rows = tableInfo.getElementsByTagName("tr");
        console.log(rows)
        for(let i = 1; i < rows.length; i++){
            let seats = parseInt(rows[i].getAttribute('data-seats'), 10);

            if(isNaN(min && isNaN(max))){
                rows[i].style.display = "";
            } 
            else if (seats >= min && seats <= max) {
                rows[i].style.display = "";
            } else if (seats < min || seats > max) {
                rows[i].style.display = "none";
            } else {
                rows[i].style.display = "";
            }
        }
    }

    document.getElementById('filter').addEventListener('keyup', function (){
        filterBenches()
    });

    // document.getElementById('min').addEventListener('keyup', filterBenches);
    // document.getElementById('max').addEventListener('keyup', filterBenches);
})();

