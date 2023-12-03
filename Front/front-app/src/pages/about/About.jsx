import '../about/About.css'
import Header from '../../components/header/Header'



const About  = () => {
    return(
        <>
            <Header/>
            <div className="title-listagem">
                <h2>Sobre o projeto</h2>
            </div>
            <div className='about-container'>
                <div className='about-header'>
                    <h2>Autores</h2>
                    <h3>Eduardo Lopes de oliveira, Bryan da Silva Ferreira, 
                        Caio Costa de Souza Lima, Murilo Lessa de Andrades, 
                        Tiago Boff do Nascimento e Washington Felix Fernandes.
                    </h3>
                    <h2>Orientador</h2>
                    <h3>Daniel Ricardo de Souza.</h3>
                </div>

                <div className='about-title-project'>
                    <h1>SISTEMA WEB - MÃO SOLIDÁRIA</h1>
                </div>                
            
                <div className='about-container-description'>
                    <h2>INTRODUÇÃO</h2>
                    <p>
                        A "Mão Solidária" surge em resposta à crescente demanda por assistência e solidariedade na sociedade, aproveitando
                        a conveniência proporcionada pela tecnologia. O projeto utiliza uma página web com cadastros de usuários e instituições,
                        empregando linguagens de programação modernas como C# com framework .NET no backend e JavaScript e ReactJs
                        no frontend. O objetivo é conectar eficazmente aqueles que desejam contribuir, seja por meio de doações ou trabalho
                        voluntário, com indivíduos em situação de necessidade ou instituições que precisam de apoio. Além de prover assistência
                        material, as doações solidárias alimentam a alma humana com generosidade e compaixão, contribuindo para a
                        construção de um mundo onde a empatia prospera e a solidariedade se torna um elo significativo que une a humanidade.
                    </p>
                </div>
                <div className='about-container-description'>
                    <h2>OBJETIVOS</h2>
                    <p>
                        O projeto tem como objetivo abranger funcionalidades essenciais que visam proporcionar aos
                        usuários a capacidade de descobrir oportunidades de trabalho voluntário e localizar pontos de coleta
                        de doações. Além disso, o sistema oferece às instituições uma plataforma para promover suas
                        oportunidades de voluntariado e listagem dos materiais que estão necessitando de doações

                    </p>
                </div>

                <div className='about-container-description'>
                    <h2>METODOLOGIA</h2>
                    <p>
                        A gestão do projeto será conduzida por meio de reuniões com planejamentos dentro do método
                        Scrum e da aplicação do método Kanban. O Kanban fornece uma visão clara do progresso das
                        tarefas, utilizando uma abordagem visual para representar o andamento de cada atividade,
                        simplificando a gestão global do projeto. É crucial realizar atualizações constantes para garantir a
                        precisão das informações. A TOTVS (2022) destaca o Kanban como um método simples e eficaz para
                        controlar os fluxos de produção. O Scrum, uma forma de método ágil, visa auxiliar na gestão de
                        projetos com prazos curtos, melhorando a eficiência, racionalizando processos e enfocando trabalho
                        em equipe, colaboração e comunicação, segundo a mesma fonte
                    </p>
                </div>
                <div className='about-container-description'>
                    <h2>CONSIDERAÇÕES FINAIS</h2>
                    <p>
                            O sistema atende às funcionalidades básicas de cadastros e inserções de informações, porém
                        necessita de futuras implementações e melhorias para facilitar a gestão de acompanhamento dos
                        projetos cadastrados
                    </p>
                </div>
                <div className='about-container-description'>
                    <h2>TECNOLOGIAS IMPLEMENTADAS</h2>
                    <div className="technology-section">
                        <div className="technology">
                            <h3>Front-end</h3>
                            <p>
                                Para o desenvolvimento das interfaces e funcionalidades, foi utilizado o framework React.
                            </p>
                        </div>
                        <div className="technology">
                            <h3>Back-end</h3>
                            <p>
                                O back-end do projeto foi desenvolvido em C#, utilizando a biblioteca Asp.net para a criação de Web APIs.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            

        </>
       
    );
}
export default About