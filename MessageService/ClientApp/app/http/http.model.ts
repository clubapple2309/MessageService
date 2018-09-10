export class HttpResponce<T> {
    constructor(
          public statusCode: number
        , public text: string
        , public data: T 
    ){ }
}