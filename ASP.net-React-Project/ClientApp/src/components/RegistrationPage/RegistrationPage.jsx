import { useFormik } from "formik";
import React from "react";
import { registration } from "../../redux/authSlice";
import { useDispatch } from "react-redux";

const RegistrationPage = () =>{
    const dispatch = useDispatch();
    const formik = useFormik({
        initialValues: {
            userName: '',
            password: '',
        },
        onSubmit: values => {
            debugger
            dispatch(registration(values));
        },
    })
    return (
        <form onSubmit={formik.handleSubmit}>
            <div>User Name</div>
            <input
                id="userName"
                name="userName"
                type="text"
                onChange={formik.handleChange}
                value={formik.values.userName}
            />
            <div>Password</div>
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
        </form>
    )
}

export default RegistrationPage;