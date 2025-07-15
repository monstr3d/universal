class Measurements extends CategoryObject : implements IMeasurements
{
    getCount(): number {
        throw new Error("Method not implemented.");
    }
    get(i: number): IMeasurement {
        throw new Error("Method not implemented.");
    }

}