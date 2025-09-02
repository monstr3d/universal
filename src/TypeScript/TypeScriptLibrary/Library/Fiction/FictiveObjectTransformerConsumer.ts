import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IObjectTransformer } from "../Measurements/Interfaces/IObjectTransformer";
import { IObjectTransformerConsumer } from "../Measurements/Interfaces/IObjectTransformerConsumer";

export class FictiveObjectTransformerConsumer implements IObjectTransformerConsumer
{
    addTransformer(transformer: IObjectTransformer): void
    {
        throw new OwnNotImplemented();
    }

}