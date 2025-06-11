import type { DateTime } from 'luxon';


export type OrbitaForecastCondition = {
    Begin: DateTime;
    End: DateTime;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
};
