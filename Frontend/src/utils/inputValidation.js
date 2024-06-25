export const getTextValidation = (id, labelText, placeholder) => {
    const valid = {
        id: id,
        labelText: labelText,
        validation: {
            required: {
                value: true,
                message: 'Поле обязательное для заполнения'
            }
        },
        placeholder: placeholder
    }
    return valid;
}

export const getReqValidation = () => {
    const validation = {
        required: {
            value: true,
            message: 'Поле обязательно для заполнения'
        }
    }
    return validation;
}

export const getNumValidation = () => {
    const validation = {
        required: {
            value: true,
            message: 'Поле обязательно для заполнения'
        },
        valueAsNumber: true,
        validate: {
            positive: v => v > 0 || 'Поле должно быть положительным числом'
        }
    }
    return validation;
}

export const getDateValidation = () => {
    const validation = {
        required: {
            value: true,
            message: 'Поле обязательно для заполнения'
        },
        valueAsDate: true,
        validate: {
            biggerThanNow: v => v.getTime() > Date.now() || 'Дата должна быть больше текущей даты'
        }
    }
    return validation;
}