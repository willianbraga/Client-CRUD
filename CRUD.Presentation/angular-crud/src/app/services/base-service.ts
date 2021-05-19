import { HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

export abstract class BaseService {

    protected extractData(response: any) {
        return response.data || {};
    }

    protected serviceError(response: Response | any) {
        let customError: string[] = [];

        if (response instanceof HttpErrorResponse) {
            if (response.statusText === "Unknown Error") {
                customError.push("Erro desconhecido");
                response.error.errors = customError;
            }
        }

        console.error(response);
        return throwError(response);
    }
}