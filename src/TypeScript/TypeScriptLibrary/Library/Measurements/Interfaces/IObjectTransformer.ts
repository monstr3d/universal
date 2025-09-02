export interface IObjectTransformer
{
    getInput(): string[];
    getOutput(): string[];
    getInputType(i: number): any;
    getOutputType(i: number): any;

    calculate(input: any[], output: any[]): void;


}