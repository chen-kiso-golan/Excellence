import React, { useState, useEffect } from "react";
import { getAllDepartmentFromDB } from "../../servicess/DepartmentService";

export function ChooseDepartmentRow({ chooseDepartment }) {
  const [AllDepartment, setAllDepartment] = useState([]);

  const getDB = async () => {
    let result = await getAllDepartmentFromDB();
    setAllDepartment(result);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      <label htmlFor="Department" className="frm-lbl">
        Department Name:
      </label>
      <select name="Department" className="form-select" aria-label="Default select example" onChange={(event) => chooseDepartment(event.target.value)}>
        <option defaultValue={"Choose The Department"}>Choose The Department</option>
        {AllDepartment.length > 0 ? (
          AllDepartment.map((Department) => {
            return <>{<option value={Department.Department}>{Department.Department}</option>}</>;
          })
        ) : (
          <option value="1">There are no Departments.</option>
        )}
      </select>
    </>
  );
}
