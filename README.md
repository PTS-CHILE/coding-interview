# Projeto base para o teste da entrevista PTS
O repositório está dividido em duas partes, backend e frontend.

# backend
Requisitos: .NET Core 3.1
Os acessos ao banco de dados SQL e MongoDb serão enviados por email.
O candidato deverá clonar o repositório enviado e subir todas as alterações nesse mesmo repositório.

## Atividades:
1. Todas as entidades do projeto possuem um campo comum "CreationDate", criar uma maneira de gravar esse campo de forma genérica sempre que criar um novo registro.
2. Corrigir o erro que ocorre um ao fazer uma requisição na controller "EnumsController" método "GetCustomerStatusValues".
3. Corrigir os erros apresentados na controller "CategoriesController":
* Erro ao realizar um GET no método GetAsync.
* Erro ao cadastrar uma nova categoria no método PostAsync.
* Erro ao atualizar o registro no método PutAsync.
* Formatar o campo CreationDate na resposta do método GetAsync. O formato deve seguir o seguinte padrão (MES_ABREVIADO/ANO), ex: jun/2020, ago/2020
