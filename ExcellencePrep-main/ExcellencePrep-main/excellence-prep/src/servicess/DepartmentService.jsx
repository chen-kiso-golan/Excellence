import axios from "axios";

const ServerAddress = "http://localhost:5120/api/Department";

export const addDepartmentToDB = async (frm) => {
  try {
    console.log("servicess - DepartmentService - addDepartmentToDB ran Successfully");
    await axios.post(`${ServerAddress}/addDepartmentToDB`, frm);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the addDepartmentToDB Service : ${ex}`);
  }
};

export const getAllDepartmentFromDB = async () => {
  try {
    console.log("servicess - DepartmentService - getAllDepartmentFromDB ran Successfully");
    let endpoint = await axios.get(`${ServerAddress}/getAllDepartmentFromDB`);
    console.log("getAllDepartmentFromDB:" + endpoint.data);
    return endpoint.data;
  } catch (ex) {
    console.log(`An Exception occurred while initializing the getAllDepartmentFromDB Service : ${ex}`);
  }
};

export const deleteDepartment = async (Code) => {
  try {
    console.log("services - DepartmentServices - deleteDepartment ran Successfully");
    await axios.delete(`${ServerAddress}/deleteDepartment/${Code}`);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the deleteDepartment Service : ${ex}`);
  }
};

export const UpdateDepartment = async (Department) => {
  try {
    console.log("servicess - DepartmentService - UpdateDepartment ran Successfully");
    await axios.post(`${ServerAddress}/UpdateDepartment`, Department);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the UpdateDepartment Service : ${ex}`);
  }
};
