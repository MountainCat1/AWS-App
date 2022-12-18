import {useEffect, useState} from "react";
import {BoardMessageDto} from "../../dto/boardMessage";
import {useGetMessagesApi} from "../../services/boardApi";


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


    return (<>
        SEX {messages.length}
        {messages.map(x =>
             <div key={x.guid}>
                <span>{x.guid}</span>
                <span>{x.text}</span>
                <span>{x.postTime}</span>
            </div>
        )}
    </>)
}