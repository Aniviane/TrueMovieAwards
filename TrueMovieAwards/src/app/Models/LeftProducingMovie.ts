import { PartialAward } from "./PartialAward";
import { PartialProducer } from "./PartialProducer";

export class LeftProducingMovie {

    producer : PartialProducer
    producingAwards : PartialAward[]

    constructor() {
       this.producer = new PartialProducer
       this.producingAwards = []
    }
}