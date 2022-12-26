import {BoardMessageDto} from "../dto/boardMessage";
import {CreateBoardMessageDto} from "../dto/CreateBoardMessageDto";
import {useState} from "react";
import useWebSocket from "react-use-websocket";

export function useGetMessagesApi(): () => Promise<BoardMessageDto[]> {
    const apiUri = process.env.REACT_APP_API_URL;
    const endpoint = new URL('/board/all', apiUri).href

    return async () => {
        const response = await fetch(endpoint);
        const responseJson = await response.json();

        return await responseJson as BoardMessageDto[];
    }
}

export function usePostMessagesApi(): (postData : CreateBoardMessageDto) => void {
    const apiUri = process.env.REACT_APP_API_URL;
    const endpoint = new URL('/board/post', apiUri).href

    return async (postData : CreateBoardMessageDto) => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(postData)
        };

        await fetch(endpoint, requestOptions);
    }
}

export function useMessageWebSocket(){
    const apiUri = process.env.REACT_APP_API_URL;
    const hostname = new URL('/board/post', apiUri).host;
    const endpoint = `wss://${hostname}/ws`;
    const [socketUrl, ] = useState(endpoint);

    const {
        sendMessage,
        lastMessage,
        readyState,
        getWebSocket,
        lastJsonMessage,
        sendJsonMessage
    } = useWebSocket(socketUrl);

    return {
        sendMessage,
        lastMessage,
        readyState,
        getWebSocket,
        lastJsonMessage,
        sendJsonMessage
    }
}