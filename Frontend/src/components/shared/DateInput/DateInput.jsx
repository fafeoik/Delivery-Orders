import React from "react";
import './DateInput.scss'
import { useFormContext } from "react-hook-form";
import { findInputError, isFormValid } from "../../../utils/findInputErrors";
import InputError from "../InputError/InputError"
import { format } from "date-fns";

const DateInput = ({props}) => {

    const [id, labelText, validation, isReadOnly, value] = props;
    const {register, formState: {errors}} = useFormContext();

    const inputError = findInputError(errors, id);
    const isValid = isFormValid(inputError)

    return(
        <div className="date-wrapper">
            <label htmlFor={id}>{labelText}</label>
            {isValid && <InputError key={inputError.error.message} message={inputError.error.message}/>}
            
            {isReadOnly 
                ? <input 
                    type="date" 
                    readOnly
                    className="date-field"
                    value={format(value, 'yyyy-MM-dd')}/> 
                : <input 
                    type="date" 
                    className="date-field"
                    {...register(id, validation)}/>}
        </div>
    )
}

export default DateInput;