import { Component } from '@angular/core';
import { iCar } from '../../models/i-car';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  randomCars:iCar[]=[]
  carArr:iCar[]=[]


  ngOnInit(){
    this.getCars()
  }

  async getCars():Promise<void>{
    let response=await fetch("../../../assets/db.json")
    let cars=<iCar[]>await response.json()
    this.carArr=cars

    console.log(this.carArr)

    this.randomCars=this.getRandomCars()
    console.log(this.randomCars)
  }

  getRandomCars(): iCar[] {
    const shuffled = [...this.carArr].sort(() => 0.5 - Math.random());
    return shuffled.slice(0, 2);
  }

  disponibile(car:iCar):string{
    if(car.available){
      return "disponibile"
    }else{
      return "non disponibile"
    }
  }
}

