import { request } from "helper/Request.helper";
import { URL_API_ADMIN } from "layouts/ApiUrl";

const api = URL_API_ADMIN + "product-management/";
export class APIProductManagerment {
    static getProductDetails() {
        return request({
            method: "GET",
            url: api + "get-all-product-detail",
        });
    }

    static getProducts() {
        return request({
            method: "GET",
            url: api + "get-all-product",
        });
    }
    static getBrands() {
        return request({
            method: "GET",
            url: api + "get-all-brand",
        });
    }
    static getCategorys() {
        return request({
            method: "GET",
            url: api + "get-all-category",
        });
    }
    static getColors() {
        return request({
            method: "GET",
            url: api + "get-all-color",
        });
    }
    static getMaterials() {
        return request({
            method: "GET",
            url: api + "get-all-material",
        });
    }
    static getSizes() {
        return request({
            method: "GET",
            url: api + "get-all-size",
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
            url: api + "create-product",
            data: data,
        });
    }
}
