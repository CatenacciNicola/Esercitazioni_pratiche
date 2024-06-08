import { Component } from '@angular/core';
import { iMovie } from '../../../models/i-movie';
import { MovieService } from '../../movie.service';

@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrl: './favourite.component.scss'
})
export class FavouriteComponent {
  favourites:iMovie[]=[]

  constructor(private movieSvc:MovieService){}

  ngOnInit(){
    this.movieSvc.getFavouriteMovies().subscribe(favourite=>{
      this.favourites=favourite
    })
  }
}
