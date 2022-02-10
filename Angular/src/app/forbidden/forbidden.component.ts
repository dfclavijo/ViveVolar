import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-forbidden',
  templateUrl: './forbidden.component.html',
  styleUrls: ['./forbidden.component.css']
})
export class ForbiddenComponent implements OnInit {

  constructor(private router:Router, private service:UserService) { }

  ngOnInit(): void {
  }
  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['user/login']);
  }

}
