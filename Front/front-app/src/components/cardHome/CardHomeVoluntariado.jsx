import '../cardHome/CardHome.css'
import { Link } from "react-router-dom";

const CardCardHomeVoluntariado = () => {
    const path = require('../../assets/voluntariado.png');
    
    
    return(
        <div className="card-conteudo">
            <img src={path} alt="Voluntariado"/>
            <hr/>
            <h1>Voluntariado</h1>
            <hr/>
            <div className="descrisao">
                <p>Descubra uma ampla gama de oportunidades de voluntariado em sua região. Seja parte ativa de causas significativas, oferecendo seu tempo, habilidades e paixão para fazer a diferença na comunidade.
                Explore oportunidades que se alinhem aos seus interesses e valores. Envolva-se em projetos que impactam positivamente a sociedade, desde atividades sociais e ambientais até programas educacionais e de saúde.</p>
            </div>
            <Link to="/voluntaraido">
                <button>Explorar</button>
            </Link>
        </div>

    );
}
export default CardCardHomeVoluntariado