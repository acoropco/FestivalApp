import { Component, OnInit, Input } from '@angular/core';
import { Festival } from 'src/app/_models/festival';
import { FestivalService } from 'src/app/_services/festival.service';
import { AuthService } from 'src/app/_services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-festival-card',
  templateUrl: './festival-card.component.html',
  styleUrls: ['./festival-card.component.css']
})
export class FestivalCardComponent implements OnInit {
  @Input() festival: Festival;

  constructor(
    private festivalService: FestivalService,
    private authService: AuthService,
    private toastrService: ToastrService
    ) { }

  ngOnInit() {
  }

  sendLike() {
    this.festivalService.likeFestival(this.festival.id, this.authService.decodedToken.nameid)
    .subscribe(next => {
      this.festival.isLiked = !this.festival.isLiked;
      if (this.festival.isLiked) {
        this.toastrService.success('Added to Favorites');
      } else {
        this.toastrService.warning('Removed from Favorites');
      }
    });
  }

  goToLink(url: string) {
    window.open(url, '_blank');
  }

}
