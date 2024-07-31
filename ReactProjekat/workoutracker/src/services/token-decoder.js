import { jwtDecode } from 'jwt-decode';


export function DecodeToken(token) {
    try {
        const decodedToken = jwtDecode(token);

        // Pristupi claim-ovima
        return {
            id: decodedToken['user_id'],    // Koristi 'user_id'
            email: decodedToken['user_email'], // Koristi 'user_email'
            name: decodedToken['user_name']  // Koristi 'user_name'
        };
    } catch (error) {
        console.error("Failed to decode token", error);
        return null;
    }
}