import { Link } from 'react-router-dom';
import '../previewVolunteering/VolunteeringPreview.css';

const VolunteeringPreview = ({ volunteering }) => {
    if (!volunteering || Array.isArray(volunteering)) {
        return <p>Nenhum voluntariado encontrado.</p>;
    }

    const { title, about, typeVolunteeringDescription } = volunteering;

    return (
        <div className="volunteeringPreview-container">
            <div className="title-volunteering">
                <h2>{title}</h2>
            </div>
            <div className="description-volunteering">
                <h4>Sobre</h4>
                <p>{about}</p>
            </div>
            <div className="tipe-volunteering">
                <h2>{typeVolunteeringDescription}</h2>
            </div>
            <div className="btn-volunterring-container">
                <Link to={`/voluntariado-detalhes/${volunteering.id}`}>
                    <button className="saibaMais-btn-Volunterring">Saber mais</button>
                </Link>
            </div>
        </div>
    );
};

export default VolunteeringPreview;
