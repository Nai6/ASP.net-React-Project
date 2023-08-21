import React from "react";
import { NavLink } from "react-router-dom";

const NavBar = (props) => {
    return (
        <ul>
            <li><NavLink to='/'>Home Page</NavLink></li>
            <li><NavLink to='/market'>Market Place</NavLink></li>
            <li><NavLink to='/cart'>My Cart</NavLink></li>
            <li><NavLink to='/login'>Login</NavLink></li>
        </ul>
    )}
    
export default NavBar   