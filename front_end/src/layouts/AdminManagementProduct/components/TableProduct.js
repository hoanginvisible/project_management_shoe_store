import React, {useEffect, useState} from "react";
import {Space, Table} from "antd";
import {APIProductManagerment} from "../api/APIProductManagement";
import {faPenToSquare, faTrash,} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

const columns = [
    {
        title: "STT",
        dataIndex: "stt",
        key: "stt",
        render: (text) => <a>{text}</a>,
    },
    {
        title: "Name",
        dataIndex: "nameProduct",
        key: "nameProduct",
    },
    {
        title: "Brand",
        dataIndex: "nameBrand",
        key: "nameBrand",
    },
    ,
    {
        title: "Category",
        dataIndex: "nameCategory",
        key: "nameCategory",
    },
    ,
    {
        title: "Color",
        dataIndex: "nameColor",
        key: "nameColor",
    }, ,
    {
        title: "Image",
        dataIndex: "image",
        key: "image",
    },
    ,
    {
        title: "Material",
        dataIndex: "nameMaterial",
        key: "nameMaterial",
    },
    ,
    {
        title: "Brand",
        dataIndex: "nameBrand",
        key: "nameBrand",
    },
    {
        title: "Price",
        dataIndex: "price",
        key: "price",
    },
    {
        title: "Quantity",
        dataIndex: "quantity",
        key: "quantity",
    },
    // {
    //     title: "Trạng thái",
    //     key: "tags",
    //     dataIndex: "tags",
    //     render: (_, {tags}) => (
    //         <>
    //             {tags.map((tag) => {
    //                 let color = tag.length > 5 ? "geekblue" : "green";
    //                 if (tag === "loser") {
    //                     color = "volcano";
    //                 }
    //                 return (
    //                     <Tag color={color} key={tag}>
    //                         {tag.toUpperCase()}
    //                     </Tag>
    //                 );
    //             })}
    //         </>
    //     ),
    // },
    {
        title: "Action",
        key: "action",
        render: (_, record) => (
            <Space size="middle">
                <FontAwesomeIcon icon={faPenToSquare} style={{color: "#0866ff"}} title={"Sửa"}/>
                <FontAwesomeIcon icon={faTrash} style={{color: "#ff0000"}} title={"Xóa"}/>
            </Space>
        ),
    },
];
const TableProduct = () => {
    const [listProduct, setListProduct] = useState([]);
    useEffect(() => {
        APIProductManagerment.getProductDetails()
            .then((response) => {
                setListProduct(response.data);
                console.log(response)
            })
            .catch((error) => {
                console.log(error)
            });
    }, []);
    return <Table columns={columns} dataSource={listProduct} scroll={{ x: '100vw' }} />;
};
export default TableProduct;
