import React, {useEffect, useState} from "react";
import {Button, Col, Input, Popconfirm, Row, Select, message, Card, Avatar, Typography, List} from "antd";
import {
    faCircleChevronLeft,
    faCircleChevronRight,
    faCircleXmark,
    faPlus,
    faQrcode
} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import "./BanHang.css"
import {APIBanHang} from "../api/APIBanHang";
import ListProductSearch from "./SearchProduct";

const {Option} = Select;
const BanHang = () => {
    const {Search} = Input;
    const [listOrder, setlistOrder] = useState([]);
    const [listProductSearch, setListProductSearch] = useState([]);

    useEffect(() => {
        APIBanHang.getOrderPending().then(
            (res) => {
                const dataArray = [];
                res.data.data.forEach((order) => {
                    const data = {
                        id: order,
                        name: `Hóa đơn ${dataArray.length + 1}`
                    }
                    dataArray.push(data);
                })
                setlistOrder(dataArray);
            },
            (err) => {
                console.log(err)
            }
        )
    }, []);

    const handleCreateOrder = () => {
        APIBanHang.createOrder().then(
            (res) => {
                const newOrder = [...listOrder, {
                    id: res.data.data,
                    name: `Hóa đơn ${listOrder.length + 1}`
                }]
                setlistOrder(newOrder);
            },
            (err) => {
                console.log(err)
            }
        )
    }
    const handleDeleteOrder = (id) => {
        APIBanHang.deleteOrder(id).then(
            (res) => {
                setlistOrder(prevState => {
                    return listOrder.filter(order => order.id !== id)
                })
                message.success("Thành công")
            },
            (err) => {
                console.log(err)
                message.success("Thất bại")
            }
        )
    }

    const handleSearchTopProduct = () => {
        APIBanHang.getTopProductHot().then(
            (res) => {
                setListProductSearch(res.data.data);
                console.log(res.data);
            },
            (err) => {
                console.log(err)
                message.success("Thất bại")
            }
        )
    }


    const dataFake = [
        {
            "code": "PD03",
            "name": "Giày Bitis Hunter X",
            "price": "2000000",
            "quantity": "5",
            "image": "https://res.cloudinary.com/dk2ygqizi/image_shoe_store/lh9tzb4ndnq9g5zrqnkf",
            "color": "Xanh",
            "id": "fc575201-67af-4b71-8f4b-2187a5c38f2c"
        },
        {
            "code": "PD01",
            "name": "Giày Adidas Superstar",
            "price": "500000",
            "quantity": "10",
            "image": "https://res.cloudinary.com/dk2ygqizi/image_shoe_store/lh9tzb4ndnq9g5zrqnkf",
            "color": "Vàng",
            "id": "e76c805a-f4de-4a7a-a8c9-9433f7f18f8a"
        },
        {
            "code": "PD04",
            "name": "Giày Converse 1970",
            "price": "1000000",
            "quantity": "15",
            "image": "https://res.cloudinary.com/dk2ygqizi/image_shoe_store/lh9tzb4ndnq9g5zrqnkf",
            "color": "Đỏ",
            "id": "3c08acdd-49ea-43e3-9f0d-3d5e2910f53d"
        }
    ]

    return (
        <div>
           <ListProductSearch products={dataFake}/>
            <div className={"div-search"}>
                <Search
                    placeholder="Thêm sản phẩm vào đơn"
                    allowClear
                    enterButton="Search"
                    style={{
                        width: 304,
                    }}
                    // onSearch={onSearch}
                />
                <FontAwesomeIcon icon={faQrcode} style={{color: "#ffffff", marginLeft: "7px"}}/>
                <FontAwesomeIcon icon={faPlus} className={"icon-add-hoa-don"} onClick={handleCreateOrder}/>
                <div className="bills">
                    <FontAwesomeIcon icon={faCircleChevronLeft} className={"icon-next"}
                                     style={{color: "#ffffff", margin: "6px 7px 0px 0px"}}/>
                    {listOrder.map(Order => (
                        <Button key={Order.id}>
                            {Order.name}
                            <Popconfirm
                                title="Xóa hóa đơn"
                                description="Bạn có chắc chắn muốn xóa"
                                onConfirm={() => handleDeleteOrder(Order.id)}
                                okText="Yes"
                                cancelText="No"
                            >
                                <FontAwesomeIcon icon={faCircleXmark} style={{color: "gray", marginLeft: "5px"}}
                                />
                            </Popconfirm>
                        </Button>
                    ))}
                    <FontAwesomeIcon icon={faCircleChevronRight} className={"icon-next"}
                                     style={{color: "#ffffff", marginTop: "6px"}}/>
                </div>
            </div>
            <div className="container">
                <div className="div-content">

                </div>
                <div className="div-thanh-toan">
                    <Row gutter={[16, 16]}>
                        <Col span={12}>
                            <p>Số lượng sản phẩm:</p>
                            <p>Tổng tiền:</p>
                            <p>Tiền khuyến mại:</p>
                            <p style={{fontWeight: "bold"}}>Khách phải trả:</p>

                        </Col>
                        <Col span={12}>
                            <p>10</p> {/* Số lượng sản phẩm */}
                            <p>$100</p> {/* Tổng tiền */}
                            <p>$10</p> {/* Tiền khuyến mại */}
                            <p>$90</p> {/* Khách phải trả */}

                        </Col>
                    </Row>
                    <Row gutter={[16, 16]}>
                        <Col span={12} align="left">
                            <p style={{marginTop: "7px"}}>Hình thức thanh toán:</p>
                            <p style={{marginTop: "15px"}}>Tiền khách đưa:</p>
                            <p style={{marginTop: "7px"}}>Tiền thừa:</p>
                        </Col>
                        <Col span={12}>
                            <Select defaultValue="Tiền mặt" style={{width: '100%', marginTop: "5px"}}>
                                <Option value="Tiền mặt">Tiền mặt</Option>
                                <Option value="Chuyển khoản">Chuyển khoản</Option>
                            </Select>
                            <Input placeholder="Nhập tiền khách đưa" style={{marginTop: '8px'}}/>
                            <p>$0</p> {/* Tiền thừa */}
                        </Col>
                    </Row>
                    <Button type="primary" className={"btn-thanh-toan"}>Thanh toán</Button>
                </div>
            </div>
        </div>

    )
}
export default BanHang;