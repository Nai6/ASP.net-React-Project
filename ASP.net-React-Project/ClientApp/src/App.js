import React, { Component, useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import './custom.css';
import NavBar from './components/Nav/NavBar';
import Header from './components/Header/Header';
import HomePage from './components/HomePage/HomePage';
import style from './App.module.css'
import LoginPage from './components/LoginPage/LoginPage'
import MarketPlace from './components/MarketPlace/MarketPlace';
import UserPage from './components/UserPage/UserPage';
import RegistrationPage from './components/RegistrationPage/RegistrationPage';
import AddNewGoodPage from './components/AddNewGood/AddNewGoodPage';
import { useDispatch, useSelector } from 'react-redux';
import { userID } from './redux/authSlice';

const App = () => {
  const dispatch = useDispatch()
  const isLogined = useSelector((state) => state.auth.isLogined )
  const jwtToken = useSelector((state) => state.auth.jwtToken)

  useEffect(() => {
    if(isLogined === true) {
      dispatch(userID(jwtToken))
    }    
}, [isLogined])

  return (
    <div>
      < Header />
      <div className={style.container}>
        < NavBar />
        <div className={style.main_content}>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path='/login' element={<LoginPage />} />
            <Route path='/market' element={<MarketPlace />} />
            <Route path='/userpage' element={<UserPage />} />
            <Route path='/registration' element={<RegistrationPage />} />
            <Route path='/addNewGood' element={<AddNewGoodPage />} />
          </Routes>
        </div>
      </div>
    </div>
  );
}




export default App;
