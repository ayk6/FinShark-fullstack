import axios from "axios"
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

const api = "http://localhost:5166/api/"

export const loginAPI = async (username: string, password: string) => {
    try {
        const response = await axios.post<UserProfileToken>(api + `Auth/login`, {
            username,
            password
        })
        return response
    } catch (error) {
        handleError(error)
    }
};

export const registerAPI = async (
    email: string,
    username: string,
    password: string
) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "Auth/register", {
            email: email,
            username: username,
            password: password,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};