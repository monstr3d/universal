

export class DateTimeConverter {

    baseDays: number = 25569;

    coeff: number = 86400000;

    coeffI: number = 1.0 / 86400000.0;

    off: number = 0;

    constructor() {
      //  this.baseOADate = new Date(1899, 12, 30, 0, 0, 0, 0);
        const baseDate = new Date(0)
        this.off = baseDate.getTimezoneOffset() * 60000;
    }


    public toOADate(date: Date): number
    {
        var t = date.getTime();
        t *= this.coeffI;
        t += this.baseDays;
        return t;
    }


    public fromOADate(date: number): Date
    {
        var x = date - this.baseDays;
        x *= this.coeff;
        return  new Date(x + this.off);
    }


    public fromSrting(s: string): number {
        return Date.parse(s)
    }

}