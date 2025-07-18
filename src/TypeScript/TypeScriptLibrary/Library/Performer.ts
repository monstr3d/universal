import { IAlias } from "./IAlias";

export class Performer {
    protected a: number = 0;


    protected b: boolean = false;

    protected s: string = "";


    enlarge<T>(t: T[], x: T, size: number): void {
        for (let i = 0; i < size; i++)  t.push(x);
    }

    enlarge2<T>(t: T[][], x: T, row: number, column: number): void {
        for (let i = 0; i < row; i++) {
            let y: T[] = [];
            t.push(y);
            for (let j = 0; i < column; j++) y.push(x);
        }
    }

    enlargeNumber(x: number[], size: number): void {
        this.enlarge<number>(x, 0, size);
    }

    enlargeNumber2(x: number[][], row: number, column: number): void {
        this.enlarge2<number>(x, 0, row, column);
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
}