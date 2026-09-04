import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.scss';
import {Canvas} from "@react-three/fiber";
//import UI from './UI/UI';
import App from './App';
//import UI from "@/UI/UI.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <div id="container">
        <Canvas camera={{ fov: 45 }} shadows>
            <App />
        </Canvas>
    </div>
  </React.StrictMode>,
)
//npm create vite @latest
// npm install three @react-three/fiber @react-three/drei @react-three/rapier zustand @tweenjs/tween.js