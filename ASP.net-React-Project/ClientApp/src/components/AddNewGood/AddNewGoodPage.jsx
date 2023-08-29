import React from "react";
import { postGood } from "../../redux/goodsSlice";
import { useDispatch } from "react-redux";
import { useFormik } from "formik";

const AddNewGoodPage = () =>{
    const dispatch = useDispatch();
    const formik = useFormik({
        initialValues: {
            Name: '',
            Price: '',
        },
        onSubmit: values => {
            dispatch(postGood(values));
        },
    })
    return (
        <form onSubmit={formik.handleSubmit}>
            <div>Product Name</div>
            <input
                id="Name"
                name="Name"
                type="text"
                onChange={formik.handleChange}
                value={formik.values.userName}
            />
            <div>Price</div>
            <input
                id='Price'
                name='Price'
                type='text'
                onChange={formik.handleChange}
                value={formik.values.password}
            />
            <div>
                <button type="submit">Submit</button>
            </div>
        </form>
    )
}

export default AddNewGoodPage;