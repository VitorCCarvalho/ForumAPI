
# ForumAPI

API básica de Fórum de Discussão. 


## Stack utilizada

- .NET Core
- Entity Framework
- MySQL



## Instalação e como usar

Clone o repositório, abra o prompt de comando e execute:

```bash
  dotnet run ForumApp
```
    
### Instalação do Banco de Dados

Tenha uma instância local de Banco MySQL em localhost, um forma de fazer isso é usando MySQL Workbench e instalando MySQL Server localmente:

[MySQL Workbench](https://www.mysql.com/products/workbench/)


Caso não tenha Entity Framework instalado execute:

```bash
  dotnet tool install --global dotnet-ef --version 6.0.6
```

Após isso execute:

```bash
  dotnet ef migrations add Add_Forum_FThread_Post
  dotnet ef database update
```

## Documentação da API

### Fórum

#### Criar um fórum novo

```http
  POST /forum/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `Name` | `string` | **Obrigatório**. Nome do Fórum |
| `Description` | `string` | **Obrigatório**. Descrição geral do Fórum |

#### Retornar todos os fóruns

```http
  GET /forum/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `take` | `int` | Quantidade de fóruns para retornar |

#### Retornar o fórum que possui forumId como ID.

```http
  GET /forum/${forumId}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `forumId`      | `int` | **Obrigatório**. ID do fórum desejado |

#### Atualizar o fórum que possui forumId como ID.

```http
  PUT /forum/${forumId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `forumId` | `int` | **Obrigatório**. ID do fórum desejado |

#### Atualizar uma parte do fórum que possui forumId como ID

```http
  PATCH /forum/${forumId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `forumId` | `int` | **Obrigatório**. ID do fórum desejado |

#### Deletar o fórum que possui forumId como ID

```http
  DELETE /forum/${forumId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `forumId` | `int` | **Obrigatório**. ID do fórum desejado |




### Thread

#### Criar uma thread nova

```http
  POST /fthread/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `ForumID` | `int` | **Obrigatório**. ID do fórum que a thread vai estar |
| `Name` | `string` | **Obrigatório**. Nome da Thread |
| `Description` | `string` | **Obrigatório**. Descrição geral da Thread |
| `UserId` | `string` | **Obrigatório**. ID do usuário que fez a Thread |

#### Retornar todas as threads

```http
  GET /fthread/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `take` | `string` | Quantidade de threads para retornar |

#### Retornar o fórum que possui forumId como ID.

```http
  GET /fthread/${fthreadId}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `fthreadId`      | `int` | **Obrigatório**. ID da thread desejada |

#### Atualizar a thread que possui fthreadId como ID.

```http
  PUT /fthread/${fthreadId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `fthreadId` | `int` | **Obrigatório**. ID da thread desejada |

#### Atualizar uma parte da thread que possui fthreadId como ID

```http
  PATCH /fthread/${fthreadId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `fthreadId` | `int` | **Obrigatório**. ID da thread desejada |

#### Deletar a thread que possui fthreadId como ID

```http
  DELETE /fthread/${fthreadId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `fthreadId` | `int` | **Obrigatório**. ID da thread desejada |



### Post

#### Criar um post novo

```http
  POST /post/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `ThreadId` | `int` | **Obrigatório**. ID da thread que o post vai estar |
| `Text` | `string` | **Obrigatório**. Nome do Post |
| `UserId` | `string` | **Obrigatório**. ID do usuário que fez o Post |

#### Retornar todos os posts

```http
  GET /post/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `take` | `string` | Quantidade de posts para retornar |

#### Retornar o post que possui postId como ID.

```http
  GET /post/${postId}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `postId`      | `int` | **Obrigatório**. ID do post desejada |

#### Atualizar o post que possui postId como ID.

```http
  PUT /post/${postId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `postId` | `int` | **Obrigatório**. ID do post desejado |

#### Atualizar uma parte do post que possui postId como ID

```http
  PATCH /post/${postId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `postId` | `int` | **Obrigatório**. ID do post desejado |

#### Deletar o post que possui postId como ID

```http
  DELETE /post/${postId}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `postId` | `int` | **Obrigatório**. ID do post desejado |



### User


#### Cadastrar um User novo

```http
  POST /user/signup
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `username` | `string` | **Obrigatório**. Usuário desejado |
| `name` | `string` | **Obrigatório**. Nome de Exibição desejado |
| `email` | `string` | **Obrigatório**. Email para cadastro |
| `password` | `string` | **Obrigatório**. Senha desejada |
| `email` | `string` | **Obrigatório**. Confirmação da senha |


#### Verificar se o user existe e retorna token de sessão jwt

```http
  POST /user/login
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `username` | `string` | **Obrigatório**. Usuário desejado |
| `password` | `string` | **Obrigatório**. Senha do usuário |

#### Retornar todos Users.

```http
  GET /user/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `take` | `int` | **Obrigatório**. Quantidade de users desejada |
