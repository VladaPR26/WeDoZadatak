import React,{useRef,useState} from 'react'
import { DecodeToken } from '../../services/token-decoder';
import Cookies from 'js-cookie';
import Report from './Report';

export default function Reports() {
  const[reports,setReports]=useState({}); 
  const monthRef=useRef(null);
     
    const handleChange = async (e) => {
        try {
            const token=Cookies.get('token');
            const userInfo=DecodeToken(token);
            const url='http://localhost:5078/api/Training/calculate'
            const response = await fetch(url, {
              method: 'POST',
              headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
              },
              body: JSON.stringify({"month":monthRef.current.value,"userId":userInfo.id}),
            });
            if (response.ok) {
              const data = await response.json();
              setReports(data.report);
            } 
            else if(response.status===400) {
             console.log("Calculation error")
              
            }
          } 
          catch (error) {
              console.error('Calculation error:', error);
            }    
    }

    let content
    const check=(Object.keys(reports).length === 0)
    if(!check){
      content=Object.entries(reports).map(([key, report]) => (
        <Report key={key} report={report} id={key} />
        ))
    }else{
      content=(<h3>No treainings in selected month</h3>)
    }

  return (
    <div>
        <select ref={monthRef} onChange={handleChange}>
            <option value="">Izaberite mesec</option>
            <option value="1">January</option>
            <option value="2">February</option>
            <option value="3">March</option>
            <option value="4">April</option>
            <option value="5">May</option>
            <option value="6">June</option>
            <option value="7">July</option>
            <option value="8">August</option>
            <option value="9">Septembar</option>
            <option value="10">October</option>
            <option value="11">November</option>
            <option value="12">December</option>
        </select>
        <div>
         {content}
        </div>
    </div>
  )
}
