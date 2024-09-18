
---

# Cabeleleila Leila - Sistema de Agendamento de Serviços

O **Cabeleleila Leila** é um sistema de agendamento de serviços para um salão de beleza. O sistema permite que os clientes agendem serviços como Corte de Cabelo, Hidratação, Manicure e Pedicure. O projeto foi desenvolvido utilizando **Clean Architecture**, com um banco de dados relacional MySQL e uma API em **.NET 8** que se conecta a uma aplicação MVC.

## Como logar como Admin?

- email: cabeleleiladsin@outlook.com
- senha: 1234

## Tecnologias Utilizadas

- **C# .NET 8** (API)
- **MySQL 8** (Banco de Dados)
- **Clean Architecture** (Estrutura de Código)
- **MVC** (Interface) utilizado **HTML5, CSS3, JS e Bootstrap**

## Funcionalidades

### Para o cliente

- **Cadastro e Login**: é possível se cadastrar e realizar login no sistema, além de redefinir a senha caso esqueça, na qual enviamos um email com uma nova senha.
- **Listagem de agendamentos**: é possível ver a listagem de agendamentos que esse cliente realizou. Através dessa tela o cliente pode saber o status de seu agendamento e ver os demais dados. A listagem possui um filtro que se encaixa a qualquer campo.
- **Criação de agendamento**: é possível criar um agendamento desde que a data e hora estejam disponíveis. No momento da criação o cliente escolhe o serviço e pode ou não informar uma observação. Caso o cliente já tenha um agendamento na mesma semana, ele sugere a criação do novo agendamento na mesma data.
- **Edição de agendamento**: é possível editar um agendamento até 2 dias antes da data do mesmo. Caso não cumpra essa condição, a edição fica desabilitada para este agendamento e é necessário que o cliente faça contato via telefone com a Leila.
- **Visualizar detalhes do agendamento**: é possível ver todos os detalhes de um determinado agendamento.
- **Logout**: é possível encerrar a sessão no sistema.
- **Redefinição de senha**: é possível redefinir a senha.

### Para a Leila

- **Login**: é possível realizar login no sistema, além de redefinir a senha caso esqueça, na qual enviamos um email com uma nova senha. Os dados de login estão na explicação anterior no início do Readme.
- **Visualização dos resultados semanais**: é possível ver a quantidade de agendamentos por dia na semana e ver quantos foram confirmados e quantos aguardam confirmação. Tudo isso através de gráficos intuitivos na Home.
- **Listagem de agendamentos**: é possível ver todos os agendamentos de todas as clientes, com os dados de cada um. A listagem possui um filtro que se encaixa a qualquer campo.
- **Atualização de agendamento**: é possível atualizar um agendamento.
- **Confirmação de agendamento**: é possível confirmar um agendamento.
- **Visualizar detalhes do agendamento**: é possível ver todos os detalhes de um determinado agendamento.
- **Logout**: é possível encerrar a sessão no sistema.
- **Redefinição de senha**: é possível redefinir a senha.

## Requisitos

### Softwares Necessários

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL 8.0](https://dev.mysql.com/downloads/mysql/)

### Instalação e Configuração

1. **Crie uma pasta para clonar o projeto**.
   
2. **Abra a pasta criada no prompt de comando** e execute o comando:
   ```bash
   git clone https://github.com/danibassetto/CabeleleilaLeila.git
   ```

3. **Após a clonagem**, navegue para a pasta da API:
   ```bash
   cd .\CabeleleilaLeila\CabeleleilaLeila.Api\
   ```

4. **Edite o arquivo de configuração `appsettings.json`**:
   Execute o comando abaixo para abrir o arquivo `appsettings.json` no Notepad:
   ```bash
   notepad appsettings.json
   ```
   No arquivo aberto, edite e salve o valor da chave `"ConnectionStrings": { "DataBase" }` para a sua string de conexão com o MySQL instalado.

5. **Atualize o banco de dados**:
   Execute o comando:
   ```bash
   dotnet ef database update
   ```

6. **Execute a API**:
   Inicie a API com o comando:
   ```bash
   dotnet run
   ```
   Deixe esse prompt aberto e em execução. A API estará disponível na porta **5080**.

7. **Abra um novo prompt de comando** e navegue até a aplicação web:
   ```bash
   cd .\CabeleleilaLeila\CabeleleilaLeila.Web\
   ```

8. **Execute a aplicação web**:
   Inicie o projeto MVC com o comando:
   ```bash
   dotnet run
   ```
   O frontend estará disponível em `http://localhost:5083`.

## Estrutura do Projeto

O projeto segue a abordagem de **Clean Architecture** com as seguintes camadas principais:

- **Domain**: Contém as entidades e regras de negócio.
- **Application**: Contém os casos de uso e lógica de aplicação.
- **Infrastructure**: Responsável pela comunicação com o banco de dados (MySQL) e outros serviços externos.
- **API**: Exposição dos serviços via HTTP, construída em .NET 8.
- **MVC**: Interface visual para interação com o sistema.

## Contribuições

Se você deseja contribuir com o projeto, sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença

Este projeto é licenciado sob a licença MIT.

---
