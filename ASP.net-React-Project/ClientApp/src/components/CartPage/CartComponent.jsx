import React from "react";

const CartComponent = (props) =>{
    return <ul>
        <li>{props.cartData.id}</li>
        <li>{props.cartData.userId}</li>
        <li>{props.cartData.goodsId}</li>
    </ul>
}

export default CartComponent;