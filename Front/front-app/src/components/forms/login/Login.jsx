import React, { useState } from 'react';
import '../login/Login.css';
import LogoLogin from '../../../assets/LOGO.svg';

const Login = (handleSuccessfulLogin ) => {
    const [loginData, setLoginData] = useState({
        email: '',
        password: ''
    });

    const handleInputChange = (e) => {
        const { id, value } = e.target;
        setLoginData({
            ...loginData,
            [id]: value
        });
    };

    const handleLogin = (e) => {
        e.preventDefault();
        const { email, password } = loginData;



        // Para este exemplo simulado de login com localStorage
        const savedFormData = JSON.parse(localStorage.getItem('formData'));
        if (savedFormData && savedFormData.email === email && savedFormData.passwordHash === password) {
            alert('Login bem sucedido!');
            // Lógica adicional após o login bem sucedido
        } else {
            alert('Falha no login. Verifique seus dados.');
        }
    };

    return (
        <div className="login-container">
            <div className='container'>
                <div className='form-image'>
                    <img src={LogoLogin} alt="Logo de Login" />
                </div>
                <div className='form'>
                    <div className='form-header'>
                        <h1>Bem Vindo(a)</h1>
                    </div>
                    <div className='input-group'>
                        <div className='input-box'>
                            <label htmlFor="email">E-mail: </label>
                            <input
                                type="text"
                                id="email"
                                placeholder="Digite seu e-mail"
                                value={loginData.email}
                                onChange={handleInputChange}
                            />
                        </div>
                        <div className='input-box'>
                            <label htmlFor="password">Senha: </label>
                            <input
                                type="password"
                                id="password"
                                placeholder="Digite sua senha"
                                value={loginData.password}
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>
                    <div className='login-button'>
                        <button onClick={handleLogin}>Entrar</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
