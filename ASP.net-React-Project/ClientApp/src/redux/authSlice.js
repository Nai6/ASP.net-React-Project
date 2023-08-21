import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { authAPI } from '../api/api'

export const login = createAsyncThunk(
    'auth/login',
    async (data) => {
        debugger
        const respond = await authAPI.login(data)
        return respond.data
    }
)

export const registration = createAsyncThunk(
    'auth/registration',
    async (data) => {
        const respond = await authAPI.registration(data);
        return respond.data;
    }
)

const initialState = {
    userData:{
        userId: null,
        userName: null,
        userPassword: null
    },
    userName: null,
    jwtToken: "",
    isLogined: false,
    error: null,
    registrationStatus: 'registrated',
    loginingStatus:'idle'
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase (login.fulfilled, (state, action) => {
                state.jwtToken += action.payload
                state.isLogined = true
            })
    }
})

export const {} = authSlice.actions;

export default authSlice.reducer;