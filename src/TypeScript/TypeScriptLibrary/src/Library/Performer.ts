/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { AliasName } from "./AliasName";
import { ConsolePrinter } from "./ConsolePrinter";
import { OwnError } from "./ErrorHandler/OwnError";
import { MeasurementsComparator } from "./Measurements/MeasurementsComparator";
import { SortingAlgorithms } from "./Utilities/Sort/SortingAlgorithms";
import { ActionArray } from "./Utilities/Generic/ActionArray";
import { DateTimeConverter } from "./Utilities/DateTime/DateTimeConverter";
import type { IAction } from "./Interfaces/IAction";
import type { IAlias } from "./Interfaces/IAlias";
import type { IAliasName } from "./Interfaces/IAliasName";
import type { ICategoryObject } from "./Interfaces/ICategoryObject";
import type { IComparator } from "./Utilities/Sort/Interfaces/IComparator";
import type { IDesktop } from "./Interfaces/IDesktop";
import type { IObject } from "./Interfaces/IObject";
import type { IPrintedObject } from "./Interfaces/IPrintedObject";
import type { IPrinter } from "./Interfaces/IPrinter";
import type { IValue } from "./Interfaces/IValue";
import type { IDataConsumer } from "./Measurements/Interfaces/IDataConsumer";
import type { IDerivation } from "./Measurements/Interfaces/IDerivation";
import type { IMeasurement } from "./Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "./Measurements/Interfaces/IMeasurements";
import type { IFeedbackCollection } from "./Interfaces/IFeedbackCollection";
import type { ICheck } from "./Interfaces/ICheck";
import type { ICheckHolder } from "./Interfaces/ICheckHolder";
import type { IProperties } from "./Interfaces/IProperties";
import type { IActionT } from "./Interfaces/IActionT";
import type { IComponentCollection } from "./Interfaces/IComponentCollection";
import type { ICategoryArrow } from "./Interfaces/ICategoryArrow";
import type { IObjectCollection } from "./Interfaces/IObjectCollection";
import type { INamed } from "./NamedTree/Interfaces/INamed";
import type { IFactory } from "./Interfaces/IFactory";
import type { IFactoryConsumer } from "./Interfaces/IFactoryConsumer";
import type { ISelfStart } from "./Interfaces/ISelfStart";
import type { ILoader } from "./Interfaces/ILoader";
import type { ISelfLoad } from "./Interfaces/ISelfLoad";
import type { IFuncT } from "./Interfaces/IFuncT";
import type { IActionAddRemove } from "./Interfaces/IActionAddRemove";
import type { IActionAddRemoveT } from "./Interfaces/IActionAddRemoveT";
import type { INodeT } from "./NamedTree/Interfaces/INodeT";
import type { IResourceItem } from "./Resources/Infrefaces/IResourceItem";
import type { IResourceCollection } from "./Resources/Infrefaces/IResouceCollection";
import type { IExternalAction } from "./Interfaces/IExternalAction";
import type { IInput } from "./Interfaces/IInput";
import type { IActionAddRemoveT2 } from "./Interfaces/IActionAddRemoveT2";
import type { IActionT2 } from "./Interfaces/IActionT2";
import type { IStartTask } from "./Interfaces/IStartTask";
import type { IRunning } from "./Interfaces/IRunning";
import type { IActionT3 } from "./Interfaces/IActionT3";
import type { IActionAddRemoveT3 } from "./Interfaces/IActionAddRemoveT3";
import type { IActionT4 } from "./Interfaces/IActionT4";
import type { IActionAddRemoveT4 } from "./Interfaces/IActionAddRemoveT4";



export class Performer
{

    public toShidtedString(str: string, shift : string) {
        if (str.startsWith(shift)) {
            return str.substring(shift.length).replace("\"", "").trim();
        }
        return null;
    }


    public  getObjectArrayFromNode<T, S>(node: INodeT<T>, func: IFuncT<S | undefined, T>): S[] {
        let a = new ArrayOfObjects<T, S>(func, this)
        return a.getArray(node)
    }

    constructor() {
        this.mCompatator = new MeasurementsComparator(this);
    }

    static desktop: IDesktop;

    public static getCurrentDesktop(): IDesktop {
        return this.desktop
    }

    public static setCurrentDesktop(desktop: IDesktop): void {
        this.desktop = desktop
    }

    public async startAsync(collection: IComponentCollection, controller: AbortController): Promise<void>
    {
        let r: Promise<void>[] = []
        let t = this.getAll<IStartTask>(collection, "IStartTask")
        for (let task of t) {
            r.push(task.startAsync(controller))
        }
        await Promise.all(r)
    }


    protected a: number = 0;

    protected b: boolean = false;

    protected s: string = "";

    protected printer: IPrinter = new ConsolePrinter();

    protected sorting: SortingAlgorithms = new SortingAlgorithms();

    protected mCompatator !: IComparator<IMeasurements>;

    public toOneDimensdional<T>(t: T[][]): T[] {
        let x: T[] = []
        for (let xx of t) {
            x.concat(xx)
        }
        return x
    }


    public createMirrorArray<T>(x: T[], y: T[], d: T): void {
        for (var i = 0; i < y.length; i++) {
            x.push(d)
        }
    }

    public createMirrorArray2<T>(x: T[][], y: T[][], d: T): void {
        for (var i = 0; i < y.length; i++) {
            let z: T[] = []
            let xx = y[i]
            this.createMirrorArray(z, xx, d)
            x.push(z)
        }
    }

    public getActionFromNode<T>(node: INodeT<T>, func: IFuncT<IAction | undefined, T>): IAction | undefined {
        let act = this.getObjectArrayFromNode(node, func)
        if (act.length == 0) return undefined
        if (act.length == 1) return act[0]
        let action = new ActionArray()
        action.addActionArray(act)
        return action
    }

    //Recursive action
    public recursiveNodeAction<T>(node: INodeT<T>, action: IActionT<T>): void
    {
        let children = node.getNodesT()
        for (let child of children) {
            this.recursiveNodeAction<T>(child, action)
        }
        let t = node.getNodeValueT()
        action.actionT(t)
    }

   
    public addUnique<T>(list: T[], item: T): boolean {
        for (let x of list) {
            if (x == item) {
                return false
            }
        }
        list.push(item)
        return true;
    }

    public toShiftString(str: string, shift: string): string {
        {
            if (str.indexOf(shift) == 0) {
                return str.substring(shift.length)
            }
            return "";
        }
    }

    public cut<T>(t: T[], n: number): T[] {
        let s: T[] = []
        for (let i = 0; i < n; i++) {
            s.push(t[i])
        }
        return s
    }

    public addCut<T>(list: T[][], t: T[], n: number): void {
        var tt = t;
        if (t.length > n) {
            tt = this.cut(t, n);
        }
        list.push(tt);
    }



    public getAllIObjects(categoryObjects: ICategoryObject[], arrows: ICategoryArrow[], objects: IObject[]): void {
        for (let o of categoryObjects) {
            var l = this.convertObject<IObject, ICategoryObject>(o, "IObject")
          if (l.length > 0) {
                objects.push(l[0])
            }
        }
        for (let a of arrows) {
            var l = this.convertObject<IObject, ICategoryArrow>(a, "IObject")
            if (l.length > 0) {
                objects.push(l[0])
            }
        }

    }

    public setPrinter(printer: IPrinter): void {
        this.printer = printer;
    }


    public getAll<T>(collection: IObjectCollection, type: string) {
        let t : T[] = []
        let obj = collection.getObjectCollection()
        for (let o of obj) {

            var x = this.convertObject<T, IObject>(o, type)
            if (x.length > 0) t.push(x[0])
        }
        return t;
  }


    public reoplaceArrayValue<T>(t: T[], s: T[]): void {

        if (s.length == 0) {
            if (t.length > 0) {
                t.pop();
                return;
            }
        }
        let ss = s[0]
        if (t.length > 0) {
            t[0] = ss;
            return;
        }
        t.push(ss);
    }


    public executeAction(acttion: IAction | undefined): void {
        if (acttion === undefined) return;
        acttion.action();
    }

    public sumOfActions(first: IAction | undefined, second: IAction | undefined): IAction | undefined {
        var act = new ActionArray();
        if (first === undefined) {
            return second;
        }
        else {
            act.addAction(first)
            if (second === undefined) {
                return first;
            }
            else {
                act.addAction(second);
            }
        }
        return act;
    }

    public setCheker(desktop: IDesktop, check: ICheck) {
        const objects = desktop.getCategoryObjects();
        for (let object of objects) {
            if (this.implementsType(object, "ICheckHolder")) {
                var ch = object as unknown as ICheckHolder;
                ch.setCheck(check);
            }
        }
    }

    public findMaxWithReduce(numbers: number[]): number | undefined {
        if (numbers.length === 0) {
            return undefined;
        }
        const maxNumber: number = numbers.reduce((max, current) => current > max ? current : max, numbers[0]);
        return maxNumber
    }

 //   k: number = 0;

    public findMinWithReduce(numbers: number[]): number | undefined {
        if (numbers.length === 0) {
            return undefined;
        }

        let minNumber = numbers.reduce(this.funcMin, numbers[0])
 /*       if (this.k < 300) {
            console.log(numbers, minNumber)
++this.k
        }*/
        return minNumber

    }

    funcMin(x: number, y: number): number {
        return x < y ? x: y
        
    }
    

    public calculateAverage(numbers: number[]): number {
        if (numbers.length === 0) {
            return 0; // Or throw an error, depending on your requirements
        }
        const sum = numbers.reduce((sum, p) => sum + p);
        return sum / numbers.length;
    }

    public calculateAverageRobust(data: any[]): number {
        const numbers = data.filter((item): item is number => typeof item === 'number'); // Type guard

        if (numbers.length === 0) {
            return 0;
        }

        const sum = numbers.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
        return sum / numbers.length;
    }


    public calculateAverageNull(data: any[]): number | undefined {
        const numbers = data.filter((item): item is number => typeof item === 'number'); // Type guard

        if (numbers.length != data.length) {
            return undefined;
        }

        const sum = numbers.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
        return sum / numbers.length;
    }

    public getPrinter(): IPrinter {
        return this.printer;
    }

    public print(object: any): void {
        if (this.implementsType(object, "IPrintedObject"))
        {
            var pr = object as unknown as IPrintedObject;
            pr.print(this.printer);
            return;
        }
        this.printer.print(object);
    }

    public convertTS<S, T>(s: S, type: string): T {
        if (this.implementsType(s, type)) {
            throw new OwnError("Illegal type", "Illegal type: " + type, undefined);
        }
        return s as undefined as T;
    }

    public getByInterface(desktop: IComponentCollection, type: string): IObject[] {
        let co = desktop.getCategoryObjects();
        let objects: IObject[] = [];
        for (var a of co) {
            if (this.implementsType(a, type)) {
                objects.push(a as unknown as IObject);
            }
        }
        return objects;
    }

    public sortMeasurements(measurements: IMeasurements[]): IMeasurements[] {
        return this.sorting.mergesort(measurements, this.mCompatator);
    }


    public getByType(desktop: IDesktop, type: string): IObject[] {
        let co = desktop.getCategoryObjects();
        let objects: IObject[] = [];
        for (var a of co)
        {
  
            if (this.implementsType(a, type))
            {
                var ob = a as unknown as IObject;
                if (ob.getClassName() == type)
                {
                    objects.push(a as unknown as IObject);
                }
            }
        }
        return objects;
    }


    public updateFeedbackData(feedback: IFeedbackCollection): void {
        if (feedback.isEmpty()) return;
        feedback.setFeedbacks();
       // this.updateChildrenData(dataConsumer);
    }

    public updateChildrenData(dataConsumer: IDataConsumer): void
    {
        let children = dataConsumer.getAllMeasurements();
        for (var child of children)
        {
            let o = child as unknown as IObject;
            if (this.implementsType(o, "IDataConsumer"))
            {
                let dc = child as unknown as IDataConsumer;
                this.updateChildrenData(dc);
            }
       //     console.log("CHILD", child)
            child.updateMeasurements();
        }
    }

    public convertArray<T, S>(objects: T[], type: string): S[] {

        const s: S[] = [];
        for (let i = 0; i < objects.length; i++) {
            let o: IObject = objects[i] as unknown as IObject;
            if (o.imlplementsType(type)) {
                s.push(o as unknown as S);
            }
        }
        return s;
    }

    public convertMap<T, S, R>(objects: Map<T, S>, type: string): Map<T, R> {
        let map: Map<T, R> = new Map();
        var ent = objects.entries();
        for (const [key, val] of ent) {
            let o: IObject = val as unknown as IObject;
            if (o.imlplementsType(type)) {
                map.set(key, o as unknown as R);
            }

        }
        return map;
    }

    public getName(obj: any): string {
        var o = this.convertArray<IObject, any>(obj, "IObject")
        return o[0].getName()
    }


    public convertObject<T, S>(s: S, type: string): T[] {
        let ob = s as unknown as IObject;
        var t: T[] = [];
        if (ob === undefined) {
            return t;
        }
        if (ob.imlplementsType(type))
        {
            var x = s as unknown as  T;
            t.push(x);
        }
        return t;
    }

    public getObjectCollectionArray<T>(collection: IObjectCollection, type: string): T[] {
        let t : T[] = []
        var s = collection.getObjectCollection();
        for (let o of s) {
            let tt = this.convertObject<T, IObject>(o, type)
            if (tt.length == 0) continue
            t.push(tt[0])
        }
        return t;
    }


    public getObjectCollectionMap<T>(collection: IObjectCollection, type: string): Map<string, T>
    {
        let map: Map<string, T> = new Map();
        var s = collection.getObjectCollection();
        for (let o of s) {
            let tt = this.convertObject<T, IObject>(o, type)
            if (tt.length == 0) continue
            let named = this.convertObject<INamed, IObject>(o, "INamed")
            if (named.length > 0) {
                map.set(named[0].getNamedName(), tt[0])
            }

        }
        return map;
    }

    public getCollectionObject<T>(collection: IComponentCollection, name: string, type: string): T[] {
        let o = collection.getCategoryObject(name)
        if (o === undefined) return []
        return this.convertObject < T, ICategoryObject>(o, type)
    }

    public convertProperties<T>(o: ICategoryObject, type: string): T[] {
        let ob = this.convertObject<T, ICategoryObject>(o, type)
        if (ob.length > 0) return ob;
        let prp = this.convertObject<IProperties, ICategoryObject>(o, "IProperties")
        if (prp.length > 0) {
            var pp = this.convertObject<T, any>(prp[0].getProperties(), type)
            if (pp.length > 0) return pp;
        }
        return [];
    }

    public select<T>(objects: IObject[], type: string): T[] {

        let t: T[] = [];
        for (var i = 0; i < objects.length; i++) {
            let o = objects[i];
            if (o.imlplementsType(type)) {
                t.push(o as unknown as T);
            }
        }
        return t;
    }


    public getDerivation(derivation: IDerivation): number
    {
        let m = derivation.getDerivation();
        let x = m.getMeasurementValue();
        return this.convertFromAny<number>(x);
    }

    public getDerivationMeasurement(measurement: IMeasurement): number {
        let d = measurement as unknown as IDerivation;
        return this.getDerivation(d);
    }

    public setDerivationValue(derivation: IDerivation, value: number): void
    {
        let m = derivation.getDerivation();
        let iv = m as unknown as IValue;
        iv.setIValue(value);
    }

    public setDerivationMeasuremtValue(measurement: IMeasurement, value: number): void
    {
        let d = measurement as unknown as IDerivation;
        this.setDerivationValue(d, value);
    }

    public dateString(x: number): string {
        let y = x / 86400;
        var d = this.dt.fromOADate(y);
        var s = d.toJSON();
        s = s.substring(0, 19) + "." + d.getMilliseconds().toString();
        return s;
    }

    public dateNumber(x: string): number {
        var d = new Date(x);
        var y = this.dt.toOADate(d);
        //var z = y * 86400;
        return y;
    }

    protected dt: DateTimeConverter = new DateTimeConverter();


    public convertFromAny<T>(t: any): T {
        return this.convert<any, T>(t);
    }


    public toNumber(s: any): number {
        return Number(s)
    }


    public convert<T, S>(t: T): S {
        // Typeof checks against string representations of types. S is a generic type,
        // so you can't directly use typeof S.  It will just return the string "object" or "function".
        // You need to find a way to determine the *actual* type S at runtime
        //  and compare it against the type of 't'.
        // A very limited approach would be to use type guards, but that means
        // you'd have to know what type S *could* be in advance. This is not
        // really a general solution.
        const tt = typeof t
        if (t === undefined) {
            throw new OwnError("Type conversion", "Performer undefined. NULL OBJECT", undefined);
        }
        if (tt === "string") {
            if ((t as any as S) instanceof String) { //VERY LIMITED AND UNSAFE EXAMPLE.
                return t as any as S; // Force the type assertion (VERY UNSAFE)
            }
        }

        if (tt === "number") { // } && (t as unknown as S) instanceof Number) {  //VERY LIMITED AND UNSAFE EXAMPLE.
            return Number(t) as S; // Force the type assertion (VERY UNSAFE)
        }

        if (tt === "boolean") { //VERY LIMITED AND UNSAFE EXAMPLE.
            return t as any as S; // Force the type assertion (VERY UNSAFE)
        }

        //This is better, but assumes S is a string or number
        if (tt === 'string' && (null as any as S) as any === String) {
            return t as any as S;
        }

        if (typeof t === 'number' && (null as any as S) as any === Number) {
            return t as any as S;
        }
        return t as any as S
        console.warn(t, typeof t)
        throw new OwnError("Type conversion", "Performer", undefined);

        // In many cases, a direct conversion may not be possible
        // or may require a more complex transformation.
        // warn("Conversion not possible for types:", typeof t, S);
        return undefined as any as S; // Or throw an error, or return a default value.
    }


    public getMeasurement(i: number, j: number, dataConsumer: IDataConsumer): IMeasurement {
        return dataConsumer.getAllMeasurements()[i].getMeasurement(j);
    }

    public remove<T>(t: T[], x: T): T[] {
        let tt: T[] = [];
        for (let y of t) {
            if (y != x) {
                tt.push(x)
            }
        }
        return tt;
    }



    public enlarge<T>(t: T[], x: T, size: number): void {
        for (let i = 0; i < size; i++) t.push(x);
    }

    public enlarge2<T>(t: T[][], x: T, row: number, column: number): void {
        for (let i = 0; i < row; i++) {
            let y: T[] = [];
            t.push(y);
            for (let j = 0; i < column; j++) y.push(x);
        }
    }

    public enlargeNumber(x: number[], size: number): void {
        this.enlarge<number>(x, 0, size);
    }

    public enlargeNumber2(x: number[][], row: number, column: number): void {
        this.enlarge2<number>(x, 0, row, column);
    }

    public pushArray<T>(f: T[], t: T[]): void {
        for (let i = 0; i < f.length; i++) {
            t.push(f[i]);
        }
    }

    public copyArray<T>(f: T[], t: T[]): void {
        for (let i = 0; i < f.length; i++) {
            t[i] = f[i];
        }
    }

    public copyArraySize<T>(f: T[], t: T[], size: number): void {
        for (let i = 0; i < size; i++) {
            t[i] = f[i];
        }
    }

    public addArray<T>(array: T[], add: T[]): void {
        for (let f of add) {
            array.push(f)
        }
    }

    public setAliasType(name: string, value: any, map: Map<string, any>, names: string[]): boolean {
        if (map.has(name)) {
            return false;
        }
        names.push(name);
        if (typeof value === 'number') {
            map.set(name, this.a);
        }
        if (typeof value === 'boolean') {
            map.set(name, this.b);
        }
        if (typeof value === 'string') {
            map.set(name, this.s);
        }
        return true;
    }

    public setAliasMap(map: Map<string, any>, alias: IAlias): void {
        var keys = map.keys();
        for (var key of keys) {
            alias.setAliasValue(key, map.get(key));
        }
    }

    public copyMap<T, S>(s: Map<T, S>, t: Map<T, S>): void {
        for (const [key, value] of s) {
            t.set(key, value);
        }
    }

    public implementsType(o: unknown, type: string): boolean {
        let obj: IObject = o as IObject;
        return obj.imlplementsType(type);
    }

    public getMeasurementsMap(measurements: IMeasurements): Map<string, IMeasurement> {

        let map: Map<string, IMeasurement> = new Map();
        var n = measurements.getMeasurementsCount();
        for (let i = 0; i < n; i++) {
            let m = measurements.getMeasurement(i);
            var nn = m.getMeasurementName();
            map.set(nn, m);
        }
        return map;
    }

    public getMeasurementDC(consumer: IDataConsumer, name: string): IMeasurement
    {
        var mm = consumer.getAllMeasurements();
        for (var mea of mm) {
            var co = mea as unknown as ICategoryObject;
            var nm = co.getCategoryObjectName();
            nm += ".";
            var n = mea.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var m = mea.getMeasurement(i);
                var nam = nm + m.getMeasurementName();
                if (nam == name) {
                    return m;
                }
            }

        }
        return this.measurement;
    }


    public getMeasurementsMMap(measurements: IMeasurements, map: Map<string, IMeasurement>): void
    {
        var n = measurements.getMeasurementsCount();
        for (let i = 0; i < n; i++) {
            var m = measurements.getMeasurement(i);
            var name = m.getMeasurementName();
            map.set(name, m);

        }
    }


    public getMeasurementsDCMap(consumer: IDataConsumer): Map<string, IMeasurement> {
        var map: Map<string, IMeasurement> = new Map();
        var mm = consumer.getAllMeasurements();
        for (var mea of mm) {
            var co = mea as unknown as ICategoryObject;
            var nm = co.getCategoryObjectName();
            nm += ".";
            var n = mea.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var m = mea.getMeasurement(i);
                var name = nm + m.getMeasurementName();
                map.set(name, m);
            }

        }
        return map;
    }

    public getMeasurements(desktop: IDesktop, name: string): IMeasurements {
        var a = desktop.getCategoryObject(name);
        if (this.implementsType(a, "IMeasurements")) {
            var al = a as unknown as IMeasurements;
            return al;
        }
        return this.measurements;
    }


    public getAlias(desktop: IDesktop, name: string): IAlias {
        var a = desktop.getCategoryObject(name);
        if (this.implementsType(a, "IAlias")) {
            var al = a as unknown as IAlias;
            return al;
        }
        return this.alias;
    }

    public getAliasName(desktop: IDesktop, name: string): IAliasName {

        var l = name.length;
        var n = name.lastIndexOf('.');
        var s = name.substring(n + 1, l);
        var t = name.substring(0, n);
        var al = this.getAlias(desktop, t);
        return new AliasName(al, s);

    }
    public isEmptyActionT<T>(action: IActionT<T> | undefined): boolean {
        if (action === undefined) return true;
        let act: IActionT<T> = action
        let arr: IActionAddRemoveT<T> = act as unknown as IActionAddRemoveT<T>
        if (arr == undefined) return false
        return arr.isEmptyActionT()
    }

    public isEmptyActionT2<T1, T2>(action: IActionT2<T1, T2> | undefined): boolean {
        if (action === undefined) return true;
        let act: IActionT2<T1, T2> = action
        let arr: IActionAddRemoveT2<T1, T2> = act as unknown as IActionAddRemoveT2<T1, T2>
        if (arr == undefined) return false
        return arr.isEmptyActionT2()
    }


    public isEmptyActionT3<T1, T2, T3>(action: IActionT3<T1, T2, T3> | undefined): boolean {
        if (action === undefined) return true;
        let act: IActionT3<T1, T2, T3> = action
        let arr: IActionAddRemoveT3<T1, T2, T3> = act as unknown as IActionAddRemoveT3<T1, T2, T3>
        if (arr == undefined) return false
        return arr.isEmptyActionT3()
    }


    public isEmptyActionT4<T1, T2, T3, T4>(action: IActionT4<T1, T2, T3, T4> | undefined): boolean {
        if (action === undefined) return true;
        let act: IActionT4<T1, T2, T3, T4> = action
        let arr: IActionAddRemoveT4<T1, T2, T3, T4> = act as unknown as IActionAddRemoveT4<T1, T2, T3, T4>
        if (arr == undefined) return false
        return arr.isEmptyActionT4()
    }





    public isEmptyAction(action: IAction | undefined): boolean {
        if (action === undefined) return true;
        let act: IAction = action
        let arr: IActionAddRemove = act as unknown as IActionAddRemove
        if (arr == undefined) return false
        return arr.isEmptyAction()
    }
  

    public convertArrayT<T, S>(collection: IObjectCollection, f: IFuncT<T, S>, type: string): T[] {
        let t: T[] = []
        let add = new AddTS<T, S>(t, f)
        this.forEach<S>(collection, add, type)
        return t
    }


    public forEach<T>(collection: IObjectCollection, action: IActionT<T>, type: string) {
        let obj = collection.getObjectCollection()
        for (let o of obj) {
            var x = this.convertObject<T, IObject>(o, type)
            if (x.length > 0) action.actionT(x[0])
            var y = this.convertObject<IObjectCollection, IObject>(o, "IObjectCollection")
            if (y.length > 0) this.forEach(y[0], action, type)
        }
    }

    public loadChildren(object: IObject, collection:
        IObjectCollection, loader: ILoader, load: boolean): void {
        var lc = new LoadChild(object, loader, load)
        this.forEach<IObject>(collection, lc, "IObject")
    }


    public setFactoryToObjectCollection(collection: IObjectCollection, factory: IFactory) {
        let setter = new FactorySetter(factory)
        this.forEach<IFactoryConsumer>(collection, setter, "IFactoryConsumer")
    }

    public getFactoryFromDesktop(desktop: IDesktop): IFactory | undefined {
        let t = this.convertObject<IFactoryConsumer, any>(desktop, "IFactoryConsumer")
        if (t.length > 0) {
            return t[0].getConsumerFactory()
        }
        return undefined;
    }


    public collectResources(res: IResourceCollection, collection: IObjectCollection) {
        var rs = new ResourceSetter(res)
        this.forEach<IResourceCollection>(collection, rs, "IResourceCollection")
    }

    public startCollecion(start: boolean, collection: IObjectCollection) {
        if (start) {
            this.forEach<ISelfStart>(collection, this.start, "ISelfStart")
        }
        else {
            this.forEach<ISelfStart>(collection, this.stop, "ISelfStart")

        }
    }

    public loadCollecion(load: boolean, collection: IObjectCollection) {
        if (load) {
            this.forEach<ISelfLoad>(collection, this.load, "ISelfLoad")
        }
        else {
            this.forEach<ISelfLoad>(collection, this.unload, "ISelfLoad")
        }
    }
 

    public createObjectCollectionAction(collection: IObjectCollection,
        f:  IFuncT<IAction | undefined, IObject>): IActionAddRemove {
        var act = new ActionArray();
        var creator = new ActionCreator(f, act)
        this.forEach<IObject>(collection, creator, "IObject")
        return act 
    }

    public createObjectCollectionExternalAction(collection: IObjectCollection): IActionAddRemove {
        var act = new ActionArray();
        var creator = new ExternalActionCreator(act)
        this.forEach<IExternalAction>(collection, creator, "IExternalAction")
        return act
    }

    public getInputsFromCollection(collection: IObjectCollection, inputs: IInput[]) {
        let s = new InputSelect(inputs)
        this.forEach<IInput>(collection, s, "IInput")
    }

    public setRunning(collection: IObjectCollection, running: boolean): void {
        let r = new Running(running)
        this.forEach<IRunning>(collection, r, "IRunning")
    }

    measurements !: IMeasurements;

    measurement !: IMeasurement;

    alias !: IAlias;

    start: Start = new Start()

    stop: Stop = new Stop()

    load: Load = new Load()

    unload: Unload = new Unload()



}

class InputSelect implements IActionT<IInput> {

    constructor(inputs: IInput[]) {
        this.inputs = inputs
    }
    actionT(t: IInput): void {
        this.inputs.push(t)
    }
    isEmptyActionT(): boolean {
        return false;
    }

    inputs !: IInput[]
}

class ExternalActionCreator implements IActionT<IExternalAction> {
    actionT(t: IExternalAction): void {
        this.action.addAction(t.getExternalAction())
    }
    isEmptyActionT(): boolean { return false }

    action !: IActionAddRemove
    
    constructor(action: IActionAddRemove) {
        this.action = action
    }

}

class ActionCreator implements IActionT<IObject> {
    actionT(t: IObject): void {
        var act = this.functT.functT(t)
        if (act != undefined) this.action.addAction(act)
    }
    isEmptyActionT(): boolean { return false }

    functT !: IFuncT<IAction | undefined, IObject>
    action !: IActionAddRemove
    constructor(functT: IFuncT<IAction | undefined, IObject>, action: IActionAddRemove) {
        this.functT = functT
        this.action = action
    }

}

class AddTS<T, S> implements IActionT<S>{

    funcT !: IFuncT<T, S>

    array: T[] = []

    constructor(array: T[], funcT : IFuncT<T, S>) {
        this.array = array
        this.funcT = funcT
    }
    actionT(s: S): void {
        let t = this.funcT.functT(s)
        if (t != undefined) this.array.push(t)
    }
    isEmptyActionT(): boolean { return false }

}



class Start implements IActionT<ISelfStart> {
    actionT(t: ISelfStart): void {
        t.startItself(true)
    }
    isEmptyActionT(): boolean { return false }

}

class Stop implements IActionT<ISelfStart> {
    actionT(t: ISelfStart): void {
        t.startItself(false)
    }
    isEmptyActionT(): boolean { return false }

}

class Load implements IActionT<ISelfLoad> {
    actionT(t: ISelfLoad): void {
        t.loadItself(true)
    }
    isEmptyActionT(): boolean { return false }

}

class Unload implements IActionT<ISelfLoad> {
    actionT(t: ISelfLoad): void {
        t.loadItself(false)
    }
    isEmptyActionT(): boolean { return false }

}



class LoadChild implements IActionT<IObject> {

    parent !: IObject;

    load: boolean = false

    loader !: ILoader


    constructor(parent: IObject, loader : ILoader, load: boolean) {
        this.parent = parent;
        this.load = load;
        this.loader = loader
    }

    actionT(t: IObject): void {
        this.loader.loadObject(this.parent, t)
    }

    isEmptyActionT(): boolean { return false }

}



class FactorySetter implements IActionT<IFactoryConsumer>
{
    constructor(factory: IFactory) {
        this.factory = factory
  }
    actionT(t: IFactoryConsumer): void {
        t.setConsumerFactory(this.factory)
    }

    isEmptyActionT(): boolean { return false }


    factory: IFactory
}

class ResourceSetter implements IActionT<IResourceCollection> {

    constructor(t: IResourceCollection) {
        this.collection = t
        var c = t.getResources()
        this.res = c;
        for (let x of c) {
            let url = x.url
            if (this.map.has(url)) {
                continue
            }
            this.map.set(url, x)
        }
    }

    actionT(t: IResourceCollection): void {
        var rr = t.getResources()
        var rs = this.collection.getResources()
        for (let x of rr) {
            let url = x.url
            if (this.map.has(url)) {
                continue
            }
            this.map.set(url, x)
            rs.push(x)
        }
    }

    isEmptyActionT(): boolean { return false }

    res: IResourceItem[] = []

    collection: IResourceCollection

    map: Map<string, IResourceItem> = new Map()
}

class ArrayOfObjects<T, S> implements IActionT<T> {
    f !: IFuncT<S | undefined, T>
    s: S[] = []

    performer !: Performer
    constructor(func: IFuncT<S | undefined, T>, performer: Performer) {
        this.performer = performer;
        this.f = func
    }
    actionT(t: T): void {
        let s = this.f.functT(t)
        if (s != undefined) {
            this.s.push(s)
        }
    }
    isEmptyActionT(): boolean {
        return false
    }

    public getArray(node: INodeT<T>): S[] {
        this.performer.recursiveNodeAction(node, this)
        return this.s
    }

}

class Running implements IActionT<IRunning> {
    constructor(running: boolean) {
        this.running = running
    }
    running: boolean = false
    actionT(t: IRunning): void {
        t.setRunning(this.running)
    }
    isEmptyActionT(): boolean {
        return false;
    }


}

