import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateClass } from "../../servicess/ClassService";

export const ClassReportEdit = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Class } = location.state;

  const [Code, setCode] = useState(Class.Code);
  const [ClassName, setClassName] = useState(Class.ClassName);
  const [ClassDescription, setClassDescription] = useState(Class.ClassDescription);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (ClassName === "" || ClassDescription === "") {
      alert("Please fill all fields");
    } else {
      const updatedClass = {
        ...Class,
        Code: parseInt(Code),
        ClassName: ClassName,
        ClassDescription: ClassDescription,
      };
      await UpdateClass(updatedClass);
      alert("Class Was Updated");
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
            Class Code:
          </label>
          <input type="text" className="form-control" id="Code" value={Code} onChange={(event) => setCode(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="ClassName" className="frm-lbl">
            Class Name:
          </label>
          <input type="text" className="form-control" id="ClassName" value={ClassName} onChange={(event) => setClassName(event.target.value)} />
        </div>
        <div className="form-group">
          <label htmlFor="ClassDescription" className="frm-lbl">
            Class Description:
          </label>
          <input type="text" className="form-control" id="ClassDescription" value={ClassDescription} onChange={(event) => setClassDescription(event.target.value)} />
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
