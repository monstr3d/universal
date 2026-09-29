import { EmptyObject } from "../EmptyObject"
import type { IScene } from "../Game/Interfaces/IScene"
import type { IFactory } from "../Interfaces/IFactory"
import { Performer } from "../Performer"
import type { ILoadUrl } from "../RemoteResuorces/Interfaces/ILoadUrl"
import Loader from "../RemoteResuorces/Loader"
import type{ ResourceInformation } from "../RemoteResuorces/Loader"
import type { IResourceFunc } from "../Resources/Infrefaces/IResourceFunc"
import type { IResourceFuncFactory } from "../Resources/Infrefaces/IResourceFuncFactory"
import type { IResourceItem } from "../Resources/Infrefaces/IResourceItem"
import { ResourceFuncFactory } from "../Resources/ResourceFuncFactory"
import type { IScadaConsumer } from "../Scada/Interfaces/IScadaConsumer"
import type { IScadaInterface } from "../Scada/Interfaces/IScadaInterface"

export class GamePerformer extends Performer {
    public sceneToScada(scene: IScene): IScadaInterface | undefined {
        var sh = this.convertObject<IScadaConsumer, IScene>(scene, "IScadaConsumer")
        if (sh.length == 0) return undefined
        return sh[0].getConsumerScada()
    }
    public convertResourceInfo(input: IResourceItem[], output: Map<string, ResourceInformation>): void {
        for (let item of input) {
            let o: ResourceInformation = { url: item.url, type: item.type }
            output.set(item.name, o)
        }
    }

    public createFactory(loader: Loader, factory: IFactory | undefined): IResourceFuncFactory {
        var fact = new ResourceFuncFactory("", factory)
        let rf = new ResourceFactory(loader)
        fact.addFunction("text", rf)
        let lf = new LoaderFactory(loader)
        fact.addFunction("image", lf)
        return fact;
    }

}

abstract class AbstractFactory extends EmptyObject implements IResourceFunc {
    constructor(loader: Loader) {
        super("")
        this.loader = loader
        this.types.push("IResourceFunc")
    }

    abstract functT(s: string): any


    protected loader !: Loader

}

class ResourceFactory extends AbstractFactory {
    constructor(loader: Loader) {
        super(loader)
    }
    functT(s: string) {
        let res = this.loader.getResult();
        let k = res.get(s)
        return k
    }
}

class LoaderFactory extends AbstractFactory {
    constructor(loader: Loader) {
        super(loader)
    }
    functT(s: string) {
        let p: ILoadUrl = { loader: this.loader, url: s }
        return p
    }
}
