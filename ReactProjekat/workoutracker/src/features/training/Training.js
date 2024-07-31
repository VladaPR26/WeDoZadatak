import React from 'react'
import './Training.css'

const exerciseMap={
  0: 'Kardio',
  1: 'Flexibility',
  2: 'Strength',
  3: 'Endurance',
  4: 'Balance',
  5: 'HighIntensity',
  6: 'Weight'
}

export default function Training({training}) {
  return (
    <div className="training-card">
      <h3>{training.name}</h3>
      <ul>
        <li><strong>Description:</strong> {training.description}</li>
        <li><strong>Intensity:</strong> {training.intensity}</li>
        <li><strong>PhysicalFatigue:</strong> {training.physicalFatigue}</li>
        <li><strong>CaloriesBurned:</strong> {training.caloriesBurned}</li>
        <li><strong>DurationTime:</strong> {training.durationTime}</li>
        <li><strong>Exercise:</strong> {exerciseMap[training.exercise]}</li>
        <li><strong>Date:</strong> {new Date(training.date).toLocaleDateString()}</li>
      </ul>
    </div>
  )
}
