class Performer {

    Enlarge<T>(t: T[], x: T, size: number): void
    {
        for (let i = 0; i < size; i++) { t.push(x); }
    }

    EnlargeNumber(x: number[], size: number): void
    {
        this.Enlarge<number>(x, 0, size);
    }
}