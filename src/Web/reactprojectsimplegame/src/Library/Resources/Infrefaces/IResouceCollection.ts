import type { IResourceItem } from "./IResourceItem";

export interface IResourceCollection {
    getResources() : IResourceItem[]
}