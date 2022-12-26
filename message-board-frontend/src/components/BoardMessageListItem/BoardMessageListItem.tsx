import {BoardMessageDto} from "../../dto/boardMessage";


interface BoardMessageListItemProps {
    dto : BoardMessageDto
}

export default function BoardMessageListItem(props : BoardMessageListItemProps){

    const date = new Date(Date.parse(props.dto.postTime));

    return (<div className={'board-message-list-item'}>
        {props.dto.text}
        <div className={'board-message-list-item-date'}>
            {date.toISOString().substring(11, 19)}
        </div>
    </div>)
}