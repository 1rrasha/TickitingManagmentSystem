import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './LoginSignup.css';
import email_icon from '../Assests/email.png';
import password_icon from '../Assests/password.png';
import tiki_icon from '../Assests/tiki.png';

function Login() {
    const [formData, setFormData] = useState({
        email: "",
        password: ""
    });

    const [errors, setErrors] = useState("");
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrors(""); 
        
        try {
            const response = await axios.post("http://localhost:5267/api/Auth/login", formData);
            const { token } = response.data;
            localStorage.setItem('authToken', token);
            localStorage.setItem('email', formData.email);
            navigate('/dashboard'); 
        } catch (error) {
            console.error("Login error:", error);
            if (error.response && error.response.data) {
                setErrors("Invalid email or password.");
            } else {
                setErrors("An error occurred during login.");
            }
        }
    };
    
    
    
    console.log('Errors:', errors);
    

    return (
        <div className="container">
            <div className="welcome">
                <img src={tiki_icon} alt="TIKI icon" />
                <div>Welcome to <span className="tiki">TIKI</span></div>
            </div>
            <div className="header">
                <div className="text">Login</div>
                <div className="underline"></div>
            </div>
            <form onSubmit={handleSubmit}>
                <div className="inputs">
                    <img src={email_icon} alt="Email icon" />
                    <input
                        type="email"
                        name="email"
                        placeholder="Email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="inputs">
                    <img src={password_icon} alt="Password icon" />
                    <input
                        type="password"
                        name="password"
                        placeholder="Password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                </div>
                {errors && <div className="error-message">{errors}</div>}
                <div className="forgot-password">
                    <Link to="/lost-password">Forgot Password?</Link>
                </div>
                <div className="submit_container">
                    <button className="submit" type="submit">Login</button>
                </div>
            </form>
            <div className="account-message">
                Don't have an account? <Link to="/signup">Sign Up</Link>
            </div>
        </div>
    );
}

export default Login;
