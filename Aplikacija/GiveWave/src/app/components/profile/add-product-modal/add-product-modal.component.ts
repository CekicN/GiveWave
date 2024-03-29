import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { ProductService } from 'app/components/products/product.service';
import { ProductHelper, Status } from 'app/Models/ProductHelper';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { uploadPhoto } from 'app/Models/uploadPhoto';
import { AuthService } from 'app/services/auth.service';
import { MyProductsComponent } from '../my-products/my-products.component';

@Component({
  selector: 'app-add-product-modal',
  templateUrl: './add-product-modal.component.html',
  styleUrls: ['./add-product-modal.component.css']
})
export class AddProductModalComponent implements OnInit{
  displayStyle:string = 'none';
  other = false;
  categories!:Category[];
  cities!:any;
  addProductForm!:FormGroup;
  imageUrl:string[] = ["https://localhost:7200//uploads/common/noimage.png"];
  status = Object.keys(Status).filter((item) => isNaN(Number(item)));
  constructor(private fb:FormBuilder,
              private service:ProfileService, 
              private authService:AuthService, 
              private productService:ProductService,
              private cdr:ChangeDetectorRef)
  {
    service.displayStyle.subscribe(d => {this.displayStyle = d; cdr.detectChanges()});
    this.addProductForm = fb.group({
      Naziv:['', Validators.required],
      Mesto:['', Validators.required],
      Kategorija:['', Validators.required],
      novaKategorija:[''],
      parentKategorija:[''],
      status:['', Validators.required],
      Opis:['', Validators.required]
    },{validator:this.categoryValidator});
  }

  categoryValidator(formGroup: FormGroup) {
    const category = formGroup.get('Kategorija')?.value;
    const newCategory = formGroup.get('novaKategorija')?.value;
    const parentCategory = formGroup.get('parentKategorija')?.value;

    if (category === 'others' && (!newCategory || !parentCategory)) {
      return { invalidCategory: true };
    }

    return null;
  }
  ngOnInit(): void {
    this.productService.getCategories().subscribe(p => {
      this.categories = extractCategories(p)
    });
    this.productService.getCities().subscribe(c => this.cities = c);
  }

  isOther(event:Event)
  {
    const select = <HTMLSelectElement>event.target;
    if(select.value == "others")
      this.other = true;
    else
      this.other = false;
    this.cdr.detectChanges();
  }
  closeModal()
  {
    this.service.cancelAdding(this.service.productId, this.authService.email).subscribe(msg => console.log(msg));
    this.imageUrl = ["https://localhost:7200//uploads/common/noimage.png"];
    this.addProductForm.reset();
    this.service.closeModal();
  }
  addProduct()
  {
    if(this.addProductForm.valid)
    {
      //za dodavanje producta
      const product:ProductHelper = this.addProductForm.value;
      product.emailKorisnika = this.authService.email;
      console.log(product);
      this.service.addProduct(product,this.service.productId).subscribe(() => {
        this.service.sendClickEvent();
        this.imageUrl = ["https://localhost:7200//uploads/common/noimage.png"];
        this.addProductForm.reset();
        this.service.closeModal();
        this.cdr.detectChanges();
      });
    }  
    else
    {
      this.validateAllFormsFields(this.addProductForm);
      this.cdr.detectChanges();
    }
  }
  private validateAllFormsFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({
          onlySelf:true
        });
      }else if(control instanceof FormGroup){
        this.validateAllFormsFields(control);
      }
    })

  }

  addPhotos(event:Event)
  {
    const files = (<HTMLInputElement>event.target).files;
    if(files)
    {
      const upload:uploadPhoto = {
        id:this.service.productId,
        email:this.authService.email,
        files:Array.from(files)
      } 
      this.service.updatePhoto(upload).subscribe((res:any) => {
        this.imageUrl = res.imageUrls
        this.cdr.detectChanges();
      });
    }
  }
}

interface Category {
  id: number;
  name: string;
}

function extractCategories(data: any[]): Category[] {
  const categories: Category[] = [];

  data.forEach((item) => {
    const category: Category = {
      id: item.id,
      name: item.name,
    };
    categories.push(category);

    if (item.subcategories && item.subcategories.length > 0) {
      const subcategories = extractCategories(item.subcategories);
      categories.push(...subcategories);
    }
  });
  return categories;
}
