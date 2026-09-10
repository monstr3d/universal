import type { IScene } from "../Game/Interfaces/IScene";
import type { IFactory } from "../Interfaces/IFactory";
import { Performer } from "../Performer";
import Loader from "../RemoteResuorces/Loader";
import type { ResourceInformation } from "../RemoteResuorces/Loader";
import type { IResourceFuncFactory } from "../Resources/Infrefaces/IResourceFuncFactory";
import type { IResourceItem } from "../Resources/Infrefaces/IResourceItem";
import type { IScadaInterface } from "../Scada/Interfaces/IScadaInterface";
export declare class GamePerformer extends Performer {
    sceneToScada(scene: IScene): IScadaInterface | undefined;
    convertResourceInfo(input: IResourceItem[], output: Map<string, ResourceInformation>): void;
    createFactory(loader: Loader, factory: IFactory | undefined): IResourceFuncFactory;
}
//# sourceMappingURL=GamePerformer.d.ts.map