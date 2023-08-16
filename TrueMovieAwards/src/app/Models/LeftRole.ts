import { PartialAward } from "./PartialAward";
import { PartialMovie } from "./PartialMovie";

export class LeftRole {

    id: number
    fName : string
    lName : string
    movie : PartialMovie
    roleAwards : PartialAward[]

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.movie = new PartialMovie
        this.roleAwards = []
    }
}