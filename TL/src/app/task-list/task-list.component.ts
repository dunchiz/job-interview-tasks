import { Component, OnInit } from '@angular/core';
import { TaskListItem } from '../TaskModel/TaskItem';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  tls: TaskListItem[] | null = JSON.parse(localStorage.getItem("tls")) || [];
  idCounter: number;
  constructor() {
    this.idCounter = this.tls.length ? Math.max(...this.tls.map(p => p.id)) : 1;
  }

  ngOnInit() {

  }
  /**Добавляет задачу */
  addTaskEvent(event: Event) {
    this.tls.push({ id: this.idCounter++, name: "", done: false } as TaskListItem);
    console.log(this.tls);
  }
  /**меняет название */
  changeName(tl: TaskListItem, name: string) {
    if (name != '') {
      tl.name = name;
      this.saveNotEmpty();

    }
  }
  /**устанавливает статус готовности */
  changeDone(tl: TaskListItem, done: boolean) {
    tl.done = done;
    this.saveNotEmpty();

  }
  /**удаляет задачу из списка */
  deleteTask(tl: TaskListItem) {
    this.tls = this.tls.filter(obj => {
      if (obj.id !== tl.id)
        return obj;
    });
    this.saveNotEmpty();
  }
  /**сохраняет не пустые задачи */
  saveNotEmpty() {
    localStorage.setItem("tls", JSON.stringify(this.tls.filter(p => p.name != '')));
  }
}
