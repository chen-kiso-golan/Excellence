import React, { useState, useEffect } from "react";
import { getAllDepartmentFromDB, deleteDepartment } from "../../servicess/DepartmentService";
import { useNavigate } from "react-router-dom";

export const DepartmentReportRow = (props) => {
  const [AllDepartment, setAllDepartment] = useState([]);

  const navigate = useNavigate();

  const getDB = async () => {
    let result = await getAllDepartmentFromDB();
    setAllDepartment(result.data);
    console.log("111" + result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handleEdit = (Department) => {
    navigate("/DepartmentReportEditPage", {
      state: {
        Department,
      },
    });
  };

  const handleDelete = async (Code) => {
    await deleteDepartment(Code);
    getDB();
  };

  return (
    <>
      {AllDepartment.length > 0 ? (
        AllDepartment.map((Department) => {
          let { Code, DepartmentName, DepartmentDescription } = Department;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{DepartmentName}</td>
                <td>{DepartmentDescription}</td>
                <td>
                  <button
                    className="btn btn-warning"
                    onClick={() => {
                      handleEdit(Department);
                    }}
                  >
                    Edit Department
                  </button>
                </td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => {
                      handleDelete(Department.Code);
                    }}
                  >
                    Remove Department
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
                  handleEdit(Department);
                }}
              >
                Edit Department
              </button>
            </td>
            <td>
              <button
                className="btn btn-danger"
                onClick={() => {
                  handleDelete(Department.Code);
                }}
              >
                Remove Department
              </button>
            </td>
          </tr>
        </>
      )}
    </>
  );
};
