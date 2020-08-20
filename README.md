# Projeto base para o teste da entrevista PTS
O repositório está dividido em duas partes, backend e frontend.

## backend
Requisitos: .NET Core 3.1

Os acessos ao banco de dados SQL e MongoDb serão enviados por email.

O candidato deverá clonar o repositório enviado e subir todas as alterações nesse mesmo repositório.

## frontend
Requisitos: 
- Node JS, pode ser a versão atual LTS (https://nodejs.org/en/).
- Angular (CLI Global) `npm install -g @angular/cli`.
- Após clonar o repositório, execute o seguinte comando dentro da pasta "frontend" `npm install`.
- Após instalar os pacotes, configure a URL da API no caminho: "frontend/src/environments/environment.ts", propriedade "host".
- Para rodar o projeto execute o comando `ng serve` ou `ng serve -o` ("-o" irá automaticamente abrir o navegador no endereço "http://localhost:4200/").

## Atividades
1. Todas as entidades do projeto possuem um campo comum "CreationDate", criar uma maneira de gravar esse campo de forma genérica sempre que criar um novo registro.
2. Corrigir o erro que ocorre ao fazer uma requisição na controller "EnumsController" método "GetCustomerStatusValues". Esse método é invocado ao abrir a tela do front lista de clientes.
3. Corrigir os erros apresentados na controller "CategoriesController":
    - Erro ao realizar um GET no método GetAsync.
    - Erro ao cadastrar uma nova categoria no método PostAsync. (TIRARRRRRR)
    - Erro ao atualizar o registro no método PutAsync.
    - Formatar o campo CreationDate na resposta do método GetAsync. O formato deve seguir o seguinte padrão (MES_ABREVIADO/ANO), ex: jun/2020, ago/2020
4. Criar um CRUD de empregados no backend e frontend, requisitos:
    - Deve contemplar cadastro, alteração e eliminação
    - A tabela de empregados deve conter os seguintes campos:
        - Nome
        - Nº de documento
        - Data de contratação
        - Endereços
    - A lista de endereços deve conter os seguintes campos:
        - Tipo (1 - Comercial e 2 - Residencial)
        - Rua
        - Numero
    - O sistema deve validar se já existe um empregado com o mesmo número de documento
    - Um empregado deve ter no mínimo 1 endereço e no máximo 3. Considerar que esses limites podem sofrer alterações no futuro.
5. Implementar uma forma de capturar todos os exceptions não tratados do sistema e gravar esses erros em uma collection do MongoDb. Deve conter os seguintes campos:
    - Data do erro;
    - Endpoint do erro;
    - Detalhes da exception;
6. Terminar a implementação do job CreateUpdateProductsJob que é executado pelo HangFire, requisitos:
    - Consumir a API que retorna uma lista de produtos
        - Os requisitos para o consumo da API estão descritos na sessão (LINK PARA REFERENCIA)
    - Para todos os produtos retornados nessa lista e que não estão registrados no nosso banco, o job deve criar o registro
    - Todos os produtos já existentes o sistema deve atualizar o registro
    - O campo ExternalReferenceId na tabela ExternalProducts faz referência ao Id retornado pela API
7. Corrigir o erro que ocorre ao fazer uma requisição na controller "ExternalProductsController"

