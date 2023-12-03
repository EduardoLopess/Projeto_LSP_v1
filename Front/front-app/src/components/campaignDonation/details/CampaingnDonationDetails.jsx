import { Link } from "react-router-dom";
import '../details/CampaignDonation.css'

const CampaignDonationDetails = ({campaignDonation}) => {
    console.log("Dados da campanha:", campaignDonation)
    if (!campaignDonation || Array.isArray(campaignDonation)) {
        return <p>Nenhum Campanha encontrado.</p>;
    }

    const{
        titleCampaing,
        descriptionCampaingn,
        typeMaterialTypeDescription,
        priorityDonationDescription,
        contact,
      
        //data inicio
        dayStart,
        monthStart,
        yearStart,

        //data final
        dayFinish,
        monthFinish,
        yearFinish,
        addressDTO
    } = campaignDonation;



    return(

        <>
            
            <div className="volunteeringDetails-container">
                <div className="volunteeringDetails-title">
                    <h3>{titleCampaing}</h3>
                </div>
            
                <div className="description-volunteeringDetails">
                    <h4>Descricao completa da campanha.</h4>
                    <p>- {descriptionCampaingn}</p>
                    
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Tipo de material da campanha.</h4>
                    <p>&rarr; {typeMaterialTypeDescription}</p>
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Nivel de prioridade da campanha.</h4>
                    <p>&rarr; {priorityDonationDescription}</p>
                </div>
        
                <div className="type-volunteeringDetails">
                    <h4>Data de Inicio.</h4>
                    <p>&rarr; {dayStart}/{monthStart}/{yearStart}</p>
                </div>
                <div className="type-volunteeringDetails">
                    <h4>Data de encerramento.</h4>
                    <p>&rarr; {dayFinish}/{monthFinish}/{yearFinish}</p>
                </div>

                <div className="type-volunteeringDetails">
                    <h4>Contato da instituicao.</h4>
                    <p>&rarr; {contact}</p>
                </div>

                <div className="localization-container">
                    <h4>Localização: </h4>
                    <div className="col">
                        <p>Rua:  {addressDTO.street}</p>
                        <p>Bairo:  {addressDTO.neighborhood}</p>
                        <p>Numero:  {addressDTO.houseNumber}</p>
                    </div>
                    <div className="col">
                        <p>Complemento:  {addressDTO.complement}</p>
                        <p>CEP:  {addressDTO.zipCode}</p>
                        <p>Cidade: {addressDTO.city}</p>

                    </div>
                </div>
                <div className="btn-retunr">
                    <Link to='/capanhas-de-doacao'>Voltar</Link>
                </div>
               
            </div>
        </>

    ); 
}
export default CampaignDonationDetails

