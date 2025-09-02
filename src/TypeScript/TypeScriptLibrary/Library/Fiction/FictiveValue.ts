import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IValue } from "../Interfaces/IValue";

export class FictiveValue implements IValue {
    getIValue() {
        throw new OwnNotImplemented();
    }
    setIValue(value: any): void {
        throw new OwnNotImplemented();
    }

}