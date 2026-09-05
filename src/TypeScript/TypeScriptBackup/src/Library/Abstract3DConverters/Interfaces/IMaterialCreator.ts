import { ColorTexture } from "../ColorTexture";
import { ImageTexture } from "../ImageTexture";
import { DiffuseMaterial } from "../Materials/DiffuseMaterial";
import { EmissiveMaterial } from "../Materials/EmissiveMaterial";
import { Material } from "../Materials/Material";
import { MaterialGroup } from "../Materials/MaterialGroup";
import { SpecularMaterial } from "../Materials/SpecularMaterial";


export interface IMaterialCreator {
    /// <summary>
    /// Creates of the  image object
    /// </summary>
    /// <param name="image">The image</param>
    /// <returns>The image object</returns>
    createFromImage(obj: any, image: ImageTexture): any;


    /// <summary>
    /// Creates of the color object
    /// </summary>
    /// <param name="color">The color</param>
    /// <returns>The color object</returns>
    createFromColor(obj: any, color: ColorTexture): any;


    /// <summary>
    /// Creates of the material group object
    /// </summary>
    /// <param name="material">The material group</param>
    /// <returns>The  material group object</returns>
    createFromMaterialGroup(group: MaterialGroup): any

    createFromDiffuseMaterial(material: DiffuseMaterial): any

    createFromSpecularMaterial(material: SpecularMaterial): any

    createFromEmissiveMaterial(material: EmissiveMaterial): any

    createFromMaterial(material: Material): any

    createFromEffect(effecty: Material): any

    addMaterialToGroup(group: any, material: any): void


    setImageToEffect(effect: any, image: any): void

    setOpacityToEffect(effect: any, opacity: number): void

}
