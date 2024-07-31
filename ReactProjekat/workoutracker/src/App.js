import * as React from 'react';
import { BrowserRouter as Router, Route,Routes} from 'react-router-dom';
import Login from './features/login/Login';
import Training from './features/training/Training';
import Register from './features/register/Register';

function App() {
  return (
    <Router>
      <Routes>
         <Route path="/" element={<Login />} />
         <Route path="training" element={<Training />} />
         <Route path="register" element={<Register />} />
      </Routes>
       </Router>
  );
}

export default App;
