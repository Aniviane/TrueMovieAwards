export class Notify{
    description : string
    seen : boolean
    awardId : number
    notificationId : number

    constructor() {
        this.description = ""
        this.seen = false
        this.awardId = 0
        this.notificationId = 0
    }
}