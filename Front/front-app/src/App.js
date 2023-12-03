import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home/Home';
import LoginPage from './pages/login/LoginPage';
import Register from './pages/register/Register';

import VolunteeringPage from './pages/volunteeringPage/VolunteeringPage'
import VolunteeringPageDetails from './pages/volunteeringPage/volunteeringPageDetails/VolunteeringPageDetails'
import CampaignDonationPage from './pages/campaingDonationPage/CampaingDonationPage';
import CampaignDonationDetailsPage from './pages/campaingDonationPage/campaingnDatailsPage/CampaignDonationDetailsPage';
import About from './pages/about/About';



function App() {
  return (
   <BrowserRouter>
    <Routes>

      <Route path='/' element= {<Home/>}/>
      <Route path='/entrar' element = {<LoginPage/>}/>
      <Route path='/cadastro' element = {<Register/>}/>
      <Route path='/sobre' element = {<About/>}/>
      
      <Route path='/voluntaraido' element = {<VolunteeringPage/>}/>
      <Route path='/voluntariado-detalhes/:id' element = {<VolunteeringPageDetails/>}/>

      <Route path='/capanhas-de-doacao' element = {<CampaignDonationPage/>}/>      
      <Route path='/campanha-detalhes/:id' element = {<CampaignDonationDetailsPage/>}/>
    </Routes>
    
   </BrowserRouter>
  
  );
}

export default App;
