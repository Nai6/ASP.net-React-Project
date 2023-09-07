import React, { useEffect } from "react";
import {  useDispatch, useSelector } from "react-redux";
import CartComponent from "./CartComponent";
import { getCartItem } from "../../redux/cartSlice"

const CartPage = () => {
    debugger
    const dispatch = useDispatch() 
    const cartData = useSelector((state) => state.cart.userCart[0].cartGoods)
    const isLogined = useSelector((state) => state.auth.isLogined)
    const isFetching = useSelector((state) => state.cart.isFetching)
    const jwtToken = useSelector((state) => state.auth.jwtToken)

    useEffect(() => {
        dispatch(getCartItem(jwtToken))
    },[isLogined])

    if(isFetching) {
        return <div>Loading...</div>
    }

    if (isLogined && cartData) {
        debugger
        return (
            <div>
                {cartData.map(c => <CartComponent
                    good={c.good}
                    key={c.id} />)}
            </div>
        )
    }

}

export default CartPage