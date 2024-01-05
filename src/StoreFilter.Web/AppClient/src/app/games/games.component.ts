import { Component, OnInit } from '@angular/core';
import { GamesService } from './games.service';
import { IUser } from './games.model';

@Component({
  selector: 'app-games',
  standalone: true,
  imports: [],
  templateUrl: './games.component.html',
})
export class GamesComponent implements OnInit {
  public AllUser: IUser[] = [];

  constructor(private gamesService: GamesService) {
    this.AllUser = this.gamesService.user;
  }

  ngOnInit(): void {
    this.filterUsers();
  }

  public filterUsers(): void {
    this.AllUser = this.gamesService.FilterUser(18);
  }

  public greet(): void {
    alert('Hello World!');
  }
}
