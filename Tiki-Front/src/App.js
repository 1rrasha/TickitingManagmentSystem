import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Signup from './Components/TickitingSystem/Signup';
import Login from './Components/TickitingSystem/Login';
import LostPassword from './Components/TickitingSystem/LostPassword';
import Dashboard from './Components/TickitingSystem/Dashboard';
import ViewTicket from './Components/TickitingSystem/ViewTicket';
import AddTicket from './Components/TickitingSystem/AddTicket';
import Profile from './Components/TickitingSystem/Profile';
import AddUser from './Components/TickitingSystem/AddUser';



function App() {
  return (
    <Router>
      <Routes>
        <Route path="/signup" element={<Signup />} />
        <Route path="/" element={<Login />} />
        <Route path="/lost-password" element={<LostPassword />} />
        <Route path="/Dashboard" element={<Dashboard />} />
        <Route path="/ViewTicket/:ticketId" element={<ViewTicket />} />
        <Route path="/AddTicket/" element={<AddTicket />} />
        <Route path="/Profile/" element={<Profile />} />
        <Route path="/AddUser/" element={<AddUser />} />




      </Routes>
    </Router>
  );
}

export default App;
