import React, { useEffect, useState } from "react";
import { Space, Table, Popconfirm, message, Button, Modal } from "antd";
import { APIProductManagerment } from "../api/APIProductManagement";
import {
    faPenToSquare,
    faTrash,
    faPlus,
    faXmark,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const TableProduct = () => {
    const [listProduct, setListProduct] = useState([]);

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
        {
            title: "Category",
            dataIndex: "nameCategory",
            key: "nameCategory",
        },
        {
            title: "Color",
            dataIndex: "nameColor",
            key: "nameColor",
        },
        {
            title: "Image",
            dataIndex: "image",
            key: "image",
            render: (image) => <img src={image} width={100} height={100} />,
        },
        {
            title: "Material",
            dataIndex: "nameMaterial",
            key: "nameMaterial",
        },
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
                    <FontAwesomeIcon
                        icon={faPenToSquare}
                        style={{ color: "#0866ff" }}
                        title={"Sửa"}
                        onMouseOver={() => {
                            document.body.style.cursor = "pointer";
                        }}
                        onMouseOut={() => {
                            document.body.style.cursor = "default";
                        }}
                    />
                    <Popconfirm
                        title="Xóa sản phẩm"
                        description="Bạn có chắc chắn muốn xóa"
                        onConfirm={() => confirm(record.id)}
                        okText="Yes"
                        cancelText="No"
                    >
                        <FontAwesomeIcon
                            icon={faTrash}
                            style={{ color: "#ff0000" }}
                            title={"Xóa"}
                            onMouseOver={() => {
                                document.body.style.cursor = "pointer";
                            }}
                            onMouseOut={() => {
                                document.body.style.cursor = "default";
                            }}
                        />
                    </Popconfirm>
                </Space>
            ),
        },
    ];

    const [isModalOpen, setIsModalOpen] = useState(false);
    const showModal = () => {
        setIsModalOpen(true);
    };
    const handleOk = () => {
        setIsModalOpen(false);
    };
    const handleCancel = () => {
        setIsModalOpen(false);
    };
    const confirm = (id) => {
        APIProductManagerment.deleteProductDetail(id)
            .then((res) => {
                const listProductNew = listProduct.filter((p) => p.id !== id);
                setListProduct(listProductNew);
                message.success("Thành công");
            })
            .catch((err) => {
                message.error("Không thành công");
                message.error(err.message);
            });
    };
    useEffect(() => {
        APIProductManagerment.getProductDetails()
            .then((response) => {
                setListProduct(response.data);
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);
    return (
        <>
            <Button type="primary" className="btn-form-event" onClick={showModal}>
                <FontAwesomeIcon
                    icon={faPlus}
                    style={{ color: "#ffffff", marginRight: "7px" }}
                />
                Thêm sản phẩm
            </Button>
            <Modal
                title="Thông tin sản phẩm"
                open={isModalOpen}
                footer={[
                    <Button
                        type="primary"
                        className="btn-form-event"
                        onClick={handleOk}
                        style={{ backgroundColor: "green" }}
                    >
                        <FontAwesomeIcon
                            icon={faPlus}
                            style={{ color: "#ffffff", marginRight: "7px" }}
                        />
                        Thêm
                    </Button>,
                    <Button
                        type="primary"
                        className="btn-form-event"
                        onClick={handleCancel}
                        style={{ backgroundColor: "red" }}
                    >
                        <FontAwesomeIcon
                            icon={faXmark}
                            style={{ color: "#ffffff", marginRight: "7px" }}
                        />
                        Hủy
                    </Button>,
                ]}
            >
                <p>Some contents...</p>
                <p>Some contents...</p>
                <p>Some contents...</p>
            </Modal>
            <Table columns={columns} dataSource={listProduct} scroll={{ x: "100vw" }} />
        </>
    );
};
export default TableProduct;
