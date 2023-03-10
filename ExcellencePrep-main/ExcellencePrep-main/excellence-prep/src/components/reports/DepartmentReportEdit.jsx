import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateDepartment } from "../../servicess/DepartmentService";

export const DepartmentReportEdit = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Department } = location.state;

  const [Id, setId] = useState(Department.id);
  const [Name, setName] = useState(Department.name);
  const [Description, setDescription] = useState(Department.description);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (Name === "" || Description === "") {
      alert("Please fill all fields");
    } else {
      const updatedDepartment = {
        ...Department,
        id: parseInt(Id),
        name: Name,
        description: Description,
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
          <label htmlFor="Id" className="frm-lbl">
            Department Id:
          </label>
          <input type="text" className="form-control" id="Id" value={Id} onChange={(event) => setId(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="Name" className="frm-lbl">
            Department Name:
          </label>
          <input type="text" className="form-control" id="Name" value={Name} onChange={(event) => setName(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="Description" className="frm-lbl">
            Department Description:
          </label>
          <input type="text" className="form-control" id="Description" value={Description} onChange={(event) => setDescription(event.target.value)} />
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
