/* eslint-disable @typescript-eslint/no-unused-vars */
import { OwnError } from "./OwnError";

export class OwnNotImplemented extends OwnError
{
    constructor(m?: string | undefined)
    {
        super(m, "Method not implemented", undefined);
    };
}