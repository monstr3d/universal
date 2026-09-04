
export interface ResourceInformation {
    url: string,
    type: 'text' | 'json' | 'image',
    success?: (name: string, data: any, resource: ResourceInformation, loader: Loader) => void
    failure?: (name: string, resource: ResourceInformation, loader: Loader) => void
};

const loadFunctions = {
    'text': async (url: string): Promise<any> => {
        //  var ss = "http://localhost:4173/static/models/" + url
        const ss = "./static/models/" + url
  //      new URL(ss)
        let response = await fetch(ss)

        let data = await response.text();
        if (response.ok) {
        }
        return data;
    },
    'json': async (url: string): Promise<any> => {
        let response = await fetch(url);
        let data = await response.json();
        return data;
    },
    'image': async (url: string): Promise<any> => {
        const ss = "./static/models/" + url
      //  let ss = "/static/models/" + url1
        return new Promise((resolve, reject) => {
            let image = new Image();
            try {
                let us = new URL(ss)
            if (us.origin !== window.origin)
                    image.crossOrigin = "";
            }
            catch
            {
                console.log("CATCH")
            }
            image.onload = () => resolve(image);
            image.onerror = reject;
            image.src = ss;
        });
    }
}

// This is helper class to fetch resources from the webserver
// Unlike C++, we can't block the main thread till files are read, so we use promises to notify the Game Class when the resources are ready
// This class is a work in progress so expect it to be enhanced in future labs
export default class Loader {
    resources: { [name: string]: any };
    promises: Promise<void>[];

    public constructor() {
        this.resources = {}
        this.promises = [];
    }

    public loadMap(resources: Map<string, ResourceInformation>): void {
        this.result.clear()
        for (let item of resources) {
            let resource = item[1]
            let name = resource.url
            let promise = loadFunctions[resource.type](resource.url)
                .then(
                    data => {
                        this.result.set(name, data)
                        this.resources[name] = data;
                        if (resource.success) resource.success(name, data, resource, this);
                    }
                ).catch(
                    reason => {
                        console.error(`Failed to load ${name}: ${reason}`);
                        if (resource.failure) resource.failure(name, resource, this);
                    }
                )
            this.promises.push(promise)
        }
    }



    public load(resources: { [name: string]: ResourceInformation }) {
        for (let name in resources) {
            let resource = resources[name];
            let promise = loadFunctions[resource.type](resource.url)
                .then(
                    data => {
                        this.resources[name] = data;
                        if (resource.success) resource.success(name, data, resource, this);
                    }
                ).catch(
                    reason => {
                        console.error(`Failed to load ${name}: ${reason}`);
                        if (resource.failure) resource.failure(name, resource, this);
                    }
                )
            this.promises.push(promise)
        }
    }

    public unload(...resources: string[]) {
        for (let name of resources) {
            delete this.resources[name];
        }
    }

    public clear() {
        for (let name in this.resources) {
            delete this.resources[name];
        }
    }

    public async wait() {
        while (this.promises.length > 0) {
            const awaited = [...this.promises];
            this.promises.splice(0, this.promises.length);
            await Promise.all(awaited);
        }
    }
    result: Map<string, any> = new Map()

    public getResult(): Map<string, any> {
        return this.result
    }
}