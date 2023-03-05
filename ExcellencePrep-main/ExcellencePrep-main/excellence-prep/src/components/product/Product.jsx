import React, { useState } from "react";
import { ChooseDepartmentRow } from "./ChooseDepartmentRow";
import { addProductToDB } from "../../servicess/ProductService";

function Product(props) {
  const [formData, setFormData] = useState({
    ProductName: "",
    ProductPrice: "",
    UnitsInStock: "",
    DepartmentName: "",
  });

  function handleChange(event) {
    const { name, value, type, checked } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: type === "checkbox" ? checked : value,
    }));
  }

  function handleSubmit(event) {
    event.preventDefault();
    if (formData.ProductName === "" || formData.ProductPrice === "" || formData.UnitsInStock === "") {
      console.log("fill all the filldes");
      return;
    } else {
      handleAddData();
      console.log("dats was sent");
    }
    setFormData({
      ProductName: "",
      ProductPrice: "",
      UnitsInStock: "",
      DepartmentName: "",
    });
  }

  const handleAddData = async () => {
    let json = formData;
    await addProductToDB(json);
  };

  const chooseDepartment = (data) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      DepartmentName: data,
    }));
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="ProductName" className="frm-lbl">
            Product Name:
          </label>
          <input type="text" placeholder="Enter Product Name" className="form-control" name="ProductName" onChange={handleChange} value={formData.ProductName} />
        </div>
        <div className="form-group">
          <label htmlFor="ProductPrice" className="frm-lbl">
            Product Price:
          </label>
          <input type="number" placeholder="Enter Product Price" className="form-control" name="ProductPrice" onChange={handleChange} value={formData.ProductPrice} />
        </div>
        <div className="form-group">
          <label htmlFor="UnitsInStock" className="frm-lbl">
            Units In Stock:
          </label>
          <input type="number" placeholder="Enter Units In Stock" className="form-control" name="UnitsInStock" onChange={handleChange} value={formData.UnitsInStock} />
        </div>
        <div className="form-group">
          <ChooseDepartmentRow chooseDepartment={chooseDepartment} />
        </div>
        <button className="form--submit btn btn-danger">Sign up</button>
      </form>
    </div>
  );
}

export default Product;
