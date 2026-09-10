import { RigidBody, CapsuleCollider } from "@react-three/rapier";
import { useRef } from "react";
import { getCoord, Coord } from "./Coord";
import { useFrame } from "@react-three/fiber";
import { getActor, getActImmelman, usePersonControls } from "./hooks";
import { Accessor } from "three/examples/jsm/transpiler/AST.js";
import { Actor } from "./Actor";
import { IUpdateRef } from "./ReactWebGL/Interfaces/IUpdateRef";
import { ActImmelman } from "./ActImmelman";


let actor: Actor = getActor()
let actImmelmann: ActImmelman = getActImmelman()

let update: IUpdateRef = actor.getMeshUpdaterPosition("pLANE")

let updateI: IUpdateRef = actImmelmann.getMeshUpdaterPositionCalibrated("Plane", 1, 2, 0, 1)

let b: boolean = true

let i: number = 0

export const Test = () => {
    const { forward, backward, left, right, jump } = usePersonControls();

    const testRef = useRef()
    const meshRef = useRef()
    const immRef = useRef()
/* useFrame((state) => {
        if (testRef.current === undefined) return
        if (b) {
            console.log(testRef.current)
            console.log(testRef.current.position)
            console.log(testRef.current.angvel)
     }
        b = false
    })*/
    useFrame((state) => {
        if (meshRef.current === undefined) return
        if (b) {
        }
        b = false
        ++i
        actor.setMotion(forward, backward, left, right, jump)
        update.updateRef(meshRef)
        if (immRef.current !== undefined)      updateI.updateRef(immRef)
       /* meshRef.current.position.x = actor.getX()
        meshRef.current.position.y = actor.getY()
        meshRef.current.quaternion.w = 0.4
        meshRef.current.quaternion.x = 0.4
        meshRef.current.quaternion.y= 0.4
        meshRef.current.quaternion.z = 0.4*/


    })
    
     return (
         <RigidBody ref={testRef} >
             <mesh position={[0, 0, 0]} ref={meshRef}  castShadow receiveShadow>
                  <meshStandardMaterial color="white" />
                  <boxGeometry />
             </mesh>
             <mesh position={[0, 0, 0]} ref={immRef} castShadow receiveShadow>
                 <meshStandardMaterial color="green" />
                 <boxGeometry />
             </mesh>

          </RigidBody>
        )
    }

