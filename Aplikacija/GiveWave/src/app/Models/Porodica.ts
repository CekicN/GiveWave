export interface Porodica {
    id: number;
    urlSlika:string[],
    naziv: string,
    grad:string,
    adresa: string,
    brClanova:number,
    status:string,
    najpotrebnijestvari: string[];
    email:string,
    ziroRacun:string,
    brTelefona:string,
    user:string,
    opis:string
}