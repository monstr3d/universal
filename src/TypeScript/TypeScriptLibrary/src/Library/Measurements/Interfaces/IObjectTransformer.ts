/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
export interface IObjectTransformer
{
    getInput(): string[];
    getOutput(): string[];
    getInputType(i: number): any;
    getOutputType(i: number): any;

    calculate(input: any[], output: any[]): void;


}