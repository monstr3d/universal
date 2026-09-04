import * as TWEEN from "@tweenjs/tween.js";
import {PointerLockControls, Sky} from "@react-three/drei";
import {useFrame} from "@react-three/fiber";
import {create} from "zustand";
import { Physics } from "@react-three/rapier";
import { Cubes } from "./Cube";
import { Ground } from "./Ground";
import { Player } from "./Player";
import { Cessna } from "./Cessna";
const shadowOffset = 50;

export const usePointerLockControlsStore = create(() => ({
    isLock: false,
}));

export const App = () => {
    let cs = new Cessna()
    console.log(cs)
    useFrame(() => {
        TWEEN.update();
    });

    const pointerLockControlsLockHandler = () => {
        usePointerLockControlsStore.setState({ isLock: true });
    }

    const pointerLockControlsUnlockHandler = () => {
        usePointerLockControlsStore.setState({ isLock: false });
    }

    return (
        <>
            <PointerLockControls onLock={pointerLockControlsLockHandler} onUnlock={pointerLockControlsUnlockHandler} />
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
            <Physics gravity={[0, -20, 0]}>
                <Ground />
                <Player />
                <Cubes />
            </Physics>
        </>
    )
}

export default App;
