import React from "react";
import { useSelector } from "react-redux";

const UserPage = () => {

    const userData = useSelector((state) => state.auth.userData)
    
    return <div>
        <ul>
            <li>{userData.id}</li>
            <li>{userData.name}</li>
            {/* <li>{userData.carts}</li> */}
        </ul>
    </div>
}

export default UserPage;