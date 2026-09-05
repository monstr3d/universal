"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Obj3DCreator = void 0;
const Converter3DPerformer_1 = require("../Converter3DPerformer");
const Performer_1 = require("../../Performer");
const ColorTexture_1 = require("../ColorTexture");
const EffectTexture_1 = require("../EffectTexture");
const ImageTexture_1 = require("../ImageTexture");
const DiffuseMaterial_1 = require("../Materials/DiffuseMaterial");
const MaterialGroup_1 = require("../Materials/MaterialGroup");
const LinesMeshCreator_1 = require("./LinesMeshCreator");
const EmissiveMaterial_1 = require("../Materials/EmissiveMaterial");
const PhongMaterial_1 = require("../Materials/PhongMaterial");
const SpecularMaterial_1 = require("../Materials/SpecularMaterial");
const AbstractMeshObj_1 = require("../Meshes/AbstractMeshObj");
class Obj3DCreator extends LinesMeshCreator_1.LinesMeshCreator {
    constructor(url, name, directory, obj, factory, func) {
        super(url, name, directory, obj, factory, func);
        this.efff = [];
        this.mttt = new Map();
        this.ns = 0;
        this.ni = 0;
        this.d = 0;
        this.illum = 0;
        this.nm = 0;
        this.objs = "# object ";
        this.fiction = "rrg5dvmg.bil";
        this.names = [];
        this.mtll = "mtllib ";
        if (this.iindexes == undefined) {
            this.iindexes = Obj3DCreator.siindexes;
        }
        this.getIndexes();
    }
    getIndexes() {
        return this.iindexes;
    }
    pushIndex(index) {
        if (this.iindexes == undefined) {
            this.iindexes = [];
            Obj3DCreator.siindexes = this.iindexes;
        }
        this.iindexes.push(index);
    }
    getNames() {
        return this.names;
    }
    loadLines() {
        this.materialLines = [];
        this.effectsPrivate = new Map();
        this.usedMaterials = [];
        this.name = "";
        this.createMaterials();
        this.createGeometry();
    }
    getVertices() {
        return this.vertices;
    }
    getTextures() {
        return this.textures;
    }
    getNormals() {
        return this.normals;
    }
    getDefaultEffect() {
        return this.default;
    }
    getMeshCreatorMeshes() {
        if (this.meshes.length == 0)
            this.createMeshes();
        return this.meshes;
    }
    createMeshes() {
        if (this.effectList.length == 0) {
            var m = new AbstractMeshObj_1.AbstractMeshObj(undefined, "", [], this.default, [], [], [], [], undefined, this, 0, 0);
            this.meshes.push(m);
            return;
        }
        for (var i = 0; i < this.iindexes.length; i++) {
            var m = new AbstractMeshObj_1.AbstractMeshObj(undefined, "", [], this.default, [], [], [], [], undefined, this, 1, i);
            this.meshes.push(m);
        }
    }
    createMaterialsFromLUrl(url, eff) {
        let lines = this.loadStrings(url);
        return this.createMaterialsFromLines(lines, eff);
    }
    getMeshName() {
        ++this.nm;
        return "Mesh_" + this.nm;
    }
    createMaterialsFromLines(lines, eff) {
        this.efff = eff;
        let mtl = new MtlWrapper(this.obj, "", this.factory, 0, lines, this.dict, "");
        let et = [];
        let mt = mtl.createFromLines(lines, 0, et);
        if (mt.has("Default")) {
            var def = mt.get("Default");
            if (def != undefined) {
                this.default = def;
            }
        }
        for (let item of mt) {
            var key = item[0];
            if (key == "Default") {
                continue;
            }
            if (!this.effectsPrivate.has(key)) {
                this.effectsPrivate.set(key, item[1]);
            }
        }
        return mt;
    }
    getMeshCreatorEffects() {
        var eff = this.effectsPrivate;
        if (this.default == undefined) {
            return eff;
        }
        let e = new Map();
        this.performer.copyMap(this.effectsPrivate, e);
        e.set("Default", this.default);
        return e;
    }
    createEffect(f) {
        var fd = this.toShiftString(f, "usemtl");
        var file = this.fileio.existsFile(fd);
        let image;
        var inm = "";
        if (file != null) {
            inm = this.path.getFileName(fd);
            image = new ImageTexture_1.ImageTexture(inm, this.getMeshCreatorDirectory());
        }
        var ff = [1, 1, 1, 1];
        var d = new DiffuseMaterial_1.DiffuseMaterial("", new ColorTexture_1.ColorTexture(ff), new ColorTexture_1.ColorTexture(ff), 1);
        let mat = new MaterialGroup_1.MaterialGroup(f);
        mat.addChildT(d);
        return new EffectTexture_1.EffectTexture(this.effectsPrivate, inm, mat, image);
    }
    createGeometry() {
        for (var line of this.lines) {
            if (line.startsWith("usemtl")) {
                this.createNamedGeometry();
                return;
            }
        }
        if (this.effectList.length == 0 && this.default != undefined) {
            this.createDefaultGeometry();
            return;
        }
        this.createUnNamedGeometry();
    }
    createMaterials() {
        try {
            let eff = [];
            let mt = new Map();
            this.mttt = mt;
            if (this.materialLines.length > 0) {
                mt = this.createMaterialsFromLines(this.materialLines, eff);
                if (eff.length > 0)
                    this.default = eff[0];
            }
            else {
                for (var line of this.lines) {
                    if (line.indexOf("mtllib ") == 0) {
                        var file = line.substring("mtllib ".length).trim();
                        mt = this.createMaterialsFromLUrl(file, eff);
                        if (eff.length > 0)
                            this.default = eff[0];
                    }
                }
                if (this.effectsPrivate.size == 0 && this.default == undefined) {
                    for (let l of this.lines) {
                        let p = this.toShiftString(l, "usemtl");
                        if (p.length > 0)
                            this.createEffect(p);
                    }
                }
                if (this.effectsPrivate.has("_default_")) {
                    let def = this.effectsPrivate.get("_default_");
                    if (def != undefined) {
                        this.default = def;
                    }
                }
            }
            if (this.default == undefined && this.effectList.length == 0) {
                let file = "";
                let files = this.directoryio.getDirectoryFiles(this.directory);
                for (var f of files) {
                    if (this.path.getFileExtension(f) == ".mtl") {
                        this.createMaterialsFromLUrl(f, eff);
                        if (eff.length > 0)
                            this.default = eff[0];
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
    createEffectFromImage(f) {
        let image = new ImageTexture_1.ImageTexture(f, this.getMeshCreatorDirectory());
        let ff = [1, 1, 1, 1];
        let d = new DiffuseMaterial_1.DiffuseMaterial("", new ColorTexture_1.ColorTexture(ff), new ColorTexture_1.ColorTexture(ff), 1);
        let mat = new MaterialGroup_1.MaterialGroup(f);
        mat.addChildT(d);
        return new EffectTexture_1.EffectTexture(this.dict, f, mat, image);
    }
    detect(st) {
        if (this.effectsPrivate.has(st)) {
            let es = this.effectsPrivate.get(st);
            if (es != undefined)
                return es;
        }
        var s = st.replaceAll("_", " ");
        if (this.effectsPrivate.has(s)) {
            let es = this.effectsPrivate.get(st);
            if (es != undefined)
                return es;
        }
        for (var ee of this.effectsPrivate) {
            var fn = this.path.getFileNameWithoutExtension(ee[0]);
            if (fn == st) {
                return ee[1];
            }
        }
        return undefined;
    }
    getInitial(line) {
        this.toShiftString(line, this.objs);
        if (line.indexOf("usemtl ") == 0) {
            var mat = line.substring("usemtl ".length);
            var effect = this.detect(mat);
            if (effect != undefined)
                this.effectList.push(effect);
            if (!this.usedMaterials.includes(mat)) {
                this.usedMaterials.push(mat);
            }
            return this.getMeshName();
        }
        return undefined;
    }
    createDefaultGeometry() {
        try {
            var effect = this.default;
            let indexes = [];
            this.pushIndex(indexes);
            this.tuple = { effect: effect, indx: [] };
            indexes.push(this.tuple);
            for (var line of this.lines) {
                if (line.startsWith("v ")) {
                    var f = this.toRealArray(line.substring("v ".length).trim());
                    this.vertices.push(f);
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
                    let ind = [];
                    for (var i = 0; i < ss.length; i++)
                        ind.push([]);
                    for (var j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/");
                        var ii = [-1, -1, -1];
                        ind[j] = ii;
                        //var k =  new int[sss.Length];
                        for (var m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                ii[m] = -1;
                            }
                            else {
                                ii[m] = this.performer.toNumber(sss[m]) - 1; // Shifts[m];
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
    createNamedGeometry() {
        // GetName = GetInititial;
        try {
            let indexes = [];
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
                                this.tuple = { effect: effect, indx: [] };
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
                    if (effect != undefined)
                        this.effectList.push(effect);
                    if (!this.usedMaterials.includes(mat)) {
                        this.usedMaterials.push(mat);
                    }
                    if (effect != undefined) {
                        this.tuple = { effect: effect, indx: [] };
                    }
                    this.pushIndex([this.tuple]);
                    continue;
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
                    var ind = [];
                    for (let i = 0; i < ss.length; i++)
                        ind.push([]);
                    for (let j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/");
                        var i = [-1, -1, -1];
                        ind[j] = i;
                        //var k =  new int[sss.Length];
                        for (let m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                i[m] = -1;
                            }
                            else {
                                i[m] = this.performer.convert(sss[m]) - 1; // Shifts[m];
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
    createUnNamedGeometry() {
        try {
            let effect = this.getDefaultEffect();
            let indexes = [];
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
                            effect = eff;
                        }
                        if (!this.usedMaterials.includes(mat)) {
                            this.usedMaterials.push(mat);
                        }
                        if (effect != undefined)
                            this.tuple = { effect: effect, indx: [] };
                        this.pushIndex([this.tuple]);
                        continue;
                    }
                }
                if (this.tuple === undefined) {
                    this.tuple = {
                        effect: effect, indx: []
                    };
                    indexes.push(this.tuple);
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
                    var ind = [];
                    for (var ii = 0; ii < ss.length; ii++) {
                        var a = [];
                        ind.push(a);
                    }
                    for (var j = 0; j < ss.length; j++) {
                        var sss = ss[j].split("/");
                        var i = [-1, -1, -1];
                        ind[j] = i;
                        //var k =  new int[sss.Length];
                        for (var m = 0; m < sss.length; m++) {
                            if (sss[m].length == 0) {
                                i[m] = -1;
                            }
                            else {
                                i[m] = this.performer.toNumber(sss[m]) - 1; // Shifts[m];
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
}
exports.Obj3DCreator = Obj3DCreator;
class MtlWrapper {
    constructor(obj, name, factory, start, lines, effects, directory) {
        this.effects = new Map();
        this.name = "";
        this.lines = [];
        this.directory = "";
        this.dict = new Map();
        this.ns = 0;
        this.ni = 0;
        this.d = 0;
        this.illum = 0;
        this.cPerformer = new Converter3DPerformer_1.Converter3DPefrormer();
        this.performer = new Performer_1.Performer();
        this.newName = "";
        this.eeef = new Map();
        this.eeef = effects;
        this.name = name;
        this.factory = factory;
        this.obj = obj;
        this.lines = lines;
        this.directory = directory;
        var i = start;
        var list = [];
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
                var ss = line.split(" ");
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
            this.effects.set(this.newName, this.effect);
        }
        if (i + 1 < lines.length) {
            new MtlWrapper(this.obj, this.newName, this.factory, i + 1, this.lines, this.effects, this.directory);
        }
    }
    /* string str, int start, List<string> lines,
    Dictionary<string, Effect> effects, string directory*/
    getEffectDictionary() {
        return this.effects;
    }
    сreateFromMaterials(keyValuePairs, creator) {
        let d = new Map();
        for (var pair of keyValuePairs.entries()) {
            let mat = pair[1];
            var v = creator.createFromMaterial(mat);
            d.set(pair[0], v);
        }
        return d;
    }
    createFromLines(lines, start, defaultEffect) {
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
    createEmpty() {
        if (this.effect != undefined) {
            return;
        }
        if (this.diffuse == undefined) {
            this.diffuse = new ColorTexture_1.ColorTexture([1, 1, 1]);
        }
        let mat = new PhongMaterial_1.PhongMaterial(this.name);
        if (this.diffuse != undefined) {
            if (this.ambient == undefined) {
                this.ambient = new ColorTexture_1.ColorTexture([1, 1, 1]);
            }
            var diff = new DiffuseMaterial_1.DiffuseMaterial("", this.diffuse, this.ambient, this.d);
            //diffuse.Texture = Kd;
            mat.addChildT(diff);
        }
        if (this.emissive == undefined) {
            this.emissive = new ColorTexture_1.ColorTexture([1, 1, 1]);
        }
        if (this.emissive != undefined) {
            var emis = new EmissiveMaterial_1.EmissiveMaterial("", this.emissive, this.ka);
            mat.addChildT(emis);
        }
        if (this.specular != null) {
            var spec = new SpecularMaterial_1.SpecularMaterial("", this.specular, this.ns);
            mat.addChildT(spec);
        }
        let dn = new Map();
        this.effect = new EffectTexture_1.EffectTexture(dn, this.name, mat, this.kd);
    }
    getEffect() {
        this.createEmpty();
        return this.effect;
    }
    toFloat(s) {
        return this.performer.convert(s);
    }
    finalize(list, directory) {
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
                    this.ambient = this.cPerformer.stringToColor(value, false);
                    break;
                case "Kd":
                    //  Similarly, the diffuse color is declared using Kd.
                    this.diffuse = this.cPerformer.stringToColor(value, false);
                    break;
                case "Ks":
                    //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                    this.specular = this.cPerformer.stringToColor(value, false);
                    break;
                case "Ke":
                    //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                    this.emissive = this.cPerformer.stringToColor(value, false);
                    break;
                // the ambient texture map
                case "map_Ka":
                    this.ka = new ImageTexture_1.ImageTexture(value, directory);
                    break;
                // the diffuse texture map 
                case "map_Kd":
                    this.kd = new ImageTexture_1.ImageTexture(value, directory);
                    break;
                //# specular color texture map
                case "map_Ks":
                    this.ks = new ImageTexture_1.ImageTexture(value, directory);
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
//# sourceMappingURL=Obj3DCreator.js.map