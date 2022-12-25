import {BoardMessageDto} from "../dto/boardMessage";
import {CreateBoardMessageDto} from "../dto/CreateBoardMessageDto";

export function useGetMessagesApi(): () => Promise<BoardMessageDto[]> {
    const apiUri = process.env.REACT_APP_API_URL;
    const endpoint = new URL('/board/all', apiUri).href

    return async () => {
        const response = await fetch(endpoint);
        const responseJson = await response.json();

        return await responseJson as BoardMessageDto[];
    }
}

export function usePostMessagesApi(): (postData : CreateBoardMessageDto) => Promise<BoardMessageDto[]> {
    const apiUri = process.env.REACT_APP_API_URL;
    const endpoint = new URL('/board/post', apiUri).href

    return async (postData : CreateBoardMessageDto) => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(postData)
        };

        const response = await fetch(endpoint, requestOptions);
        const responseJson = await response.json();

        return await responseJson as BoardMessageDto[];
    }
}