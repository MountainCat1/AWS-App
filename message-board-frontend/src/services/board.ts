
export function useGetMessages() {
    const apiUri = process.env.REACT_APP_API_URL;
    console.log(apiUri)
    const endpoint = new URL('/board/all', apiUri).href


    return async () => {
        const response = await fetch(endpoint);

        return await response.json();
    }
}