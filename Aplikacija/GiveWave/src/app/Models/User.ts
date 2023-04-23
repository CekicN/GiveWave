export interface User
{
            id: number,
            ime:string,
            prezime:string,
            email:string,
            brTelefona:string,
            datumRodjenja:Date,
            pol:string,
            statusAktivnosti:boolean,
            datumRegistracije:Date,
            slika:slika,
            lajkovi:number
}
interface slika
{
    type:string,
    media:media

}
interface media
{
    binaryEncoding: string,
    type: string
}