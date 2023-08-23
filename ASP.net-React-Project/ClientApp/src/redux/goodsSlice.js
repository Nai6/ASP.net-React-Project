import { createAsyncThunk, createSlice, } from "@reduxjs/toolkit"
import { goodsAPI } from "../api/api"

export const getAllGoods = createAsyncThunk(
    'good/getAllGoods',
    async () => {
        const respond = await goodsAPI.getAllGoods()
        return respond.data
    }
)

export const getGoodById = createAsyncThunk(
    'good/getGoodById',
    async (id) => {
        const respond = await goodsAPI.getGoodsById(id)
        return respond.data
    }
)

export const postGood = createAsyncThunk(
    'good/postGood',
    async (good) => {
        const respond = await goodsAPI.postGood(good)
        return respond.status
    }
)

export const updateGood = createAsyncThunk(
    'good/putGood',
    async (good) => {
        const respond = await goodsAPI.putGood(good)
        return respond.status
    }
)

export const removeGood = createAsyncThunk(
    'good/removeGood',
    async (id) => {
        const respond = await goodsAPI.removeGood(id)
        return respond.status
    }
)

const initialState = {
    goods: null,
    good: {
        id: null,
        name: null,
        price: null,
        img: null
    },
    goodById: {
        id: null,
        name: null,
        price: null,
        img: null
    },
    operationStatus: null

}

const goodsSlice = createSlice({
    name: 'goods',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
            builder
            .addCase(getAllGoods.fulfilled, (state, actions) => {
                state.goods = actions.payload
            })
            .addCase(getGoodById.fulfilled, (state, actions) => {
                state.goodsById = actions.payload
            })
            .addCase(postGood.fulfilled, (state, action) => {
                state.operationStatus = action.payload
            })
            .addCase(updateGood.fulfilled, (state, action) => {
                state.operationStatus = action.payload
            })
            .addCase(removeGood.fulfilled, (state, action) =>{
                state.operationStatus = action.payload
            })
    }
})

export const { } = goodsSlice.actions

export default goodsSlice.reducer