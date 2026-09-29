import { EffectTexture } from "../EffectTexture";
import type { IMesh } from "../Interfaces/IMesh";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import { Obj3DCreator } from "../MeshCreators/Obj3DCreator";
import { Polygon } from "../Points/Polygon";
import { AbstractMeshPolygon } from "./AbstractMeshPolygon";


export class AbstractMeshObj extends AbstractMeshPolygon {
    constructor(parent: IMesh | undefined, name: string, transformationMatrix: number[], effect: EffectTexture, polygons: Polygon[],
        vertices: number[][], textures: number[][], normals: number[][], tuple: ITextureIndex | undefined,
        creatorObj: Obj3DCreator, variant: number, meshNumber: number) {
        super(parent, name, transformationMatrix, effect, polygons, vertices, textures, normals, tuple,
            creatorObj);
        this.o3dCreator = creatorObj;
        this.meshNumber = meshNumber
        this.vertices = [];
        this.textures = [];
        this.normals = [];
        this.intVertices = this.o3dCreator.getVertices();
        this.intNormals = this.o3dCreator.getNormals();
        this.intTextures = this.o3dCreator.getTextures();
        this.polygons = []
        let ind = this.o3dCreator.getIndexes();
        let indexes = ind[meshNumber]
        if (variant == 0) {
            /*  for (let ii of indexes)
              {
                /*  var idxx = ii.indx
                  for (var i of idxx) {
                      {
                   /*   this.vertices.push(this.intVertices[i[0]]);
                      this.textures.push(this.intTextures[i[1]]);
                      if (i.length > 2) {
                          if (i[2] >= 0) {
                              this.normals.push(this.intNormals[i[2]]);
                          }
                      }
                  }
              }*/
            var eff = tuple?.effect;
            if (eff != undefined) this.effect = eff;

            if (this.o3dCreator.getNames().length > meshNumber) {
                this.name = this.o3dCreator.getNames()[meshNumber]
            }
            else {
                this.name = this.o3dCreator.getMeshName();
            }
            let nm = 0
            for (let tuple of indexes) {
                new AbstractMeshObj(this, "", [], effect, [], this.intVertices, this.intTextures, this.intNormals,
                    tuple, this.o3dCreator, 1, nm)
                ++nm;
            }
            return
        }
        let indx = this.tuple.indx;
        for (var ii of indx) {
            for (var i of ii) {
                this.vertices.push(this.intVertices[i[0]]);
                this.textures.push(this.intTextures[i[1]]);
                if (i.length > 2) {
                    if (i[2] >= 0) {
                        this.normals.push(this.intNormals[i[2]]);
                    }
                }
            }
        }
    }
      /*      let np = 0;
            var eff = tuple?.effect;
            if (eff != undefined) this.effect = eff;

            var idx = tuple?.indx;
            if (idx === undefined) return;
            for (var ind of idx) {
                var l: PointTexture[] = [];
                for (let ii = 0; ii < ind.length; ii++) {
                    var ik = (this.normals.length == 0) ? -1 : np;
                    var point = this.createPointTexture(this, np, np, ik);
                    ++np;
                    if (point == undefined) {
                        throw new OwnError("AbstractMeshObj POINT ERROR SINLE", "", "");
                    }
                    l.push(point);
                }
                if (l.length != 3) {
                }
                var polygon = new Polygon(this, l, undefined);
                this.polygons.push(polygon);
            }
            return
        }
        /*      if (variant == 1) {
                  this.effect = creator.getDefaultEffect()
                  /*     var el = creator.EffectList;
                       if (el != null)
                       {
                           if (number < el.Count)
                           {
                               Effect = el[number];
                           }
                       }
                  this.intVertices = creator.getVertices()
                  this.intTextures = creator.getTextures()
                  this.intNormals = creator.getNormals()
                  this.polygons = []
                  let number = meshNumber
                  this.iindexes = creator.getIndexes()[number];
                  let names = creator.getNames()
                  if (names.length > number) {
                      this.name = names[number];
                  }
                  else {
                      name = creator.getMeshName();
                  }
                  if (this.iindexes != undefined)
                  {
                      if (this.iindexes.length == 0) {
                          for (var t of this.iindexes) {
                              new AbstractMeshObj(this, "", [], t.effect, [], [], [], [], undefined, creator, 1, 0)
                          }
                          return;
                      }
                  }
                  if (this.iindexes != undefined) {
       /*           for (var tp of this.iindexes)
                  {
                      var iind = tp.indx
                      for (var ii of iind)
                      {
                          for (var iii of ii)
                          {
                              this.vertices.push(this.intVertices[iii[0]])
                              this.textures.push(this.intTextures[iii[1]])
                              if (iii.length > 2) {
                                  if (iii[2] >= 0) {
                                      this.normals.push(this.intNormals[iii[2]])
                                }
                              }
                          }
                      }
                  }
                      for (var tpi of this.iindexes) {
                          var effect = tpi.effect
                          var idxx = tpi.indx;
                          for (var indx of idxx) {
                              var l: PointTexture[] = []
                              for (let i = 0; i < indx.length; i++) {
                                  let npp = this.np
                                  var ik = (this.normals.length == 0) ? -1 : npp;
                                  var point = this.createPointTexture(this, npp, npp, ik);
                                  ++this.np;
                                  l.push(point);
                              }
                              var polygon = new Polygon(this, l, effect);
                              this.polygons.push(polygon);
                          }
                      }
                  }
      
              }
          }*/

    createTriangles(): void {
    }
    protected o3dCreator!: Obj3DCreator;
    protected global: Map<number, number[]> = new Map();
    np: number = 0

    protected shift: number = 0;
    protected shiftTexture: number = 0;
    protected shiftNormal: number = 0;

    protected iindexes: ITextureIndex[] = [];

    protected intVertices: number[][] = [];
    protected intNormals: number[][] = [];
    protected intTextures: number[][] = [];

    meshNumber: number = 0

}
