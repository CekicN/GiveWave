export interface ProductHelper
{
    Naziv:string,
    Opis:String,
    Mesto:String,
    status:string,
    emailKorisnika:string|null,
    Kategorija:string,
    novaKategorija:string,
    parentKategorija:string
}

export enum Status{
    New,
    SecondHand
}