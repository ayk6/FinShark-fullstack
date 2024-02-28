
import { ToastContainer } from 'react-toastify';
import './App.css';
import "react-toastify/dist/ReactToastify.css"
import NavBar from './Components/NavBar/NavBar';
import { Outlet } from 'react-router';
import { UserProvider } from './Context/useAuth';

function App() {
  return (
    <UserProvider>
      <NavBar />
      <Outlet />
      <ToastContainer />
    </UserProvider>
  );
}

export default App;
