import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FestivalListComponent } from './festivals/festival-list/festival-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { FestivalListResolver } from './_resolvers/festival-list.resolver';
import { RentalListComponent } from './rentals/rental-list/rental-list.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { RentalListResolver } from './_resolvers/rental-list.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { EmailConfirmationComponent } from './authentication/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './authentication/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './authentication/reset-password/reset-password.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        {
          path: 'festivals',
          component: FestivalListComponent,
          resolve: {festivals: FestivalListResolver}
        },
        {
          path: 'user/edit',
          component: UserEditComponent,
          resolve: {user: UserEditResolver},
          canDeactivate: [PreventUnsavedChanges]
        },
        {
          path: 'rentals',
          component: RentalListComponent,
          resolve: {rentals: RentalListResolver}
        }
      ]
    },
    {
      path: 'emailConfirmation', 
      component: EmailConfirmationComponent 
    },
    { 
      path: 'forgotPassword', 
      component: ForgotPasswordComponent 
    },
    { 
      path: 'resetPassword', 
      component: ResetPasswordComponent 
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
