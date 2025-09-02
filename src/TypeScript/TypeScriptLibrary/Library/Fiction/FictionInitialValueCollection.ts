import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IInitialValue } from "../Interfaces/IInitialValue";
import { IInitialValueCollection } from "../Interfaces/IInitialValueCollection";

export class FictionInitialValueCollection implements IInitialValueCollection {
    getInitialValues(): IInitialValue[] {
        throw new OwnNotImplemented();
    }
    resetInitialValues(): void {
        throw new OwnNotImplemented();
    }
    addInitialValue(value: IInitialValue): void {
        throw new OwnNotImplemented();
    }

}