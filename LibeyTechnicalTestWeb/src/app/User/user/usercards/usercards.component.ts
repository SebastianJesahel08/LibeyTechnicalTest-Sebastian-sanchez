import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";

@Component({
  selector: "app-usercards",
  templateUrl: "./usercards.component.html",
  styleUrls: ["./usercards.component.css"],
})
export class UsercardsComponent implements OnInit {
  search = "";
  loading = false;
  users: any[] = [];

  constructor(
    private libeyUserService: LibeyUserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.loading = true;
    this.libeyUserService.List(this.search).subscribe({
      next: (res) => {
        this.users = res || [];
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        alert("Error loading users");
      },
    });
  }

  onSearch(): void {
    this.loadUsers();
  }

  onDelete(documentNumber: string): void {
    if (!confirm("¿Eliminar usuario?")) return;

    this.libeyUserService.Delete(documentNumber).subscribe({
      next: () => {
        this.loadUsers();
      },
      error: () => {
        alert("No se pudo eliminar");
      },
    });
  }

  goNew(): void {
    this.router.navigate(["/user/maintenance"]);
  }

  goEdit(documentNumber: string): void {
    this.router.navigate(["/user/maintenance"], {
      queryParams: { documentNumber },
    });
  }
}
