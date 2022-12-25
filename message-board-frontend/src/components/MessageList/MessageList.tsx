import {useEffect, useState} from "react";
import {BoardMessageDto} from "../../dto/boardMessage";
import {useGetMessagesApi} from "../../services/boardApi";
import BoardMessageListItem from "../BoardMessageListItem/BoardMessageListItem";
import './BoardMessageItemList.css';


export default function (){

    const [messages, setMessages] = useState<Array<BoardMessageDto>>(new Array<BoardMessageDto>)
    const getMessagesFromApi = useGetMessagesApi();

    const retrieveMessages = async () => {
        const retrievedMessages = await getMessagesFromApi();

        setMessages(messages.concat(retrievedMessages));
    }

    useEffect( () => {
        retrieveMessages().then(_ => {})
    }, [])


    return (<div className={'board-message-list'}>
        <div className={'board-message-list-header'}>Message count: {messages.length}</div>
        <div className={'board-message-list-body'}>
            {messages.map(x =>
                <BoardMessageListItem dto={x} key={x.guid}/>
            )}
        </div>
        <div className={'board-message-list-input-container'}>
            <input className={'board-message-list-input'}/>
        </div>

    </div>)
}