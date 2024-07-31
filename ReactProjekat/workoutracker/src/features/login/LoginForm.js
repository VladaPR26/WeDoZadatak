import React,{useState,useRef} from 'react'
import { useNavigate  } from 'react-router-dom';
import Cookies from 'js-cookie';
import "./LoginForm.css"

export default function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);
    const errorLabel=useRef("")
    const [labelColor, setLabelColor] = useState('black');
    const navigate = useNavigate();

    const handleEmailChange = (e) => {
        setEmail(e.target.value);
      };
    
      const handlePasswordChange = (e) => {
        setPassword(e.target.value);
      };
    
      const handleLogin = async (e) => {
        e.preventDefault();
        try {
                const response = await fetch('http://localhost:5078/api/User/login', {
                method: 'POST',
                headers: {
                  'Content-Type': 'application/json',
                },
               body: JSON.stringify({"Email":email, "Password":password }),
            });
            if (response.ok) {
              const data = await response.json();
              Cookies.set('token', data)
              navigate('/training');
            } 
            else if(response.status==400) {
              setLabelColor('red')
              errorLabel.current="Pogresan email ili lozinka"
              
            }
          } 
          catch (error) {
              setError('An unexpected error occurred');
              console.error('Login error:', error);
            }    
    }
  return (
    <div className='login_container'>
        <h2>Login</h2>
      <div>
        <form onSubmit={handleLogin}>
          <label>
            Username:
            <input type="text" value={email} onChange={handleEmailChange} required />
          </label>
          <br />
          <label>
            Password:
            <input type="password" value={password} onChange={handlePasswordChange} required />
          </label>
          <br />
          <label style={{ color: labelColor }}>{errorLabel.current}</label>
          <button type="submit">Login</button><br/>
          <a href='register'>I don't have an account</a>

        </form>
      </div>
    </div>
  )
}
