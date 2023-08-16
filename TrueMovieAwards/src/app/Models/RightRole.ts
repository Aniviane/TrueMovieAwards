import { PartialAward } from "./PartialAward";
import { PartialActor } from "./PartialActor";
import { PartialMovie } from "./PartialMovie";

export class RightRole {

    id: number
    fName : string
    lName : string
    actor : PartialActor
    roleAwards : PartialAward[]

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.actor = new PartialActor
        this.roleAwards = []
    }
}