import { useState, useEffect } from 'react'
import './App.css'

function App() {
  const [sessions, setSessions] = useState(undefined)
  const updateSessions = async () => {
    const response = await fetch('https://localhost:7223/api/session')
    const data = await response.json()
    setSessions(data)
  }
  useEffect(() => {
    updateSessions()
  }, [])

  if (sessions===undefined) {
    return (
      <>
        <div>
          <a href="https://that.us" target="_blank">
            <img src="/that-conference-texas.avif" className="logo" alt="Vite logo" />
          </a>
        </div>
        <h1>THAT.us Texas 2024</h1>
        <h2>Loading...</h2>
      </>
    )
  }

  return (
    <>
      <div>
        <a href="https://that.us" target="_blank">
          <img src="/that-conference-texas.avif" className="logo" alt="Vite logo" />
        </a>
      </div>
      <h1>THAT.us Texas 2024</h1>
    </>
  )
}

export default App
