import * as TWEEN from "@tweenjs/tween.js";
import { useFrame } from "@react-three/fiber";
import { Physics, RigidBody } from "@react-three/rapier";
import { Ground } from "./Ground";
import { Test } from "./Test";
import { Coord, getCoord } from "./Coord"
import { PointerLockControls, Sky } from "@react-three/drei";
import { getActor, Actor, getActImmelman } from "./hooks";
import { ActImmelman } from "./ActImmelman";

let actor: Actor = getActor()

let actImmelmann: ActImmelman = getActImmelman()

export const App = () => {

    useFrame(() => {
        TWEEN.update();
        let t = TWEEN.now() * 0.001
        actor.actionT(t)
        actImmelmann.actionT(t)
    })

    return (
        <>
            <Sky sunPosition={[100, 20, 100]} />
            <ambientLight intensity={1.5} />
            <Physics gravity={[0, 0, 0]}>
                <Ground />
                <RigidBody>
                    <mesh position={[3, 3, -5]}>
                        <boxGeometry />
                    </mesh>
                </RigidBody>
                <Test />
            </Physics>
        </>
    );
};

export default App
