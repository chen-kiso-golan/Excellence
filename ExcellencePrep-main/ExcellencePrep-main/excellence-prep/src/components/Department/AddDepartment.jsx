import React, { useState } from "react";
import { addDepartmentToDB } from "../../servicess/DepartmentService";

function AddDepartment(props) {
  const [formData, setFormData] = useState({
    name: "",
    description: "",
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
    if (formData.name === "" || formData.description === "") {
      console.log("fill all the filldes");
      return;
    } else {
      handleAddData();
      console.log("dats was sent");
    }
    setFormData({
      name: "",
      description: "",
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
          <label htmlFor="name" className="frm-lbl">
            Department name:
          </label>
          <input type="text" placeholder="Enter Department name" className="form-control" name="name" onChange={handleChange} value={formData.name} />
        </div>
        <div className="form-group">
          <label htmlFor="description" className="frm-lbl">
            Department description:
          </label>
          <input type="text" placeholder="Enter Department description" className="form-control" name="description" onChange={handleChange} value={formData.description} />
        </div>
        <button className="form--submit btn btn-danger">Sign up</button>
      </form>
    </div>
  );
}

export default AddDepartment;
