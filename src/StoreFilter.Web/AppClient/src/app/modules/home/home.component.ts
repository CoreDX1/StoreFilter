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
  public gameResponse: ResponseDto = {
    isSuccess: false,
    message: '',
    data: [],
  };

  constructor(private service: GameService) {}

  ngOnInit(): void {
    this.FethGames();
  }

  public FethGames(): void {
    this.service.getList().subscribe((data) => {
      this.gameResponse = data;
      console.log(this.gameResponse);
    });
  }
}
