import { useEffect } from 'react';
import { http } from './http';
import { getOrbitalForecastFromNumber, obritalInitial, getOrbitalInitial } from './OrbitalData';

export interface Note {
  Name: string;
  Description: string;
}

export interface ExtededNote {
  Name: string;
  Description: string;
  DateTime: string;
}



export const getExtendedNote = async (
  note: Note,
): Promise<ExtededNote | null> => {
  console.log('Extended node');
  const result = await http<ExtededNote, Note>({
      path: `/notes`,
    method: "post",
    body: note,
  });
    console.log("ok", result.ok);
    console.log("body", result.body);
  if (result.ok && result.body) {
    return result.body;
  } else {
    return null;
  }
};

export const getOrbdNote = async (
    note: Note,
): Promise<ExtededNote | null> => {
    console.log('Extended ORB node');
    const result = await http<ExtededNote, Note>({
        path: `/orbital/GetExtendedNote`,
        method: "post",
        body: note,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};


export const getFictiondNote = async (
    note: Note,
): Promise<ExtededNote | null> => {
    console.log('Extended node');
    const result = await http<ExtededNote, Note>({
        path: `/notes/fiction`,
        method: "post",
        body: note,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};


export const nodeOrbClick = (): void => {
    console.log('nodeORBClick');
    const note = { Name: 'N', Description: 'd' };
    getOrbdNote(note);
    console.log('Node ORB Click');
};

export const nodeOrbIClick = (): void => {

    try {
        console.log('nodeORBClick');
        const o = obritalInitial();
        console.log('Node ORB Click', o);
    } catch (error) {
        console.error("Error fetching data:", error);
    }
};

export async function nodeWeatheerClick1 (): Promise<void> {

    try {
        const response = await fetch('api/weatherforecast');
        if (response.ok) {
            console.log("R", response)
            const data = await response.json();
            console.log("D", data)
        }
    }
    catch (error) {
        console.error("Error fetching data:", error);
    }
};


export async function nodeOrbitalIClick(): Promise<void> {

    try {

  //      const cond = {
  //          Begin: 0, End: 20000, X: -5448.34815324, Y: -4463.93698421, Z: 0, Vx: 0.98539477743, Vy: 1.21681893834, Vz: 7.45047785592
        //       };
        console.log("ORBITAL");

        const response = await getOrbitalInitial();
        console.log("ORBITALLLL", response);
        console.log("X", response.x);
        if (response.ok) {
            console.log("ORBITAL", response);
            console.log("X", response.X);
         }
    }
    catch (error) {
        console.error("Error fetching data:", error);
    }
};



export async function nodeOrbitalClick(): Promise<void> {

    try {

        const cond = {
            Begin: 0, End: 20000, X: -5448.34815324, Y: -4463.93698421, Z: 0, Vx: 0.98539477743, Vy: 1.21681893834, Vz: 7.45047785592
        };
        const response = await getOrbitalForecastFromNumber(cond);
        if (response.ok) {
            console.log("R", response)
            const data = await response.json();
            console.log("D", data)
        }
    }
    catch (error) {
        console.error("Error fetching data:", error);
    }
};


export async function nodeWheatherForecastClick(): Promise<void> {

    try {
        const response = await fetch('weatherforecast/ttts');
        if (response.ok) {
            console.log("R", response)
            const data = await response.json();
            console.log("D", data)
        }
    }
    catch (error) {
        console.error("Error fetching data:", error);
    }
};





export async function orbIClick(): Promise<void> {

    try {
        const response = await fetch('api/orbital/initial');
        if (response.ok) {
            console.log("R", response)
        }
    }
    catch (error) {
        console.error("Error fetching data:", error);
    }
};




export const nodeClick = (): void => {
    console.log('nodeClick');
    const note = { Name: 'N', Description: 'd' };
    getFictiondNote(note);
    console.log('Node Click');
};
/*
const [begin, setBegin] = useState('');
const [end, setEnd] = useState('');
const [x, setX] = useState('');
const [y, setY] = useState('');
const [z, setZ] = useState('');
const [Vx, setVx] = useState('');
const [Vy, setVy] = useState('');
const [Vz, setVz] = useState('');

*/



