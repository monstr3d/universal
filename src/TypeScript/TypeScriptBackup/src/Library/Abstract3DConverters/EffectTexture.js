"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EffectTexture = void 0;
class EffectTexture {
    constructor(effects, name, material, image) {
        this.name = "";
        this.name = name;
        this.material = material;
        this.image = image;
        if (!effects.has(name)) {
            effects.set(name, this);
        }
    }
}
exports.EffectTexture = EffectTexture;
//# sourceMappingURL=EffectTexture.js.map