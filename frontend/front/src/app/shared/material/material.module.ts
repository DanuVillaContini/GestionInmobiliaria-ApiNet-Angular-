import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import {MatDialog,MatDialogRef, MatDialogActions, MatDialogClose,MatDialogTitle,MatDialogContent} from '@angular/material/dialog';

@NgModule({
  declarations: [
  ],
  exports:[
    MatTableModule, MatButtonModule, MatIconModule,
    MatInputModule, MatFormFieldModule, MatDividerModule,MatSelectModule,
    MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent,
  ],
  imports: [
    CommonModule,
    MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent
  ]
})
export class MaterialModule { }
