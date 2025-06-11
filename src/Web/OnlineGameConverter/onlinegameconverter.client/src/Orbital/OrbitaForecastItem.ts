import type { DateTime } from 'luxon';

export type OrbitaForecastItem = {
    DateTime: DateTime;
    X: number;
    Y: number;
    Z: number;
    Vx: number;
    Vy: number;
    Vz: number;
};
