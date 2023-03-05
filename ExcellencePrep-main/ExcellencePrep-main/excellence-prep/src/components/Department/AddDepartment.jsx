import React, { useState } from "react";
import { addDepartmentToDB } from "../../servicess/DepartmentService";

function AddDepartment(props) {
  const [formData, setFormData] = useState({
    DepartmentName: "",
    DepartmentDescription: "",
  });

  function handleChange(event) {
    const { name, value, type, checked } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: type === "checkbox" ? checked : value,
    }));
  }

  function handleSubmit(event) {
    event.preventDefault();
    if (formData.DepartmentName === "" || formData.DepartmentDescription === "") {
      console.log("fill all the filldes");
      return;
    } else {
      handleAddData();
      console.log("dats was sent");
    }
    setFormData({
      DepartmentName: "",
      DepartmentDescription: "",
    });
  }

  const handleAddData = async () => {
    let json = formData;
    await addDepartmentToDB(json);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="DepartmentName" className="frm-lbl">
            Department name:
          </label>
          <input type="text" placeholder="Enter Department name" className="form-control" name="DepartmentName" onChange={handleChange} value={formData.DepartmentName} />
        </div>
        <div className="form-group">
          <label htmlFor="DepartmentDescription" className="frm-lbl">
            Department description:
          </label>
          <input type="text" placeholder="Enter Department description" className="form-control" name="DepartmentDescription" onChange={handleChange} value={formData.DepartmentDescription} />
        </div>
        <button className="form--submit btn btn-danger">Sign up</button>
      </form>
    </div>
  );
}

export default AddDepartment;
