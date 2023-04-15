import { Component } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faFacebook, faInstagram, faBitbucket} from '@fortawesome/free-brands-svg-icons'
@Component({
  selector: 'app-footer-bar',
  templateUrl: './footer-bar.component.html',
  styleUrls: ['./footer-bar.component.css']
})
export class FooterBarComponent {
 constructor(library:FaIconLibrary)
 {
  library.addIcons(faFacebook, faInstagram, faBitbucket);
 }
}
