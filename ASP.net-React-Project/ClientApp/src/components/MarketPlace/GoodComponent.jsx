import React from "react";

const GoodComponent = ({good}) =>{
    debugger
    return <div>
        <ul>
            <li>{good.id}</li>
            <li>{good.name}</li>
            <li>{good.price}</li>
            <li>{good.img}</li>
        </ul>
    </div>
}

export default GoodComponent;