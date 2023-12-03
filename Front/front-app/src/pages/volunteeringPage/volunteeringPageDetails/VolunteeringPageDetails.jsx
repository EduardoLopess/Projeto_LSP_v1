import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from "../../../components/header/Header";
import { getVolunteeringById } from "../../../components/volunteering/detailsVolunteering/VolunterringDetailsLogic_api";
import '../volunteeringPageDetails/VolunteeringPageDetails.css';
import VolunteeringDetails from '../../../components/volunteering/detailsVolunteering/VolunteeringDetails';

const VolunteeringPageDetails = () => {
    const { id } = useParams();
    const [volunteeringDetails, setVolunteeringDetails] = useState(null);

    useEffect(() => {
        const fetchVolunteeringDetails = async () => {
            try {
                const details = await getVolunteeringById(id);
                setVolunteeringDetails(details);
            } catch (error) {
                console.error("Erro ao buscar detalhes do voluntariado:", error);
            }
        };

        fetchVolunteeringDetails();
    }, [id]);

    return (
        <>
            <Header />
            <div className="title-listagem">
                <h2>Detalhes sobre o voluntariado.</h2>
            </div>
            <div className="details-container">
                {volunteeringDetails ? (
                    <VolunteeringDetails volunteering={volunteeringDetails} />
                ) : (
                    <p>Carregando detalhes do voluntariado...</p>
                )}
            </div>
        </>
    );
};

export default VolunteeringPageDetails;
