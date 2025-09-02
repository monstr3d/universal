import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { INormalizable } from "../Measurements/Interfaces/INormalizable";

export class FictiveNormalizable implements INormalizable
{
    normalize(): void
    {
        throw new OwnNotImplemented();
    }

}