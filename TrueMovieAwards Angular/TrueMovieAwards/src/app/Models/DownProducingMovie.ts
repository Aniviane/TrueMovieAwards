import { PartialAward } from "./PartialAward";
import { PartialMovie } from "./PartialMovie";
import { PartialProducer } from "./PartialProducer";

export class DownProducingMovie {

    producer : PartialProducer
    movie : PartialMovie

    constructor() {
       this.producer = new PartialProducer
       this.movie = new PartialMovie
    }
}