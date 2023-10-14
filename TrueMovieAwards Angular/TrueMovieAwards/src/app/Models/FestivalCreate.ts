import { Holding } from "./Holding"


export class FestivalCreate {

    id: number
    name : string
    description : string
    photo! : File

    constructor() {
        this.id = 0;
        this.name = ""
        this.description = ""
       
        
    }
}