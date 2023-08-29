import React from "react";
import style from './Header.module.css'
import { NavLink } from "react-router-dom";
import { useSelector } from "react-redux";
import CartPage from "../CartPage/CartPage";

const Header = (props) => {
    const isLogined = useSelector((state) => state.auth.isLogined)
    return (
        <div>
            <div className={style.container}>Header</div>
            {isLogined ?
                <div><NavLink to='/userpage'>User Page</NavLink> <CartPage /></div>
                : null}

        </div>)
}

export default Header