export interface Categories
{
    id:number,
    category:category
}

export interface category
{
    naziv:string,
    podkategorije:subCategory[]
}

interface subCategory
{
    category:category
}