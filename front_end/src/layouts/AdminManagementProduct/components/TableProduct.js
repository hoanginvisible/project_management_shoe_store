import React, { useEffect, useState } from "react";
import { UploadOutlined } from "@ant-design/icons";
import {
    Space,
    Table,
    Popconfirm,
    message,
    Button,
    Modal,
    Form,
    Input,
    Select,
} from "antd";
import { APIProductManagerment } from "../api/APIProductManagement";
import {
    faPenToSquare,
    faTrash,
    faPlus,
    faXmark,
    faFileCsv
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import ExportExcel from "./ExportExcel"
import "./ZoomImage.css"
import "./TableProduct.css"

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

    const { Search } = Input;

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
            width: 10,
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
            width: 10,
        },
        {
            title: "Image",
            dataIndex: "image",
            key: "image",
            render: (image) => {
                if (image != null) {
                    return (
                        <div
                            className="img-container"
                            onMouseEnter={(e) => e.currentTarget.classList.add("hover")}
                            onMouseLeave={(e) => e.currentTarget.classList.remove("hover")}
                        >
                            <img
                                src={image}
                                width={100}
                                height={100}
                                className="img-zoom"
                            />
                        </div>
                    );
                }
                return "--";
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
            width: 5,
        },
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
    const handleClearFormInfoProduct = () => {
        setIdProduct("");
        setIdBrand("");
        setIdCategory("");
        setIdColor("");
        setIdSize("");
        setIdMaterial("");
        setImage("");
        setPrice("");
        setQuantity("");
    };
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
            quantity: quantity,
        };
        APIProductManagerment.createProductDetail(data).then(
            (response) => {
                setListProductDetail([data, ...listProductDetail]);
                APIProductManagerment.getProductDetails()
                    .then((response) => {
                        setListProductDetail(response.data);
                    })
                    .catch((error) => {
                        console.log(error);
                    });
                message.success("Thành công");
                handleClearFormInfoProduct();
                setIsModalOpen(false);
            },
            (error) => {
                message.error("Thất bại");
                console.log(error);
            }
        );
        console.log(listProductDetail);
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
            <div className={"btn-search"}>
               
            </div>
            <Button type="primary" className="btn-form-event" onClick={showModal} style={{marginRight: "7px"}}>
                <FontAwesomeIcon
                    icon={faPlus}
                    style={{ color: "#ffffff", marginRight: "7px" }}
                />
                Thêm sản phẩm
            </Button>

            <ExportExcel data={listProductDetail} />
            <Button type="primary" className="btn-form-event"  style={{backgroundColor: "#217346", marginRight: "220px"}}>
                <FontAwesomeIcon
                    icon={faFileCsv}
                    style={{ color: "#ffffff", marginRight: "7px" }}
                />
                Import Excel
            </Button>
            {/*<Search placeholder="input search text" onSearch={onSearch} enterButton />*/}
            <Search
                placeholder="Full text search"
                allowClear
                enterButton="Search"
                style={{
                    width: 304,
                }}
                // onSearch={onSearch}
            />
            <Modal
                title="Thông tin sản phẩm"
                open={isModalOpen}
                closable={false}
                footer={[
                    <Button
                        type="primary"
                        className="btn-form-event"
                        onClick={handleCreateProductDetail}
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
                <Form>
                    <Form.Item label="Prodcut" rules={[{ required: true }]}>
                        <Select
                            value={idProduct}
                            onChange={(value) => setIdProduct(value)}
                            options={listProduct.map((product) => ({
                                value: product.id,
                                label: product.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Brand" rules={[{ required: true }]}>
                        <Select
                            value={idBrand}
                            onChange={(value) => setIdBrand(value)}
                            options={listBrand.map((brand) => ({
                                value: brand.id,
                                label: brand.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Category" rules={[{ required: true }]}>
                        <Select
                            value={idCategory}
                            onChange={(value) => setIdCategory(value)}
                            options={listCategory.map((category) => ({
                                value: category.id,
                                label: category.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Color" rules={[{ required: true }]}>
                        <Select
                            value={idColor}
                            onChange={(value) => setIdColor(value)}
                            options={listColor.map((color) => ({
                                value: color.id,
                                label: color.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Material" rules={[{ required: true }]}>
                        <Select
                            value={idMaterial}
                            onChange={(value) => setIdMaterial(value)}
                            options={listMaterial.map((material) => ({
                                value: material.id,
                                label: material.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Size" rules={[{ required: true }]}>
                        <Select
                            value={idSize}
                            onChange={(value) => setIdSize(value)}
                            options={listSize.map((size) => ({
                                value: size.id,
                                label: size.name,
                            }))}
                        />
                    </Form.Item>
                    <Form.Item label="Price">
                        <Input
                            placeholder="Nhập vào giá"
                            value={price}
                            onChange={(e) => setPrice(e.target.value)}
                        />
                        {/*<span style={{ fontSize: 15, color: "red" }}>*/}
                        {/*        {errorEventName}*/}
                        {/*    </span>*/}
                    </Form.Item>
                    <Form.Item label="Quantity">
                        <Input
                            placeholder="Nhập vào số lượng"
                            value={quantity}
                            onChange={(e) => setQuantity(e.target.value)}
                        />
                        {/*<span style={{ fontSize: 15, color: "red" }}>*/}
                        {/*        {errorEventName}*/}
                        {/*    </span>*/}
                    </Form.Item>
                    <Form.Item label={"Image"}>
                        <Button
                            // disabled={isDisabledImg}
                            icon={<UploadOutlined />}
                            // onClick={() => showModalImageUpload(background, 0)}
                        >
                            Tải lên
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>
            <Table
                style={{marginTop: "7px"}}
                columns={columns}
                dataSource={listProductDetail}
                pagination={
                    {
                        // current: 1,
                        pageSize: 3,
                        // total: 1
                    }
                }
            />
        </>
    );
};
export default TableProduct;
