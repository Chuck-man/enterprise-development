import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';
import PassengerDelete from './PassengerDelete';

const PassengerList = () => {
    const [passengers, setPassengers] = useState([]);
    const [message, setMessage] = useState('');

    const handleDeleteSuccess = (id) => {
        setPassengers(passengers.filter((passenger) => passenger.id !== id));
    };

    useEffect(() => {
        const fetchPassengers = async () => {
            try {
                const response = await api.get('/passenger');
                setPassengers(response.data);
            } catch (error) {
                console.error('Error fetching passengers:', error);
                setMessage('Failed to fetch passengers.');
                setTimeout(() => setMessage(''), 3000);
            }
        };
        fetchPassengers();
    }, []);

    return (
        <div className="container mt-5">
            <h2>Passenger List</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <Link to="/passenger/create" className="btn btn-success mb-3">Create New Passenger</Link>
            <ul className="list-group">
                {passengers.length > 0 ? (
                    passengers.map((passenger) => (
                        <li key={passenger.id} className="list-group-item d-flex justify-content-between align-items-center">
                            <div>
                                <p><strong>Passport Number:</strong> {passenger.passportNumber}</p>
                                <p><strong>Full Name:</strong> {passenger.fullName}</p>
                            </div>
                            <div>
                                <Link to={`/passenger/update/${passenger.id}`} className="btn btn-warning btn-sm me-2">Update</Link>
                                <PassengerDelete id={passenger.id} onDeleteSuccess={handleDeleteSuccess} />
                            </div>
                        </li>
                    ))
                ) : (
                        <li className="list-group-item">No passengers found</li>
                )}
            </ul>
        </div>
    );
}

export default PassengerList;