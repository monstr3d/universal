export interface IChildrenT<T> {
    getChildernT(): T[]

    /// <summary>
    /// Adds child
    /// </summary>
    /// <param name="child">The child to add</param>
    addChildT(child: T): void

    /// <summary>
    /// Remove child
    /// </summary>
    /// <param name="child"></param>
    removeChildT(child: T): void

}