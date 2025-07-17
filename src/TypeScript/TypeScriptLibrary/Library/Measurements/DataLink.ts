import { ICategoryObject } from "../ICategoryObject";
import { CategoryArrow } from "../CategoryArrow";
import { IDesktop } from "../IDesktop";

export class DataLink extends  CategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
    }

    name!: string;
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