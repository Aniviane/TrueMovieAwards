import { Award } from "./Award"
import { MovieAward } from "./MovieAward"
import { ProducerAward } from "./ProducerAward"
import { RoleAward } from "./RoleAward"

export class AwardWrapper {
    awardType : string = ""
    movieAward: MovieAward = new MovieAward
    roleAward : RoleAward = new RoleAward
    producerAward : ProducerAward = new ProducerAward
    constructor() {
        
        
    }
}