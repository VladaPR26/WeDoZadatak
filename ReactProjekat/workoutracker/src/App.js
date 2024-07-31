import * as React from 'react';
import { BrowserRouter as Router, Route,Routes} from 'react-router-dom';
import Login from './features/login/Login';
import Training from './features/training/Training';
import Register from './features/register/Register';
import TrainingPage from './features/training/TrainingPage';

function App() {
  return (
    <Router>
      <Routes>
         <Route path="/" element={<Login />} />
         <Route path="training" element={<TrainingPage />} />
         <Route path="register" element={<Register />} />
      </Routes>
       </Router>
  );
}

export default App;
