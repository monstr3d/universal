"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Performer = void 0;
class Performer {
    constructor() {
        this.a = 0;
        this.b = false;
        this.s = "";
    }
    enlarge(t, x, size) {
        for (let i = 0; i < size; i++)
            t.push(x);
    }
    enlarge2(t, x, row, column) {
        for (let i = 0; i < row; i++) {
            let y = [];
            t.push(y);
            for (let j = 0; i < column; j++)
                y.push(x);
        }
    }
    enlargeNumber(x, size) {
        this.enlarge(x, 0, size);
    }
    enlargeNumber2(x, row, column) {
        this.enlarge2(x, 0, row, column);
    }
    setAliasType(name, value, map, names) {
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
    SetAliasMap(map, alias) {
        for (const key in map.keys()) {
            alias.setAliasValue(key, map.get(key));
        }
    }
}
exports.Performer = Performer;
//# sourceMappingURL=Performer.js.map