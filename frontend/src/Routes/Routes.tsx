import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/Registerpage/RegisterPage";
import ProtectedRoute from "./ProtectedRoute";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "",
                element: <HomePage />
            },
            {
                path: "search",
                element:
                    <ProtectedRoute>
                        <SearchPage />
                    </ProtectedRoute>
            },
            {
                path: "company/:ticker",
                element: <CompanyPage />
            },
            {
                path: "login",
                element: <LoginPage />
            }, {
                path: "register",
                element: <RegisterPage />
            }
        ]
    }
])