import { CategoryArrow } from "../../CategoryArrow";
import { OwnError } from "../../ErrorHandler/OwnError";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IPosition } from "../Interfaces/IPosition";
import { RelativeMeasurements } from "../Objects/RelativeMeasurements";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";


export class RelativeMeasurementsLink extends CategoryArrow {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "RelativeMeasurementsLink";
        this.types.push("RelativeMeasurementsLink");
    }


    public getRelativeMeasurerements(): RelativeMeasurements[] {
        let rs = this.performer.convertObject<RelativeMeasurements, any>(this.source, "RelativeMeasurements");
        if (rs.length > 0) {
            return rs;
        }
        let rt = this.performer.convertObject<RelativeMeasurements, any>(this.target, "RelativeMeasurements");
        if (rt.length > 0) {
            return rt;
        }
        return [];

    }

    public getSourceObject(obj: ICategoryObject): ICategoryObject {
        var rm = this.performer.convertObject<RelativeMeasurements, ICategoryObject>(obj, "RelativeMeasurements")
        if (rm.length > 0)
        {
            var r = rm[0]
            if (r.getClassName() == "RelativeMeasurements") {
                return r;
            }
        }
        let rp = this.performer.convertObject<IPosition, ICategoryObject>(obj, "IPosition");
        if (rp.length > 0) {
            return obj;
        }
        throw new OwnError("Illegal type", "", "");

    }

    setSource(source: ICategoryObject): void {
        this.source = this.getSourceObject(source)
    }

    setTarget(target: ICategoryObject): void {
        this.target = target;
       let sr = this.performer.convertObject<IPosition, ICategoryObject>(this.source, "IPosition");
        let m = this.getRelativeMeasurerements();
        if (m.length > 0) {
            if (sr.length > 0) {
                m[0].setSource(sr[0])
                return;
            }
        }
        m[0].setTaget(sr[0])
    }


}
