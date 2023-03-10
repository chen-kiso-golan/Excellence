import axios from "axios";

const ServerAddress = "http://localhost:5120/api/Department";

export const addDepartmentToDB = async (Department) => {
  try {
    console.log("servicess - DepartmentService - addDepartmentToDB ran Successfully");
    await axios.post(`${ServerAddress}/addDepartmentToDB`, Department);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the addDepartmentToDB Service : ${ex}`);
  }
};

export const getAllDepartmentFromDB = async () => {
  try {
    console.log("servicess - DepartmentService - getAllDepartmentFromDB ran Successfully");
    let endpoint = await axios.get(`${ServerAddress}/getAllDepartmentFromDB`);
    return endpoint.data;
  } catch (ex) {
    console.log(`An Exception occurred while initializing the getAllDepartmentFromDB Service : ${ex}`);
  }
};

export const deleteDepartment = async (id) => {
  try {
    console.log("services - DepartmentServices - deleteDepartment ran Successfully");
    await axios.delete(`${ServerAddress}/deleteDepartment/${id}`);
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
