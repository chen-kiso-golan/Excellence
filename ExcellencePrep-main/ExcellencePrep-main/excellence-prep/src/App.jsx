import React from "react";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { DepartmentReportEditPage, AddDepartmentPage, ProductPage, ProductAndDepartmentReportPage, ProductsReportEditPage } from "./pages/pagesIndex";
import TopNavbar from "./components/topnavbar/TopNavbar";
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  return (
    <div className="App">
      <div>
        <header>
          <TopNavbar />
        </header>
        <div className="app--pageContent">
          <Routes>
            <Route path="/AddDepartmentPage" element={<AddDepartmentPage />}></Route>
            <Route path="/ProductPage" element={<ProductPage />}></Route>
            <Route path="/ProductAndDepartmentReportPage" element={<ProductAndDepartmentReportPage />}></Route>
            <Route path="/ProductsReportEditPage" element={<ProductsReportEditPage />}></Route>
            <Route path="/DepartmentReportEditPage" element={<DepartmentReportEditPage />}></Route>
          </Routes>
        </div>
      </div>
    </div>
  );
}

export default App;
