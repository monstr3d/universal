import { IObjectTransformer } from "./IObjectTransformer";

export interface IObjectTransformerConsumer
{

    addTransformer(transformer: IObjectTransformer) : void
}