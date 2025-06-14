import React, { useState } from 'react';
import { getOrbitalForecastFromNumber, getOrbitalForecastFromSting } from './OrbitalData';
function OrbitalTest() {
    const [begin, setBegin] = useState('0');
    const [end, setEnd] = useState('8000');
    const [x, setX] = useState('-5448.34815324');
    const [y, setY] = useState('-4463.93698421');
    const [z, setZ] = useState('0');
    const [Vx, setVx] = useState('0.985394777432');
    const [Vy, setVy] = useState('1.21681893834');
    const [Vz, setVz] = useState('7.45047785592');

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();

        const condition = {
            Begin: parseFloat(begin),
            End: parseFloat(end),
            X: parseFloat(x),
            Y: parseFloat(y),
            Z: parseFloat(z),
            Vx: parseFloat(Vx),
            Vy: parseFloat(Vy),
            Vz: parseFloat(Vz),
        };

        try {
            const response = getOrbitalForecastFromNumber(condition);
            console.error('Forecast:', response);
        } catch (error) {
            console.error('Network error:', error);
            alert('Network error occurred.');
        }
    };

    const handleSubmitString = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();

        const condition = {
            Begin: begin,
            End: end,
            X: x,
            Y: y,
            Z: z,
            Vx: Vx,
            Vy: Vy,
            Vz: Vz,
        };

        try {
            const response = getOrbitalForecastFromSting(condition);
            console.error('Forecast:', response);
        } catch (error) {
            console.error('Network error:', error);
            alert('Network error occurred.');
        }
    };




    return (
        <form onSubmit={handleSubmitString}>
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