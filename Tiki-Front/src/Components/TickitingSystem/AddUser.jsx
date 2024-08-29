import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Profile.css'; 
import tiki_icon from '../Assests/tiki.png';
import notification_icon from '../Assests/notification.png';
import profile_icon from '../Assests/profile.png';

const AddUser = () => {
    const [userData, setUserData] = useState({
        username: '',
        email: '',
        password: 'Rasha@tiki1',
        phone: '',
        address: '',
        companyId: '',
        isActive: true,
    });
    const [companies, setCompanies] = useState([]);
    const [userName, setUserName] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const fetchUserData = async () => {
            const authToken = localStorage.getItem('authToken');
            const email = localStorage.getItem('email');

            try {
                const userResponse = await axios.get(`http://localhost:5267/api/User/email/${encodeURIComponent(email)}`, {
                    headers: { Authorization: `Bearer ${authToken}` }
                });
                setUserName(userResponse.data.userName);

                const companyResponse = await axios.get('http://localhost:5267/api/Company', {
                    headers: { Authorization: `Bearer ${authToken}` }
                });
                setCompanies(companyResponse.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchUserData();
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setUserData(prevData => ({ ...prevData, [name]: value }));
    };

    const handleSave = async () => {
        try {
            const authToken = localStorage.getItem('authToken');
            await axios.post('http://localhost:5267/api/User', userData, {
                headers: { Authorization: `Bearer ${authToken}` }
            });
            alert('User added successfully');
        } catch (error) {
            console.error('Error saving user data:', error);
        }
    };

    const handleCancel = () => {
        setUserData({
            username: '',
            email: '',
            password: 'Rasha@tiki1',
            phone: '',
            address: '',
            companyId: '',
            isActive: true,
        });
    };

    const handleProfileClick = () => {
        navigate(`/Profile`); 
    };

    return (
        <div className="profile-page">
            <div className="app-bar">
                <a href="/Dashboard">
                    <img src={tiki_icon} alt="TIKI icon" className="logo" />
                </a>
                <h1 className="tiki">TIKI</h1>
                <div className="profile-section" onClick={handleProfileClick}>
                    <img src={notification_icon} alt="Notifications" className="notification-icon" />
                    <img src={profile_icon} alt="User" className="profile-icon" />
                    <span className="profile-name">{userName || 'Your Profile'}</span>
                </div>
            </div>

            <div className="profile-content">
                <div className="profile-header">
                    <h2>Add User</h2>
                </div>
                <div className="profile-details">
                    <div className="profile-item">
                        <label><strong>Username:</strong></label>
                        <input
                            type="text"
                            name="username"
                            value={userData.username}
                            onChange={handleInputChange}
                            className="input-field"
                        />
                    </div>
                    <div className="profile-item">
                        <label><strong>Email:</strong></label>
                        <input
                            type="email"
                            name="email"
                            value={userData.email}
                            onChange={handleInputChange}
                            className="input-field"
                        />
                    </div>
                    <div className="profile-item">
                        <label><strong>Phone Number:</strong></label>
                        <input
                            type="text"
                            name="phone"
                            value={userData.phone}
                            onChange={handleInputChange}
                            className="input-field"
                        />
                    </div>
                    <div className="profile-item">
                        <label><strong>Address:</strong></label>
                        <input
                            type="text"
                            name="address"
                            value={userData.address}
                            onChange={handleInputChange}
                            className="input-field"
                        />
                    </div>
                    <div className="profile-item">
                        <label><strong>Company:</strong></label>
                        <select
                            name="companyId"
                            value={userData.companyId}
                            onChange={handleInputChange}
                            className="input-field"
                        >
                            <option value="">Select a Company</option>
                            {companies.map(company => (
                                <option key={company.id} value={company.id}>
                                    {company.name}
                                </option>
                            ))}
                        </select>
                    </div>
                    <div className="save-cancel-buttons">
                        <button className="save-button" onClick={handleSave}>Save</button>
                        <button className="cancel-button" onClick={handleCancel}>Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AddUser;