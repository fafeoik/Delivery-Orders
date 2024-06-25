import React, {StrictMode} from "react";
import {createRoot} from "react-dom/client"
import './Main.scss'

import MainPage from "./components/MainPage/MainPage";

function App() {
    return (
        <MainPage/>
    )
}

const rootElement = document.getElementById('app')
const root = createRoot(rootElement)

root.render(
    <StrictMode>
        <App />
    </StrictMode>
)