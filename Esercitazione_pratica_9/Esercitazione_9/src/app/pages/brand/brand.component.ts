import { Component } from '@angular/core';
import { iCar } from '../../models/i-car';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrl: './brand.component.scss'
})
export class BrandComponent {
  brandCar:iCar[]=[]
  carArr:iCar[]=[]


  constructor(
    private route:ActivatedRoute
  ){}

  ngOnInit(){
    this.route.params.subscribe((params:any)=>{
      this.getBrandCars(params.brand)
    })
  }

  async getBrandCars(brand:string){
    let response=await fetch("../../../assets/db.json")
    let cars=<iCar[]>await response.json()
    let carArr=cars
    this.brandCar=carArr.filter(car=>car.brand==brand)
    console.log(this.brandCar)
  }

  disponibile(car:iCar):string{
    if(car.available){
      return "disponibile"
    }else{
      return "non disponibile"
    }
  }
}
