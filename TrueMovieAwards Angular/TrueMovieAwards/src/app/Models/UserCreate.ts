

export class UserCreate {
    id : number
    username: string
    password!: string
    token!: string
    fName!: string
    lName!: string
    eMail!: string
    uType!: string
    uPhoto!: File
    bio!: string

    

    constructor() {
        this.id = 0
        this.username = ""
        this.password = ""
        this.token = ""
        this.fName = ""
        this.lName = ""
        this.eMail = ""
        this.uType = ""
        
        this.bio = ""
       
    }
}