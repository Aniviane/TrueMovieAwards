import { Award } from "./Award";
import { DownProducingMovie } from "./DownProducingMovie";

export class ProducerAward extends Award {
    producings : DownProducingMovie[]

    constructor() {
        super()
        this.producings = []
    }
}