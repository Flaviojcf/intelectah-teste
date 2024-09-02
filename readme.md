<h1 align="center">Library Manager</h1>

<br />
<div align="center">
  <a href="https://github.com/Flaviojcf/projects-payments">
    <img src="./intelectah-capa.png" alt="intelectah-capa-png">
  </a>
</div>

O projeto envolve o desenvolvimento de uma aplica��o web para a gest�o de concession�rias de ve�culos utilizando ASP.NET MVC e Entity Framework. A aplica��o tem como objetivo gerenciar fabricantes de ve�culos, concession�rias, e a realiza��o de vendas, integrando autentica��o e autoriza��o de usu�rios.

## Tecnologias, Arquitetura e Design Patterns
- ASP Net MVC
- Entity Framework Core
- Clean Architecture
- Repository
- CQRS
- MediatR
- FluentValidation

# Rodando a aplica��o localmente

## Clonando a aplica��o

``` 
https://github.com/Flaviojcf/intelectah-teste.git
```

Entre na pasta do projeto

``` 
cd intelectah-teste
```

## Configurando a String de Conex�o

Abra o arquivo appsettings.json no projeto intelectah.MVC.

Atualize a string de conex�o para usar o banco de dados local:

``` 

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=Intelectah;Integrated Security=True;TrustServerCertificate=True"
}

``` 

## Aplicando as Migrations

Abra o Package Manager Console.

Selecione o projeto intelectah.Infrastructure como o projeto padr�o.

Execute o comando para aplicar as migrations

``` 

Update-Database

``` 



## Rodando a aplica��o

No Visual Studio, defina intelectah.MVC como o projeto de inicializa��o:

Clique com o bot�o direito no projeto intelectah.MVC.

Selecione Set as Startup Project.

Pressione F5 para rodar em modo de depura��o ou Ctrl + F5 para rodar sem depura��o.

# Acessando a aplica��o hospedada

``` 
https://intelectahmvc.azurewebsites.net/

```

## Contato

[@Flaviojcf](mailto:flaviojcostafilho@gmail.com)


