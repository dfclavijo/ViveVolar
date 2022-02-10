import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styles: [
  ]
})
export class AdminPanelComponent implements OnInit {

  constructor(private router:Router, private service:UserService) { }

  ngOnInit(): void {

  }

  goToLink(url: string){
    window.open(url, "_blank");
    }

    onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['user/login']);
  }

}
