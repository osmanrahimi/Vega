import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicle.service";


@Component({
    selector: 'app-vehicle-form',
    templateUrl: './vehicle-form.component.html',
    styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

    makes: any[];
    models: any[];
    features: any[];
    vehicle: any = {};

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
        this.vehicleService.getFeatures().subscribe(res => this.features = res);
    }

    onMakeChange() {
        console.log(this.vehicle);
        var selectedMake = this.makes.find(m => m.id == this.vehicle);
        this.models = selectedMake ? selectedMake.models : [];
    }

}
