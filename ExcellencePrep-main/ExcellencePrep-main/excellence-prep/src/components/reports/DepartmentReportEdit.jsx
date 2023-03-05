import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateDepartment } from "../../servicess/DepartmentService";

export const DepartmentReportEdit = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Class } = location.state;

  const [Code, setCode] = useState(Class.Code);
  const [DepartmentName, setDepartmentName] = useState(Department.DepartmentName);
  const [DepartmentDescription, setDepartmentDescription] = useState(Department.DepartmentDescription);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (DepartmentName === "" || DepartmentDescription === "") {
      alert("Please fill all fields");
    } else {
      const updatedDepartment = {
        ...Department,
        Code: parseInt(Code),
        DepartmentName: DepartmentName,
        DepartmentDescription: DepartmentDescription,
      };
      await UpdateDepartment(updatedDepartment);
      alert("Department Was Updated");
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
          <label htmlFor="Code" className="frm-lbl">
            Department Code:
          </label>
          <input type="text" className="form-control" id="Code" value={Code} onChange={(event) => setCode(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="DepartmentName" className="frm-lbl">
            Department Name:
          </label>
          <input type="text" className="form-control" id="DepartmentName" value={DepartmentName} onChange={(event) => setDepartmentName(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="DepartmentDescription" className="frm-lbl">
            Department Description:
          </label>
          <input type="text" className="form-control" id="DepartmentDescription" value={DepartmentDescription} onChange={(event) => setDepartmentDescription(event.target.value)} />
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
