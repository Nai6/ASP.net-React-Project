import { useFormik } from "formik";
import React from "react";
import { useDispatch } from "react-redux";
import { login } from "../../redux/authSlice";
import { NavLink } from "react-router-dom";

const LoginPage = (props) => {

    return <div>
        <LoginForm />
    </div>
}

const LoginForm = (props) => {
    const dispatch = useDispatch();
    const formik = useFormik({
        initialValues: {
            userName: '',
            password: '',
        },
        onSubmit: values => {
            dispatch(login(values));
        },
    })
    return (
        <form onSubmit={formik.handleSubmit}>
            <div>Login Name:</div>
            <input
                id="userName"
                name="userName"
                type="text"
                onChange={formik.handleChange}
                value={formik.values.userName}
            />
            <div>Password:</div>
            <input
                id='password'
                name='password'
                type='password'
                onChange={formik.handleChange}
                value={formik.values.password}
            />
            <div>
                <button type="submit">Submit</button>
            </div>
            <div>
                <NavLink to={'/registration'}><p>Registration</p></NavLink>
            </div>
        </form>
    )
}

export default LoginPage