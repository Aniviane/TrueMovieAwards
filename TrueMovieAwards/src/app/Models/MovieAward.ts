import { Award } from "./Award";
import { PartialMovie } from "./PartialMovie";

export class MovieAward  extends Award {
    movies : PartialMovie[]

    constructor() {
        super();
        this.movies = []
    }
}