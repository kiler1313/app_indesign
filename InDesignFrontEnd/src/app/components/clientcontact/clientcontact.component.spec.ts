import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientcontactComponent } from './clientcontact.component';

describe('ClientcontactComponent', () => {
  let component: ClientcontactComponent;
  let fixture: ComponentFixture<ClientcontactComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientcontactComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientcontactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
