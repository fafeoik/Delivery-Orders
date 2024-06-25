import Input from '@mui/joy/Input';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import Button from '@mui/joy/Button'

export default function CreateOrderForm() {
    return (
        <form className="w-full flex flex-col gap-3">
                    <h3 className="font-bold text-xl">Создание заказа</h3>
                    <Input placeholder="Город отправителя" />
                    <Input placeholder="Адрес отправителя" />
                    <Input placeholder="Город получателя" />
                    <Input placeholder="Адрес получателя" />
                    <Input placeholder="Вес груза" />
                    <DatePicker label="Дата забора груза" />
                    <Button color="success" size="lg" variant="soft">Создать</Button>
                </form>
    );
}