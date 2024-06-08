import { Component } from '@angular/core';
import { MovieService } from '../movie.service';
import { iMovie } from '../../models/i-movie';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  movies:iMovie[]=[]

  constructor(private movieSvc:MovieService){}

  ngOnInit(){
    this.movieSvc.getAll().subscribe(movies=>{
      this.movies=movies
    })
  }


  toggleFavourite(movie:iMovie):void{
    if (this.isFavourite(movie)){
      console.log("Preferito rimosso")
      this.movieSvc.removeFromFavourites(movie).subscribe()
    }
    else{
      console.log("Preferito aggiunto")
      this.movieSvc.addToFavourites(movie).subscribe()
    }
  }


  isFavourite(movie:iMovie):boolean {
    return this.movieSvc.isFavourite(movie)
  }

}
