class FictiveDataConsumer implements IDataConsumer {
    get(): IMeasurements[] {
        throw new OwnNotImplemented();
    }
    add(item: IMeasurements): void {
        throw new OwnNotImplemented();;
    }
}

class FictiveMeasurements implements IMeasurements {
    getCount(): number {
        throw new OwnNotImplemented();
    }
    get(i: number): IMeasurement {
        throw new OwnNotImplemented();
    }
    Update(): void {
        throw new OwnNotImplemented();;
    }
}