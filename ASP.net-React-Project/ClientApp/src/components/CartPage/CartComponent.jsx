import React from "react";

const CartComponent = (props) =>{
    debugger
    return <ul>
        <li>{props.good.name}</li>
        <li>{props.good.price}</li>
        <li>{props.quantity}</li>
    </ul>
}

export default CartComponent;