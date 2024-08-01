import React,{useState,useEffect} from 'react'

import Cookies from 'js-cookie';
import Training from './Training';
import { DecodeToken } from '../../services/token-decoder';
import './Trainings.css'
import { Link } from 'react-router-dom';

export default function Trainings() {
    const[trainings,setTrainings]=useState([]);

    useEffect(() => {
        const fetchData = async () => {
          try {
            const token=Cookies.get('token');
            const userInfo=DecodeToken(token);
            const url='http://localhost:5078/api/Training/'+ userInfo.id
            const response = await fetch(url, {
              method: 'GET',
              headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
              },
            });
    
            if (response.ok) {
              const data = await response.json();
              setTrainings(data.trainings)
              console.log(data)
            } else if (response.status === 400) {
              console.log('Get trainings error');
            }
          } catch (error) {
            console.error('Get trainings error:', error);
          }
        };
    
        fetchData(); 
      }, []);

      

    return (
    <div>
        <div className='trainings-container'>
        {trainings.map((training) => (
        <Training key={training.trainingId} training={training} />
        ))}
        </div>
      <Link to="/addtraining">
        <button>Add Training</button>
      </Link>
    </div>
  )
}
