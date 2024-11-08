import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import {MatMenuModule} from '@angular/material/menu';
import {MatDialog,MatDialogRef, MatDialogActions, MatDialogClose,MatDialogTitle,MatDialogContent} from '@angular/material/dialog';
import {MatListModule} from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';

@NgModule({
  declarations: [
  ],
  exports:[
    MatTableModule, MatButtonModule, MatIconModule,
    MatInputModule, MatFormFieldModule, MatDividerModule,MatSelectModule,
    MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent,
    MatMenuModule,
    MatListModule,
    FormsModule,MatTabsModule,
    MatFormFieldModule, MatSelectModule, MatInputModule
  ],
  imports: [
    CommonModule,
    MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent
  ]
})
export class MaterialModule { }
