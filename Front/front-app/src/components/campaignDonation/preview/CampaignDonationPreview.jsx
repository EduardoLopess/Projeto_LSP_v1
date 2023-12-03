import { Link } from 'react-router-dom';

import './CampaignDonationPreview.css'; // Arquivo CSS

const CampaignDonationPreview = ({campaignDonation}) => {
    if (!campaignDonation || Array.isArray(campaignDonation)) {
        return <p>Nenhum voluntariado encontrado.</p>;
    }
    const { titleCampaing, about, typeMaterialTypeDescription} = campaignDonation;
  
    
    return (
        <div className="campaignPreview-container">
            <div className="title-campaign">
                
                <h2>{titleCampaing}</h2>
            </div>
            <div className="description-campaign">
                <h4>Sobre.</h4>
                <p>{about}</p>
            </div>
            <div className="tipe-campaign">
                <h2>{typeMaterialTypeDescription}</h2>
            </div>
            <div className="btn-campaign-container">
                <Link to={`/campanha-detalhes/${campaignDonation.id}`}>
                    <button className="saibaMais-btn-Campaign">Saber mais</button>
                </Link>
            </div>
        </div>
    );
}

export default CampaignDonationPreview;
