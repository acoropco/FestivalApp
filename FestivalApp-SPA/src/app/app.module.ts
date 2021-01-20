import { BrowserModule, HAMMER_GESTURE_CONFIG, HammerGestureConfig } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { JwtModule } from '@auth0/angular-jwt';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AgmCoreModule } from '@agm/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { FestivalListComponent } from './festivals/festival-list/festival-list.component';
import { FestivalCardComponent } from './festivals/festival-card/festival-card.component';
import { FestivalListResolver } from './_resolvers/festival-list.resolver';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { RentalListResolver } from './_resolvers/rental-list.resolver';
import { RentalListComponent } from './rentals/rental-list/rental-list.component';
import { RentalCardComponent } from './rentals/rental-card/rental-card.component';
import { RentalDetailedComponent } from './rentals/rental-detailed/rental-detailed.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { DatePipe } from '@angular/common';
import { environment } from 'src/environments/environment';
import { GoogleMapsComponent } from './google-maps/google-maps.component';
import { SafePipe } from 'src/app/pipes/safe.pipe';

export function tokenGetter() {
  return localStorage.getItem('token');
}

export class CustomHammerConfig extends HammerGestureConfig  {
  overrides = {
      pinch: { enable: false },
      rotate: { enable: false }
  };
}

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    NavComponent,
    HomeComponent,
    FestivalListComponent,
    FestivalCardComponent,
    RentalListComponent,
    RentalCardComponent,
    UserEditComponent,
    UserDetailComponent,
    GoogleMapsComponent,
    RentalDetailedComponent,
    SafePipe
   ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AgmCoreModule.forRoot({
      apiKey: environment.googleMapsApiKey
    }),
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    BsDatepickerModule.forRoot(),
    TabsModule.forRoot(),
    JwtModule.forRoot({
      config: {
         tokenGetter,
         allowedDomains: ['localhost:5000'],
         disallowedRoutes: ['localhost:5000/api/auth']
      }
   })
  ],
  providers: [
    FestivalListResolver,
    UserEditResolver,
    RentalListResolver,
    DatePipe,
    { provide: HAMMER_GESTURE_CONFIG, useClass: CustomHammerConfig }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
