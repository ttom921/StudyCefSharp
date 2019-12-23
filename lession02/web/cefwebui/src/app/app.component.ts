import { Component } from '@angular/core';
declare var cefCustomObject;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'cefwebui';
  openDevTools() {
    cefCustomObject.showDevTools();
  }
  opencmdTools() {
    cefCustomObject.opencmd();
  }
  showJsArg() {
    cefCustomObject.showJsArg("參數arg1", "參數arg2");
  }
  showJsObj() {
    let obj = {
      name: "apple",
      price: 25
    }
    let str = JSON.stringify(obj);
    cefCustomObject.showJsObj(str);
  }
  showJsListObj() {
    let objlist = [];
    for (let index = 0; index < 3; index++) {
      let obj = {
        name: `name${index}`,
        price: (index + 10)
      }
      objlist.push(obj);
    }
    let str = JSON.stringify(objlist);
    cefCustomObject.showJsListObj(str);
  }
}
