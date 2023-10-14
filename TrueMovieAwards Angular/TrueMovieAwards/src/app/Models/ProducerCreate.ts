import { RightProducingMovie } from "./RightProducingMovie"

export class ProducerCreate {

    id: number
    fName : string
    lName : string
    doB : Date
    photo! : File
    bio : string

    constructor() {
        this.id = 0;
        this.fName = ""
        this.lName = ""
        this.doB = new Date
      
        this.bio = ""
        
    }
}