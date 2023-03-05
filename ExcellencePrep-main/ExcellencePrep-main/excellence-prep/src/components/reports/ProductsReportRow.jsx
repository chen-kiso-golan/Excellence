import React, { useState, useEffect } from "react";
import { getAllProductsFromDB, deleteProduct } from "../../servicess/ProductService";
import { useNavigate } from "react-router-dom";

export const ProductsReportRow = (props) => {
  const [AllProducts, setAllProducts] = useState([]);

  const navigate = useNavigate();

  const getDB = async () => {
    let result = await getAllProductsFromDB();
    setAllProducts(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handleEdit = (Product) => {
    navigate("/ProductsReportEditPage", {
      state: {
        Product,
      },
    });
  };

  const handleDelete = async (Code) => {
    await deleteProduct(Code);
    getDB();
  };

  return (
    <>
      {AllProducts.length > 0 ? (
        AllProducts.map((Product) => {
          let { Code, Name, Price, UnitsInStock, DepartmentName } = Product;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{Name}</td>
                <td>{Price}</td>
                <td>{UnitsInStock}</td>
                <td>{DepartmentName}</td>
                <td>
                  <button
                    className="btn btn-warning"
                    onClick={() => {
                      handleEdit(Product);
                    }}
                  >
                    Edit Product
                  </button>
                </td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => {
                      handleDelete(Product.Code);
                    }}
                  >
                    Remove Product
                  </button>
                </td>
              </tr>
            </>
          );
        })
      ) : (
        <>
          {/* <h1>There are no Products.</h1> */}
          <tr>
            <th scope="row">?</th>
            <td>?</td>
            <td>?</td>
            <td>?</td>
            <td>?</td>
            <td>
              <button
                className="btn btn-warning"
                onClick={() => {
                  handleEdit(Product);
                }}
              >
                Edit Product
              </button>
            </td>
            <td>
              <button
                className="btn btn-danger"
                onClick={() => {
                  handleDelete(Product.Code);
                }}
              >
                Remove Product
              </button>
            </td>
          </tr>
        </>
      )}
    </>
  );
};
