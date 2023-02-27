import React, { useState } from "react";
import { addClassToDB } from "../../servicess/ClassService";

function AddClass(props) {
  const [formData, setFormData] = useState({
    ClassName: "",
    ClassDescription: "",
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
    if (formData.ClassName === "" || formData.ClassDescription === "") {
      console.log("fill all the filldes");
      return;
    } else {
      handleAddData();
      console.log("dats was sent");
    }
    setFormData({
      ClassName: "",
      ClassDescription: "",
    });
  }

  const handleAddData = async () => {
    let json = formData;
    await addClassToDB(json);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="ClassName" className="frm-lbl">
            class name:
          </label>
          <input type="text" placeholder="Enter class name" className="form-control" name="ClassName" onChange={handleChange} value={formData.ClassName} />
        </div>
        <div className="form-group">
          <label htmlFor="ClassDescription" className="frm-lbl">
            class description:
          </label>
          <input type="text" placeholder="Enter class description" className="form-control" name="ClassDescription" onChange={handleChange} value={formData.ClassDescription} />
        </div>
        <button className="form--submit btn btn-danger">Sign up</button>
      </form>
    </div>
  );
}

export default AddClass;
