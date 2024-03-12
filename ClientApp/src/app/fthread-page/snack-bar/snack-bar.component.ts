import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-snack-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './snack-bar.component.html',
  styleUrls: ['./snack-bar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SnackBarComponent {

}
