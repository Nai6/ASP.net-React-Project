import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getAllGoods } from "../../redux/goodsSlice";
import GoodComponent from "./GoodComponent";
import { NavLink } from "react-router-dom";

const MarketPlace = (props) =>{
    const dispatch = useDispatch()
    useEffect(() =>{
        dispatch(getAllGoods())
    }, [dispatch])
    const goodsData = useSelector((state) => state.good.goods);

    if (!goodsData) return <div>Loading...</div>
    return <div>
        <div>
            <NavLink to='/addNewGood'><p>Add new product</p></NavLink>
        </div>
        {
            goodsData.map(g => <GoodComponent key={g.id}
                good={g}
            />)
        }
        </div>
}

export default MarketPlace;