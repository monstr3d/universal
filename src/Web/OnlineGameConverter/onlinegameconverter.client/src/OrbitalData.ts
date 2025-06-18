/* eslint-disable @typescript-eslint/no-unused-vars */
import { http } from './http';

export interface OrbitalForecastConditionNumber {
    Begin: number;
    End: number;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
}

export interface OrbitalForecastItemNumber {
    OrbitalTime: number;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
}

export interface OrbitalForecastConditionString {
    Begin: string;
    End: string;
    X: string;
    Y: string;
    Z: string;
    Vx: string;
    Vy: string;
    Vz: string;
}

export interface OrbitalForecastItemString {
    OrbitalTime: string;
    X: string;
    Y: string;
    Z: string;
    Vx: string;
    Vy: string;
    Vz: string;
}

export const getOrbitalForecastFromNumber = async (
    condition: OrbitalForecastConditionNumber,
): Promise<OrbitalForecastItemNumber[] | null> => {
    console.log('ForecastFromNumber');
    const result = await http<OrbitalForecastItemNumber[], OrbitalForecastConditionNumber>({
        path: `/orbital`,
        method: "post",
        body: condition,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};

export const getOrbitalForecastFromNumber1 = async (
   condition: OrbitalForecastConditionNumber,
): Promise<OrbitalForecastItemNumber[] | null> => {
    console.log('ForecastFromNumber');
    const result = await http<OrbitalForecastItemNumber[], OrbitalForecastConditionNumber>({
        path: `/orbitalforecastfronumber`,
        method: "post",
        body: condition,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};

export const getOrbitalInitial = async (): Promise<OrbitalForecastConditionNumber | null> => {
    const result = await http<OrbitalForecastConditionNumber>({
        path: '/orbital/initial',
    });
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};

export const obritalInitial = async (
): Promise<OrbitalForecastConditionNumber | null> => {
    try {
        console.log("obritalInitial");

        const response = await fetch('api/orbital');
        if (response.ok) {
            console.log("obritalInitial RESPONSE", response);
            if (response.body) {
                console.log("BI+ODY RESPONSE", response.body);
                const data = await response.body.json();
                return data;
            }
        }
    }
    catch (ex) {
        console.log(ex);
    }
    console.log("obritalInitial null");
    return null;
}

    export async function initCond():void {

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


export const weather = async (
):Promise< void> => {
    try {
        console.log("obritalInitial");

        const response = await fetch('/weatherfoecast');
        if (response.ok) {
            console.log("obritalInitial RESPONSE", response);
            if (response.body) {
                console.log("BI+ODY RESPONSE", response.body);
         //       const data = await response.body.json();
                return;
            }
        }
    }
    catch (ex) {
        console.log(ex);
    }
    console.log("obritalInitial null");
}



