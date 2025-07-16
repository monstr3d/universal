class Performer
{

    enlarge<T>(t: T[], x: T, size: number): void {
        for (let i = 0; i < size; i++)  t.push(x); 
    }

    enlarge2<T>(t: T[][], x: T, row: number, column: number): void {
        for (let i = 0; i < row; i++)
        {
            let y: T[] = [];
            t.push(y);
            for (let j = 0; i < column; j++) y.push(x);
        }
    }

    enlargeNumber(x: number[], size: number): void
    {
        this.enlarge<number>(x, 0, size);
    }

    enlargeNumber2(x: number[][], row: number, column: number): void {
        this.enlarge2<number>(x, 0, row, column);
    }
}
