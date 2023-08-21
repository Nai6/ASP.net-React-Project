import { configureStore } from "@reduxjs/toolkit";
import authSlice from "./authSlice";
import goodsSlice from "./goodsSlice";
import cartSlice from "./cartSlice";

const store = configureStore({
    reducer:{
        auth: authSlice,
        good: goodsSlice,
        cart: cartSlice
    },
    devTools: true,
})

export default store;