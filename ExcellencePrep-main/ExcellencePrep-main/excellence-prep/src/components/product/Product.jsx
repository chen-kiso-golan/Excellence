import React, { useState } from "react";
import { ChooseDepartmentRow } from "./ChooseDepartmentRow";
import { addProductToDB } from "../../servicess/ProductService";

function Product(props) {
  const [formData, setFormData] = useState({
    name: "",
    price: "",
    unitsInStock: "",
    departmentName: "",
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
    if (formData.name === "" || formData.price === "" || formData.unitsInStock === "") {
      console.log("fill all the filldes");
      return;
    } else {
      handleAddData();
      console.log("dats was sent");
    }
    setFormData({
      name: "",
      productPrice: "",
      unitsInStock: "",
      departmentName: "",
    });
  }

  const handleAddData = async () => {
    let json = formData;
    await addProductToDB(json);
  };

  const chooseDepartment = (data) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      departmentName: data,
    }));
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name" className="frm-lbl">
            Product Name:
          </label>
          <input type="text" placeholder="Enter Product Name" className="form-control" name="name" onChange={handleChange} value={formData.name} />
        </div>
        <div className="form-group">
          <label htmlFor="price" className="frm-lbl">
            Product Price:
          </label>
          <input type="number" placeholder="Enter Product Price" className="form-control" name="price" onChange={handleChange} value={formData.price} />
        </div>
        <div className="form-group">
          <label htmlFor="unitsInStock" className="frm-lbl">
            Units In Stock:
          </label>
          <input type="number" placeholder="Enter Units In Stock" className="form-control" name="unitsInStock" onChange={handleChange} value={formData.unitsInStock} />
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
