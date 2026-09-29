import type { IVisible } from "../Visible/Interfaces/IVisible";

export interface IVisibleConsumer {

    addVisibleObject(object: IVisible): void;
    removeVisibleObject(object: IVisible): void;
    postVisibleObject(object: IVisible): void;
}