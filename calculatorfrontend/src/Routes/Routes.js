import App from "../App";
import CalculatorPage from "../Pages/CalculatorPage";
import HomePage from "../Pages/HomePage";
import { createBrowserRouter } from "react-router-dom";


export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { path: "calculation", element: <CalculatorPage /> },
        ]
    }
])