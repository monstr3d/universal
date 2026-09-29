import React from 'react';
import { useGLTF } from '@react-three/drei';
import { GLTF } from 'three-stdlib';
import * as THREE from 'three'
import { useFrame } from "@react-three/fiber";
import { useRef } from "react";
import { getActImmelman, usePersonControls } from "./hooks";
import { ActImmelman } from "./ActImmelman";
import { IUpdateRef } from './ReactWebGL/Interfaces/IUpdateRef';
import { Quaternion } from './Library/Vector3D/Quaternion';

let actImmelmann: ActImmelman = getActImmelman()

let updateI: IUpdateRef = actImmelmann.getMeshUpdaterPositionCalibratedScene("Plane", -1, -4, 0, 0.03)

let q = new Quaternion

q.W = 0
q.X = 0
q.Y = 0
q.Z = 1

//updateI = actImmelmann.getQuaternionScene("Plane", -1, -1, 0, 0.01, q)

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


export const Model: React.FC<ModelProps> = ({ url }) => {
    const modRef = useRef()
    const { forward, backward, left, right, jump, stop } = usePersonControls();

    useFrame((state) => {
        if (modRef.current !== undefined) {
         //   if (f) {
         //       console.log(modRef.current)
         //       f = false
            //  }
            updateI.updateRef(modRef)
            if (stop) {
                modRef.current.stopItself()
            }
        }
    })

    // 2. Load the GLB file. The hook automatically handles preloading and caching.
    const gltf = useGLTF(url) as GLTFResult;

    console.log(gltf)
    // 3. Render the scene using a primitive tag
    let ret = <primitive ref={modRef} object={gltf.scene} scale={0.05} position={[0, 0, 0]} />;
    return ret;
}

// Optional: Preload the model asset to eliminate loading delays when the component mounts
useGLTF.preload('./shuttle/SpaceShuttle.gltf');
