import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = "https://localhost:7075/api/";

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
  list: () => requests.get("Products/GetProducts"),
  details: (id: number) => requests.get(`Products/GetProduct/${id}`),
};

const TestErrors = {
  get400Error: () => requests.get("Buggy/GetBadRequest"),
  get401Error: () => requests.get("Buggy/GetUnauthorized"),
  get404Error: () => requests.get("Buggy/GetNotFound"),
  get500Error: () => requests.get("Buggy/GetServerError"),
  getValidationError: () => requests.get("Buggy/GetValidationError"),
};

const agent = {
  Catalog,
  TestErrors,
};

export default agent;
