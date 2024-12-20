import React, { useState } from 'react';
import api from '../api/api';

function PassengerDelete({ id, onDeleteSuccess }) {
    const [message, setMessage] = useState('');
    const handleDelete = async () => {
        try {
            await api.delete(`/api/Passenger/${id}`);
            onDeleteSuccess(id);
            setMessage('Passenger deleted successfully!');
        } catch (error) {
            setMessage('Failed to delete passenger');
        }
    };

    return (
        <div>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <button onClick={handleDelete} className="btn btn-danger btn-sm">
                Delete
            </button>
        </div>
    );
}

export default PassengerDelete;