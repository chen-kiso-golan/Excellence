import React from "react";
import { ProductsReportRow } from "./ProductsReportRow";
import { ClassReportRow } from "./ClassReportRow";

function ProductAndClassReport(props) {
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
            <th scope="col">Class Name</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <ProductsReportRow />
        </tbody>
      </table>
      <br />
      <br />
      <h1>All Class Report:</h1>
      <br />
      <table className="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Class Name</th>
            <th scope="col">Class Description</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <ClassReportRow />
        </tbody>
      </table>
    </>
  );
}

export default ProductAndClassReport;
