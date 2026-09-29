
// Author Meir Blachman

// https://gist.githubusercontent.com/Meir017/dec210bd552a9d4906336ac61f513cf6/raw/a73259114072f86cb09fabac5eea050172a6187b/timespan.ts

type TimeSpanCtorArguments = number
    | [number, number, number]
    | [number, number, number, number]
    | [number, number, number, number, number];

export class TimeSpan {
    public static readonly ticksPerMillisecond = 10000;
    private static readonly millisecondsPerTick = 1.0 / TimeSpan.ticksPerMillisecond;
    public static readonly ticksPerSecond = TimeSpan.ticksPerMillisecond * 1000;   // 10,000,000
    private static readonly secondsPerTick = 1.0 / TimeSpan.ticksPerSecond;         // 0.0000001
    public static readonly ticksPerMinute = TimeSpan.ticksPerSecond * 60;         // 600,000,000
    private static readonly minutesPerTick = 1.0 / TimeSpan.ticksPerMinute; // 1.6666666666667e-9
    public static readonly ticksPerHour = TimeSpan.ticksPerMinute * 60;        // 36,000,000,000
    private static readonly hoursPerTick = 1.0 / TimeSpan.ticksPerHour; // 2.77777777777777778e-11
    public static readonly ticksPerDay = TimeSpan.ticksPerHour * 24;          // 864,000,000,000
    private static readonly daysPerTick = 1.0 / TimeSpan.ticksPerDay; // 1.1574074074074074074e-12

    //private static readonly millisPerSecond = 1000;
   // private static readonly millisPerMinute = TimeSpan.millisPerSecond * 60; //     60,000
   // private static readonly millisPerHour = TimeSpan.millisPerMinute * 60;   //  3,600,000
   /* private static readonly millisPerDay = TimeSpan.millisPerHour * 24;      // 86,400,000

    private static readonly maxSeconds = Number.MAX_VALUE / TimeSpan.ticksPerSecond;
    private static readonly minSeconds = Number.MIN_VALUE / TimeSpan.ticksPerSecond;

    private static readonly maxMilliseconds = Number.MAX_VALUE / TimeSpan.ticksPerMillisecond;
    private static readonly minMilliseconds = Number.MIN_VALUE / TimeSpan.ticksPerMillisecond;

    private static readonly ticksPerTenthSecond = TimeSpan.ticksPerMillisecond * 100;// */

    public static readonly zero = new TimeSpan(0);
    public static readonly maxValue = new TimeSpan(Number.MAX_VALUE);
    public static readonly minValue = new TimeSpan(Number.MIN_VALUE);


    private readonly _ticks: number;

    constructor(args: TimeSpanCtorArguments) {
        if (typeof args === 'number') {
            this._ticks = args;
        } else if (args.length === 3) {
            const [hours, minutes, seconds] = args;
            this._ticks = (hours * 3600 + minutes * 60 + seconds) * TimeSpan.ticksPerSecond
        } else if (args.length === 4) {
            const [days, hours, minutes, seconds] = args;
            this._ticks = (days * 3600 * 24 + hours * 3600 + minutes * 60 + seconds) * TimeSpan.ticksPerSecond;
        } else {
            const [days, hours, minutes, seconds, milliseconds] = args;
            this._ticks = (days * 3600 * 24 + hours * 3600 + minutes * 60 + seconds) * TimeSpan.ticksPerSecond + milliseconds * TimeSpan.ticksPerMillisecond;
        }
    }

    get ticks() {
        return this._ticks;
    }
    get days() {
        return Math.round(this._ticks / TimeSpan.ticksPerDay);
    }
    get hours() {
        return Math.round((this._ticks / TimeSpan.ticksPerHour) % 24);
    }
    public get milliseconds() {
        return Math.round((this._ticks / TimeSpan.ticksPerMillisecond) % 1000);
    }
    get minutes() {
        return Math.round((this._ticks / TimeSpan.ticksPerMinute) % 60);
    }
    get seconds() {
        return Math.round((this._ticks / TimeSpan.ticksPerSecond) % 60);
    }

    get totalDays() {
        return this._ticks * TimeSpan.daysPerTick;
    }
    get totalHours() {
        return this._ticks * TimeSpan.hoursPerTick;
    }

    get totalMilliseconds() {
        return this._ticks * TimeSpan.millisecondsPerTick;
    }

    getTotalMilliseconds(): number{
        return this._ticks * TimeSpan.millisecondsPerTick;
    }


    get totalMinutes() {
        return this._ticks * TimeSpan.minutesPerTick;
    }
    get totalSeconds() {
        return this._ticks * TimeSpan.secondsPerTick;
    }

    add(ts: TimeSpan) {
        return new TimeSpan(this._ticks + ts._ticks);
    }

    subtract(ts: TimeSpan) {
        return new TimeSpan(this._ticks - ts._ticks);
    }

    multiply(factor: number) {
        return new TimeSpan(this._ticks * factor);
    }

    divide(divisor: number | TimeSpan) {
        if (divisor instanceof TimeSpan) {
            return this._ticks / divisor._ticks;
        }
        return new TimeSpan(this._ticks / divisor);
    }

    valueOf() {
        return this._ticks;
    }
    toString() {
        const days = this.days >= 10 ? this.days : '0' + this.days;
        const hours = this.hours >= 10 ? this.hours : '0' + this.hours;
        const minutes = this.minutes >= 10 ? this.minutes : '0' + this.minutes;
        const seconds = this.seconds >= 10 ? this.seconds : '0' + this.seconds;
        const milliseconds = this.milliseconds >= 100 ? this.milliseconds : this.milliseconds >= 100 ? '0' + this.milliseconds : '00' + this.milliseconds;
        return `${days}:${hours}:${minutes}:${seconds}.${milliseconds}`;
    }

    duration() {
        return new TimeSpan(this._ticks >= 0 ? this._ticks : -this._ticks);
    }

    negate() {
        return new TimeSpan(-this._ticks);
    }

 //   static parse(s: string) {
 //       return new TimeSpan(undefined);
   // }
    /*static tryParse(s: string) {
        return {
            success: true,
            value: TimeSpan.zero
        };
    }*/

    static fromDays(value: number) {
        return new TimeSpan(value * TimeSpan.ticksPerDay);
    }
    static fromHours(value: number) {
        return new TimeSpan(value * TimeSpan.ticksPerHour);
    }
    static fromMilliseconds(value: number) {
        return new TimeSpan(value * TimeSpan.ticksPerMillisecond);
    }
    static fromMinutes(value: number) {
        return new TimeSpan(value * TimeSpan.ticksPerMinute);
    }
    static fromSeconds(value: number) {
        return new TimeSpan(value * TimeSpan.ticksPerSecond);
    }
}