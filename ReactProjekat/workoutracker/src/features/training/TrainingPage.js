import React from 'react'
import Trainings from './Trainings'
import Reports from '../report/Reports'
import Cookies from 'js-cookie';
import { useNavigate  } from 'react-router-dom';

export default function TrainingPage() {
  const navigate = useNavigate();

  const handleClick = async (e) => {
  Cookies.remove("token")
  navigate("/")
}

  return (
    <div>
      <h1>Workout Tracker</h1>
      <button onClick={handleClick}>Logout</button>
      <Trainings/>
      <Reports/>
    </div>
  )
}
