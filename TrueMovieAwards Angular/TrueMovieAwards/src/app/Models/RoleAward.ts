import { Award } from "./Award";
import { DownRole } from "./DownRole";

export class RoleAward extends Award {
    roles : DownRole[]

    constructor() {
        super()
        this.roles = []
    }
}