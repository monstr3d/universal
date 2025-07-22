import { ICategoryArrow } from "./Library/ICategoryArrow";
import { ICategoryObject } from "./Library/ICategoryObject";
import { DataLink } from "./Library/Measurements/DataLink";
import { IDataConsumer } from "./Library/Measurements/IDataConsumer";
import { PefrormerMeasuremets } from "./Library/Measurements/PefrormerMeasuremets";
import { DetaRuntimeConsumer } from "./Library/Measurements/Runtime/DetaRuntimeConsumer";
import { IDataRuntime } from "./Library/Measurements/Runtime/IDataRuntime";
import { Performer } from "./Library/Performer";
import { OrbitAct } from "./OrbitAct";
import { Orbital } from "./src/Orbital";
actT();

function load() {
    try {

        let orb = new Orbital();
        let objs = orb.getObjects();
        let p = new Performer();
        var al = p.select<ICategoryObject>(objs, "IAlias");
        var ln = p.select<ICategoryArrow>(objs, "DataLink");
        var dl = p.select<DataLink>(objs, "ICategoryArrow");
        let i = 0;
    }
    catch (e: any) {
        let ii = 0;
        ii++;

    }
}



function actT() {
    try {
        var o = new OrbitAct();
        o.test();
    }
    catch (e: any)
    {
        var i = 0;
    }
}

