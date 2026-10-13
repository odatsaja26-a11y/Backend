
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "./Authentication/Login/Login";

function App() {
  return (
    <Routes>
      <Route
        path="/"
        element={<Navigate to="/User/Login" replace />}
      />
      <Route
        path="/User/Login"
        element={<Login />}
      />
    </Routes>
  );
}

export default App;
