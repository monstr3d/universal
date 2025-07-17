interface IDataConsumer
{

    getAllMeasurements(): IMeasurements[];
    addMeasurements(item: IMeasurements) : void;
}
