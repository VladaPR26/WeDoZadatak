import React,{useRef} from 'react'
import './AddTraining.css'
import Cookies from 'js-cookie';
import { DecodeToken } from '../../services/token-decoder';

export default function AddTraining() {

    const nameRef=useRef(null)
    const descriptionRef=useRef(null)
    const intensityRef=useRef(null)
    const physicalFatigueRef=useRef(null)
    const caloriesBurnedRef=useRef(null)
    const exerciseRef=useRef(null)
    const dateRef=useRef(null)
    const hhRef=useRef(null)
    const mmRef=useRef(null)
    const ssRef=useRef(null)

    const handleBlur = (ref) => {
        let value = ref.current.value;
        if (value.length === 1) {
          value = '0' + value;
        }
        ref.current.value = value;
      };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (hhRef.current) handleBlur(hhRef);
        if (mmRef.current) handleBlur(mmRef);
        if (ssRef.current) handleBlur(ssRef);

        const hours = hhRef.current ? hhRef.current.value || '00' : '00';
        const minutes = mmRef.current ? mmRef.current.value || '00' : '00';
        const seconds = ssRef.current ? ssRef.current.value || '00' : '00';
        

        const durationTime = `${hhRef.current.value}:${mmRef.current.value}:${ssRef.current.value}`
        const exerciseValue = exerciseRef.current ? parseInt(exerciseRef.current.value, 10):null
        console.log(durationTime)
        const date=new Date(dateRef.current.value).toISOString()
        console.log(date)
        const token=Cookies.get('token');
        const userInfo=DecodeToken(token)
        console.log(userInfo.id)
        console.log(exerciseRef.current.value)
        try {
                const response = await fetch('http://localhost:5078/api/Training', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json',
                },
               body: JSON.stringify({"UserId":userInfo.id,"Name":nameRef.current.value,"Description":descriptionRef.current.value,"Intensity":intensityRef.current.value,"PhysicalFatigue":physicalFatigueRef.current.value, "CaloriesBurned":caloriesBurnedRef.current.value,"DurationTime":durationTime,"Exercise":exerciseValue,"Date":date }),
            });
            if (response.ok) {
                alert("Succsessfuly added training")
            } 
            else if(response.status==400) {
              console.log("Add training error")
            }
          } 
          catch (error) {
              console.error('Add training:', error);
            }    
    }

  return (
    <form onSubmit={handleSubmit}>
        <div className='addtraining-container'>
            <label>Name: </label>
            <input ref={nameRef} type='text' required></input>
            <label>Descripton: </label>
            <input ref={descriptionRef} type='text'></input>
            <label>Intensity: </label>
            <input ref={intensityRef} type='number' min='0' max='10' required></input>
            <label>Physical fatigue: </label>
            <input ref={physicalFatigueRef} type='number' min='0' max='10' required></input>
            <label>Calories burned: </label>
            <input ref={caloriesBurnedRef} type='number' required></input>
            <div className='durationtime-container'>
                <label>Duration Time: </label><br/>
                <label className='durationtime-input' >HH: </label>
                <input ref={hhRef} className='durationtime-input' type='number' min='0' required defaultValue="0"></input>
                <label className='durationtime-input' >MM: </label>
                <input ref={mmRef} className='durationtime-input' type='number' min='0' max='59' defaultValue="0"></input>
                <label className='durationtime-input' >SS: </label>
                <input ref={ssRef} className='durationtime-input' type='number' min='0' max='59' required defaultValue="0"></input>
            </div>
            <label>Exercise: </label>
            <select ref={exerciseRef} className='exercise-input'>
                <option value="0">Kardio</option>
                <option value="1">Flexibility</option>
                <option value="2">Strength</option>
                <option value="3">Endurance</option>
                <option value="4">Balance</option>
                <option value="5">HighIntensity</option>
                <option value="6">Weight</option>
            </select><br/>
            <label>Date: </label>
            <input ref={dateRef} type='date' required></input>
            <button type='submit'>Add training</button>
        </div>
    </form>
  )
}
