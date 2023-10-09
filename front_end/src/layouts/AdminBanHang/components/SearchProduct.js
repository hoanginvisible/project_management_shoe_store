import React, {useState} from "react";
import {
    Button,
    Input,
    List,
    ListItem,
    ListItemAvatar,
    ListItemMeta,
    ListItemText,
} from "antd";
import "./SearchProduct.css"

const ListProductSearch = ({products}) => {
    return (
        <div className={"container-search-product"}>
            {products.map(product => (
                <div key={product.id} className="product-row">
                    <div className={"div-1"}>
                        <img style={{width: "50px", height: "50px"}}
                             src={product.image}/>
                    </div>
                    <div className={"div-2"}>
                        <p style={{fontSize: "medium", color: "black"}}>{product.name}</p>
                        <small style={{fontSize: "small", color: "gray"}}>{product.code} {product.color}</small>
                    </div>
                    <div className={"div-3"}>
                        <p style={{fontSize: "medium", color: "black"}}>{product.price}</p>
                        <small style={{fontSize: "small", color: "gray"}}>Có thể bán {product.quantity}</small>
                    </div>
                </div>
            ))}
        </div>
    )
}
export default ListProductSearch;