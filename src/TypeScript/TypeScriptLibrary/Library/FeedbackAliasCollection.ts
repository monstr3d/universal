import { FeedbackAlias } from "./FeedbackAlias";
import { FeedbackCollection } from "./FeedbackCollection";
import { FictiveDesktop } from "./Fiction/FictiveDesktop";
import { FictiveMeasurements } from "./Fiction/FictiveMeasurements";
import { ICategoryObject } from "./Interfaces/ICategoryObject";
import { IDesktop } from "./Interfaces/IDesktop";
import { IValue } from "./Interfaces/IValue";
import { IMeasurements } from "./Measurements/Interfaces/IMeasurements";

export class FeedbackAliasCollection extends FeedbackCollection
{

    constructor(map: Map<string, string>, measurements: IMeasurements, obj: ICategoryObject) 
    {
        super(map);
        this.desktop = obj.getDesktop();
        this.measurements = measurements;
        this.fillFeedBackAliases();
    }


    fillFeedBackAliases(): void
    {
        var measuremets = this.performer.getMeasurementsMap(this.measurements);
        for (const [key, val] of this.map.entries()) {
            var an = this.performer.getAliasName(this.desktop, val);
            var m = measuremets.get(key);
            var iv = m as unknown as IValue;
            var alias = new FeedbackAlias(an, iv);
            this.addFeedback(alias);
        }
    }

    protected desktop: IDesktop = new FictiveDesktop();

    protected measurements: IMeasurements = new FictiveMeasurements();
}