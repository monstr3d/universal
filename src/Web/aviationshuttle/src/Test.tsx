import { RigidBody, CapsuleCollider } from "@react-three/rapier";
import React, { Suspense } from 'react';
import { Model } from "./Model"
import { ModelCessna } from "./ModelCessna";

//let updateI: IUpdateRef = actImmelmann.getMeshUpdaterPositionCalibrated("Plane", -1, -1, 0, 0.01)




export const Test = () => {

    var first : boolean = true
    
     return (
         <RigidBody>
             <Suspense fallback={null}>
                 <Model url='./shuttle/SpaceShuttle.gltf'> </Model>
                 <ModelCessna url='./cessna/Cessna_208_Caravan.gltf'> </ModelCessna>
             </Suspense>

          </RigidBody>
        )
    }

