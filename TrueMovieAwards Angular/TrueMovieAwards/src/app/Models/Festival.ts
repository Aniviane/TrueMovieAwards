import { Holding } from "./Holding"


export class Festival {

    id: number
    name : string
    description : string
    photo : string
    holdings : Holding[]

    constructor() {
        this.id = 0;
        this.name = ""
        this.description = ""
        this.photo = ""
        this.holdings = []
    }
}