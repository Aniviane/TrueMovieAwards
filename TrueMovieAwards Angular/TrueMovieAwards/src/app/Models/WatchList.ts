import { PartialMovie } from "./PartialMovie"

export class WatchList {
    id : number
    movies : PartialMovie[]

    constructor() {
        this.id = 0
        this.movies = []
        
    }
}