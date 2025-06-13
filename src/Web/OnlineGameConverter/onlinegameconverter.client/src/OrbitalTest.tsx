import React, { useState } from 'react';
import { webAPIUrl } from './AppSettings';
function OrbitalTest() {
    const [begin, setBegin] = useState('0');
    const [end, setEnd] = useState('8000000');
    const [x, setX] = useState('-5448.34815324');
    const [y, setY] = useState('-4463.93698421');
    const [z, setZ] = useState('0');
    const [Vx, setVx] = useState('0.985394777432');
    const [Vy, setVy] = useState('1.21681893834');
    const [Vz, setVz] = useState('7.45047785592');

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();

        const condition = {
            Begin: begin,
            End : end,
            X: x,
            Y: y,
            Z: z,
            Vx: Vx,
            Vy: Vy,
            Vz: Vz,
       };

        try {
            const bd = JSON.stringify(condition);
            console.log("Body", bd)
         /*   const response = await fetch(webAPIUrl +  '/OrbitalForecastController/ForecastFromNumber', { // Replace with your API endpoint
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: bd,
            });*/
            const response = await fetch('OrbitalForecast/GetOrbitalForecastFromNumber', { // Replace with your API endpoint
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: bd,
            });
            if (response.ok) {
                const data = await response.json();
                alert(data.Message); // Show success message
                console.log("Responose", response);
                console.log('Json', data);
                // Optionally, clear the form or redirect
            } else {
                const errorData = await response.json(); // Try to parse error details
                console.error('Error creating user:', errorData);
                alert(`Error: ${errorData.message || response.statusText}`); // Show error message
            }
        } catch (error) {
            console.error('Network error:', error);
            alert('Network error occurred.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="begin">Begin:</label>
                <input
                    type="text"
                    id="begin"
                    value={begin}
                    onChange={(e) => setBegin(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="end">End:</label>
                <input
                    type="text"
                    id="end"
                    value={end}
                    onChange={(e) => setEnd(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="x">X:</label>
                <input
                    type="text"
                    id="x"
                    value={x}
                    onChange={(e) => setX(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="y">Y:</label>
                <input
                    type="text"
                    id="y"
                    value={y}
                    onChange={(e) => setY(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="z">Z:</label>
                <input
                    type="text"
                    id="z"
                    value={end}
                    onChange={(e) => setZ(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="Vx">Vx:</label>
                <input
                    type="text"
                    id="Vx"
                    value={Vx}
                    onChange={(e) => setVx(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="Vy">Vy:</label>
                <input
                    type="text"
                    id="Vy"
                    value={Vy}
                    onChange={(e) => setVy(e.target.value)}
                />
            </div>
            <div>
                <label htmlFor="Vz">Vz:</label>
                <input
                    type="text"
                    id="Vz"
                    value={Vz}
                    onChange={(e) => setVz(e.target.value)}
                />
            </div>
            <button type="submit">Create User</button>
        </form>
    );
}

export default OrbitalTest;