import type { IFactory } from "../../Interfaces/IFactory";
import type { IFile } from "../../IO/Interfaces/IFile";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import type { IMesh } from "../Interfaces/IMesh";
import type { IMeshCreator } from "../Interfaces/IMeshCreator";
import type { IPath } from "../../IO/Interfaces/IPath";
import type { IIODirectory } from "../../IO/Interfaces/IIODirectory";
import type { IImageDetector } from "../Interfaces/IImageDetector";
import type { IStringSplitter } from "../../Utilities/String/Interfaces/IStringSplitter";
import { Performer } from "../../Performer";
import { Converter3DPefrormer } from "../Converter3DPerformer";
import { EffectTexture } from "../EffectTexture";
import { FactoryObject } from "../../FactoryObject";


export abstract class AbstractMeshCreator extends FactoryObject implements IMeshCreator {

    constructor(url: string, name: string, directory: string, obj: any, factory: IFactory) {
        super(name, factory)
        this.url = url
        this.directory = directory
        this.obj = obj
        this.types.push("IMeshCreator")
        this.types.push("AbstractMeshCreator")
        this.typeName = "AbstractMeshCreator"
    }
    getObjectUrl(): string {
        return this.url
    }
    setObjecttUrl(url: string): void {
        this.url = url
    }


    getMeshCreatorDirectory(): string {
        return this.directory
    }

    abstract loadMeshCreator(): void 

    getName(): string {
        return ""
    }

    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }


    getMeshCreatorURL(): string {
        return this.url;
    }


    getMeshCreatorMeshes(): IMesh[] {
        return this.meshes
    }

    getMeshCreatorEffects(): Map<string, EffectTexture> {
        return this.effects
    }

    getMeshCreatorFactory(): IFactory {
        return this.factory;
    }
    getMeshCreatorGenerator() {
        return this.obj;
    }


    protected detectImage(path: string): boolean {
        if (this.imageDetector === undefined) {
            return true
        }
        return this.imageDetector.detectImage(path)
    }

    protected existsFile(fileName: string) {
        return this.fileio.existsFile(fileName)
    }

    protected pathCombine(path1: string, path2: string): string {
        return this.path.pathCombine(path1, path2)
    }

    protected toStringT(object: any): string {
        return this.performer.convert<any, string>(object)
    }

    protected toShiftString(str: string, shift: string): string {
        return this.cPerformer.toShiftString(str, shift)
    }

    protected toReal(s: string): number {
        return this.performer.convert<string, number>(s)
    }

    protected toRealArray(str: string): number[]
    {
        return this.cPerformer.toRealArray(str)
    }

    protected addTexture(l: number[][], texture: number[]): void {
        this.cPerformer.addTexture(l, texture)
    }

    protected toFloat(s: string): number {
        return this.performer.convert<string, number>(s)
    }


    protected effects: Map<string, EffectTexture> = new Map()

    protected meshes: IMesh[] = []

    protected performer: Performer = new Performer()

    protected directory: string = ""

    protected dict: Map<string, EffectTexture> = new Map();

    protected directoryio !: IIODirectory

    protected url: string = "";

    protected obj: any

    protected typeName: string = "AbstractMeshCreator";

    protected types: string[] = ["IObject", "IMeshCreator", "AbstractMeshCreator"];

    protected name: string = ""

    protected textConverter !: IStringSplitter

    protected textReaderFactory !: ITextReaderFactory

    cPerformer: Converter3DPefrormer = new Converter3DPefrormer()

    protected fileio !: IFile

    protected path !: IPath

    protected effectList: EffectTexture[] = []

    protected imageDetector !: IImageDetector

    protected vertices: number[][] = []
    protected normals: number[][] = []
    protected textures: number[][] = []
}