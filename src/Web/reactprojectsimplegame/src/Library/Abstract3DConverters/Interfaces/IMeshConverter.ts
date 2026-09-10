import type { IMaterialCreator } from "./IMaterialCreator";
import { EffectTexture } from "../EffectTexture";
import type { IMesh } from "./IMesh";

export interface IMeshConverter {        /// <summary>

    getMeshCoverterDirectory(): string

    getMeshCoverterMaterialCreator(): IMaterialCreator

    getMeshCoverterFffects(): Map<string, EffectTexture>
    /// <summary>
    /// Creates a mesh object from the mesh
    /// </summary>
    /// <param name="mesh">The mesh</param>
    /// <returns>The mesh object</returns>
    createFromMesh(mesh: IMesh): any

    /// <summary>
    /// Sets effect to a mesh
    /// </summary>
    /// <param name="mesh">The mesh</param>
    /// <param name="effect">The material</param>
    setEffectToMesh(mesh: any, effect: any): void

    /// <summary>
    /// Adds child mesh
    /// </summary>
    /// <param name="parent">The parent mesh</param>
    /// <param name="child">The child mesh</param>
    addParentMesh(parent: any, child: any): void

    /// <summary>
    /// Combines mashes
    /// </summary>
    /// <param name="meshes">The meshes</param>
    /// <returns>The combination result</returns>
    combineMeshes(meshes: any[]): void

    /// <summary>
    /// Sets transformation matrix to the mesh
    /// </summary>
    /// <param name="mesh">The mesh</param>
    /// <param name="transformation">The transformation matrix</param>
    setMeshTransformation(mesh: any, transformation: number[]): void

    getMeshFilename(): string


}