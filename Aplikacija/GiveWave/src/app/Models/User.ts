export interface User
{
            id: number,
            ime:string,
            prezime:string,
            email:string,
            brTelefona:string,
            datumRodjenja:string,
            pol:string,
            statusAktivnosti:boolean,
            datumRegistracije:string,
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