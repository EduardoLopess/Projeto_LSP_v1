import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import '../header/Header.css';

const Header = () => {
    const path = require('../../assets/logo.png');
    const location = useLocation();
    const [menuActive, setMenuActive] = useState(false);

    const handleMenuClick = () => {
        setMenuActive(!menuActive);
    };

    const closeMenu = () => {
        setMenuActive(false);
    };

    return (
        <header>
            <div className='logo'>
                <img src={path} alt="Logo do site" />
                <p>Mão Solidária</p>
                <p>Juntos somos mais fortes.</p>
            </div>
            <ul className={`list-menu ${menuActive ? 'active' : ''}`}>
                <li className={`item ${location.pathname === '/' ? 'active' : ''}`}>
                    <Link to="/" onClick={closeMenu}>Página Inicial</Link>
                </li>
                <li className={`item ${location.pathname === '/sobre' ? 'active' : ''}`}>
                    <Link to="/sobre" onClick={closeMenu}>Sobre</Link>
                </li>
                
                <li className="item">
                    <Link to="/voluntaraido" onClick={closeMenu}>Voluntariados</Link>
                </li>
                <li className="item">
                    <Link to="/capanhas-de-doacao" onClick={closeMenu}>Campanhas</Link>
                </li>
                
                <li className={`item ${location.pathname === '/entrar' ? 'active' : ''}`}>
                    <Link to="/entrar" onClick={closeMenu}>Entrar</Link>
                </li>
                <li className={`item ${location.pathname === '/cadastro' ? 'active' : ''}`}>
                    <Link to="/cadastro" onClick={closeMenu}>Cadastrar-se</Link>
                </li>
            </ul>
            <div className="menu-icon" onClick={handleMenuClick}>
                {menuActive ? (
                    <div className="close-icon" onClick={closeMenu}>
                        &#10006;
                    </div>
                ) : (
                    <div>
                        <div className="bar"></div>
                        <div className="bar"></div>
                        <div className="bar"></div>
                    </div>
                )}
            </div>
        </header>
    );
}

export default Header;
