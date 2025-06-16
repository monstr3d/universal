/* eslint-disable no-empty */
import React, { useState } from 'react';
import { getOrbitalForecastFromNumber, obritalInitial } from './OrbitalData';
/*
  const [begin, setBegin] = useState('0');
   const [end, setEnd] = useState('20000');
   const [x, setX] = useState('-5448.34815324');
   const [y, setY] = useState('-4463.93698421');
   const [z, setZ] = useState('0');
   const [Vx, setVx] = useState('0.985394777432');
   const [Vy, setVy] = useState('1.21681893834');
   const [Vz, setVz] = useState('7.45047785592');
*/
const OrbitalTest = async () => {
    const [begin, setBegin] = useState('');
    const [end, setEnd] = useState('');
    const [x, setX] = useState('');
    const [y, setY] = useState('');
    const [z, setZ] = useState('');
    const [Vx, setVx] = useState('');
    const [Vy, setVy] = useState('');
    const [Vz, setVz] = useState('');
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
    const initCond = async () => {
 
        const result = await obritalInitial();
        if (result != null) {
            console.log(result);
        /*    const b = result.Begin + '';
            setBegin(b);
            const e = result.End + '';
            setEnd(e);
            const x = result.X + '';
            setX(x);
            const y = result.Y + '';
            setY(y)
            const z = result.Z + '';
            setZ(z)
            const Vx = result.Vx + '';
            setVx(Vx)
            const Vy = result.Vx + '';
            setVy(Vy)
            const Vz = result.Vx + '';
            setVz(Vz);*/
        }

    };

    await initCond();

    return (
        <form onSubmit={handleSubmit} >
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


};
export default OrbitalTest;



