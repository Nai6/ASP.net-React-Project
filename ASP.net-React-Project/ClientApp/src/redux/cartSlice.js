import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { cartAPI } from "../api/api"

export const getAllCarts = createAsyncThunk(
    'cart/getAllCarts',
    async () => {
        const respond = await cartAPI.getAllCarts()
        return respond.data
    }
)

export const getCartItem = createAsyncThunk(
    'cart/getCartItem',
    async (JWTtoken) => {
        const respond = await cartAPI.getCartItem(JWTtoken)
        return respond.data
    }
)

export const postCart = createAsyncThunk(
    'cart/postCart',
    async (data) => {
        const respond = await cartAPI.postCart(data)
        return respond.status
    }
)

export const removeCartFromItem = createAsyncThunk(
    'cart/removeCartFromItem',
    async (data) => {
        const respond = await cartAPI.deleteItemFromCart(data)
        return respond.status
    }
)


const initialState = {
    userCart: null,
    allCarts: [],
    status: null,
    isFetching: true,
}

const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(getAllCarts.fulfilled, (state, actions) =>{
                state.allCarts.push(actions.payload)
            })
            .addCase(getCartItem.pending, (state) =>{
                state.isFetching = true
            })
            .addCase(getCartItem.fulfilled, (state, actions) =>{
                state.userCart = actions.payload
                state.isFetching = false
            })
            .addCase(postCart.fulfilled, (state, actions) => {
                state.status.push(actions.payload)
            })
            .addCase(removeCartFromItem.fulfilled, (state, actions) =>{
                state.status.push(actions.payload)
            })
    }
})

export const { } = cartSlice.actions

export default cartSlice.reducer