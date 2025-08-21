# API de Brinquedos

## Descrição do Projeto

Este projeto consiste em uma API RESTful para gerenciamento de brinquedos infantis, desenvolvida como parte do Checkpoint 4 da disciplina de .NET. A aplicação permite realizar operações CRUD (Create, Read, Update, Delete) em um catálogo de brinquedos, oferecendo endpoints para cadastro, consulta, atualização e remoção de produtos. A API foi construída utilizando as melhores práticas de desenvolvimento com ASP.NET Core, Entity Framework Core para acesso a dados e SQL Server como banco de dados, além de contar com documentação automática através do Swagger.

API para gerenciamento de brinquedos infantis desenvolvida com ASP.NET Core e Entity Framework Core.

## Integrantes

- Afonso Correia Pereira - RM557863
- Adel Mouhaidly - RM557705
- Felipe Horta Gresele - RM556955
- Tiago Augusto Desiderato - RM558485
- Arthur - RM550615
- João Henrique - RM556221

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger para documentação da API

## Estrutura do Projeto

- **Models**: Contém a classe Brinquedo com as propriedades necessárias
- **Data**: Contém o BrinquedosContext para acesso ao banco de dados
- **Controllers**: Contém o BrinquedosController com os endpoints CRUD

## Endpoints da API

A API possui os seguintes endpoints:

- `GET /api/brinquedos`: Retorna todos os brinquedos cadastrados
- `GET /api/brinquedos/{id}`: Retorna um brinquedo específico pelo ID
- `POST /api/brinquedos`: Cadastra um novo brinquedo
- `PUT /api/brinquedos/{id}`: Atualiza um brinquedo existente
- `DELETE /api/brinquedos/{id}`: Remove um brinquedo

## Exemplo de JSON para Teste no Postman

Para cadastrar um novo brinquedo (POST):

```json
{
  "nome_brinquedo": "Boneca Barbie",
  "tipo_brinquedo": "Boneca",
  "classificacao": "3+",
  "tamanho": "Médio",
  "preco": 89.90
}
```

Para atualizar um brinquedo existente (PUT):

```json
{
  "id_brinquedo": 1,
  "nome_brinquedo": "Boneca Barbie Profissões",
  "tipo_brinquedo": "Boneca",
  "classificacao": "3+",
  "tamanho": "Médio",
  "preco": 99.90
}
```

## Como Executar o Projeto

1. Clone o repositório
2. Abra o projeto no Visual Studio
3. Execute as migrações do Entity Framework:
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
4. Execute o projeto (F5)
5. Acesse o Swagger em: https://localhost:5001/swagger

## Testes no Postman

### GET - Listar todos os brinquedos
![GET Brinquedos](imagem_get_brinquedos.png)

### POST - Cadastrar novo brinquedo
![POST Brinquedo](imagem_post_brinquedo.png)

### PUT - Atualizar brinquedo existente
![PUT Brinquedo](imagem_put_brinquedo.png)

### DELETE - Remover brinquedo
![DELETE Brinquedo](imagem_delete_brinquedo.png)