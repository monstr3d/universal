import { OwnError } from "./OwnError";

export class OwnNotImplemented extends OwnError {

    constructor() { super("", "Method not implemented", undefined) };
}