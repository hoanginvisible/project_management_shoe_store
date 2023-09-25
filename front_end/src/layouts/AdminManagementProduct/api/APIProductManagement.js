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
}
