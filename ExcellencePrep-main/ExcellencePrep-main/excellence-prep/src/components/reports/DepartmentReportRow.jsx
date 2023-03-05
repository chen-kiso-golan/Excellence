import React, { useState, useEffect } from "react";
import { getAllDepartmentFromDB, deleteDepartment } from "../../servicess/DepartmentService";
import { useNavigate } from "react-router-dom";

export const DepartmentReportRow = (props) => {
  const [AllDepartment, setAllDepartment] = useState([]);

  const navigate = useNavigate();

  const getDB = async () => {
    let result = await getAllDepartmentFromDB();
    setAllDepartment(result);
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

  const handleDelete = async (id) => {
    await deleteDepartment(id);
    getDB();
  };

  return (
    <>
      {AllDepartment.length > 0 ? (
        AllDepartment.map((Department) => {
          let { id, name, description } = Department;
          return (
            <>
              <tr>
                <th scope="row">{id}</th>
                <td>{name}</td>
                <td>{description}</td>
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
                      handleDelete(Department.id);
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
        <>{<h1>There are no Departments.</h1>}</>
      )}
    </>
  );
};
