"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReferenceFrameGameAction = void 0;
const AbstractGameAction_1 = require("../../Game/Abstract/AbstractGameAction");
const AbstractSceneGameAction_1 = require("../../Game/GameActions/AbstractSceneGameAction");
const ReferenceFrame_1 = require("../../Motion6D/ReferenceFrame");
const Game3DPerformer_1 = require("../Game3DPerformer");
class ReferenceFrameGameAction extends AbstractGameAction_1.AbstractGameAction {
    constructor(frame, name, factory) {
        super(name, factory);
        this.mPerformer = new Game3DPerformer_1.Game3DPerformer();
        this.typeName = "ReferenceFrameGameAction";
        this.types.push("ISceneObjectActionHolder");
        this.types.push("ReferenceFrameGameAction");
        this.frame = frame;
    }
    getSceneObjectAction() {
        return this.holder;
    }
    createHolder(obj) {
        this.holder = new RotationAction(obj, this.frame);
    }
    functT(s) {
        this.createHolder(s);
        return this.getSceneObjectAction();
    }
}
exports.ReferenceFrameGameAction = ReferenceFrameGameAction;
class RotationAction extends AbstractSceneGameAction_1.AbstractSceneGameAction {
    constructor(object, frame) {
        super(object, object.getConsumerFactory());
        this.relative = new ReferenceFrame_1.ReferenceFrame();
        this.motionPerformer = new Game3DPerformer_1.Game3DPerformer();
        this.typeName = "RotationAction";
        this.types.push("RotationAction");
        this.object = object;
        if (frame != undefined) {
            var fr = this.motionPerformer.getOwnFrame(frame);
            if (fr != undefined)
                this.baseFrame = fr;
        }
        var bf = this.motionPerformer.getOwnFrame(object);
        if (bf != undefined)
            this.target = bf;
    }
    action() {
        this.motionPerformer.getRelativeFrame(this.baseFrame, this.target, this.relative);
    }
    isEmptyAction() {
        return (this.baseFrame == undefined) || (this.target == undefined);
    }
    getActionSceneAdditionalObject() {
        return this.relative;
    }
}
//# sourceMappingURL=ReferenceFrameGameAction.js.map