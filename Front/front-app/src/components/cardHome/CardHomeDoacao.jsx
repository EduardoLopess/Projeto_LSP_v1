import '../cardHome/CardHome.css'
import { Link } from 'react-router-dom';

const CardCardHomeDoacao = () => {
   
    const path = require('../../assets/doacao.png')

    
    return(
        <div className="card-conteudo">
            <img src={path} alt="Doação"/>
            <hr/>
            <h1>Campanhas de doações</h1>
            <hr/>
            <div className="descrisao">
                <p>Explore diversas campanhas de doação em andamento na sua região. Descubra como você pode fazer a diferença contribuindo com recursos financeiros, doando itens essenciais ou participando de eventos beneficentes. Além disso, encontre locais de coleta de materiais próximos a você.
                Seja parte ativa da comunidade, ajudando a fornecer os recursos necessários para causas importantes e impactar positivamente a vida das pessoas ao seu redor.</p>
            </div>
            <Link to="/capanhas-de-doacao">
                <button>Explorar</button>
            </Link>
        </div>

    );
}

export default CardCardHomeDoacao


