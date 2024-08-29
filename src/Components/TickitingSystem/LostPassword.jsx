import React, { useState } from 'react';
import './LostPassword.css';
import email_icon from '../Assests/email.png';

function LostPassword() {
    const [email, setEmail] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Handle the password reset request here
        // You might want to call an API to send a password reset email
        console.log('Password reset email sent to:', email);
    };

    return (
        <div className="container">
            <div className="header">
                <div className="text">Lost Password</div>
                <div className="underline"></div>
            </div>
            <div className="inputs">
                <img src={email_icon} alt="Email icon" />
                <input
                    type="email"
                    placeholder="Enter your email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>
            <div className="submit_container">
                <button className="submit" onClick={handleSubmit}>Send Reset Link</button>
            </div>
        </div>
    );
}

export default LostPassword;
