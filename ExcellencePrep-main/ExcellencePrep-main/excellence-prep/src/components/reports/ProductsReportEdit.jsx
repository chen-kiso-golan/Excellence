import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateProduct } from "../../servicess/ProductService";

export const ProductsReportEdit = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Product } = location.state;

  const [Code, setCode] = useState(Product.Code);
  const [Name, setName] = useState(Product.Name);
  const [Price, setPrice] = useState(Product.Price);
  const [UnitsInStock, setUnitsInStock] = useState(Product.UnitsInStock);
  const [ClassName, setClassName] = useState(Product.ClassName);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (Name === "" || Price === "" || UnitsInStock === "" || ClassName === "") {
      alert("Please fill all fields");
    } else {
      const updatedProduct = {
        ...Product,
        Code: parseInt(Code),
        Name: Name,
        Price: parseInt(Price),
        UnitsInStock: parseInt(UnitsInStock),
        ClassName: ClassName,
      };
      await UpdateProduct(updatedProduct);
      alert("Product Was Updated");
      navigate("/ProductAndClassReportPage");
    }
  };

  const handleReturn = () => {
    navigate("/ProductAndClassReportPage");
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="Code" className="frm-lbl">
            Product Code:
          </label>
          <input type="text" className="form-control" id="Code" value={Code} onChange={(event) => setCode(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="Name" className="frm-lbl">
            Product Name:
          </label>
          <input type="text" className="form-control" id="Name" value={Name} onChange={(event) => setName(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="Price" className="frm-lbl">
            Product Price:
          </label>
          <input type="number" className="form-control" id="Price" value={Price} onChange={(event) => setPrice(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="UnitsInStock" className="frm-lbl">
            Units In Stock:
          </label>
          <input type="number" className="form-control" id="UnitsInStock" value={UnitsInStock} onChange={(event) => setUnitsInStock(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="ClassName" className="frm-lbl">
            Class Name:
          </label>
          <input type="text" className="form-control" id="ClassName" value={ClassName} onChange={(event) => setClassName(event.target.value)} />
        </div>
        <div>
          <button type="submit" className="btn btn-primary">
            Submit
          </button>
          <button type="submit" className="btn btn-danger" onClick={handleReturn}>
            Return
          </button>
        </div>
      </form>
    </div>
  );
};
