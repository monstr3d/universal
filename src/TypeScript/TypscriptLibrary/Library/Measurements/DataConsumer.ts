class DataConsumer implements IDataConsumer {

    private measurements: IMeasurements[] = [];
    get(): IMeasurements[] {
        return this.measurements;
    }
    add(item: IMeasurements): void {
        this.measurements.push(item);
    }

}
