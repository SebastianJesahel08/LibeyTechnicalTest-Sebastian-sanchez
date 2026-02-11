import swal from "sweetalert2";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";

@Component({
  selector: "app-usermaintenance",
  templateUrl: "./usermaintenance.component.html",
  styleUrls: ["./usermaintenance.component.css"],
})
export class UsermaintenanceComponent implements OnInit {
  documentNumberParam: string | null = null;
  isEdit = false;
  loading = false;

  documentTypes: any[] = [];

  model: any = {
    documentNumber: "",
    documentTypeId: null,
    name: "",
    fathersLastName: "",
    mothersLastName: "",
    address: "",
    ubigeoCode: "",
    phone: "",
    email: "",
    password: "",
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private libeyUserService: LibeyUserService
  ) {}

  ngOnInit(): void {
    this.documentNumberParam = this.route.snapshot.queryParamMap.get("documentNumber");
    this.isEdit = !!this.documentNumberParam;

    this.loadDocumentTypes();

    if (this.isEdit && this.documentNumberParam) {
      this.loadUser(this.documentNumberParam);
    }
  }

  loadDocumentTypes(): void {
    this.libeyUserService.GetDocumentTypes().subscribe({
      next: (res) => (this.documentTypes = res || []),
      error: () => swal.fire("Error", "No se pudo cargar tipos de documento", "error"),
    });
  }

  loadUser(documentNumber: string): void {
    this.loading = true;
    this.libeyUserService.Find(documentNumber).subscribe({
      next: (u: any) => {
        this.loading = false;
        this.model = {
          documentNumber: u.documentNumber || "",
          documentTypeId: u.documentTypeId ?? null,
          name: u.name || "",
          fathersLastName: u.fathersLastName || "",
          mothersLastName: u.mothersLastName || "",
          address: u.address || "",
          ubigeoCode: u.ubigeoCode || "",
          phone: u.phone || "",
          email: u.email || "",
          password: u.password || "",
        };
      },
      error: () => {
        this.loading = false;
        swal.fire("Error", "No se pudo cargar el usuario", "error");
      },
    });
  }

  Save(form: NgForm): void {
    if (form.invalid) {
      swal.fire("Falta información", "Completa los campos requeridos", "warning");
      return;
    }

    this.loading = true;

    if (!this.isEdit) {
      this.libeyUserService.Create(this.model).subscribe({
        next: () => {
          this.loading = false;
          swal.fire("OK", "Usuario creado", "success").then(() => {
            this.router.navigate(["/user/card"]);
          });
        },
        error: () => {
          this.loading = false;
          swal.fire("Error", "No se pudo crear el usuario", "error");
        },
      });
      return;
    }

    const doc = this.documentNumberParam!;
    this.libeyUserService.Update(doc, this.model).subscribe({
      next: () => {
        this.loading = false;
        swal.fire("OK", "Usuario actualizado", "success").then(() => {
          this.router.navigate(["/user/card"]);
        });
      },
      error: () => {
        this.loading = false;
        swal.fire("Error", "No se pudo actualizar el usuario", "error");
      },
    });
  }

  Clear(form: NgForm): void {
    form.resetForm();
    this.model = {
      documentNumber: "",
      documentTypeId: null,
      name: "",
      fathersLastName: "",
      mothersLastName: "",
      address: "",
      ubigeoCode: "",
      phone: "",
      email: "",
      password: "",
    };
    if (this.isEdit && this.documentNumberParam) {
      this.loadUser(this.documentNumberParam);
    }
  }

  Back(): void {
    this.router.navigate(["/user/card"]);
  }
}
