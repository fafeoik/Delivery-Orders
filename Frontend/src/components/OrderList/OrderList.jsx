import React, { useState } from "react";
import './OrderList.scss'
import OrderForm from "../OrderForm/OrderForm";
import {format} from "date-fns";

const OrderList = ({list}) => {
    const [open, setOpen] = useState(-1);
    const [page, setPage] = useState(1);
    const [pageSize, setPageSize] = useState(10);
  
    const parseItem = (item) => {
      const formated = format(item.orderCreationDate, 'yyyy/MM/dd hh:mm:ss');
      return `Номер заказа: ${item.id}; Дата создания заказа: ${formated}`;
    }
  
    list.sort((a, b) => {
      const dateA = new Date(a.orderCreationDate);
      const dateB = new Date(b.orderCreationDate);
      return dateB - dateA;
    });
  
    const startIndex = (page - 1) * pageSize;
    const endIndex = startIndex + pageSize;
    const currentPageItems = list.slice(startIndex, endIndex);
  
    const items = currentPageItems.map((item, index) => {
      return(
        <li className="list-group-item" key={index}>
          {parseItem(item)}
          <button className="list-show-btn" onClick={() => setOpen(index)}>{'>'}</button>
        </li>
      )
    });
  
    return(
      <div className="list-wrapper">
        <div>
          <h5>Список грузов</h5>
          {list.length > 0
            ? <ui className="list-group">
              {items}
            </ui>
            : <p>Нет грузов</p>}
          <button onClick={() => setPage(page - 1)} disabled={page === 1}>Назад</button>
          <button onClick={() => setPage(page + 1)} disabled={endIndex >= list.length}>Вперед</button>
        </div>
        {open != -1 && <OrderForm isReadOnly={true} values={list[open]}/>}
      </div>
    )
  }
export default OrderList;