import './Home.css'
import CardHomeDoacao from "../../components/cardHome/CardHomeDoacao";
import CardCardHomeVoluntariado from "../../components/cardHome/CardHomeVoluntariado";
import Header from "../../components/header/Header"
import Message from '../../components/message/Message';

const Home = () => {
    return (
    <> 
        <Header/>
        <Message/>
        <div className="conteudo">
            <CardHomeDoacao/>
            <CardCardHomeVoluntariado/>
        </div>

    </>
    );
}

export default Home