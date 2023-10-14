import { PartialMovie } from "./PartialMovie"

export class UpReview {
    id : number
    description : string
    grade : number
    revTime : Date
    movie : PartialMovie

    constructor() {
        this.id = 0
        this.description = ""
        this.grade = 0
        this.revTime = new Date
        this.movie = new PartialMovie
    }
}