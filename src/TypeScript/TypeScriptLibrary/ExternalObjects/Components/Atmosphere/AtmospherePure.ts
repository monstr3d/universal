
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import { DateTimeConverter } from "../../../Library/Utilities/DateTime/DateTimeConverter";
import { RealMatrix } from "../../../Library/Utilities/Linear_Algebra/RealMatrix";
import { GeoCoordinates } from "../../Libraries/Geography/GeoCoordinates";
import { SunCoordinates } from "../../Libraries/Sun.Service/SunCoordinates";
import { SunPosition } from "../../Libraries/Sun.Service/SunPosition";
import { SunTime } from "../../Libraries/Sun.Service/SunTime";

export class AtmospherePure {

    constructor() {
        this.initSelf();
        this.setIf(this.ifa);
    }

    protected ASoL: number[] = [0]
    protected DSoL: number[] = [0]
    protected ed: number[] = [0]
    protected eh: number[] = [0]


    //  protected Object[] ob = new Object[2];

    //  public String[] sins = new String[] { "t", "x", "y", "z" };

    // public String[] sous = new String[] { "Density" };

    protected mac: number[] = [31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365];
    protected f01: number[] = [- 14.608, 0.8969, 67.596, -0.4016, 0.3031E-2, 0.2344E-5, 0.130,
        0.14E-3, 3.733, -507.95, 189.85, 4.2, 0.653, -0.7379, 0.8524E-2,
    -0.5328E-5, -0.1767, 0.1859E-2, -0.1172E-5, 0.80, 2.0, -14.469,
        0.8517, 56.026, -0.3957, 0.2988E-2, 0.2246E-5, -0.172, 0.217E-2,
        3.784, -566.11, 200.97, 4.1, 0.621, -0.7379, 0.8524E-2, -0.5328E-5,
    -0.1785, 0.1848E-2, -0.1211E-5, 0.89, 2.0, -15.415, 0.7729, 61.836
        , -0.3898, 0.2945E-2, 0.2148E-5, -0.274, 0.257E-2, 4.048, -632.63,
        230.76, 4.4, 0.635, -0.7379, 0.8524E-2, -0.5328E-5, -0.1802,
        0.1838E-2, -0.125E-5, 1.0, 3.0, -16.559,
        0.6982, 75.401, -0.3839, 0.2902E-2, 0.2051E-5, -0.247, 0.199E-2,
        3.495, -707.58, 278.35, 4.7, 0.632, -0.7379, 0.8524E-2, -0.5328E-5,
    -0.182, 0.1826E-2, -0.1289E-5, 1.0, 4.0, -18.219, 0.5863, 98.336
        , -0.3472, 0.2562E-2, 0.2344E-5, -0.201, 0.161E-2, 3.2, -712.0,
        290.0, 4.5, 0.611, -0.7379, 0.8524E-2, -0.5328E-5, -0.1855, 0.1805E-2,
    -0.1367E-5, 1.0, 5.0, -19.068, 0.5177, 109.999, -0.3271, 0.2305E-2,
        0.2539E-5, -0.194, 0.134E-2, 3.0, -727.0, 300.0, 4.5, 0.611,
    -0.7379, 0.8524E-2, -0.5328E-5, -0.1891, 0.1783E-2, -0.1445E-5,
        1.0, 5.0];
    protected f0: number[] = [
        - 18.873, 0.666, 118.013, -0.3644, 0.2618E-2, 0.349E-5, -1.0445, 0.9532E-2,
        -6.4688, -507.95, 189.85, 4.2, 0.653, -2.6122, 0.02935,
        -0.6318E-4, -0.4422, 0.4809E-2, -0.9367E-5, 0.8, 2.0, -19.308, 0.596,
        119.285, -0.3525, 0.2508E-2, 0.3579E-5, -0.8181, 0.723E-2, -6.8255,
        -566.11, 200.97, 4.1, 0.621, -2.6122, 0.2935E-1, -0.6318E-4,
        -0.4109, 0.443E-2, -0.8384E-5, 0.89, 2.0, -19.532, 0.5519, 119.744,
        -0.3406, 0.2398E-2, 0.3667E-5, -0.6404, 0.5594E-2, -4.2892, -632.63,
        230.76, 4.4, 0.635, -2.6122, 0.2935E-1, -0.6318E-4, -0.3814,
        0.4074E-2, -0.7461E-5, 1.0, 3.0, -19.592,
        0.5296, 119.828, -0.3288, 0.2289E-2, 0.3752E-5, -0.4438, 0.3836E-2
        , -1.4294, -707.58, 278.35, 4.7, 0.632, -2.6122, 0.2935E-1, -0.6318E-4,
        -0.349, 0.3682E-2, -0.6444E-5, 1.0, 4.0, -19.614, 0.5032, 119.846,
        -0.2931, 0.1961E-2, 0.4012E-5, -0.4581, 0.4157E-2, -2.6263, -712.0,
        290.0, 4.5, 0.611, -2.6122, 0.2935E-1, -0.6318E-4, -0.2882, 0.2946E-2,
        -0.4538E-5, 1.0, 5.0, -19.682, 0.4796, 119.927, -0.2016, 0.9112E-3,
        0.6411E-5, -0.2977, 0.2401E-2, 0.5736, -727.0, 300.0, 4.5,
        0.611, -2.6122, 0.02935, -0.6318E-4, -0.2255, 0.2188E-2, -0.257E-5
        , 1.0, 5.0];
    protected ad: number[] = [
        - 0.067, -0.088, -0.094, -0.088, -0.053,
        -0.005, 0.039, 0.09, 0.123, 0.133,
        0.123, 0.099, 0.059, 0.017, -0.027, -0.065, -0.103, -0.136, -0.156, -0.172,
        -0.18, -0.183, -0.179, -0.163, -0.133, -0.085, -0.018, 0.059, 0.123, 0.161,
        0.17, 0.156, 0.119, 0.073, 0.027, -0.023, -0.055, -0.078];

    protected KDNEY: number[] = [31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    N10: number = 0;
    f1: number[] = [];
    protected ifa: number[] = [150, 6, 140];
    if1: number[] = [75, 100, 125, 150, 200, 250];
    date: number[] = [0, 0, 0];
    protected r: number[] = [0, 0, 0];
    protected y: number[] = [0, 0, 0];
    protected ff0: number[][] = [];
    protected ff1: number[][] = [];
    protected ome: number = 7.292115085E-5;
    private dd: number[] = [0, 0, 0, 0];
    protected xout: number[] = [0, 0, 0];
    protected alphastar: number[] = [0];
    protected h: number[] = [0]


    private set(x: number[], n: number): void {
        for (let i = 0; i < n; i++) {
            x.push(0);
        }
    }

    private initSelf(): void {
        if (this.ff0.length > 0) {
            return;
        }
        let n = Math.floor(this.f0.length / 21);
        for (let i = 0; i < n; i++) {
            this.ff0.push([]);
            this.ff1.push([]);
        }
        for (let i = 0; i < this.ff0.length; i++) {
            let fff: number[] = [];
            let fff1: number[] = [];
            this.set(fff, 21);
            this.set(fff1, 21);
            this.ff0[i] = fff;
            this.ff1[i] = fff1;
            let j = i * 21;
            for (let k = 0; k < 21; k++) {
                let n = k + j;
                fff[k] = this.f0[n];
                fff1[k] = this.f01[n];
            }
        }
    }

    protected setIf(value: number[]): void
    {
        this.N10 = 0;
        for (var i = 0; i < 6; i++) {
            if (this.if1[i] == value[0]) {
                break;
            }
            else
            {
                this.N10++;
            }
        }
        this.ifa[0] = value[0];
        this.ifa[1] = value[1];
        this.ifa[2] = value[2];
    }

   
    public atmosphere(t: number, x: number[]): number {
        var r2 = x[0] * x[0] + x[1] * x[1];
        var lat = Math.atan2(x[2], Math.sqrt(r2));
        var lon = Math.atan2(x[1], x[0]);
        this.coordinates.setLatitude(lat);
        this.coordinates.setLongitude(lon);
        let tday = t / 86400;
        let dt = this.dateTimeConverter.fromOADate(tday);
        var hh = this.realMatrix.normalize(x, this.y, 0);
        let ho = dt.getHours();
        let mi = dt.getMinutes();
        let ss = dt.getSeconds();
        let it = Math.floor(t);
        let sss = 1000 * (t - it);
        let tt = (ho * 60 + mi) * 60 + ss + .001 * sss;
        this.sunPosition.getPosition(dt, this.coordinates, this.sunCoordinates, this.ASoL, this.DSoL, this.ed, this.eh);
        var alphastar = this.sunTime.CalculateGreenwichSiderealTimeFromDate(dt);
        this.date[0] = dt.getDate();
        this.date[1] = dt.getMonth() + 1;
        this.date[2] = dt.getFullYear();
        var rho = this.atm(x, tt, this.DSoL[0], this.ASoL[0], alphastar, this.h, this.date);
        var s = `${rho}`;
        var b = s.includes("NaN");
        if (b) {
            var i = 0;
        }

        return rho;
    }

    /// <summary>
    /// Atmosphere parameters
    /// </summary>
    /// 
    public getIf(): number[] {
        return this.ifa;
    }
    

    rad(x: number[]): number {
   let a = 0;
        for (var i = 0; i < 3; i++) {
            a += x[i] * x[i];
        }
        return Math.sqrt(a);
    }

    atm(x: number[], t: number, alf: number, del: number, s0: number, h: number[], it: number[]): number {
        let hh = this.rad(x);

        for (let i = 0; i < 3; i++) {
            this.y[i] = x[i] / hh;
        }
        h[0] = hh - 6378.140 * (1.0 - 0.335282E-2 * this.y[2] * this.y[2]);
        if (h[0] <= 180)
        {
            this.f1 = this.ff0[this.N10];
        }
        else
        {
            this.f1 = this.ff1[this.N10];
        }
        let N3 = it[1] - 1;
        let a2 = 0;
        let dat2 = 0;
        if (N3 <= 0)
            a2 = it[0] / 10;
        else {
            dat2 = it[1] / 4;
            if (Math.abs(Math.floor(dat2 + .00001) - dat2) < .0001)
                a2 = (this.mac[N3 - 1] + 1 + it[0]) / 10.0;
            else
                a2 = (this.mac[N3 - 1] + it[0]) / 10.0;
        }
        let N2 = Math.floor(a2);
        let a3 = a2 - N2;
        N2++;
        let ad1 = this.ad[N2 - 1] + (this.ad[N2] - this.ad[N2 - 1]) * a3;
        let gam = alf + this.f1[12] - s0 - this.ome * (t - 10800.0);
        let cosfi = this.y[2] * Math.sin(del) + Math.cos(del) * (this.y[0] * Math.cos(gam) +
            this.y[1] * Math.sin(gam));
        let xk4 = 1 + (this.f1[16] + this.f1[17] * this.h[0] + this.f1[18] * this.h[0] * this.h[0]) *
            Math.log(this.ifa[1] / this.f1[20] + this.f1[19]);
        let xk3 = 1 + (this.f1[13] + this.f1[14] * this.h[0] + this.f1[15] * this.h[0] * this.h[0]) * ad1;
        let cosfi2 = Math.abs((1.0 + cosfi) / 2.0);
        let xk2 = 1 + (this.f1[6] + this.f1[7] * this.h[0] + this.f1[8] * Math.exp(-(this.h[0] + this.f1[9]) / this.f1[10]
            * (h[0] + this.f1[9]) / this.f1[10])) * Math.pow(cosfi2, this.f1[11] / 2);
        let xk1 = 1.0 + (this.f1[3] + this.f1[4] * this.h[0] + this.f1[5] * this.h[0] * this.h[0]) * (this.ifa[2] - this.ifa[0]) / this.ifa[0];
        let roh = Math.exp(this.f1[0] - this.f1[1] * Math.sqrt(this.h[0] - this.f1[2]));
        return roh * xk1 * xk2 * xk3 * xk4;
    }







    private coordinates: GeoCoordinates = new GeoCoordinates();

    private sunCoordinates: SunCoordinates = new SunCoordinates();

    private realMatrix: RealMatrix = new RealMatrix();

    private sunPosition: SunPosition = new SunPosition();

    private sunTime: SunTime = new SunTime();

    private dateTimeConverter: DateTimeConverter = new DateTimeConverter();




}

