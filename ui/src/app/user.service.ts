import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

import { UserModel } from "./models/user-model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    public http: HttpClient
  ) { }

  list(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(environment.apiEndpoint + "api/User/List");
  }
}
