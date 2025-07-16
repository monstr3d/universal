class DataLink implements ICategoryArrow
{
    constructor(name: string) {
        this.name = name;
    }

    name: string = "";
    getSource(): ICategoryObject {
        return this.source as unknown as ICategoryObject;
    }
    getTagret(): ICategoryObject {
        return this.target as unknown as ICategoryObject;
    }
    setSource(source: ICategoryObject): void {
        this.source = source as unknown as IDataConsumer;
    }
    setTarget(target: ICategoryObject): void {
        this.target = target as unknown as IMeasurements;
        this.source.add(this.target);
    }
    GetName(): string {
        return this.name;
    }
    source: IDataConsumer = new FictiveDataConsumer();

    target: IMeasurements = new FictiveMeasurements();;


}