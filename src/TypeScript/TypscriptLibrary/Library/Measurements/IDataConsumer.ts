interface IDataConsumer {

    get(): IMeasurements[];
    add(item: IMeasurements) : void;
}
