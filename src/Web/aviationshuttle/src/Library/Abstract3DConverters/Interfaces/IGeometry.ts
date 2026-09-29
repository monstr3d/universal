import type { IObject } from "../../Interfaces/IObject"
import type { INamed } from "../../NamedTree/Interfaces/INamed"

export interface IGeometry extends INamed, IObject {

    getVertices(): number[][]
    getNormals(): number[][]
    getTextures(): number[][]
    getTransformationMatrix(): number[]

}