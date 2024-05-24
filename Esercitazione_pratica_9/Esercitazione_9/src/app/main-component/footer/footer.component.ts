import { Component } from '@angular/core';
import { iCar } from '../../models/i-car';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {
  carArr:iCar[]=[]
  carBrands: { [brand: string]: iCar[] } = {};

  ngOnInit(){
    this.getCars()
  }

  async getCars():Promise<void>{
    let response=await fetch("../../../assets/db.json")
    let cars=<iCar[]>await response.json()
    this.carArr=cars

    console.log(this.carArr)
    console.log(this.carBrands);
  }
}
