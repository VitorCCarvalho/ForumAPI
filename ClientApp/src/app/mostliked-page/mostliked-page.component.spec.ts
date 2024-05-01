import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostlikedPageComponent } from './mostliked-page.component';

describe('MostlikedPageComponent', () => {
  let component: MostlikedPageComponent;
  let fixture: ComponentFixture<MostlikedPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MostlikedPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MostlikedPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
