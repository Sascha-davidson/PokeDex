let map;

export function initialize(element, svgPath) {

    if (map) {
        map.remove();
        map = null;
    }

    map = L.map(element, {
        crs: L.CRS.Simple,
        minZoom: -2,
        maxZoom: 4,
        zoomSnap: 0.25,
        zoomControl: false
    });

    L.control.zoom({
        position: "bottomright"
    }).addTo(map);

    if (!svgPath) {
        console.warn("No SVG path supplied.");
        return;
    }

    console.log("SVG path received:", svgPath);

    const image = new Image();

    image.onload = () => {
        const width = image.naturalWidth;
        const height = image.naturalHeight;

        const bounds = [
            [0, 0],
            [height, width]
        ];

        L.imageOverlay(
            svgPath,
            bounds
        ).addTo(map);

        map.fitBounds(bounds);
    };

    image.onerror = () => {
        console.error(
            `Could not load map image: ${svgPath}`
        );
    };

    image.src = svgPath;
}