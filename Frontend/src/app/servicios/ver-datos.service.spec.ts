import { TestBed } from '@angular/core/testing';

import { VerDatosService } from './ver-datos.service';

describe('VerDatosService', () => {
  let service: VerDatosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VerDatosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
