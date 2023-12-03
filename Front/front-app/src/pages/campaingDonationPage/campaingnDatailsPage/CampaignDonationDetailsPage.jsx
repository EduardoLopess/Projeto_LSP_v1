import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getCampaingnById } from '../../../components/campaignDonation/details/CampaignDonationLogic_api'
import Header from "../../../components/header/Header";
import CampaignDonationDetails from '../../../components/campaignDonation/details/CampaingnDonationDetails'
import '../campaingnDatailsPage/CampaignDonationDetailsPage.css'

const CampaignDonationDetailsPage = () => {
    const { id } = useParams();
    const [campaignDonationDetails, setCampaignDonationDetails] = useState(null);
    console.log("ID recebido:", id);

    useEffect(() => {
        console.log("ID recebido:", id);  // Adicionando console.log aqui

        const fetchCampaignDonationDetails = async () => {
            try{
                const details = await getCampaingnById(id);
                setCampaignDonationDetails(details);
            }catch(error) {
                console.error("Erro ao buscar detalhes da campanha:", error);
            }
        };
        fetchCampaignDonationDetails();
    }, [id])
    console.log("Valor de campaignDonationDetails:", campaignDonationDetails)
    return(
        
        <>
            <Header/>
            <div className="title-listagem">
                <h2>Destalhes da campanha.</h2>
            </div>
            <div className="container-details-campaign">
            

                {campaignDonationDetails ? (
                    <CampaignDonationDetails campaignDonation={campaignDonationDetails}/>

                ) : (
                    <p>ERRO AO CARREGAR AS CAMOPANHAS</p>
                )}
            </div>
        </>
    );
}
export default CampaignDonationDetailsPage