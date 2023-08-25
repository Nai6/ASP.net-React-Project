import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import './custom.css';
import NavBar from './components/Nav/NavBar';
import Header from './components/Header/Header';
import HomePage from './components/HomePage/HomePage';
import style from './App.module.css'
import LoginPage from './components/LoginPage/LoginPage'
import MarketPlace from './components/MarketPlace/MarketPlace';
import UserPage from './components/UserPage/UserPage';

export default class App extends Component {
  static displayName = App.name;

  render() {
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
            </Routes>
          </div>
        </div>
      </div>
    );
  }
}
