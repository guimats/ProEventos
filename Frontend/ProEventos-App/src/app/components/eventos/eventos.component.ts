import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef = {} as BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  showImg = false;
  private _filterList: string = '';

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public get filterList() {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventosFiltrados = this.filterList ? this.filterEvents(this.filterList) : this.eventos
  }

  public filterEvents(filter: string): Evento[] {
    filter = filter.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filter) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filter) !== -1
    )
  }

  public ngOnInit(): void {
    this.getEventos();
    this.spinner.show();
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide(),
        this.toastr.error('Erro ao carregar os eventos.', 'Erro!')
      },
      complete: () => this.spinner.hide()
    });
  }

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }

  public decline(): void {
    this.modalRef.hide();
  }
}
