/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IFeedbackAliasCollection } from "./IFeedbackAliasCollection";

export interface IFeedbackAliasCollectionHolder
{
    getFeedbackAliasCollection(): IFeedbackAliasCollection;
}