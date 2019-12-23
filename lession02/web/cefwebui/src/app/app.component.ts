import { Component, OnInit } from '@angular/core';
declare var cefCustomObject;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'cefwebui';
  constructor() {

  }
  ngOnInit(): void {
    window['AppComponentRef'] = this;
  }
  //#region JS呼叫C#
  openDevTools() {
    cefCustomObject.showDevTools();
  }
  opencmdTools() {
    cefCustomObject.opencmd();
  }
  showJsArg() {
    console.log("showJsArg");
    cefCustomObject.showJsArg("參數arg1", "參數arg2");
  }
  showJsObj() {
    console.log("showJsObj");
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
  //#endregion JS呼叫C#
  //#region C#呼叫JS
  callByNet(arg1, arg2) {
    let alertMessage = "angular :arg1 is " + arg1 + " and arg2 is " + arg2 + "!";
    alert(alertMessage);
  }
  callbyNetobj(jsonstr) {
    let jo = JSON.parse(jsonstr);
    alert(JSON.stringify(jo));
  }
  callbyNetobjlst(jsonstr) {
    let jo = JSON.parse(jsonstr);
    let msg = JSON.stringify(jo);
    console.log(msg);
    alert(msg);
  }
  //#endregion C#呼叫JS
}
