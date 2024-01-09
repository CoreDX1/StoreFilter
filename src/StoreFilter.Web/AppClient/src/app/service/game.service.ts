import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseDto } from '../Interfaces/responseDto';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private url = 'http://localhost:5031/api/game/';

  constructor(private http: HttpClient) {}

  public getList(): Observable<ResponseDto> {
    return this.http.get<ResponseDto>(this.url);
  }
}
