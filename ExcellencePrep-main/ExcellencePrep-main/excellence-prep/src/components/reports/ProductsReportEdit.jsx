import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateProduct } from "../../servicess/ProductService";

export const ProductsReportEdit = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Product } = location.state;

  const [Id, setId] = useState(Product.Id);
  const [Name, setName] = useState(Product.Name);
  const [Price, setPrice] = useState(Product.Price);
  const [UnitsInStock, setUnitsInStock] = useState(Product.UnitsInStock);
  const [DepartmentName, setDepartmentName] = useState(Product.DepartmentName);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (Name === "" || Price === "" || UnitsInStock === "" || DepartmentName === "") {
      alert("Please fill all fields");
    } else {
      const updatedProduct = {
        ...Product,
        id: parseInt(Id),
        name: Name,
        price: parseInt(Price),
        unitsInStock: parseInt(UnitsInStock),
        departmentName: DepartmentName,
      };
      await UpdateProduct(updatedProduct);
      alert("Product Was Updated");
      navigate("/ProductAndDepartmentReportPage");
    }
  };

  const handleReturn = () => {
    navigate("/ProductAndDepartmentReportPage");
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="Id" className="frm-lbl">
            Product Code:
          </label>
          <input type="text" className="form-control" id="Id" value={Id} onChange={(event) => setId(event.target.value)} />
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
          <label htmlFor="DepartmentName" className="frm-lbl">
            Department Name:
          </label>
          <input type="text" className="form-control" id="DepartmentName" value={DepartmentName} onChange={(event) => setDepartmentName(event.target.value)} />
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
