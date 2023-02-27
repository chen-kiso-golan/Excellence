import React, { useState } from "react";
import { ChooseClassRow } from "./ChooseClassRow";
import { addProductToDB } from "../../servicess/ProductService";

function Product(props) {
  const [formData, setFormData] = useState({
    ProductName: "",
    ProductPrice: "",
    UnitsInStock: "",
    ClassName: "",
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
      ClassName: "",
    });
  }

  const handleAddData = async () => {
    let json = formData;
    await addProductToDB(json);
  };

  const chooseClass = (data) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      ClassName: data,
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
          <ChooseClassRow chooseClass={chooseClass} />
        </div>
        <button className="form--submit btn btn-danger">Sign up</button>
      </form>
    </div>
  );
}

export default Product;
