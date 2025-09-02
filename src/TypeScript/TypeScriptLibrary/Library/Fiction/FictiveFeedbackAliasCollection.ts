import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IFeedbackAlias } from "../Interfaces/IFeedbackAlias";
import { IFeedbackAliasCollection } from "../Interfaces/IFeedbackAliasCollection";

export class FictiveFeedbackAliasCollection implements IFeedbackAliasCollection
{
    getFeedbackAliasCollectionMap(): Map<string, string> {
        throw new OwnNotImplemented();
    }
    getFeedbackAliasCollectionAliases(): IFeedbackAlias[] {
        throw new OwnNotImplemented();
    }
    addFeedbackAliasCollectionAlias(alias: IFeedbackAlias): void {
        throw new OwnNotImplemented();
    }
    setFeedBackAliases(): void {
        throw new OwnNotImplemented();
    }
    fillFeedBackAliases(): void {
        throw new OwnNotImplemented();
    }

}