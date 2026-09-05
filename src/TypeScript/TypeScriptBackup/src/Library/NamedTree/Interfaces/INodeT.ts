export interface INodeT<T> {

    getParentT(): INodeT<T> | undefined

    setParentT(parent: INodeT<T>): void

    getNodesT(): INodeT<T>[]

    addNodeT(node: INodeT<T>): void

    removeNodeT(node: INodeT<T>): void

    getNodeValueT() : T

}