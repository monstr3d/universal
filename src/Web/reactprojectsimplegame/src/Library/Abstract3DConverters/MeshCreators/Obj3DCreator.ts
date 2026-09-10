import type { IFactory } from "../../Interfaces/IFactory";
import type { IMtlDetector } from "../Interfaces/IMtlDetector"
import type { IEffectDitionary } from "../Interfaces/IEffectDitionary";
import type { IMaterialCreator } from "../Interfaces/IMaterialCreator";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import type { IMesh } from "../Interfaces/IMesh";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import { Converter3DPefrormer } from "../Converter3DPerformer";
import { Performer } from "../../Performer";
import { ColorTexture } from "../ColorTexture";
import { EffectTexture } from "../EffectTexture";
import { ImageTexture } from "../ImageTexture";
import { DiffuseMaterial } from "../Materials/DiffuseMaterial";
import { MaterialGroup } from "../Materials/MaterialGroup";
import { LinesMeshCreator } from "./LinesMeshCreator";
import { EmissiveMaterial } from "../Materials/EmissiveMaterial";
import { Material } from "../Materials/Material";
import { PhongMaterial } from "../Materials/PhongMaterial";
import { SpecularMaterial } from "../Materials/SpecularMaterial";
import { AbstractMeshObj } from "../Meshes/AbstractMeshObj";
export class Obj3DCreator extends LinesMeshCreator
{
    constructor(url: string, name: string, directory: string, obj: any,
        factory: IFactory, func: ITextReaderFactory | undefined) {
        super(url, name, directory, obj, factory, func)
        if (this.iindexes == undefined) {
            this.iindexes = Obj3DCreator.siindexes
        }
        this.getIndexes()
    }

    public getIndexes(): ITextureIndex[][] {
        return this.iindexes
    }

    private pushIndex(index: ITextureIndex[]): void {
        if (this.iindexes == undefined) {
            this.iindexes = []
            Obj3DCreator.siindexes = this.iindexes
        }
        this.iindexes.push(index)
    }

    public getNames(): string[] {
        return this.names
    }

    loadLines(): void {
        this.materialLines = []
        this.effectsPrivate = new Map()
        this.usedMaterials = []
        this.name = ""
        this.createMaterials()
        this.createGeometry()
 }

    private iindexes !: ITextureIndex[][]

    private static siindexes : ITextureIndex[][]


    public getVertices(): number[][] {
        return this.vertices
    }
    public getTextures(): number[][] {
        return this.textures
    }
    public getNormals(): number[][] {
        return this.normals
    }

    public getDefaultEffect(): EffectTexture {
        return this.default
    }

    getMeshCreatorMeshes(): IMesh[] {

        if (this.meshes.length == 0) this.createMeshes()
        return this.meshes
    }

    createMeshes(): void {
        if (this.effectList.length == 0) {
            var m = new AbstractMeshObj(undefined, "", [], this.default, [], [], [], [], undefined, this, 0, 0)
            this.meshes.push(m)
            return
        }
        for (var i = 0; i < this.iindexes.length; i++) {
            var m = new AbstractMeshObj(undefined, "", [], this.default, [], [], [], [], undefined, this, 1, i)
            this.meshes.push(m)
        }

    }


    createMaterialsFromLUrl(url: string, eff: EffectTexture[]): Map<string, EffectTexture> {
        let lines = this.loadStrings(url)
        return this.createMaterialsFromLines(lines, eff);
    }

    getMeshName(): string {
        ++this.nm;
        return "Mesh_" + this.nm;
    }

    efff: EffectTexture[] = []

    createMaterialsFromLines(lines: string[], eff: EffectTexture[]): Map<string, EffectTexture> {
        this.efff = eff
        let mtl = new MtlWrapper(this.obj, "", this.factory, 0, lines, this.dict, "")
        let et: EffectTexture[] = []
        let mt = mtl.createFromLines(lines, 0, et)
        if (mt.has("Default")) {
            var def = mt.get("Default");
            if (def != undefined) {
                this.default = def
            }
        }
        for (let item of mt) {
            var key = item[0]
            if (key == "Default") {
                continue
            }
            if (!this.effectsPrivate.has(key)) {
                this.effectsPrivate.set(key, item[1])
            }

        }
        return mt

    }

    getMeshCreatorEffects(): Map<string, EffectTexture> {
        var eff = this.effectsPrivate;
        if (this.default == undefined) {
            return eff;
        }
        let e: Map<string, EffectTexture> = new Map();
        this.performer.copyMap(this.effectsPrivate, e)
        e.set("Default", this.default)
        return e;

    }

    createEffect(f: string): EffectTexture {
        var fd = this.toShiftString(f, "usemtl");
        var file = this.fileio.existsFile(fd);
        let image !: ImageTexture;
        var inm = "";
        if (file != null) {
            inm = this.path.getFileName(fd);
            image = new ImageTexture(inm, this.getMeshCreatorDirectory())
        }
        var ff: number[] = [1, 1, 1, 1]
        var d = new DiffuseMaterial("", new ColorTexture(ff), new ColorTexture(ff), 1)
        let mat = new MaterialGroup(f);
        mat.addChildT(d);
        return new EffectTexture(this.effectsPrivate, inm, mat, image);
    }

    createGeometry(): void {
        for (var line of this.lines) {
            if (line.startsWith("usemtl")) {
                this.createNamedGeometry()
                return
            }
        }
        if (this.effectList.length == 0 && this.default != undefined) {
            this.createDefaultGeometry();
            return;
        }
        this.createUnNamedGeometry();
    }

    mttt: Map<string, EffectTexture> = new Map()

    createMaterials(): void {
        try {
            let eff: EffectTexture[] = []
            let mt: Map<string, EffectTexture> = new Map()
            this.mttt = mt
            if (this.materialLines.length > 0) {
                mt = this.createMaterialsFromLines(this.materialLines, eff)
                if (eff.length > 0) this.default = eff[0]
            }
            else {
                for (var line of this.lines) {
                    if (line.indexOf("mtllib ") == 0) {
                        var file = line.substring("mtllib ".length).trim();
                        mt = this.createMaterialsFromLUrl(file, eff)
                        if (eff.length > 0) this.default = eff[0]
                    }
                }
                if (this.effectsPrivate.size == 0 && this.default == undefined) {
                    for (let l of this.lines) {
                        let p = this.toShiftString(l, "usemtl")
                        if (p.length > 0) this.createEffect(p)
                    }
                }
                if (this.effectsPrivate.has("_default_")) {
                    let def = this.effectsPrivate.get("_default_")
                    if (def != undefined) {
                        this.default = def
                    }
                }
            }
            if (this.default == undefined && this.effectList.length == 0) {
                let file: string = ""
                let files = this.directoryio.getDirectoryFiles(this.directory)
                for (var f of files) {
                    if (this.path.getFileExtension(f) == ".mtl") {
                        this.createMaterialsFromLUrl(f, eff)
                        if (eff.length > 0) this.default = eff[0]
                        break;
                    }
                }
                if (file.length >= 0) {
                    if (this.detectImage(file)) {
                        this.default = this.createEffectFromImage(file);
                    }
                }
            }

        }
        catch (e) {
        }
    }

    createEffectFromImage(f: string): EffectTexture {
        let image = new ImageTexture(f, this.getMeshCreatorDirectory());
        let ff: number[] = [1, 1, 1, 1]
        let d = new DiffuseMaterial("", new ColorTexture(ff), new ColorTexture(ff), 1);
        let mat = new MaterialGroup(f);
        mat.addChildT(d);
        return new EffectTexture(this.dict, f, mat, image);
    }

    detect(st: string): EffectTexture | undefined {
        if (this.effectsPrivate.has(st)) {
            let es = this.effectsPrivate.get(st);
            if (es != undefined) return es
        }
        var s = st.replaceAll("_", " ");
        if (this.effectsPrivate.has(s)) {
            let es = this.effectsPrivate.get(st);
            if (es != undefined) return es
        }
        for (var ee of this.effectsPrivate) {
            var fn = this.path.getFileNameWithoutExtension(ee[0]);
            if (fn == st) {
                return ee[1];
            }
        }
        return undefined;
    }



    getInitial(line: string): string | undefined {
        this.toShiftString(line, this.objs);
        if (line.indexOf("usemtl ") == 0) {
            var mat = line.substring("usemtl ".length);
            var effect = this.detect(mat);
            if (effect != undefined) this.effectList.push(effect);
            if (!this.usedMaterials.includes(mat)) {
                this.usedMaterials.push(mat);
            }
            return this.getMeshName();
        }
        return undefined

    }

    createDefaultGeometry(): void {
        try {
            var effect = this.default;
            let indexes: ITextureIndex[] = []
            this.pushIndex(indexes);
            this.tuple = { effect: effect, indx: [] }
            indexes.push(this.tuple)
            for (var line of this.lines) {
                if (line.startsWith("v ")) {
                    var f = this.toRealArray(line.substring("v ".length).trim());
                    this.vertices.push(f)
                    continue;
                }
                if (line.startsWith("vt ")) {
                    var f = this.toRealArray(line.substring("vt ".length).trim());
                    this.addTexture(this.textures, f);
                    continue;
                }
                if (line.startsWith("vn ")) {
                    var f = this.toRealArray(line.substring("vn ".length).trim());
                    this.normals.push(f);
                    continue;
                }
                if (line.startsWith("f ")) {
                    var s = line.substring("f ".length).trim();
                    var ss = s.split(" ");
                    if (ss.length != 3) {

                    }
                    let ind: number[][] = []
                    for (var i = 0; i < ss.length; i++) ind.push([])
                    for (var j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/")
                        var ii = [-1, -1, -1]
                        ind[j] = ii;
                        //var k =  new int[sss.Length];
                        for (var m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                ii[m] = -1;
                            }
                            else {
                                ii[m] = this.performer.toNumber(sss[m]) - 1;// Shifts[m];
                            }
                        }
                    }
                    this.tuple.indx.push(ind);
                    continue;
                }

            }
        }
        catch (e) {
        }
    }

    createNamedGeometry(): void {
        // GetName = GetInititial;
        try {
            let indexes: ITextureIndex[] = []
            for (let k = 0; k < this.lines.length; k++) {
                var line = this.lines[k];
                var name = this.getInitial(line);
                if (name != undefined) {
                    if (name != this.fiction) {
                        this.names.push(name);
                        indexes = [];
                        this.pushIndex(indexes);
                        if (line.indexOf("usemtl ") == 0) {
                            var mat = line.substring("usemtl ".length);
                            if (mat == "_default_") {
                                continue;
                            }
                            var effect = this.detect(mat);
                            if (effect != undefined) {
                                this.effectList.push(effect);
                            }
                            if (!this.usedMaterials.includes(mat)) {
                                this.usedMaterials.push(mat);
                            }
                            if (effect != undefined) {
                                this.tuple = { effect: effect, indx: [] }
                            }
                            this.pushIndex([this.tuple]);
                            continue;
                        }
                        continue;
                    }
                    else {
                    }
                }
                if (line.indexOf("usemtl ") == 0) {
                    var mat = line.substring("usemtl ".length);
                    if (mat == "_default_") {
                        continue;
                    }
                    var effect = this.effectsPrivate.get(mat);
                    if (effect != undefined) this.effectList.push(effect);
                    if (!this.usedMaterials.includes(mat)) {
                        this.usedMaterials.push(mat);
                    }
                    if (effect != undefined) {
                        this.tuple = { effect: effect, indx: [] }
                    }
                    this.pushIndex([this.tuple]);
                    continue;
                }

                if (line.indexOf("v ") == 0) {
                    var f = this.toRealArray(line.substring("v ".length).trim());
                    this.vertices.push(f)
                    continue;
                }
                if (line.indexOf("vt ") == 0) {
                    var f = this.toRealArray(line.substring("vt ".length).trim());
                    this.addTexture(this.textures, f);
                    continue;
                }
                if (line.indexOf("vn ") == 0) {
                    var f = this.toRealArray(line.substring("vn ".length).trim());
                    this.normals.push(f);
                    continue;
                }
                if (line.indexOf("f ") == 0) {
                    var s = line.substring("f ".length).trim();
                    var ss = s.split(" ");
                    var ind: number[][] = []
                    for (let i = 0; i < ss.length; i++) ind.push([])
                    for (let j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/");
                        var i: number[] = [-1, -1, -1]
                        ind[j] = i;
                        //var k =  new int[sss.Length];
                        for (let m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                i[m] = -1;
                            }
                            else {
                                i[m] = this.performer.convert<string, number>(sss[m]) - 1;// Shifts[m];
                            }
                        }
                    }
                    this.tuple.indx.push(ind);
                    continue;
                }
            }
        }
        catch (e) {

        }
    }

    createUnNamedGeometry(): void {
        try {
            let effect = this.getDefaultEffect();
            let indexes: ITextureIndex[] = []
            this.pushIndex(indexes);

            for (var line of this.lines) {
                if (line.startsWith("usemtl")) {
                    var mat = line.substring("usemtl ".length);
                    if (mat != undefined) {
                        if (mat == "_default_") {
                            continue;
                        }
                        let eff = this.detect(mat);
                        if (eff != undefined) {
                            effect = eff
                        }
                        if (!this.usedMaterials.includes(mat)) {
                            this.usedMaterials.push(mat);
                        }
                        if (effect != undefined) this.tuple = { effect: effect, indx: [] }
                        this.pushIndex([this.tuple]);
                        continue;
                    }
                }
                if (this.tuple === undefined) {
                    this.tuple = {
                        effect: effect, indx: []
                    }
                    indexes.push(this.tuple)
                }


                if (line.indexOf("v ") == 0) {
                    var f = this.toRealArray(line.substring("v ".length).trim());
                    this.vertices.push(f);
                    continue;
                }
                if (line.indexOf("vt ") == 0) {
                    var f = this.toRealArray(line.substring("vt ".length).trim());
                    this.addTexture(this.textures, f);
                    continue;
                }
                if (line.indexOf("vn ") == 0) {
                    var f = this.toRealArray(line.substring("vn ".length).trim());
                    this.normals.push(f);
                    continue;
                }
                if (line.indexOf("f ") == 0) {
                    var s = line.substring("f ".length).trim();
                    var ss = s.split(" ");
                    var ind: number[][] = []
                    for (var ii = 0; ii < ss.length; ii++) {
                        var a: number[] = []
                        ind.push(a)
                    }
                    for (var j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/");
                        var i: number[] = [-1, -1, -1]
                        ind[j] = i;
                        //var k =  new int[sss.Length];
                        for (var m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                i[m] = -1;
                            }
                            else {
                                i[m] = this.performer.toNumber(sss[m]) - 1;// Shifts[m];
                            }
                        }
                    }
                    this.tuple.indx.push(ind);
                    continue;
                }

            }
        }
        catch (e) {
        }
    }

    effectsPrivate !: Map<string, EffectTexture>
    ka !: ImageTexture
    kd !: ImageTexture
    ks !: ImageTexture

    ambient !: ColorTexture
    emissive !: ColorTexture
    specular !: ColorTexture

    ns: number = 0
    ni: number = 0
    d: number = 0
    illum: number = 0

    effect !: EffectTexture

    default !: EffectTexture

    nm: number = 0

    usedMaterials !: string[]

    objs: string = "# object "

    fiction: string = "rrg5dvmg.bil";

    names : string[] = []


    tuple !: ITextureIndex

    mtlDetetctor !: IMtlDetector


    materialLines !: string[];

    mtll: string = "mtllib "



}

class MtlWrapper implements IEffectDitionary {
    effects: Map<string, EffectTexture> = new Map();
    name: string = "";
    obj: any;
    factory!: IFactory;
    lines: string[] = [];
    directory: string = "";
    dict: Map<string, EffectTexture> = new Map();
    ka!: ImageTexture;
    kd!: ImageTexture;
    ks!: ImageTexture;

    ambient!: ColorTexture;
    emissive!: ColorTexture;
    specular!: ColorTexture;
    diffuse!: ColorTexture;

    ns: number = 0;
    ni: number = 0;
    d: number = 0;
    illum: number = 0;

    effect!: EffectTexture;

    default!: EffectTexture;

    cPerformer: Converter3DPefrormer = new Converter3DPefrormer()

    performer: Performer = new Performer()

    newName: string = ""

    eeef: Map<string, EffectTexture> = new Map()
    constructor(obj: any, name: string, factory: IFactory, start: number, lines: string[], effects: Map<string, EffectTexture>,
        directory: string) {
        this.eeef = effects
        this.name = name;
        this.factory = factory;
        this.obj = obj;
        this.lines = lines;
        this.directory = directory;
        var i = start;
        var list: string[] = []
        for (; i < lines.length; i++) {
            var line = lines[i];
            if (line == undefined) {
                break;
            }
            if (line.length == 0) {
                continue;
            }
            list.push(line);
            if (line.startsWith("newmtl")) {
                var ss = line.split(" ")
                this.newName = ss[ss.length - 1];
                break;
            }

        }
        if (list.length == 0) {
            return;
        }

        this.finalize(list, this.directory);
        this.createEmpty();
        var mat = this.effect;
        if (mat != undefined) {
            this.effects.set(this.newName, this.effect)
        }

        if (i + 1 < lines.length) {
            new MtlWrapper(this.obj, this.newName, this.factory, i + 1, this.lines, this.effects, this.directory);
        }

    }
    /* string str, int start, List<string> lines,
    Dictionary<string, Effect> effects, string directory*/
    getEffectDictionary(): Map<string, EffectTexture> {
        return this.effects;
    }
    public сreateFromMaterials(keyValuePairs: Map<string, Material>,
        creator: IMaterialCreator): Map<string, any> {
        let d: Map<string, any> = new Map();
        for (var pair of keyValuePairs.entries()) {
            let mat = pair[1];
            var v = creator.createFromMaterial(mat);
            d.set(pair[0], v);
        }
        return d;
    }

    createFromLines(lines: string[], start: number, defaultEffect: EffectTexture[]): Map<string, EffectTexture> {
        if (defaultEffect.length > 0) {
            defaultEffect.pop();
        }
        var name = "";
        var i = start;
        for (; i < lines.length; i++) {
            var line = lines[i];
            if (line.startsWith("newmtl")) {
                var ss = line.split(" ");
                name = ss[ss.length - 1];
                break;
            }

        }
        var mt = new MtlWrapper(this.obj, name, this.factory, i, this.lines, this.dict, this.directory);
        var eff = mt.getEffectDictionary();
        return eff;

    }

    createEmpty(): void {
        if (this.effect != undefined) {
            return;
        }
        if (this.diffuse == undefined) {
            this.diffuse = new ColorTexture([1, 1, 1]);
        }
        let mat = new PhongMaterial(this.name);
        if (this.diffuse != undefined) {
            if (this.ambient == undefined) {
                this.ambient = new ColorTexture([1, 1, 1]);
            }
            var diff = new DiffuseMaterial("", this.diffuse, this.ambient, this.d);
            //diffuse.Texture = Kd;
            mat.addChildT(diff);
        }
        if (this.emissive == undefined) {
            this.emissive = new ColorTexture([1, 1, 1])
        }
        if (this.emissive != undefined) {
            var emis = new EmissiveMaterial("", this.emissive, this.ka)
            mat.addChildT(emis);
        }
        if (this.specular != null) {
            var spec = new SpecularMaterial("", this.specular, this.ns);
            mat.addChildT(spec);
        }
        let dn: Map<string, EffectTexture> = new Map()
        this.effect = new EffectTexture(dn, this.name, mat as Material, this.kd)

    }

    public getEffect(): EffectTexture {
        this.createEmpty()
        return this.effect
    }

    protected toFloat(s: string): number {
        return this.performer.convert<string, number>(s)
    }


    finalize(list: string[], directory: string) {
        for (let s of list) {
            if (s.length == 0) {
                continue;
            }
            var t = s.trim();
            var n = t.indexOf(" ");
            var name = t.substring(0, n);
            var value = t.substring(n + 1);
            switch (name) {
                /// The ambient color of the material is declared using Ka. Color definitions are in RGB where each channel's 
                /// value is between 0 and 1.

                case "Ka":
                    this.ambient = this.cPerformer.stringToColor(value, false)
                    break;
                case "Kd":
                    //  Similarly, the diffuse color is declared using Kd.
                    this.diffuse = this.cPerformer.stringToColor(value, false)
                    break;
                case "Ks":
                    //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                    this.specular = this.cPerformer.stringToColor(value, false)
                    break;
                case "Ke":
                    //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                    this.emissive = this.cPerformer.stringToColor(value, false)
                    break;

                // the ambient texture map
                case "map_Ka":
                    this.ka = new ImageTexture(value, directory);
                    break;
                // the diffuse texture map 
                case "map_Kd":
                    this.kd = new ImageTexture(value, directory);
                    break;

                //# specular color texture map
                case "map_Ks":
                    this.ks = new ImageTexture(value, directory);
                    break;
                case "Ns":
                    /// Specular exponent ranges between 0 and 1000                        Ns 10.000            
                    this.ns = this.toFloat(value);
                    break;
                case "Ni":
                    // # optical density Values can range from 0.001 to 10
                    this.ni = this.toFloat(value);
                    break;
                case "d":
                    // some implementations use 'd' d 0.9 # others use 'Tr' (inverted: Tr = 1 - d) Tr 0.1
                    this.d = this.toFloat(value);
                    break;
                case "Tr":
                    this.d = 1 - this.toFloat(value);
                    break;
                //            illumination model
                case "illum":
                    this.illum = this.toFloat(value);
                    break;
                default:
                    break;

            }
        }

    }
}



