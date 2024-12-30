/**
 * Gets the base URL for API requests.
 * If the environment is production, an empty string is returned.
 * Otherwise, the value of `VITE_API_URL` from the environment is returned.
 * @returns The base URL for API requests.
 * @throws An error if the base URL is not defined.
 */
export function useBaseUrl(): string {
    if (import.meta.env.PROD) {
        return "";
    }
    const baseURL = import.meta.env.VITE_API_URL;
    if (!baseURL) {
        throw new Error("Base URL is not defined");
    }
    return baseURL;
}