import { CategoryObject } from "../CategoryObject";
import { OwnError } from "../ErrorHandler/OwnError";
import { FictiveDataConsumer } from "../Fiction/FictiveDataConsumer";
import { IDesktop } from "../Interfaces/IDesktop";
import { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { Performer } from "../Performer";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { IObjectTransformer } from "./Interfaces/IObjectTransformer";
import { IObjectTransformerConsumer } from "./Interfaces/IObjectTransformerConsumer";

export class ObjectTransformer extends CategoryObject implements IObjectTransformerConsumer,
    IDataConsumer, IMeasurements, IPostSetArrow
{
    // ----------------------------------------
    // Region: Data Types and Variables
    // ----------------------------------------

    // Fields


 
    /// <summary>
    /// This object as IObjectTransformer
    /// </summary>
    transformer !: IObjectTransformer;

    performer : Performer = new Performer()

    /// <summary>
    /// Input
    /// </summary>
    protected input : [] = [];

    /// <summary>
    /// Output measurements
    /// </summary>
    protected outMea: TransMeasurement[] = [];

    /// <summary>
    /// Input measurements
    /// </summary>
    protected inMea: IMeasurement[] = [];

    /// <summary>
    /// Input objects
    /// </summary>
    protected  inO : any[] = [];

    /// <summary>
    /// Output objects
    /// </summary>
    protected outO : any[] = [];

    /// <summary>
    /// Single output
    /// </summary>
    protected outS : [] = [];

    /// <summary>
    /// Single input
    /// </summary>
    protected inS = [];

    /// <summary>
    /// The "is updated" sign
    /// </summary>
    protected isUpdated: boolean = false;

    /// <summary>
    /// External measurements
    /// </summary>
    /// <summary>
    /// Providers of measurements
    /// </summary>
    measurements: IMeasurements[] = [];

   /// <summary>
    /// Links to variables
    /// </summary>
    links: Map<string, string> = new Map();

    /// <summary>
    /// Providers of measurements
    /// </summary>
    providers: IMeasurements[] = [];

    cons: IDataConsumer = new FictiveDataConsumer();

    transformers: IObjectTransformer[] = [];



    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "ObjectTransformer";
        this.types.push("ObjectTransformer");
        this.types.push("IObjectTransformerConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.cons = this;
    }
    postSetArrow(): void
    {
        this.initTransformer();
    }
    getMeasurementsCount(): number
    {
        return this.outMea.length;
    }
    getMeasurement(i: number): IMeasurement
    {
        return this.outMea[i];
    }

    updateMeasurements(): void
    {
        this.performer.updateChildrenData(this);
        for (var i = 0; i < this.inO.length; i++)
        {
            var m = this.inMea[i];
            this.inO[i] = m.getMeasurementValue();
        }
        this.transformer.calculate(this.inO, this.outO);
    }

    addMeasurement(measurement: IMeasurement): void
    {
        this.outMea.push(measurement as TransMeasurement);
    }

    getAllMeasurements(): IMeasurements[]
    {
        return this.measurements;
    }

    addMeasurements(item: IMeasurements): void {
        this.measurements.push(item);
    }


    addTransformer(transformer: IObjectTransformer): void
    {
        if (this.transformer != null)
        {
            throw new OwnError("", "", "");
        }
        this.transformer = transformer;
    }

    initTransformer(): void {
        var inp = this.transformer.getInput();
        var out = this.transformer.getOutput();
        this.inO = new Array(inp.length)
        this.outO = new Array(out.length)
        this.createOutput();
    }


    createOutput() : void
    {
        this.inMea = [];
        var outS = this.transformer.getOutput();
        for (var i: number = 0; i < outS.length; i++)
        {
            var name = outS[i];
            var type = this.getOutputType(i);
            this.outMea.push(new TransMeasurement(i, this.outO, name, type));
        }
        var mm = this.performer.getMeasurementsDCMap(this);
        var ent = this.links.entries();
        for (var [s, t] of ent)
        {
            var mt = mm.get(t);
            if (mt != undefined)
            {
                this.inMea.push(mt);
            }
        }
    }

    getOutputType(i: number): any
    {
        return this.transformer.getOutputType(i);
    }

    protected setLinks(map: Map<string, string>): void
    {
        this.performer.copyMap(map, this.links);
    }

 }

class TransMeasurement implements IMeasurement
{
    n: number;

    outO : any[] = [];

    name: string = "";

    type!: any;

    links: Map<string, string> = new Map();

    performer: Performer = new Performer();

    protected setLinks(links: Map<string, string>): void
    {
        this.performer.copyMap(links, this.links);
    }




    constructor(n : number, outO : any[], name : string, type : any)
    {
        this.n = n;
        this.outO = outO;
        this.name = name;
        this.type = type;
    }
    getMeasurementName(): string
    {
        return this.name;
    }
    getMeasurementType(): any
    {
        return this.type;
    }
    getMeasurementValue(): any
    {
        return this.outO[this.n];
    }
}
