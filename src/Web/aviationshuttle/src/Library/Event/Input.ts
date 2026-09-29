import { CategoryObject } from "../CategoryObject";
import { EmptyObject } from "../EmptyObject";
import { ActionArray } from "../Utilities/Generic/ActionArray";
import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IInput } from "../Interfaces/IInput";
import type { IMeasurement } from "../Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../Measurements/Interfaces/IMeasurements";
import type { IStarted } from "../Measurements/Interfaces/IStarted";

export class Input extends CategoryObject implements IInput, IMeasurements, IStarted {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.types.push("IInput")
        this.types.push("IEvent")
        this.types.push("IMeasurements")
        this.types.push("Input")
        this.typeName = "Input"
    }
    startedStart(start: number): void {
        this.fx = start
        for (let i = 0; i < this.idata.length; i++) this.data[i] = this.idata[i];
    }
    getMeasurementsCount(): number {
        return this.measuremenrs.length
    }
    getMeasurement(i: number): IMeasurement {
        return this.measuremenrs[i];
    }
    updateMeasurements(): void {

    }

    getInputTypes(): Map<string, any> {
        return this.inputtypes
    }

    getInitalConditions(): Map<string, any> {
        return this.inputconitions
    }

    setInputValue(name: string, value: any): void {
        if (this.num.has(name)) {
            let n = this.num.get(name)
            if (n != undefined) {
                if (this.data[n] != value) {
                    this.data[n] = value
                    this.action.action()
                }
            }
        }
    }

    eventAction(): IActionAddRemove {
        return this.action
    }
    isEventEnabled(): boolean {
        return true
    }
    setEventEnabled(enabled: boolean): void {
        this.en = enabled
    }

    protected createAll(): void {
        let i = 0
        for (let x of this.array) {
            let n = x[0] as unknown as string 
            let type = x[0]
            let value = x[1]
            this.num.set(n, i)
            this.inputtypes.set(n, type)
            this.inputconitions.set(n, value)
            this.idata.push(value)
            this.data.push(value)
            const m = new Measurement(n, this.data, type, i)
            this.measuremenrs.push(m)
            ++i
        }
    }

    protected measuremenrs: IMeasurement[] = []

    protected inputtypes: Map<string, any> = new Map

    protected inputconitions: Map<string, any> = new Map

    protected num: Map<string, number> = new Map


    protected data: any[] = []

    protected idata: any[] = []

    protected array: any[][] = []

    protected measurements: IMeasurement[] = []

    protected en: boolean = false

    protected action: IActionAddRemove = new ActionArray

    protected fx: number = 0

}
class Measurement extends EmptyObject implements IMeasurement {
    constructor(name: string, data: any[], type : any, num: number) {
        super(name)
        this.data = data
        this.type = type
        this.num = num
    }
    getMeasurementName(): string {
        return this.name
    }
    getMeasurementType() {
        return this.type
    }
    getMeasurementValue() {
        return this.data[this.num]
    }

    type: any
    data !: any[]
    num !: number
}