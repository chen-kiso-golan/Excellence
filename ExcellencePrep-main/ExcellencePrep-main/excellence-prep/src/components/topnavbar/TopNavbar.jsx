import React from "react";
import { Link } from "react-router-dom";
import { AddDepartmentPage, ProductPage, ProductAndDepartmentReportPage } from "../../pages/pagesIndex";

function TopNavbar() {
  return (
    <div>
      <ul className="topnavbar--menu">
        <li>
          <Link to="/AddDepartmentPage">
            <label>Add Department</label>
          </Link>
        </li>
        <li>
          <Link to="/ProductPage">
            <label>Add Product</label>
          </Link>
        </li>
        <li>
          <Link to="/ProductAndDepartmentReportPage">
            <label>Product And Department Report Page</label>
          </Link>
        </li>
      </ul>
    </div>
  );
}

export default TopNavbar;
