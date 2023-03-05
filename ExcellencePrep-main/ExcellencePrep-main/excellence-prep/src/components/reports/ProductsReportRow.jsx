import React, { useState, useEffect } from "react";
import { getAllProductsFromDB, deleteProduct } from "../../servicess/ProductService";
import { useNavigate } from "react-router-dom";

export const ProductsReportRow = (props) => {
  const [AllProducts, setAllProducts] = useState([]);

  const navigate = useNavigate();

  const getDB = async () => {
    let result = await getAllProductsFromDB();
    console.log("result:" + JSON.stringify(result));
    setAllProducts(result);
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

  const handleDelete = async (id) => {
    await deleteProduct(id);
    getDB();
  };

  return (
    <>
      {AllProducts.length > 0 ? (
        AllProducts.map((Product) => {
          let { id, name, price, unitsInStock, departmentName } = Product;
          return (
            <>
              <tr>
                <th scope="row">{id}</th>
                <td>{name}</td>
                <td>{price}</td>
                <td>{unitsInStock}</td>
                <td>{departmentName}</td>
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
                      handleDelete(Product.id);
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
        <>{<h1>There are no Products.</h1>}</>
      )}
    </>
  );
};
