import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
//import OrbitalInput from './OrbitalInput.tsx'
import OrbitalTest from './OrbitalTest.tsx'
import App from './App.tsx'
import { NodePage } from './NodePage.tsx'
import MyComponent from './MyComponent.tsx'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <App />
   </StrictMode>
)
