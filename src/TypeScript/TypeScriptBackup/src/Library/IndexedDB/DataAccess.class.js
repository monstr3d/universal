"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataAccess = void 0;
const DBAccess_class_1 = require("./DBAccess.class");
class DataAccess {
    constructor(dbName, storeName) {
        this.storeName = storeName;
        this.connection = new DBAccess_class_1.DBAccess().instance.connect(dbName, storeName);
    }
    async close() {
        const db = await this.connection;
        db.close();
    }
    async clear() {
        const db = await this.connection;
        const req = db.transaction([this.storeName], 'readwrite');
        const store = req.objectStore(this.storeName);
        store.clear();
    }
    async add(item) {
        const db = await this.connection;
        const request = db.transaction([this.storeName], 'readwrite')
            .objectStore(this.storeName)
            .add(item);
        return this.requestHandler(request);
    }
    async retrieve() {
        const db = await this.connection;
        const st = db.transaction([this.storeName], 'readonly');
        const store = st.objectStore(this.storeName);
        return new Promise((resolve, reject) => {
            this.any = reject;
            const result = [];
            store.openCursor().onsuccess = event => {
                const cursor = event.target.result;
                if (cursor) {
                    result.push(cursor.value);
                    cursor.continue();
                }
                else {
                    return resolve(result);
                }
            };
        });
    }
    async update(item) {
        const db = await this.connection;
        const request = db.transaction([this.storeName], 'readwrite')
            .objectStore(this.storeName)
            .put(item);
        return this.requestHandler(request);
    }
    async get(uid) {
        const db = await this.connection;
        const request = db.transaction([this.storeName], 'readonly')
            .objectStore(this.storeName)
            .get(uid);
        return this.requestHandler(request);
    }
    async remove(uid) {
        const db = await this.connection;
        const request = db.transaction([this.storeName], 'readwrite')
            .objectStore(this.storeName)
            .delete(uid);
        return this.requestHandler(request);
    }
    requestHandler(request) {
        return new Promise((resolve, reject) => {
            request.onsuccess = () => resolve(request.result);
            request.onerror = () => reject(request.result);
        });
    }
}
exports.DataAccess = DataAccess;
//# sourceMappingURL=DataAccess.class.js.map