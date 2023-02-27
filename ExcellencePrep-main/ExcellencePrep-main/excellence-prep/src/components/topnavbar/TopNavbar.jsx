import React from "react";
import { Link } from "react-router-dom";
import { AddClassPage, ProductPage, ProductAndClassReportPage } from "../../pages/pagesIndex";

function TopNavbar() {
  return (
    <div>
      <ul className="topnavbar--menu">
        <li>
          <Link to="/AddClassPage">
            <label>AddClass</label>
          </Link>
        </li>
        <li>
          <Link to="/ProductPage">
            <label>ProductPage</label>
          </Link>
        </li>
        <li>
          <Link to="/ProductAndClassReportPage">
            <label>ProductAndClassReportPage</label>
          </Link>
        </li>
      </ul>
    </div>
  );
}

export default TopNavbar;
