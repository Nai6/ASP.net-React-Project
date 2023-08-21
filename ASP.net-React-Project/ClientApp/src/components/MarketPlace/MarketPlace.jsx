import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { getAllGoods } from "../../redux/goodsSlice";

const MarketPlace = (props) =>{
    const dispatch = useDispatch()
    const [goods, setGoods] = useState(props.goods)
    useEffect = (() =>{
        if(props.goods === null){
            const updatedGoods = dispatch(getAllGoods())
            setGoods(updatedGoods)
        }
    }, [props.goods])
    return <div>MarketPlace</div>
}

export default MarketPlace;