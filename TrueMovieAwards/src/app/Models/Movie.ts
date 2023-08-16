import { DownReview } from "./DownReview"
import { LeftProducingMovie } from "./LeftProducingMovie"
import { PartialAward } from "./PartialAward"
import { PartialGenre } from "./PartialGenre"
import { PartialSeries } from "./PartialSeries"
import { PartialStudio } from "./PartialStudio"
import { RightRole } from "./RightRole"

export class Movie {

    id! :number
    title! : string
    description!: string
    dateOfRelease!: Date
    photo! : string
    revGrade!: number
    revCount!: number
    producings: LeftProducingMovie[] = []
    roles: RightRole[] = []
    movieAwards: PartialAward[] = []
    series: PartialSeries = new PartialSeries
    studio: PartialStudio = new PartialStudio
    genres: PartialGenre[] = []
    reviews: DownReview[] = []
}