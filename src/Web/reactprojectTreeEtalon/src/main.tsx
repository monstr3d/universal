import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.scss';
import {Canvas} from "@react-three/fiber";
import UI from './UI/UI';
import App from './App';
//import UI from "@/UI/UI.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <div id="container">
        <UI />
        <Canvas camera={{ fov: 45 }} shadows>
            <App />
        </Canvas>
    </div>
  </React.StrictMode>,
)
