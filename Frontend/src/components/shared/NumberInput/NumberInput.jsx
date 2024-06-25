import React from "react";
import './NumberInput.scss'
import { useFormContext } from "react-hook-form";
import { findInputError, isFormValid } from "../../../utils/findInputErrors";
import InputError from "../InputError/InputError"

const NumberInput = ({props}) => {

    const [id, labelText, validation, step, isReadOnly, value] = props;
    const {register, formState: {errors}} = useFormContext();

    const inputError = findInputError(errors, id);
    const isValid = isFormValid(inputError)

    let clazzName = (isValid) ? 'num-field-error' :'num-field';

    return(
        <div className="num-wrapper">
            <label htmlFor={id}>{labelText}</label>
            {isValid && <InputError key={inputError.error.message} message={inputError.error.message}/>}
            {isReadOnly 
                ? <input 
                    id={id} 
                    type="number" 
                    readOnly 
                    value={value} 
                    className="num-field-disabled"/> 
                    
                : <input 
                    id={id} 
                    type="number"
                    readOnly={isReadOnly}
                    step={step} 
                    className={clazzName}
                    {...register(id, validation)}/>}

        </div>
    )
}

export default NumberInput;