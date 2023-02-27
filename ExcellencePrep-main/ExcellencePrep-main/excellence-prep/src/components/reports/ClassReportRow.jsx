import React, { useState, useEffect } from "react";
import { getAllClassFromDB, deleteClass } from "../../servicess/ClassService";
import { useNavigate } from "react-router-dom";

export const ClassReportRow = (props) => {
  const [AllClass, setAllClass] = useState([]);

  const navigate = useNavigate();

  const getDB = async () => {
    let result = await getAllClassFromDB();
    setAllClass(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handleEdit = (Class) => {
    navigate("/ClassReportEditPage", {
      state: {
        Class,
      },
    });
  };

  const handleDelete = async (Code) => {
    await deleteClass(Code);
    getDB();
  };

  return (
    <>
      {AllClass.length > 0 ? (
        AllClass.map((Class) => {
          let { Code, ClassName, ClassDescription } = Class;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{ClassName}</td>
                <td>{ClassDescription}</td>
                <td>
                  <button
                    className="btn btn-warning"
                    onClick={() => {
                      handleEdit(Class);
                    }}
                  >
                    Edit Class
                  </button>
                </td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => {
                      handleDelete(Class.Code);
                    }}
                  >
                    Remove Class
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
                  handleEdit(Class);
                }}
              >
                Edit Class
              </button>
            </td>
            <td>
              <button
                className="btn btn-danger"
                onClick={() => {
                  handleDelete(Class.Code);
                }}
              >
                Remove Class
              </button>
            </td>
          </tr>
        </>
      )}
    </>
  );
};
