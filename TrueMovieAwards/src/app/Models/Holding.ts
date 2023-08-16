import { MovieAward } from "./MovieAward"
import { ProducerAward } from "./ProducerAward"
import { RoleAward } from "./RoleAward"

export class Holding {

    id: number
    name : string
    city : string
    year : number
    festivalId: number
    
    roleAwards : RoleAward[]
    movieAwards : MovieAward[]
    producerAwards : ProducerAward[]

    constructor() {
        this.id = 0;
        this.name = ""
        this.city = ""
        this.year = 0
        this.festivalId = 0
        this.roleAwards = []
        this.movieAwards = []
        this.producerAwards = []
        
    }
}