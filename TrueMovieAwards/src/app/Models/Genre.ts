import { PartialMovie } from "./PartialMovie";

export class Genre {

    id: number
    name : string
    movies : PartialMovie[]

    constructor() {
        this.id = 0;
        this.name = ""
        this.movies = []
    }
}