import axios from "axios";

const ServerAddress = "http://localhost:7015/api/Class";

export const addClassToDB = async (frm) => {
  try {
    console.log("servicess - ClassService - addClassToDB ran Successfully");
    await axios.post(`${ServerAddress}/addClassToDB`, frm);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the addClassToDB Service : ${ex}`);
  }
};

export const getAllClassFromDB = async () => {
  try {
    console.log("servicess - ClassService - getAllClassFromDB ran Successfully");
    let endpoint = await axios.get(`${ServerAddress}/getAllClassFromDB`);
    return endpoint;
  } catch (ex) {
    console.log(`An Exception occurred while initializing the getAllClassFromDB Service : ${ex}`);
  }
};

export const deleteClass = async (Code) => {
  try {
    console.log("services - ClassServices - deleteClass ran Successfully");
    await axios.delete(`${ServerAddress}/deleteClass/${Code}`);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the deleteClass Service : ${ex}`);
  }
};

export const UpdateClass = async (Class) => {
  try {
    console.log("servicess - ClassService - UpdateClass ran Successfully");
    await axios.post(`${ServerAddress}/UpdateClass`, Class);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the UpdateClass Service : ${ex}`);
  }
};
