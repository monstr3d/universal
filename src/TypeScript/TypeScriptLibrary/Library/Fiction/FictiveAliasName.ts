import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IAlias } from "../Interfaces/IAlias";
import { IAliasName } from "../Interfaces/IAliasName";

export class FictiveAliasName implements IAliasName {
    getAliasNameValue() {
        throw new OwnNotImplemented();
    }
    setAliasNameValue(value: any): void {
        throw new OwnNotImplemented();
    }
    getAlias(): IAlias {
        throw new OwnNotImplemented();
    }
    getNameOfAliasName(): string {
        throw new OwnNotImplemented();
    }
}