"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
;
const loadFunctions = {
    'text': async (url) => {
        //  var ss = "http://localhost:4173/static/models/" + url
        const ss = "./static/models/" + url;
        //      new URL(ss)
        let response = await fetch(ss);
        let data = await response.text();
        if (response.ok) {
        }
        return data;
    },
    'json': async (url) => {
        let response = await fetch(url);
        let data = await response.json();
        return data;
    },
    'image': async (url) => {
        const ss = "./static/models/" + url;
        //  let ss = "/static/models/" + url1
        return new Promise((resolve, reject) => {
            let image = new Image();
            try {
                let us = new URL(ss);
                if (us.origin !== window.origin)
                    image.crossOrigin = "";
            }
            catch {
                console.log("CATCH");
            }
            image.onload = () => resolve(image);
            image.onerror = reject;
            image.src = ss;
        });
    }
};
// This is helper class to fetch resources from the webserver
// Unlike C++, we can't block the main thread till files are read, so we use promises to notify the Game Class when the resources are ready
// This class is a work in progress so expect it to be enhanced in future labs
class Loader {
    resources;
    promises;
    constructor() {
        this.resources = {};
        this.promises = [];
    }
    loadMap(resources) {
        this.result.clear();
        for (let item of resources) {
            let resource = item[1];
            let name = resource.url;
            let promise = loadFunctions[resource.type](resource.url)
                .then(data => {
                this.result.set(name, data);
                this.resources[name] = data;
                if (resource.success)
                    resource.success(name, data, resource, this);
            }).catch(reason => {
                console.error(`Failed to load ${name}: ${reason}`);
                if (resource.failure)
                    resource.failure(name, resource, this);
            });
            this.promises.push(promise);
        }
    }
    load(resources) {
        for (let name in resources) {
            let resource = resources[name];
            let promise = loadFunctions[resource.type](resource.url)
                .then(data => {
                this.resources[name] = data;
                if (resource.success)
                    resource.success(name, data, resource, this);
            }).catch(reason => {
                console.error(`Failed to load ${name}: ${reason}`);
                if (resource.failure)
                    resource.failure(name, resource, this);
            });
            this.promises.push(promise);
        }
    }
    unload(...resources) {
        for (let name of resources) {
            delete this.resources[name];
        }
    }
    clear() {
        for (let name in this.resources) {
            delete this.resources[name];
        }
    }
    async wait() {
        while (this.promises.length > 0) {
            const awaited = [...this.promises];
            this.promises.splice(0, this.promises.length);
            await Promise.all(awaited);
        }
    }
    result = new Map();
    getResult() {
        return this.result;
    }
}
exports.default = Loader;
