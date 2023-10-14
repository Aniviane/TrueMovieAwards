import { LeftRole } from "./LeftRole"

export class ActorCreate {

    id: number
    fName : string
    lName : string
    doB : Date
    aPhoto! : File
    bio : string

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.doB = new Date
        
        this.bio = ""
    }
}