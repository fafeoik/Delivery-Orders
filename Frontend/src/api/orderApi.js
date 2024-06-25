import BaseApi from "./baseApi";

export default class OrderApi {

    baseApi = new BaseApi('https://localhost:7059/');

    getOrderById = async(id) => {
        return await this.baseApi.getResource(`Order/?id=${id}`);
    }

    getAllOrders = async() => {
        return await this.baseApi.getResource('Order/getall');
    }

    postOrder = async(order) => {
        return await this.baseApi.getResourceWithBody('Order', order);
    }
}