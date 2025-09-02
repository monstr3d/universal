import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IObjectTransformer } from "../Measurements/Interfaces/IObjectTransformer";

export class FictiveObjectTransformer implements IObjectTransformer
{
    getInput(): string[] {
        throw new OwnNotImplemented();
    }
    getOutput(): string[] {
        throw new OwnNotImplemented();
    }
    getInputType(i: number) {
        throw new OwnNotImplemented();
    }
    getOutputType(i: number) {
        throw new OwnNotImplemented();
    }
    calculate(input: any[], output: any[]): void {
        throw new OwnNotImplemented();
    }

}