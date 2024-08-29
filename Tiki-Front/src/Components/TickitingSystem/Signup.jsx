import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import './LoginSignup.css';
import email_icon from '../Assests/email.png';
import password_icon from '../Assests/password.png';
import confirm from '../Assests/confirm.png';
import person_icon from '../Assests/person.png';
import phone_icon from '../Assests/phone.png';
import tiki_icon from '../Assests/tiki.png';

function Signup() {
    const [formData, setFormData] = useState({
        userName: "",
        email: "",
        phone: "",
        password: "",
        confirmPassword: ""
    });

    const [errors, setErrors] = useState("");
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrors(""); // Clear previous errors

        try {
            const response = await axios.post("http://localhost:5267/api/Auth/register", formData);
            alert(response.data.result);
            navigate('/'); 
        } catch (error) {
            console.error("Registration error:", error);
            let errorMessage = "An error occurred during registration.";

            if (error.response && error.response.data) {
                // Assuming the API returns an object with error details
                if (typeof error.response.data === "object") {
                    // Extract a meaningful error message from the object
                    errorMessage = error.response.data.message || "An unexpected error occurred.";
                } else {
                    errorMessage = error.response.data;
                }
            }

            setErrors(errorMessage);
        }
    };

    return (
        <div className="container">
            <div className="welcome">
                <img src={tiki_icon} alt="TIKI icon" />
                <div>Welcome to <span className="tiki">TIKI</span></div>
            </div>
            <div className="header">
                <div className="text">Sign Up</div>
                <div className="underline"></div>
            </div>
            <form onSubmit={handleSubmit}>
                <div className="inputs">
                    <img src={person_icon} alt="Person icon" />
                    <input
                        type="text"
                        name="userName"
                        placeholder="Username"
                        value={formData.userName}
                        onChange={handleChange}
                        required
                    />
                </div>
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
                    <img src={phone_icon} alt="Phone icon" />
                    <input
                        type="tel"
                        name="phone"
                        placeholder="Phone"
                        value={formData.phone}
                        onChange={handleChange}
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
                <div className="inputs">
                    <img src={confirm} alt="Confirm Password icon" />
                    <input
                        type="password"
                        name="confirmPassword"
                        placeholder="Confirm Password"
                        value={formData.confirmPassword}
                        onChange={handleChange}
                        required
                    />
                </div>
                {errors && <div className="error-message">{errors}</div>}
                <div className="submit_container">
                    <button className="submit" type="submit">Sign Up</button>
                </div>
            </form>
            <div className="account-message">
                Already have an account?<span onClick={() => navigate('/')}> Login</span>
            </div>
        </div>
    );
}

export default Signup;
