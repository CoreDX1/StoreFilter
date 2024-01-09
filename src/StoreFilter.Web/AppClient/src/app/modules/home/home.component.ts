import { Component, OnInit } from '@angular/core';
import { Game, ResponseDto } from '../../Interfaces/responseDto';
import { GameService } from '../../service/game.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public data: ResponseDto = {
    isSuccess: false,
    message: '',
    data: [],
  };

  constructor(private service: GameService) {}

  ngOnInit(): void {
    this.getGames();
  }

  public getGames(): void {
    this.service.getList().subscribe((data) => {
      this.data = data;
      console.log(this.data);
    });
  }
}
