import {useEffect, useRef, useState, UIEvent} from "react";
import {BoardMessageDto} from "../../dto/boardMessage";
import {useGetMessagesApi, useMessageWebSocket, usePostMessagesApi} from "../../services/boardApi";
import BoardMessageListItem from "../BoardMessageListItem/BoardMessageListItem";
import './BoardMessageItemList.css';
import MessageSendInput from "../MessageSendInput/MessageSendInput";


export default function () {
    const itemsContainerRef = useRef<HTMLDivElement>(null);
    const [messages, setMessages] = useState<Array<BoardMessageDto>>(new Array<BoardMessageDto>)

    const [stickToBottom, setStickToBottom] = useState<Boolean>(false);
    const [previousScrollTop, setPreviousScrollTop] = useState<number>(0);

    const getMessagesFromApi = useGetMessagesApi();
    const postMessageApi = usePostMessagesApi();

    const {
        lastMessage,
    } = useMessageWebSocket();

    const retrieveMessages = async () => {
        const retrievedMessages = await getMessagesFromApi();
        messages.splice(0);
        setMessages(messages.concat(retrievedMessages));
    }

    useEffect(() => {
        retrieveMessages().then(_ => {
        })
    }, [])

    useEffect(() => {
        retrieveMessages().then()
    }, [lastMessage])


    const messageSendHandler = (message: string) => {
        const dto = {
            text: message
        }
        postMessageApi(dto);
    }

    function onScroll(event: UIEvent<HTMLDivElement>) {
        const element = event.currentTarget;
        const direction = element.scrollTop - previousScrollTop < 0; // direction true means up, false means down

        if(direction){
            setStickToBottom(false);
        }
        else if (!direction && element.scrollHeight == element.scrollTop + element.clientHeight) {
            setStickToBottom(true);
        }

        setPreviousScrollTop(element.scrollTop);
    }

    useEffect(() => {
        if (!stickToBottom)
            return;
        if (itemsContainerRef.current === null)
            return;

        const element = itemsContainerRef.current;

        if (element.scrollHeight === element.scrollTop + element.clientHeight)
            return;

        itemsContainerRef.current.scrollTo({
            top: element.scrollTop + element.clientHeight,
            behavior: "smooth"
        })
    })

    return (<div className={'board-message-list'}>
        <div className={'board-message-list-header'}>Message count: {messages.length}</div>
        <div className={'board-message-list-body'} ref={itemsContainerRef} onScroll={onScroll}>
            {messages.map(x =>
                <BoardMessageListItem dto={x} key={x.guid}/>
            )}
        </div>
        <div className={'board-message-list-input-container'}>
            <MessageSendInput handleMessageSend={messageSendHandler}/>
        </div>
    </div>)
}