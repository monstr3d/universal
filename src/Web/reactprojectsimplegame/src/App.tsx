import { PointerLockControls, Sky } from "@react-three/drei";
import { Ground } from "./Ground.jsx";
import { Physics, RigidBody } from "@react-three/rapier";
import { Player } from "./Player";
import { create } from "zustand";


export const usePointerLockControlsStore = create(() => ({
    isLock: false,
}));



export const App = () => {
    return (
        <>
            <Sky sunPosition={[100, 20, 100]} />
            <ambientLight intensity={1.5} />
            <Player/>
          </>
    )
}

export default App