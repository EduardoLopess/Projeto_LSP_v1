import { Link } from 'react-router-dom';
import '../detailsVolunteering/VolunteeringDetails.css'

const VolunteeringDetails = ({ volunteering }) => {
    if (!volunteering || Array.isArray(volunteering)) {
           return <p>Nenhum voluntariado encontrado.</p>;
       }

       const {
           title, 
           description,
           typeVolunteeringDescription, 
           responsibilities, benefits,
           addressDTOs,
           contact, 

            //data inicio
            dayStart,
            monthStart,
            yearStart,

            //data final
            dayFinish,
            monthFinish,
            yearFinish
           
       } = volunteering;

       

    return(
        <>
            
            <div className="volunteeringDetails-container">
                <div className="volunteeringDetails-title">
                    <h3>{title}</h3>
                </div>
            
                <div className="description-volunteeringDetails">
                    <h4>Descricao completa do voluntariado.</h4>
                    <p>- {description}</p>
                    
                </div>

                <div className="responsibilitiesBenefits-container">
                    <h4>Responsabilidades.</h4>
                    <ul>
                        {responsibilities.map((responsibility, index) => (
                            <li key={index}>&rarr; {responsibility}.</li>
                        ))}
                    </ul>
                </div>

                <div className="responsibilitiesBenefits-container">
                    <h4>Beneficios.</h4>
                    <ul>
                        {benefits.map((benefit, index) => (
                            <li key={index}>&rarr; {benefit}.</li>
                        ))}
                    </ul>
                </div>
               
                <div className="type-volunteeringDetails">
                    <h4>Área de atuação voluntariado..</h4>
                    <p>&rarr; {typeVolunteeringDescription}</p>
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Data de inicio.</h4>
                    <p>&rarr; {dayStart}/{monthStart}/{yearStart}</p>
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Data de encerramento.</h4>
                    <p>&rarr; {dayFinish}/{monthFinish}/{yearFinish}</p>
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Link de Contato</h4>
                    <p>{contact}</p>
                </div>
                <div className="localization-container">
                    <h4>Localização: </h4>
                    <div className="col">
                        <p>Rua:  {addressDTOs.street}</p>
                        <p>Bairo:  {addressDTOs.neighborhood}</p>
                        <p>Numero:  {addressDTOs.houseNumber}</p>
                    </div>
                    <div className="col">
                        <p>Complemento:  {addressDTOs.complement}</p>
                        <p>CEP:  {addressDTOs.zipCode}</p>
                        <p>Cidade: {addressDTOs.city}</p>
                    </div>
    
                </div>
                <div className='btn-sub'>
                    <Link to='/voluntaraido'>VOLTAR</Link>
                </div>
            </div>
        </>
    );
}
export default VolunteeringDetails