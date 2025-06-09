import { DateTime } from 'luxon';
export interface OrbitaForecastItem {
    DateTime: DateTime;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
}

export interface OrbitaForecastCondition {
    Begin: DateTime;
    End: DateTime;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
}

