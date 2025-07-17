import { IDesktop } from "../IDesktop";
import { Measurements } from "./Measurements";

export class RandomGenerator extends Measurements
{
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
    }
}