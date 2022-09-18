import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { ierror } from "../models/ierror";

axios.defaults.baseURL = `${process.env.REACT_APP_APIBASEURL}/api/`;

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.response.use(
  async (response) => {
    return response;
  },
  (error: AxiosError) => {
    const { data, status } = error.response!;
    const errInfo = data as ierror;
    switch (status) {
      case 400:
      case 401:
      case 404:
      case 500:
        toast.error(errInfo.title);
        break;
      default:
        break;
    }

    return Promise.reject(error.response);
  }
);

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
  list: () => requests.get("Products/Get"),
  details: (id: number) => requests.get(`Products/Get/${id}`),
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
