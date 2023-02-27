import React from "react";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { ClassReportEditPage, AddClassPage, ProductPage, ProductAndClassReportPage, ProductsReportEditPage } from "./pages/pagesIndex";
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
            <Route path="/AddClassPage" element={<AddClassPage />}></Route>
            <Route path="/ProductPage" element={<ProductPage />}></Route>
            <Route path="/ProductAndClassReportPage" element={<ProductAndClassReportPage />}></Route>
            <Route path="/ProductsReportEditPage" element={<ProductsReportEditPage />}></Route>
            <Route path="/ClassReportEditPage" element={<ClassReportEditPage />}></Route>
          </Routes>
        </div>
      </div>
    </div>
  );
}

export default App;
