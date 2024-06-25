import './App.css';
import CreateOrderForm from './components/CreateNoteForm';
import OrderButton from './components/OrderButton';
import WholeOrder from './components/WholeOrder';

function App() {
    return (
        <section className="p-8 flex flex-row justify-start items-start gap-12">
            <div className="flex flex-col w-1/3 gap-10">
                <CreateOrderForm/>
            </div>
                <ul className="flex flex-col gap-5 flex-1">
                    <li>
                        <OrderButton/>
                        <WholeOrder/>
                    </li>
                </ul>
        </section>
    );
}

export default App;