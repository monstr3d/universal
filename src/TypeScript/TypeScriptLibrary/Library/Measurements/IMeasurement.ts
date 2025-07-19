import { Operation } from "../Types/Operation";

export interface IMeasurement
{
    getName(): string;
    getType(): any;
    getOperation(): Operation<any>;
}