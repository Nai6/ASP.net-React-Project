import React from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import CartComponent from "./CartComponent";
import { userID } from "../../redux/authSlice";
import { getCartItem } from "../../redux/cartSlice";

const CartPage = () => {
    const dispatch = useDispatch()
    const jwtToken = useSelector((state) => state.auth.jwtToken)
    const cartData = useSelector((state) => state.cart.userCart)
    const isFetching = useSelector((state) => state.cart.isFetching)
    useEffect(() => {
        dispatch(getCartItem(jwtToken))
    }, [])

    if (isFetching === true) return <div>Loading...</div>
    return (
        <div>
            {cartData.map(c => <CartComponent
                cartData={c}
                key={c.id} />)}
        </div>
    )
}

export default CartPage