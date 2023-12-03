import Header from '../../components/header/Header'
import VolunteeringList from '../../components/volunteering/previewVolunteering/VolunteeringList'
import '../volunteeringPage/VolunteeringPage.css'
import Message from '../../components/message/Message'

const VolunteeringPage = () => {
    return (
        <>
            <Header/>
            <div className="title-listagem">
                <h2>Listagem dos Voluntariados Disponíveis no Litoral Norte</h2>
            </div>
            <div class="volunteeringPage-container">
                <VolunteeringList/>
                
                
            </div> 
        </>
    );
}
export default VolunteeringPage