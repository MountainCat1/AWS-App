import {BoardMessageDto} from "../dto/boardMessage";

export function useGetMessages(): () => Promise<BoardMessageDto> {
    const apiUri = process.env.REACT_APP_API_URL;
    console.log(apiUri)
    const endpoint = new URL('/board/all', apiUri).href


    return async () => {
        const response = await fetch(endpoint);
        const responseJson = await response.json();

        return await responseJson as BoardMessageDto;
    }
}