import React, { useState } from "react";

const ZoomImage = ({ image }) => {
    const [zoomed, setZoomed] = useState(false);

    return (
        <div onMouseOver={() => setZoomed(true)} onMouseOut={() => setZoomed(false)}>
            <img src={image} width={zoomed ? 200 : 100} height={zoomed ? 200 : 100} />
        </div>
    );
};
export default ZoomImage;
