import React, { useState, useEffect } from "react";
import { getAllClassFromDB } from "../../servicess/ClassService";

export function ChooseClassRow({ chooseClass }) {
  const [AllClass, setAllClass] = useState([]);

  const getDB = async () => {
    let result = await getAllClassFromDB();
    setAllClass(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      <label htmlFor="Class" className="frm-lbl">
        Class
      </label>
      <select name="Class" className="form-select" aria-label="Default select example" onChange={(event) => chooseClass(event.target.value)}>
        <option defaultValue={"Choose The Class"}>Choose The Class</option>
        {AllClass.length > 0 ? (
          AllClass.map((Class) => {
            return <>{<option value={Class.Class}>{Class.Class}</option>}</>;
          })
        ) : (
          <option value="1">There are no Class.</option>
        )}
      </select>
    </>
  );
}
