export class RealMatrix {
    public normalize(inp: number[], outp: number[], offset: number): number{
        let a = 0;
        for (let i = offset; i < outp.length + offset; i++)
        {
            let b = inp[i];
            a += b * b;
        }
        a = Math.sqrt(a);
        let c = 1 / a;
        for (let i = 0; i < outp.length; i++)
        {
            outp[i] = c * inp[i + offset];
        }
        return a;
    }
}