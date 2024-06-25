import React from "react";
import './TextInput.scss'
import { useFormContext } from "react-hook-form";
import { findInputError, isFormValid } from "../../../utils/findInputErrors";
import InputError from "../InputError/InputError"

const TextField = ({props}) => {

    const [id, labelText, validation, placeholder, isReadOnly, value] = props;
    const {register, formState: {errors}} = useFormContext();

    const inputError = findInputError(errors, id);
    const isValid = isFormValid(inputError)

    let clazzName = (isValid) ? 'text-field-error' : 'text-field';

    return(
        <div className="text-wrapper">
            <label htmlFor={id}>{labelText}</label>
            {isValid && <InputError key={inputError.error.message} message={inputError.error.message}/>}
            {isReadOnly 
                ? <input 
                    id={id} 
                    type="text" 
                    readOnly 
                    value={value} 
                    className="text-field-disabled"/> 
                    
                : <input 
                    id={id} 
                    type="text"
                    name={id} 
                    readOnly={isReadOnly}
                    placeholder={placeholder} 
                    className={clazzName}
                    {...register(id, validation)}/>} 
        </div>
    )
}

export default TextField;