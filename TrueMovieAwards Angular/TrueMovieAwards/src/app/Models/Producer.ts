import { LeftRole } from "./LeftRole"
import { RightProducingMovie } from "./RightProducingMovie"

export class Producer {

    id: number
    fName : string
    lName : string
    doB : Date
    photo : string
    bio : string
    producings : RightProducingMovie[]

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.doB = new Date
        this.photo = ""
        this.bio = ""
        this.producings = []
    }
}