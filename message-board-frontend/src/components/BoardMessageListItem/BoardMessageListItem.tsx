import {BoardMessageDto} from "../../dto/boardMessage";


interface BoardMessageListItemProps {
    dto : BoardMessageDto
}

export default function BoardMessageListItem(props : BoardMessageListItemProps){

    const xd = new Date(Date.parse(props.dto.postTime));

    return (<div className={'board-message-list-item'}>
        {props.dto.text}
        <div className={'board-message-list-item-date'}>
            {xd.getHours()}:{xd.getMinutes()}
        </div>
    </div>)
}