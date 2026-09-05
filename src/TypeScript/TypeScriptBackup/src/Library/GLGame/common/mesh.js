"use strict";
//This file contains a Mesh class (used to store Vertices and how to draw them)
Object.defineProperty(exports, "__esModule", { value: true });
class Mesh {
    // The constructor takes a WebGL context and a list of vertex attribute descriptors
    // It will get all the buffer names and create them then it will build the Vertex Array to read the attributes from them
    constructor(gl, descriptors) {
        this.elementCount = 0;
        this.elementType = 0;
        this.meshes = [];
        this.gl = gl;
        this.descriptors = descriptors;
        this.VBOs = {};
        const bufferNames = Array.from(new Set(descriptors.map((desc) => desc.buffer)));
        for (const bufferName of bufferNames)
            this.VBOs[bufferName] = this.gl.createBuffer();
        this.EBO = this.gl.createBuffer();
        let m = this.gl.createVertexArray();
        if (m === null)
            return;
        this.VAO = m;
        this.gl.bindVertexArray(this.VAO);
        for (let descriptor of this.descriptors) {
            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.VBOs[descriptor.buffer]);
            this.gl.enableVertexAttribArray(descriptor.attributeLocation);
            this.gl.vertexAttribPointer(descriptor.attributeLocation, descriptor.size, descriptor.type, descriptor.normalized, descriptor.stride, descriptor.offset);
        }
        this.gl.bindBuffer(this.gl.ELEMENT_ARRAY_BUFFER, this.EBO);
        this.gl.bindVertexArray(null);
    }
    // Just a dispose variable to free memory
    dispose() {
        this.gl.deleteVertexArray(this.VAO);
        this.gl.deleteBuffer(this.EBO);
        for (let bufferName in this.VBOs)
            this.gl.deleteBuffer(this.VBOs[bufferName]);
        this.VBOs = undefined;
    }
    getChildren() {
        return this.meshes;
    }
    // We will use this to fill the vertex buffer data
    setBufferData(bufferName, bufferData, usage) {
        if (this.VBOs === undefined)
            return;
        if (bufferName in this.VBOs) {
            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.VBOs[bufferName]);
            const tt = typeof bufferData;
            if (tt == "number") {
                const bd = bufferData;
                this.gl.bufferData(this.gl.ARRAY_BUFFER, bd, usage);
            }
        }
        else {
            console.error(`"${bufferName}" is not found in the buffers list`);
        }
    }
    // We will use this to fill the Elements Buffer data and know how many vertex we will draw
    setElementsData(bufferData, usage) {
        this.gl.bindBuffer(this.gl.ELEMENT_ARRAY_BUFFER, this.EBO);
        this.gl.bufferData(this.gl.ELEMENT_ARRAY_BUFFER, bufferData, usage);
        this.elementCount = bufferData.length;
        if (bufferData instanceof Uint8Array || bufferData instanceof Uint8ClampedArray)
            this.elementType = this.gl.UNSIGNED_BYTE;
        else if (bufferData instanceof Uint16Array)
            this.elementType = this.gl.UNSIGNED_SHORT;
        else if (bufferData instanceof Uint32Array)
            this.elementType = this.gl.UNSIGNED_INT;
    }
    // As the name says, this draws the mesh
    draw(mode = this.gl.TRIANGLES) {
        this.gl.bindVertexArray(this.VAO);
        this.gl.drawElements(mode, this.elementCount, this.elementType, 0);
        this.gl.bindVertexArray(null);
    }
}
exports.default = Mesh;
//# sourceMappingURL=mesh.js.map