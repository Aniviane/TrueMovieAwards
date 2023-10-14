import { PartialMovie } from "./PartialMovie";

export class Studio {

    id: number
    name : string
    photo : string
    description : string
    movies : PartialMovie[]

    constructor() {
        this.id = 0;
        this.name = ""
        this.photo = ""
        this.description = ""
        this.movies = []
    }
}