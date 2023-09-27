import { request } from "helper/Request.helper";
import { URL_API_ADMIN } from "layouts/ApiUrl";

const api = URL_API_ADMIN + "product-management/";
export class APIProductManagerment {
    static getProductDetails() {
        return request({
            method: "GET",
            url: api + "get-all-product",
        });
    }

    static deleteProductDetail(id) {
        return request({
            method: "DELETE",
            url: api + "delete-product?id=" + id,
        });
    }

    static createProductDetail(data) {
        return request({
            method: "POST",
            url: api + "create-product?id=",
            data: data,
        });
    }
}
