import axios from "axios";

const ServerAddress = "http://localhost:7015/api/Class";

export const addProductToDB = async (frm) => {
  try {
    console.log("servicess - ProductService - addProductToDB ran Successfully");
    await axios.post(`${ServerAddress}/addProductToDB`, frm);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the addProductToDB Service : ${ex}`);
  }
};

export const getAllProductsFromDB = async () => {
  try {
    console.log("servicess - ProductService - getAllProductsFromDB ran Successfully");
    let endpoint = await axios.get(`${ServerAddress}/getAllProductsFromDB`);
    return endpoint;
  } catch (ex) {
    console.log(`An Exception occurred while initializing the getAllProductsFromDB Service : ${ex}`);
  }
};

export const deleteProduct = async (Code) => {
  try {
    console.log("services - ProductServices - deleteProduct ran Successfully");
    await axios.delete(`${ServerAddress}/deleteProduct/${Code}`);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the deleteProduct Service : ${ex}`);
  }
};

export const UpdateProduct = async (Product) => {
  try {
    console.log("servicess - ProductService - UpdateProduct ran Successfully");
    await axios.post(`${ServerAddress}/UpdateProduct`, Product);
  } catch (ex) {
    console.log(`An Exception occurred while initializing the UpdateProduct Service : ${ex}`);
  }
};
