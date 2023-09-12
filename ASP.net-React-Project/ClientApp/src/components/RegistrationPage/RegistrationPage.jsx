import { useFormik } from "formik";
import React from "react";
import { registration } from "../../redux/authSlice";
import { useDispatch } from "react-redux";

const RegistrationPage = () => {
    const dispatch = useDispatch();
    const formik = useFormik({
        initialValues: {
            userName: '',
            password: '',
            email: '',
            phoneNumber: '',
            city: '',
            dateOfBirth: '',
            isSeller: false,
        },
        onSubmit: values => {
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
            <div>Email:</div>
            <input
                id='email'
                name='email'
                type='email'
                onChange={formik.handleChange}
                value={formik.values.email}
            />
            <div>City</div>
            <input
                id='city'
                name='city'
                type='text'
                onChange={formik.handleChange}
                value={formik.values.city}
            />

            <div>Phone:</div>
            <input
                id='phoneNumber'
                name='phoneNumber'
                type='text'
                onChange={formik.handleChange}
                value={formik.values.phoneNumber}
            />
            <div>Date of birth:</div>
            <input
                id='dateOfBirth'
                name='dateOfBirth'
                type='date'
                onChange={formik.handleChange}
                value={formik.values.dateOfBirth}
            />
            <div>Are you going to sell items?</div>
            <input
                id='isSeller'
                name='isSeller'
                type='checkbox'
                onChange={formik.handleChange}
                value={formik.values.isSeller}
            />

            <div>
                <button type="submit">Submit</button>
            </div>
        </form>
    )
}

export default RegistrationPage;