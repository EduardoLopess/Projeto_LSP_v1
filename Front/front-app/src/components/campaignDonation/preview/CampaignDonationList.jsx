import { useEffect, useState } from "react"
import { getCampaignDonation } from "./CampaignDonationPreview_api";
import CampaignDonationPreview from "./CampaignDonationPreview";

const CampaignDonationList = () => {
    const [campaignDonation, setCampaignDonation] = useState([]);
    useEffect(() =>{
        async function fetchCampaignDonation(){
            try{
                const data = await getCampaignDonation();
                setCampaignDonation(data);
            }catch(error){
                console.error('Erro ao buscar as campanhas: ', error);
            }
        }
        fetchCampaignDonation();
    }, []);

    return(
        <div>
            {campaignDonation && campaignDonation.map(singleCampaignDonation => 
                <CampaignDonationPreview key={singleCampaignDonation.id} campaignDonation ={singleCampaignDonation}/>
            )}
        </div>
    )
}
export default CampaignDonationList