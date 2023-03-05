import React from "react";
import { ProductsReportRow } from "./ProductsReportRow";
import { DepartmentReportRow } from "./DepartmentReportRow";

function ProductAndDepartmentReport(props) {
  return (
    <>
      <h1>All Products Report:</h1>
      <br />
      <table className="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Name</th>
            <th scope="col">Price</th>
            <th scope="col">Units In Stock</th>
            <th scope="col">Department Name</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <ProductsReportRow />
        </tbody>
      </table>
      <br />
      <br />
      <h1>All Departments Report:</h1>
      <br />
      <table className="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Department Name</th>
            <th scope="col">Department Description</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <DepartmentReportRow />
        </tbody>
      </table>
    </>
  );
}

export default ProductAndDepartmentReport;
