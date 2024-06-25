import React, { useEffect, useState } from "react";
import OrderForm from "../OrderForm/OrderForm";
import OrderApi from "../../api/orderApi";
import OrderList from "../OrderList/OrderList";
import './MainPage.scss'

const MainPage = () => {

    const [response, setResponse] = useState(false);
    const [message, setMessage] = useState('')
    const [list, setList] = useState([]);

    const orderApi = new OrderApi()

    const pushResponse = (message) => {
        setResponse(true);
        setMessage(message);
        setTimeout(() => setResponse(false), 5000);
    }

    const updateOrders = () => {
        orderApi.getAllOrders()
        .then(res => {
            setList(res);
        })
        .catch(res => {
            pushResponse(res.message);
        })
    }

    const moment = require('moment');

    const onSubmitHandle = async (formData) => {
        formData.cargoPickupDate = moment(formData.cargoPickupDate).format('YYYY-MM-DD');
      
        const objData = JSON.stringify(formData);
        await orderApi.postOrder(objData);
        updateOrders();
      }

    useEffect(() => {
        updateOrders();
    }, []);

    return(
        <div className="main-wrapper">
            <OrderForm isReadOnly={false} onSubmitHandle={onSubmitHandle} values={{}}/>
            <OrderList list={list}/>
            {response && <p className="error-message">ERROR: {message}</p>}
        </div>
    )
}

export default MainPage;