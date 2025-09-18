/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { CategoryArrow } from "../../CategoryArrow";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IDataConsumer } from "../Interfaces/IDataConsumer";
import type { IMeasurements } from "../Interfaces/IMeasurements";

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