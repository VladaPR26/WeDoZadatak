import React from 'react'
import './Report.css'


export default function Report({report,id}) {
  return (
    <div className='report-container'>
      <ul>
        <li><strong>Week:</strong> {id}</li>
        <li><strong>Training durations:</strong> {report.trainingDurations}</li>
        <li><strong>Training count:</strong> {report.trainingCount}</li>
        <li><strong>Training average intensity:</strong> {report.trainingAverageIntensity}</li>
        <li><strong>Training average physical fatigue:</strong> {report.trainingAveragePhysicalFatigue}</li>
      </ul>
    </div>
  )
}
