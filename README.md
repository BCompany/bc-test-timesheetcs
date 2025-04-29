# bc-test-timesheetcs
Teste para desenvolvedores CSharp - BCompany

# Requisitos Funcionais

Cadastrar colaborador  
Registrar entrada e saída com ip do colaborador a cada lançamento  
Consultar horas trabalhadas por período  
Relatório periodo com: Total de horas /  Média diária / Horas extras (acima 8h)  
Relatório de dias com inconsistências/alertas  (pontos não marcados)  


# Requisitos Técnicos

.NET Core (>= 6)  
Separação clara de responsabilidades (Clean Architecture ou similar)  
Uso de Interfaces  
Padrões de projeto (como Repository, Service, DTOs, Mapper, SAGA)  
Verbos REST bem definidos  
Tratamento de erros com retorno adequados  
Persistir colaborador, entrada e saída em banco de dados conforme abaixo - usar ADO ou ORM de preferência

# Sugestão de EndPoints

Método	Endpoint	Descrição  
POST	/api/employees	Criar colaborador  
POST	/api/timesheet/clockopen	Registrar entrada  
POST	/api/timesheet/clockin	Registrar entrada  
POST	/api/timesheet/clockout	Registrar saída  
GET	/api/timesheet/report	Obter relatório por período  
GET /api/timesheet/alerts  


# Banco de Dados

TSM_Employee - armazena dados de colaboradores
TSM_Entrie - armazena entradas e saidas
O campo typ_entrie deve armazenat CHEKOUT OU CHECKIN DE de acordo com o ipo de lançamento

![DatabaseER](https://github.com/user-attachments/assets/19c2fada-a5a8-4266-b996-f2406320a710)


# Regras

Validar duplicidade, apontamentos abaixo de 1 min    
Jornada máxima: 8h/dia (acima disto é hora extra)  
Jornadas partidas precisam ser somadas no report  
Considerar períodos inválidos (ex: saída sem entrada anterior, entrada dupla e/ou sem saída anterior)  
Programar regras de cálculo de horas (ex: tratar jornadas partidas, duplicidade de lançamento, inconsistências como lançamentos faltantes, horas extras)  
Ao registrar entrada ou saída primeiro salvar os dados enviados, posteriormente obter e salvar o IP (ver API abaixo), caso a API falhe, compensar usando o pattern SAGA.

**API IP Colaborador: https://api.ipify.org?format=json**

Os endpoins do relatorio devem retornar os dados em formato JSON.


# Camadas

- Timesheet.API           // Controllers, Middlewares, DTOs  
- Timesheet.Domain        // Entidades, Enums, Lógicas de Negócio  
- Timesheet.Data          // Repositórios, Persistencia  


 
