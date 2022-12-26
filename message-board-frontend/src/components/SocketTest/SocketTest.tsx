import {useCallback, useEffect, useState} from "react";
import useWebSocket from 'react-use-websocket';


export default function () {
    const [socketUrl, setSocketUrl] = useState('wss://localhost:7183/board/socket');

    const {
        sendMessage,
        lastMessage,
        readyState,
        getWebSocket,
        lastJsonMessage,
        sendJsonMessage
    } = useWebSocket(socketUrl);

    useEffect(() => {
        console.log(`Message got! ${lastMessage?.data}`)
    }, [lastMessage]);

    useEffect(() => {
        sendMessage('SEX', true)
    }, []);


    return (<>

    </>)
}