import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { authAPI } from '../api/api'

export const login = createAsyncThunk(
    'auth/login',
    async (data) => {
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

export const userID = createAsyncThunk(
    'auth/userID',
    async (jwtToken) => {
        const respond = await authAPI.getUserByJWT(jwtToken);
        return respond.data
    }
)

const initialState = {
    userData: null,
    userName: null,
    jwtToken: "",
    isLogined: false,
    error: null,
    registrationStatus: 'registrated',
    loginingStatus: 'idle',
    isFetching: true
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(login.fulfilled, (state, action) => {
                state.jwtToken += action.payload
                state.isLogined = true
            })
            .addCase(userID.fulfilled, (state, action) => {
                state.userData = action.payload
                state.isFetching = false
            })
    }
})

export const { } = authSlice.actions;

export default authSlice.reducer;