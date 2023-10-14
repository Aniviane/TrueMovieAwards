import { PartialActor } from "./PartialActor";
import { PartialMovie } from "./PartialMovie";

export class DownRole {

    id: number
    fName : string
    lName : string
    movie : PartialMovie
    actor : PartialActor

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.movie = new PartialMovie
        this.actor = new PartialActor
    }
}