import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import OrbitalInput from './OrbitalInput.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <OrbitalInput />
  </StrictMode>,
)
