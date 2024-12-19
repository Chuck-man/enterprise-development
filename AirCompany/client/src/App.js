import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import PassengerCreate from './components/PassengerCreate';
import PassengerDelete from './components/PassengerDelete';
import PassengerList from './components/PassengerList';
import PassengerUpdate from './components/PassengerUpdate';


function App() {
    return (
        <Router>
            <div>
                <h1 className="text-center">Passenger Client</h1>
                <Routes>
                    <Route path="/" element={<PassengerList />} />
                    <Route path="/passenger/create" element={<PassengerCreate />} />
                    <Route path="/passenger/update/:id" element={<PassengerUpdate />} />
                    <Route path="/passenger/delete/:id" element={<PassengerDelete />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;