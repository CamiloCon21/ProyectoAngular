// app.module.ts o el módulo donde esté tu LoginComponent
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {  provideHttpClient, withFetch } from '@angular/common/http'; // Importar HttpClientModule
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component'; // Asegúrate de importar el componente
import { LoginModule } from './login/Login.module';

@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    BrowserModule,
    LoginModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
