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
    user:string 
}