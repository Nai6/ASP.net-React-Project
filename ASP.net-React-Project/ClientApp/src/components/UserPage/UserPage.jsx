import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { userID } from "../../redux/authSlice";

const UserPage = () => {
    const dispatch = useDispatch();
    const JWTToken = useSelector((state) => state.auth.jwtToken)
    const userData = useSelector((state) => state.auth.userData)
    const isFetching = useSelector((state) => state.auth.isFetching)
    useEffect(() => {
        dispatch(userID(JWTToken))
    }, [dispatch, JWTToken])
    debugger

    if(isFetching === true) return <div>Loading...</div>
    return <div>
        <ul>
            <li>{userData.id}</li>
            <li>{userData.name}</li>
            <li>{userData.carts}</li>
        </ul>
    </div>
}

export default UserPage;