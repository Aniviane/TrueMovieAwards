export class Award {

    id: number
    name : string
    awardType : string
    festivalId : number
    holdingId: number

    constructor() {
        this.id = 0;
        this.name = ""
        
        this.awardType = ""
        this.festivalId = 0
        this.holdingId = 0
    }
}