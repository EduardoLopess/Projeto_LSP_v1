import CampaignDonationList from "../../components/campaignDonation/preview/CampaignDonationList";
import Header from "../../components/header/Header";
import '../campaingDonationPage/CampaignDonationPage.css'

const CampaignDonationPage = () =>  {
    return(
       <>
        <Header/>
        <div className="title-listagem">
            <h2>Listagem das campanhas de doações ativas no Litoral Norte.</h2>
        </div>
        <div className="campaign-page-container">
            <CampaignDonationList/>
        </div>
       
       </>
    );

}
export default CampaignDonationPage