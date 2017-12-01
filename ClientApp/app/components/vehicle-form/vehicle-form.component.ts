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
    vehicle: any =
    {
        features: [],
        contact: {}
    };

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
        this.vehicleService.getFeatures().subscribe(res => this.features = res);
    }

    onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.vehicle.MakeId);
        this.models = selectedMake ? selectedMake.models : [];
        delete this.vehicle.ModelId;
    }

    onFeatureToggle(featureId: number, $event: any) {

        if ($event.target.checked) {
            this.vehicle.features.push(featureId);
        }
        else {
            var index = this.vehicle.features.indexOf(featureId);
            this.vehicle.features.splice(index, 1);
        }
    }

    onSubmit() {
        this.vehicleService.createVehicle(this.vehicle).subscribe(
            res => console.log(res)
        );
    }

}
