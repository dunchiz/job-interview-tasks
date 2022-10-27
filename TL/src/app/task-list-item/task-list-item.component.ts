import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-task-list-item',
  templateUrl: './task-list-item.component.html',
  styleUrls: ['./task-list-item.component.css']
})
export class TaskListItemComponent implements OnInit {

  @Input()
  id: number;
  @Input()
  name: string;
  @Output() nameChange = new EventEmitter<string>();

  @Input()
  done: boolean;
  @Output() doneChange = new EventEmitter<boolean>();
  @Output() deleteTask= new EventEmitter<void>();

  constructor() { }

  ngOnInit() {
  }

  onNameChange(event: Event) {
    this.nameChange.emit((event.target as HTMLTextAreaElement).value);
  }

  onDoneChange(event: Event) {
    console.log('change triggered')
    this.done = (event.target as HTMLInputElement).checked;
    this.doneChange.emit(this.done);
  }

  deleteTaskBtnClick() {
    this.deleteTask.emit();
  }

}
