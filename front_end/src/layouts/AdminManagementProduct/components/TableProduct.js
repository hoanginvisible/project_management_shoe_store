import React, {useEffect, useState} from "react";
import {Space, Table, Popconfirm, message, Button, Modal, Form, Input, Select} from "antd";
import {APIProductManagerment} from "../api/APIProductManagement";
import {
    faPenToSquare,
    faTrash,
    faPlus,
    faXmark,
} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

const TableProduct = () => {
    const [listProductDetail, setListProductDetail] = useState([]);
    const [idProduct, setIdProduct] = useState("");
    const [idBrand, setIdBrand] = useState("");
    const [idCategory, setIdCategory] = useState("");
    const [idColor, setIdColor] = useState("");
    const [image, setImage] = useState("");
    const [idMaterial, setIdMaterial] = useState("");
    const [idSize, setIdSize] = useState("");
    const [price, setPrice] = useState();
    const [quantity, setQuantity] = useState();
    // List
    const [listProduct, setListProduct] = useState([]);
    const [listBrand, setListBrand] = useState([]);
    const [listCategory, setListCategory] = useState([]);
    const [listColor, setListColor] = useState([]);
    const [listMaterial, setListMaterial] = useState([]);
    const [listSize, setListSize] = useState([]);

    const columns = [
        {
            title: "STT",
            dataIndex: "stt",
            key: "stt",
            render: (text, record, index) => <span>{index + 1}</span>,
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
            render: (image) => {
                if (image != null) {
                    return <img src={image} width={100} height={100}/>
                }
                return "--"
            },
        },
        {
            title: "Material",
            dataIndex: "nameMaterial",
            key: "nameMaterial",
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
                        style={{color: "#0866ff"}}
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
                            style={{color: "#ff0000"}}
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
    const handleClearFormInfoProduct = () => {
        setIdProduct("")
        setIdBrand("")
        setIdCategory("")
        setIdColor("")
        setIdSize("")
        setIdMaterial("")
        setImage("")
        setPrice("")
        setQuantity("")
    }
    const handleCancel = () => {
        handleClearFormInfoProduct();
        setIsModalOpen(false);
    };
    const handleCreateProductDetail = () => {
        const data = {
            idProduct: idProduct,
            idBrand: idBrand,
            idCategory: idCategory,
            idColor: idColor,
            image: image,
            idMaterial: idMaterial,
            idSize: idSize,
            price: price,
            quantity: quantity
        }
        APIProductManagerment.createProductDetail(data).then(
            (response) => {
                setListProductDetail([data, ...listProductDetail])
                message.success("Thành công");
                console.log(data)
                setIsModalOpen(false);
            },
            (error) => {
                message.error("Thất bại")
                console.log(error)
            }
        )
        // OREventDetailApi.updateEvent(obj).then(
        //     (response) => {
        //         message.success("Cập nhật thành công");
        //     },
        //     (error) => {
        //         message.error(error.response.data.message);
        //     }
        // );
    };
    const confirm = (id) => {
        APIProductManagerment.deleteProductDetail(id)
            .then((res) => {
                const listProductNew = listProductDetail.filter((p) => p.id !== id);
                setListProductDetail(listProductNew);
                message.success("Thành công");
            })
            .catch((err) => {
                message.error("Thất bại");
            });
    };
    useEffect(() => {
        APIProductManagerment.getProductDetails()
            .then((response) => {
                setListProductDetail(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getProducts()
            .then((response) => {
                setListProduct(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getBrands()
            .then((response) => {
                setListBrand(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getCategorys()
            .then((response) => {
                setListCategory(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getColors()
            .then((response) => {
                setListColor(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getMaterials()
            .then((response) => {
                setListMaterial(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

        APIProductManagerment.getSizes()
            .then((response) => {
                setListSize(response.data);
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
                    style={{color: "#ffffff", marginRight: "7px"}}
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
                        onClick={handleCreateProductDetail}
                        style={{backgroundColor: "green"}}
                    >
                        <FontAwesomeIcon
                            icon={faPlus}
                            style={{color: "#ffffff", marginRight: "7px"}}
                        />
                        Thêm
                    </Button>,
                    <Button
                        type="primary"
                        className="btn-form-event"
                        onClick={handleCancel}
                        style={{backgroundColor: "red"}}
                    >
                        <FontAwesomeIcon
                            icon={faXmark}
                            style={{color: "#ffffff", marginRight: "7px"}}
                        />
                        Hủy
                    </Button>,
                ]}
            >
                <Form>
                    <Form.Item label="Prodcut" rules={[{required: true}]}>
                        <Select
                            value={idProduct}
                            onChange={(value) => setIdProduct(value)}
                            options={listProduct.map((product) => ({
                                value: product.id,
                                label: product.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Brand" rules={[{required: true}]}>
                        <Select
                            value={idBrand}
                            onChange={(value) => setIdBrand(value)}
                            options={listBrand.map((brand) => ({
                                value: brand.id,
                                label: brand.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Category" rules={[{required: true}]}>
                        <Select
                            value={idCategory}
                            onChange={(value) => setIdCategory(value)}
                            options={listCategory.map((category) => ({
                                value: category.id,
                                label: category.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Color" rules={[{required: true}]}>
                        <Select
                            value={idColor}
                            onChange={(value) => setIdColor(value)}
                            options={listColor.map((color) => ({
                                value: color.id,
                                label: color.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Material" rules={[{required: true}]}>
                        <Select
                            value={idMaterial}
                            onChange={(value) => setIdMaterial(value)}
                            options={listMaterial.map((material) => ({
                                value: material.id,
                                label: material.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Size" rules={[{required: true}]}>
                        <Select
                            value={idSize}
                            onChange={(value) => setIdSize(value)}
                            options={listSize.map((size) => ({
                                value: size.id,
                                label: size.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item
                        label="Price"
                    >
                        <Input
                            placeholder="Nhập vào giá"
                            value={price}
                            onChange={(e) => setPrice(e.target.value)}
                        />
                        {/*<span style={{ fontSize: 15, color: "red" }}>*/}
                        {/*        {errorEventName}*/}
                        {/*    </span>*/}
                    </Form.Item>
                    <Form.Item
                        label="Quantity"
                    >
                        <Input
                            placeholder="Nhập vào số lượng"
                            value={quantity}
                            onChange={(e) => setQuantity(e.target.value)}
                        />
                        {/*<span style={{ fontSize: 15, color: "red" }}>*/}
                        {/*        {errorEventName}*/}
                        {/*    </span>*/}
                    </Form.Item>
                </Form>
            </Modal>
            <Table columns={columns} dataSource={listProductDetail} scroll={{x: "100vw"}} pagination={{
                current: 1,
                pageSize: 5,
                // total: 1
            }}/>
        </>
    );
};
export default TableProduct;
