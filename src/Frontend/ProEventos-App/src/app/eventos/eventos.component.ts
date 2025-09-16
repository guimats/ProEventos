import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventosFiltrados: any = [];
  showImg = false;
  private _filterList: string = '';

  public get filterList() {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventosFiltrados = this.filterList ? this.filterEvents(this.filterList) : this.eventos
  }

  filterEvents(filter: string): any {
    filter = filter.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filter) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filter) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get(`https://localhost:5001/eventos`).subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = response;
      },
      error => console.log(error)
    );
  }
}
