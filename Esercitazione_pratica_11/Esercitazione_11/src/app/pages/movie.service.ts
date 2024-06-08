import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { iMovie} from '../models/i-movie';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  favouriteMovies:iMovie[]=[]
  favouriteMoviesSubject=new BehaviorSubject<iMovie[]>(this.favouriteMovies)

  constructor(private http:HttpClient) { }

  movieUrl:string="http://localhost:3000/movie"
  favouriteUrl:string="http://localhost:3000/favourite"


  getAll():Observable<iMovie[]>{
    return this.http.get<iMovie[]>(this.movieUrl)
  }


  //I PREFERITI VENGONO AGGIUNTI UNIVERSALMENTE SENZA ESSERE ASSOCIATI AD UN UTENTE SPECIFICO.
  addToFavourites(movie:iMovie):Observable<iMovie>{
    return this.http.post<iMovie>(this.favouriteUrl,movie)
    .pipe(tap((addedMovie:iMovie)=>{
        this.favouriteMovies.push(addedMovie)
        this.favouriteMoviesSubject.next(this.favouriteMovies)
      })
    )
  }


  /* CON QUESTO METODO VENIVA PASSATO ALLA DELETE IL filmId, MA PER FUNZIONARE SERVE L'ID DEL PREFERITO (CANCELLAVA IL FILM SBAGLIATO DANDO POI 404)
  removeFromFavourites(movie:iMovie):Observable<void>{
    return this.http.delete<void>(`${this.favouriteUrl}/${movie.filmId}`)
    .pipe(tap(()=>{
        this.favouriteMovies=this.favouriteMovies.filter(favMovie=>favMovie.filmId !== movie.filmId)
        this.favouriteMoviesSubject.next(this.favouriteMovies)
      })
    )
  }
    */

  //PASSO IL FILM COME PARAMETRO, CERCO NELL'ARRAY FAVOURITE IL FILM CON LO STESSO filmId E PRENDO IL SUO ID PER PASSARLO COME PARAMETRO ALLA DELETE
  removeFromFavourites(movie: iMovie):Observable<void>{
    const favouriteMovie=this.favouriteMovies.find(favMovie=>favMovie.filmId === movie.filmId)

    //FAVOURITEMOVIE POTREBBE ESSERE UNDEFINED, QUINDI METTO UN IF CHE NEL CASO LO SIA RESTITUISCA UN OBSERVABLE VUOTO PER RISPETTARE LA TIPIZZAZIONE
    if (!favouriteMovie) {
      return new Observable<void>
  }
        const favoriteId=favouriteMovie.id
    return this.http.delete<void>(`${this.favouriteUrl}/${favoriteId}`).pipe(
      tap(()=>{
        this.favouriteMovies=this.favouriteMovies.filter(favMovie=>favMovie.id !== favoriteId)
        this.favouriteMoviesSubject.next(this.favouriteMovies)
      })
    )
  }




  getFavouriteMovies():Observable<iMovie[]>{
    return this.http.get<iMovie[]>(this.favouriteUrl)
    .pipe(tap((movies:iMovie[])=>{
        this.favouriteMovies=movies
        this.favouriteMoviesSubject.next(this.favouriteMovies)
      })
    )
  }


  isFavourite(movie:iMovie):boolean{
    return this.favouriteMovies.some(favMovie=>favMovie.filmId === movie.filmId)
  }
}


