import * as TWEEN from "@tweenjs/tween.js";
import {PointerLockControls, Sky} from "@react-three/drei";
import {useFrame} from "@react-three/fiber";
import {create} from "zustand";
import { Physics } from "@react-three/rapier";
import { Ground } from "./Ground";
import { Actor } from "./Actor";
import { getActImmelman, getActor, usePersonControls } from "./hooks";
import { ActImmelman } from "./ActImmelman";
import { Test } from "./Test"

const shadowOffset = 50;

export const usePointerLockControlsStore = create(() => ({
    isLock: false,
}));

let actor: Actor = getActor()

let actImmelmann: ActImmelman = getActImmelman()


export const App = () => {

    useFrame(() => {
        TWEEN.update();
        let t = TWEEN.now() * 0.001
        actor.actionT(t)
        actImmelmann.actionT(t)
   });

    const pointerLockControlsLockHandler = () => {
        usePointerLockControlsStore.setState({ isLock: true });
    }

    const pointerLockControlsUnlockHandler = () => {
        usePointerLockControlsStore.setState({ isLock: false });
    }

    return (
        <>
            <Sky sunPosition={[100, 20, 100]}/>
            <ambientLight intensity={1.5} />
            <directionalLight
                castShadow
                intensity={1.5}
                shadow-mapSize={4096}
                shadow-camera-top={shadowOffset}
                shadow-camera-bottom={-shadowOffset}
                shadow-camera-left={shadowOffset}
                shadow-camera-right={-shadowOffset}
                position={[100, 100, 0]}
            />
            <Physics gravity={[0, 0, 0]}>
                <Ground />
                <Test />
            </Physics>
        </>
    )
}

export default App;
