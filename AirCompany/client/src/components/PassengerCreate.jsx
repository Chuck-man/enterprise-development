import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';

const PassengerCreate = () => {
    const [passportNumber, setpassportNumber] = useState('');
    const [fullName, setfullName] = useState('');
    const [message, setMessage] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.post('/api/passenger', { passportNumber, fullName });
            setMessage('Passenger created successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error creating passenger:', error);
            setMessage(`Failed to create passenger: ${error.response?.data || error.message}`);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Create passenger</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="passportNumber" className="form-label">Pasport:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="passportNumber"
                        value={passportNumber}
                        onChange={(e) => setpassportNumber(e.target.value)}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="fullName" className="form-label">Full Name:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="fullName"
                        value={fullName}
                        onChange={(e) => setfullName(e.target.value)}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Create</button>
            </form>
        </div>
    );
}

export default PassengerCreate;