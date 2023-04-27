export interface User
{
            mail:string,
            username:string,
            brTelefona:number,
            adresa:string,
            datumRodjenja:Date,
            datumRegistracije:Date,
            pol:string,
            statusAktivnosti:boolean,
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