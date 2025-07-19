import { IAlias } from "./IAlias";
import { IDataConsumer } from "./Measurements/IDataConsumer";
import { IMeasurement } from "./Measurements/IMeasurement";
import { ITimeMeasurementConsumer } from "./Measurements/ITimeMeasurementConsumer";
import { Operation } from "./Types/Operation";

export class Performer
{
    protected a: number = 0;


    protected b: boolean = false;

    protected s: string = "";

    public Convert(operation: Operation<any>): Operation<number>  {
      
        return () => {
            let value = operation();
            if (typeof value === 'number') {
                return value; // Already a number
            }
            return 0;
        }
    }

    public GetAnyTimeOperation(consumer: ITimeMeasurementConsumer): Operation<any> {
        var m = consumer.getTimeMeasutement();
        return () => { m.getOperation()(); }
    }

    public GetNumberTimeOperation(consumer: ITimeMeasurementConsumer): Operation<number> {
        return () => {
            var m = consumer.getTimeMeasutement();
            let value = m.getOperation()();
            if (typeof value === 'number') {
                return value; // Already a number
            }
            return 0;
        }
    }


    public getMeasurement(i: number, j: number, dataConsumer: IDataConsumer): IMeasurement
    {
        return dataConsumer.getAllMeasurements()[i].geMeasurement(j);
    }


    public enlarge<T>(t: T[], x: T, size: number): void
    {
        for (let i = 0; i < size; i++)  t.push(x);
    }

    public enlarge2<T>(t: T[][], x: T, row: number, column: number): void {
        for (let i = 0; i < row; i++) {
            let y: T[] = [];
            t.push(y);
            for (let j = 0; i < column; j++) y.push(x);
        }
    }

    public enlargeNumber(x: number[], size: number): void {
        this.enlarge<number>(x, 0, size);
    }

    public enlargeNumber2(x: number[][], row: number, column: number): void {
        this.enlarge2<number>(x, 0, row, column);
    }

    public copyArray<T>(f: T[], t: T[]): void
    {
        let i = 0;
        for (i = 0; i < f.length; i++)
        {
            t.push(f[i]);
        }
    }

    public setAliasType(name: string, value: any, map: Map<string, any>, names: string[]): boolean {
        if (map.has(name)) {
            return false;
        }
        names.push(name);
        if (typeof value === 'number') {
            map.set(name, this.a);
        }
        if (typeof value === 'boolean') {
            map.set(name, this.b);
        }
        if (typeof value === 'string') {
            map.set(name, this.s);
        }
        return true;
    }

    public SetAliasMap(map: Map<string, any>, alias: IAlias): void
    {
        for (const key in map.keys())
        {
            alias.setAliasValue(key, map.get(key));
        }
    }

    public copyMap<T, S>(s: Map<T, S>, t: Map<T, S>): void
    {
        for (const [key, value] of s) {
            t.set(key, value);
        }
    }
}