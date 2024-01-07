import { TestBed } from '@angular/core/testing';

import { EditarDatosService } from './editar-datos.service';

describe('EditarDatosService', () => {
  let service: EditarDatosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditarDatosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
