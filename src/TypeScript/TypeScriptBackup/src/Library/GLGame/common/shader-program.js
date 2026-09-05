"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// This class is responsible for handling shaders for us
// Since this is a common operation in all of our scenes, we will write in a class to reuse it every where
class ShaderProgram {
    constructor(gl) {
        this.gl = gl;
        this.program = this.gl.createProgram(); // Tell webgl to create an empty program (we will attach the shaders to it later)
    }
    dispose() {
        this.gl.deleteProgram(this.program); // Tell webgl to delete our program
    }
    // This function compiles a shader from source and if the compilation was successful, it attaches it to the program
    // source: the source code of the shader
    // type: the type of the shader, it can be gl.VERTEX_SHADER or gl.FRAGMENT_SHADER
    attach(source, type) {
        let shader = this.gl.createShader(type); // Create an empty shader of the given type
        if (shader == null)
            return false;
        this.gl.shaderSource(shader, source); // Add the source code to the shader
        this.gl.compileShader(shader); // Now, we compile the shader
        if (!this.gl.getShaderParameter(shader, this.gl.COMPILE_STATUS)) { // If the shader failed to compile, we print the error messages, delete the shader and return 
            console.error(`An error occurred compiling the ${{ [this.gl.VERTEX_SHADER]: "vertex", [this.gl.FRAGMENT_SHADER]: "fragment" }[type]} shader: ${this.gl.getShaderInfoLog(shader)}`);
            this.gl.deleteShader(shader);
            return false;
        }
        this.gl.attachShader(this.program, shader); // If it compiled successfully, we attach it to the program
        this.gl.deleteShader(shader); // Now that the shader is attached, we don't need to keep its object anymore, so we delete it.
        return true;
    }
    // After attaching all the shader we need for our program, we link the whole program
    link() {
        this.gl.linkProgram(this.program); // Tell webgl to link the programs
        if (!this.gl.getProgramParameter(this.program, this.gl.LINK_STATUS)) { // Check if the linking failed (the shaders could be incompatible)
            console.error('Unable to initialize the shader program: ' + this.gl.getProgramInfoLog(this.program));
            return false;
        }
        else {
            return true;
        }
    }
    use() {
        this.gl.useProgram(this.program);
    }
    //
    // Uniform Setters (For convenience)
    //
    // One Component Setters
    setUniform1f(name, x) {
        this.gl.uniform1f(this.gl.getUniformLocation(this.program, name), x);
    }
    setUniform1fv(name, data, srcOffset, srcLength) {
        this.gl.uniform1fv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform1i(name, x) {
        this.gl.uniform1i(this.gl.getUniformLocation(this.program, name), x);
    }
    setUniform1iv(name, data, srcOffset, srcLength) {
        this.gl.uniform1iv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform1ui(name, x) {
        this.gl.uniform1ui(this.gl.getUniformLocation(this.program, name), x);
    }
    setUniform1uiv(name, data, srcOffset, srcLength) {
        this.gl.uniform1uiv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    // Two Component Setters
    setUniform2f(name, v) {
        this.gl.uniform2f(this.gl.getUniformLocation(this.program, name), v[0], v[1]);
    }
    setUniform2fv(name, data, srcOffset, srcLength) {
        this.gl.uniform2fv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform2i(name, v) {
        this.gl.uniform2i(this.gl.getUniformLocation(this.program, name), v[0], v[1]);
    }
    setUniform2iv(name, data, srcOffset, srcLength) {
        this.gl.uniform2iv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform2ui(name, v) {
        this.gl.uniform2ui(this.gl.getUniformLocation(this.program, name), v[0], v[1]);
    }
    setUniform2uiv(name, data, srcOffset, srcLength) {
        this.gl.uniform2uiv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    // Three Component Setters
    setUniform3f(name, v) {
        this.gl.uniform3f(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2]);
    }
    setUniform3fv(name, data, srcOffset, srcLength) {
        this.gl.uniform3fv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform3i(name, v) {
        this.gl.uniform3i(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2]);
    }
    setUniform3iv(name, data, srcOffset, srcLength) {
        this.gl.uniform3iv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform3ui(name, v) {
        this.gl.uniform3ui(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2]);
    }
    setUniform3uiv(name, data, srcOffset, srcLength) {
        this.gl.uniform3uiv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    // four Component Setters
    setUniform4f(name, v) {
        this.gl.uniform4f(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2], v[3]);
    }
    setUniform4fv(name, data, srcOffset, srcLength) {
        this.gl.uniform4fv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform4i(name, v) {
        this.gl.uniform4i(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2], v[3]);
    }
    setUniform4iv(name, data, srcOffset, srcLength) {
        this.gl.uniform4iv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    setUniform4ui(name, v) {
        this.gl.uniform4ui(this.gl.getUniformLocation(this.program, name), v[0], v[1], v[2], v[3]);
    }
    setUniform4uiv(name, data, srcOffset, srcLength) {
        this.gl.uniform4uiv(this.gl.getUniformLocation(this.program, name), data, srcOffset, srcLength);
    }
    // Matrix Setters
    setUniformMatrix2fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix2fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix2x3fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix2x3fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix2x4fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix2x4fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix3fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix3fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix3x2fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix3x2fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix3x4fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix3x4fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix4fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix4fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix4x2fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix4x2fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
    setUniformMatrix4x3fv(name, transpose, data, srcOffset, srcLength) {
        this.gl.uniformMatrix4x3fv(this.gl.getUniformLocation(this.program, name), transpose, data, srcOffset, srcLength);
    }
}
exports.default = ShaderProgram;
//# sourceMappingURL=shader-program.js.map