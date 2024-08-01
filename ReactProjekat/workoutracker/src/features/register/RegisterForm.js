import React,{useRef} from 'react'
import { useNavigate  } from 'react-router-dom';
import "./RegisterForm.css"
export default function RegisterForm() {

    const nameRef=useRef(null);
    const lastnameRef=useRef(null);
    const emailRef=useRef(null);
    const passwordRef=useRef(null);
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();
        try {
                const response = await fetch('http://localhost:5078/api/User', {
                method: 'POST',
                headers: {
                  'Content-Type': 'application/json',
                },
               body: JSON.stringify({"Name":nameRef.current.value,"Lastname":lastnameRef.current.value,"Email":emailRef.current.value,"Password":passwordRef.current.value}),
            });
            if (response.ok) {
             navigate('/')
            } 
            else if(response.status==500) {
              console.log("Register error")
              alert("User with this email already exists")
            }
          } 
          catch (error) {
              console.error('Registe error:', error);
            }    
    }
    
  return (
    <form onSubmit={handleRegister}>
    <div className="register_container">
    <h1>Register</h1>
    <label>Name:</label>
    <input type="text" ref={nameRef} required></input><br/>
    <label>Lastname:</label>
    <input type="text" ref={lastnameRef} required></input><br/>
    <label >Email:</label>
    <input type="text" ref={emailRef} required></input><br/>
    <label >Pasword:</label>
    <input type="password" ref={passwordRef} required ></input><br/>
    <button type='submit'>Register</button>
    </div>
  </form>
  )
}
