import { useEffect, useState } from "react";
import { getVolunteering } from "./VolunteeringPreviewLogic_api";
import VolunteeringPreview from "./VolunteeringPreview";

const VolunteeringList = () => {
    const [volunteering, setVolunteering] = useState([]);

    useEffect(() => {
        async function fetchVolunteering() {
            try {
                const data = await getVolunteering();
                setVolunteering(data);
                
            } catch (error) {
                console.error('Erro ao buscar os voluntariados: ', error);
            }
        }
        fetchVolunteering();
    }, []);

    return (
        <div>
            {volunteering && volunteering.map(singleVolunteering => (
                <VolunteeringPreview key={singleVolunteering.id} volunteering={singleVolunteering} />
            ))}
        </div>
    );
};

export default VolunteeringList;
