/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IFeedbackAlias } from "./IFeedbackAlias";

export interface IFeedbackAliasCollection
{
    getFeedbackAliasCollectionMap(): Map<string, string>;

    getFeedbackAliasCollectionAliases(): IFeedbackAlias[];

    addFeedbackAliasCollectionAlias(alias: IFeedbackAlias): void;

    setFeedBackAliases(): void;

    fillFeedBackAliases(): void;

}