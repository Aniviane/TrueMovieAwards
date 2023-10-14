import { LeftRole } from "./LeftRole"

export class Actor {

    id: number
    fName : string
    lName : string
    doB : Date
    aPhoto : string
    bio : string
    roles : LeftRole[]

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.doB = new Date
        this.aPhoto = ""
        this.bio = ""
        this.roles = []
    }
}