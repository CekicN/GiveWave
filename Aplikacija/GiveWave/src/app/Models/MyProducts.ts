export interface MyProducts
{
    Naziv:string,
    Kategorija:kategorija
}
interface kategorija
{
    type:string,
    podaci:podaci
}
interface podaci
{
    VrstaOdece:string,
    Stanje:string,
    Velicina:string,
    Uzrast:string,
    opis:string
}