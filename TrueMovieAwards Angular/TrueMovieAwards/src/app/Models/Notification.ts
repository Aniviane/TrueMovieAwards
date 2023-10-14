import { PartialAward } from "./PartialAward"

export class Notification {
    id : number
    description : string
    dateOfNotification : Date
    award : PartialAward

    constructor() {
        this.id = 0
        this.description = ""
        this.dateOfNotification = new Date
        this.award = new PartialAward
    }
}