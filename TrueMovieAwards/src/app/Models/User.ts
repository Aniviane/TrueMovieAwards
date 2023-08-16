import { Notify } from "./Notify"
import { PartialActor } from "./PartialActor"
import { PartialMovie } from "./PartialMovie"
import { PartialProducer } from "./PartialProducer"
import { UpReview } from "./UpReview"
import { WatchList } from "./WatchList"

export class User {
    id : number
    username: string
    password!: string
    token!: string
    fName!: string
    lName!: string
    eMail!: string
    uType!: string
    uPhoto!: string
    bio!: string

    favActors!: PartialActor[]
    favProducers!: PartialProducer[]
    favMovies!: PartialMovie[]
    reviews! : UpReview[]
    notifies!: Notify[]
    watchList!: WatchList

    constructor() {
        this.id = 0
        this.username = ""
        this.password = ""
        this.token = ""
        this.fName = ""
        this.lName = ""
        this.eMail = ""
        this.uType = ""
        this.uPhoto = ""
        this.bio = ""
        this.favActors = []
        this.favProducers = []
        this.favMovies = []
        this.reviews = []
        this.notifies = []
        this.watchList = new WatchList
    }
}