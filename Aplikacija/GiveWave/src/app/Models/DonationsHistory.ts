export interface DonationHistory
{
    id:number,
    Naziv:string,
    Adresa:string,
    opis:string,
    donacija:donacija
}
interface donacija
{
    naziv:string,
    kolicina:number
}