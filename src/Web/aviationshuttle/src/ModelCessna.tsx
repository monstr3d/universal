import React from 'react';
import { useGLTF } from '@react-three/drei';
import { GLTF } from 'three-stdlib';
import * as THREE from 'three'
import { useFrame } from "@react-three/fiber";
import { useRef } from "react";
import { getActor, usePersonControls } from "./hooks";
import { Actor } from "./Actor";
import { IUpdateRef } from './ReactWebGL/Interfaces/IUpdateRef';
import { rollupVersion } from 'vite';


let actor: Actor = getActor()

let updateI: IUpdateRef = actor.getMeshUpdaterPositionCalibrated("pLANE", -3, 0, 0, 1)




// 1. Define custom types for the GLTF result if you need strict typing for nodes/materials
type GLTFResult = GLTF & {
    nodes: {
        [key: string]: THREE.Mesh;
    };
    materials: {
        [key: string]: THREE.Material;
    };
};

let f: boolean = true



interface ModelProps {
    url: string;
}


export const ModelCessna: React.FC<ModelProps> = ({ url }) => {
    const { forward, backward, left, right, jump, stop } = usePersonControls();

    const modRef = useRef()
    useFrame((state) => {
        if (stop) {
        }
        
        if (modRef.current !== undefined) {
            actor.setMotion(forward, backward, left, right, jump, stop)
           
            updateI.updateRef(modRef)
        }
    })

    // 2. Load the GLB file. The hook automatically handles preloading and caching.
    const gltf = useGLTF(url) as GLTFResult;

    console.log(gltf)
    // 3. Render the scene using a primitive tag
    let ret = <primitive ref={modRef} object={gltf.scene} scale={0.08} position={[0, 0, 0]} />;
    return ret;
}

// Optional: Preload the model asset to eliminate loading delays when the component mounts
useGLTF.preload('./cessna/Cessna_208_Caravan.gltf');
