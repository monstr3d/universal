import { ColorTexture } from "../ColorTexture";
import { ImageTexture } from "../ImageTexture";
import { DiffuseMaterial } from "../Materials/DiffuseMaterial";
import { EmissiveMaterial } from "../Materials/EmissiveMaterial";
import { Material } from "../Materials/Material";
import { MaterialGroup } from "../Materials/MaterialGroup";
import { SpecularMaterial } from "../Materials/SpecularMaterial";
export interface IMaterialCreator {
    createFromImage(obj: any, image: ImageTexture): any;
    createFromColor(obj: any, color: ColorTexture): any;
    createFromMaterialGroup(group: MaterialGroup): any;
    createFromDiffuseMaterial(material: DiffuseMaterial): any;
    createFromSpecularMaterial(material: SpecularMaterial): any;
    createFromEmissiveMaterial(material: EmissiveMaterial): any;
    createFromMaterial(material: Material): any;
    createFromEffect(effecty: Material): any;
    addMaterialToGroup(group: any, material: any): void;
    setImageToEffect(effect: any, image: any): void;
    setOpacityToEffect(effect: any, opacity: number): void;
}
//# sourceMappingURL=IMaterialCreator.d.ts.map