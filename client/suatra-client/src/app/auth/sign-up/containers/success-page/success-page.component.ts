import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { faSignInAlt } from '@fortawesome/free-solid-svg-icons';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-success-page',
  templateUrl: './success-page.component.html',
  styleUrls: ['./success-page.component.scss'],
})
export class SuccessPageComponent implements OnInit {
  faSignIn = faSignInAlt;
  email: string;
  subSink = new SubSink();

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.subSink.sink = this.route.queryParams.subscribe((query) => {
      const { email } = query;
      if (!email) {
        this.router.navigate(['auth']);
      }
      this.email = email;
    });
  }
}
