import React from "react";
import './InputError.scss'

const InputError = ({message}) => {
    return(
        <p className="input-error">{message}</p>
    )
}

export default InputError