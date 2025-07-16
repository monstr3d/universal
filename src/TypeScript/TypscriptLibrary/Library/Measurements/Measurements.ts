class Measurements extends CategoryObject  implements IMeasurements, ICategoryArrow
{
    GetName(): string {
        throw new Error("Method not implemented.");
    }
    Update(): void {
        throw new Error("Method not implemented.");
    }
    getSource(): ICategoryObject {
        throw new Error("Method not implemented.");
    }
    getTagret(): ICategoryObject {
        throw new Error("Method not implemented.");
    }
    setSource(source: ICategoryObject): void {
        throw new Error("Method not implemented.");
    }
    setTarget(target: ICategoryObject): void {
        throw new Error("Method not implemented.");
    }
    getCount(): number {
        throw new Error("Method not implemented.");
    }
    get(i: number): IMeasurement {
        throw new Error("Method not implemented.");
    }

}