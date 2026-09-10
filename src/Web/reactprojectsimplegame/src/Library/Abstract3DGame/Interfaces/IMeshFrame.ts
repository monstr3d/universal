import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";

export interface IMeshFrame { mesh: IMesh[], frame: ReferenceFrame}