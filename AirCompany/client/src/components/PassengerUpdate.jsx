import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api/api';

const PassengerUpdate = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [passportNumber, setPassportNumber] = useState('');
    const [fullName, setFullName] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchPassenger = async () => {
            try {
                const response = await api.get(`/passenger/${id}`);
                setPassportNumber(response.data.passportNumber);
                setFullName(response.data.fullName);
            } catch (error) {
                console.error('Error fetching passenger:', error);
                setError('Passenger not found');
            }
        };

        fetchPassenger();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.put(`/passenger/${id}`, { passportNumber, fullName });
            setMessage('Passenger updated successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error updating passenger:', error);
            setMessage('Failed to update passenger.');
        }
    };

    return (
        <div className="container mt-5">
            <h2>Update Passenger</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            {error && (
                <div className="alert alert-danger" role="alert">
                    {error}
                </div>
            )}
            {!error && (
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label htmlFor="passportNumber" className="form-label">Passport Number:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="passportNumber"
                            value={passportNumber}
                            onChange={(e) => setPassportNumber(e.target.value)}
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
                            onChange={(e) => setFullName(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Update Passenger</button>
                </form>
            )}
        </div>
    );
};

export default PassengerUpdate;