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
6. Escrever no arquivo [query-mongo](feedback/query-mongo.txt) qual seria a query no MongoDb para retornar todos os erros desde 01/08/2020.
6. Finalizar a implementação do método CreateUpdateProductsAsync da service ExternalProductService que é invocado pelo HangFire ([clique aqui para mais detalhes do Hangfire](#hangfire))
    - Esse método irá trabalhar com a entidade ExternalProducts que já está criada com os seguintes campos:
        - Id
        - ExternalReferenceId
        - Name
        - Code
        - ExpireDate
        - LastUpdate
        - IsRemoved
        - CreationDate
    - O processo deve consumir uma API e popular a tabela de acordo com os dados retornados
        - Os requisitos para o consumo da API estão descritos na sessão ([documentação API de produtos](#api))
    - O fluxo do processo deve ser o seguinte:
        - Inserir no banco de dados todos os produtos retornados da API e que ainda não estão registrados
        - Atualizar os produtos no banco de dados que já estejam registrados
        - Para verificar se o produto já se encontra registrado, utilizar o campo ExternalReferenceId que faz referência ao Id retornado pela API
7. Corrigir o erro que ocorre ao fazer uma requisição na controller "ExternalProductsController"

## HangFire
Hangfire é uma ferramenta para executar processos e jobs em background diretamente nas aplicações ASP.NET Core.

O framework já está configurado nessa aplicação e para acessá-lo basta entrar em "https://url-aplicacao-backend/jobs/recurring"

A documentação do Hangfire está disponível em https://www.hangfire.io/

## API Produtos - Documentação 
A API possui dois metodos:
 - Login, para se autenticar na API e que te devolve um token valido para acesso aos outros métodos.
    [POST][https://dev.paytechholding.com/coding-interview-products/api/login]
    Request Body: objeto JSON conforme estrutura e valores abaixo
    {
        "id": "paytech",
        "password": "pts@2020"
    }
    Response Body: objeto JSON conforme estrutura e valores abaixo
    "user": {
        "id": "paytech"
    },
    "token": "<token>"
 - Consulta de produtos, retorna uma lista de produtos
    [GET][https://dev.paytechholding.com/coding-interview-products/api/products]
    Request Header: enviar parametro "Authorization" com valor conforme abaixo, onde <token> é o <token> retornado no Login
    "Bearer <token>" (sem os caracteres <>)
    Response Body: lista de objetos JSON conforme estrutura abaixo
    [
        {
            "id": int,
            "name": string,
            "code": string,
            "creationDate": dateTime,
            "expireDate": dateTime,
            "lastUpdate": dateTime,
            "isRemoved": boolean
        },
        ...
    ]
    
## Feedbacks
Caso deseje explicar alguma implementação, por favor deixar seus comentários no arquivo [feedback](feedback/feedback.txt)

Gostaríamos também de ouvir a sua opnião e sugestões sobre a prova.

Obrigado por participar do processo seletivo da PTS.
