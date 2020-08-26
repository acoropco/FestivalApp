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
        }
      ]
    },
    {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        {
          path: 'user/edit',
          component: UserEditComponent,
          resolve: {user: UserEditResolver},
          canDeactivate: [PreventUnsavedChanges]
        }
      ]
    },
    {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        {
          path: 'rentals',
          component: RentalListComponent,
          resolve: {rentals: RentalListResolver}
        }
      ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
