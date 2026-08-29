// JavaScript for Gen4Map component

let map;
export function initialize(element) {
    map = L.map(element, {
        crs: L.CRS.Simple,
        minZoom: -2,
        maxZoom: 4,
        zoomSnap: 0.25,
        zoomControl: false
    });

    const width = 1419;
    const height = 1063;

    const bounds = [
        [0, 0],
        [height, width]
    ];

    L.imageOverlay(
        "/Image/Map/test.png",
        bounds
    ).addTo(map);

    L.control.zoom(
        { position: "bottomright" }
    ).addTo(map);

    map.fitBounds(bounds);
}

export function dispose() {
    if (map) {
        map.remove();
        map = null;
    }
}