import './MessageSendInput.css'

import {ChangeEvent, useState} from "react";
import { KeyboardEvent } from 'react';

export interface MessageSendInputProps {
    handleMessageSend? : ((message : string) => void)
}

export default function MessageSendInput(props : MessageSendInputProps) {
    const [message, setMessage] = useState("");


    function handleChange(event : ChangeEvent) {
        setMessage((event.target as HTMLInputElement).value);
    }

    const handleKeyboardEvent = (event: KeyboardEvent) => {
        // Do something
        if(event.key === "Enter"){
            if(props.handleMessageSend !== undefined)
                props.handleMessageSend(message);

            setMessage("");
        }
    };

    return (<>
        <input onKeyDown={handleKeyboardEvent} className={'board-message-list-input'} value={message} onChange={handleChange}/>
    </>)


}