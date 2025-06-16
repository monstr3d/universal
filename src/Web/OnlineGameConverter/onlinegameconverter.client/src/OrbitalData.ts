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

export const obritalInitial = async (
): Promise<OrbitalForecastConditionNumber | null> => {
    try {
        console.log("obritalInitial");

        const response = await fetch('api/orbital/initial');
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

