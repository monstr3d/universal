import { CategoryArrow } from "../../CategoryArrow";
import { ICategoryObject } from "../../Interfaces/ICategoryObject";
import { IDesktop } from "../../Interfaces/IDesktop";
import { IDataConsumer } from "../Interfaces/IDataConsumer";
import { IMeasurements } from "../Interfaces/IMeasurements";

export class DataLink extends CategoryArrow 
{
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name)
        this.typeName = "DataLink";
        this.types.push("DataLink");
    }

    name: string = "";

    getSource(): ICategoryObject {
        return this.consumer as unknown as ICategoryObject;
    }

    getTagret(): ICategoryObject {
        return this.measurements as unknown as ICategoryObject;
    }

    setSource(source: ICategoryObject): void {
        this.consumer = source as unknown as IDataConsumer;
    }

    setTarget(target: ICategoryObject): void {
        this.measurements = target as unknown as IMeasurements;
        this.consumer.addMeasurements(this.measurements);
    }

    getName(): string {
        return this.name;
    }

    consumer!: IDataConsumer;

    measurements!: IMeasurements;


}