import { PartialAward } from "./PartialAward";
import { PartialMovie } from "./PartialMovie";

export class RightProducingMovie {

    movie: PartialMovie
    producingAwards : PartialAward[]

    constructor() {
       this.movie = new PartialMovie
       this.producingAwards = []
    }
}