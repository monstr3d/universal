import { OwnError } from "./ErrorHandler/OwnError";
import { IAlias } from "./Interfaces/IAlias";
import { IObject } from "./Interfaces/IObject";
import { IDataConsumer } from "./Measurements/Interfaces/IDataConsumer";
import { IMeasurement } from "./Measurements/Interfaces/IMeasurement";

export class Performer
{
    protected a: number = 0;


    protected b: boolean = false;

    protected s: string = "";

    public select<T>(objects: IObject[], type: string): T[] {

        let t: T[] = [];
        for (var i = 0; i < objects.length; i++)
        {
            let o = objects[i];
            if (o.imlplementsType(type))
            {
                t.push(o as unknown as T);
            }
        }
        return t;
    }

 
    /*
     public getAnyTimeOperation(consumer: ITimeMeasurementConsumer): Operation<any> {
        var m = consumer.getTimeMeasutement();
        return () => { m.getOperation()(); }
    }

    public getNumberTimeOperation(consumer: ITimeMeasurementConsumer): Operation<number> {
        return () => {
            var m = consumer.getTimeMeasutement();
            var v = m.getOperation();
            var value = v();
            if (typeof value === 'number') {
                return value; 
            }
            return 0;
        }
    }*/

    public convertFromAny<T>(t: any): T
    {
        return this.convert<any, T>(t);
    }

 
    public convert<T, S>(t: T): S {
        // Typeof checks against string representations of types. S is a generic type,
        // so you can't directly use typeof S.  It will just return the string "object" or "function".

        // You need to find a way to determine the *actual* type S at runtime
        //  and compare it against the type of 't'.

        // A very limited approach would be to use type guards, but that means
        // you'd have to know what type S *could* be in advance. This is not
        // really a general solution.

        if (typeof t === "string" && (null as any as S) instanceof String) {  //VERY LIMITED AND UNSAFE EXAMPLE.
            return t as any as S; // Force the type assertion (VERY UNSAFE)
        }

        if (typeof t === "number") {// } && (t as unknown as S) instanceof Number) {  //VERY LIMITED AND UNSAFE EXAMPLE.
            return t as unknown as S; // Force the type assertion (VERY UNSAFE)
        }

        if (typeof t === "boolean" && (null as any as S) instanceof Boolean) {  //VERY LIMITED AND UNSAFE EXAMPLE.
            return t as any as S; // Force the type assertion (VERY UNSAFE)
        }

        //This is better, but assumes S is a string or number
        if (typeof t === 'string' && (null as any as S) as any === String) {
            return t as any as S;
        }

        if (typeof t === 'number' && (null as any as S) as any === Number) {
            return t as any as S;
        }

        throw new OwnError("Type conversion", "Performer", undefined);

        // In many cases, a direct conversion may not be possible
        // or may require a more complex transformation.
       // console.warn("Conversion not possible for types:", typeof t, S);
        return undefined as any as S; // Or throw an error, or return a default value.
    }


    public getMeasurement(i: number, j: number, dataConsumer: IDataConsumer): IMeasurement
    {
        return dataConsumer.getAllMeasurements()[i].getMeasurement(j);
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

    public setAliasMap(map: Map<string, any>, alias: IAlias): void
    {
        var keys = map.keys();
    /*    keys.foreach(
            key => alias.setAliasValue(key, map.get(key));
        );
        return;*/
        for (var key of keys)
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

    public implementsType(o: unknown, type: string): boolean {
        let obj: IObject = o as IObject;
        return obj.imlplementsType(type);
    }


}