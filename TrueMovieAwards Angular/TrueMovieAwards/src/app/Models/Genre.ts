import { PartialMovie } from "./PartialMovie";

export class Genre {

    id: number
    fName : string
    movies : PartialMovie[]

    constructor() {
        this.id = 0;
        this.fName = ""
        this.movies = []
    }
}