/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IObjectTransformer } from "./IObjectTransformer";

export interface IObjectTransformerConsumer
{

    addTransformer(transformer: IObjectTransformer) : void
}