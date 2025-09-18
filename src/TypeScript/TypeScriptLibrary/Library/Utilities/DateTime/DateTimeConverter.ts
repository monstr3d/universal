import { DateTime } from "luxon";

export class DateTimeConverter {

    baseOADate: Date = new Date(1899, 12, 30, 0, 0, 0, 0);

    baseDate: Date = new Date(0);

    baseDays: number = 25569;

    coeff: number = 86400000;

    coeffI: number = 1.0 / 86400000.0;


  /*  constructor()
    {
        var x = this.baseOADate.getTime();
        this.baseDays = x * this.coeffI - 2;
    }*/

    public toOADate(date: Date): number
    {
        var x = date.getTime() * this.coeffI;
        return x - this.baseDays;
    }


    public fromOADate(date: number): Date
    {
        var x = date - this.baseDays;
        x *= this.coeff;
        var d = new Date();
        var off  =  d.getTimezoneOffset() * 60000;
        return new Date(x + off);
    }
    
}