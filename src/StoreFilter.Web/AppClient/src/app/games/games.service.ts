import { Injectable } from '@angular/core';
import { IUser } from './games.model';

@Injectable({
  providedIn: 'root',
})
export class GamesService {
  public user: IUser[] = [
    {
      id: 1,
      name: 'Camilo',
      age: 17,
    },
    {
      id: 2,
      name: 'Juan',
      age: 30,
    },
    {
      id: 3,
      name: 'Pedro',
      age: 25,
    },
    {
      id: 4,
      name: 'Maria',
      age: 20,
    },
    {
      id: 5,
      name: 'Luis',
      age: 15,
    },
  ];

  public FilterUser(age: number): IUser[] {
    return this.user.filter((user) => user.age >= age);
  }

}
