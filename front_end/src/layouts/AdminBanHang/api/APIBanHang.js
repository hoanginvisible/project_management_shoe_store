import { request } from "helper/Request.helper";
import { URL_API_ADMIN } from "layouts/ApiUrl";

const api = URL_API_ADMIN + "payment/";
export class APIBanHang {

    static getOrderPending() {
        return request({
            method: "GET",
            url: api + "get-order-pending",
        });
    }

    static getTopProductHot() {
        return request({
            method: "GET",
            url: api + "get-top-product-hot",
        });
    }

    static createOrder() {
        return request({
            method: "POST",
            url: api + "create-order",
        });
    }

    static deleteOrder(id) {
        return request({
            method: "DELETE",
            url: api + "delete-order?id=" + id,
        });
    }

    static createProductDetail(data) {
        return request({
            method: "POST",
            url: api + "create-product",
            data: data,
        });
    }
}
