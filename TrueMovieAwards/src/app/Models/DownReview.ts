import { PartialMovie } from "./PartialMovie"
import { PartialUser } from "./PartialUser"

export class DownReview {
    id : number
    description : string
    grade : number
    revTime : Date
    reviewer : PartialUser

    constructor() {
        this.id = 0
        this.description = ""
        this.grade = 0
        this.revTime = new Date
        this.reviewer = new PartialUser
    }
}