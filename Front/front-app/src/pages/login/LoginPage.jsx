import '../login/LoginPage.css'
import Login from '../../components/forms/login/Login'
import Header from '../../components/header/Header';

const LoginPage = () => {
    return (
       <>
        <Header/>
        <div className='login-container'>
            <Login/>
        </div>
       </>
        
    );
}
export default LoginPage