# api-csharp
API REST utilizando a linguagem C#, contendo as seguintes funcionalidades:

## Requisitos
- [x] 1. Uma rota para autenticação;

- [x] 2. Uma rota para consulta de pessoas, que deve retornar uma lista de objeto de pessoas;

- [x] 3. Uma rota para consultar uma pessoa pelo seu código;

- [x] 4. Uma rota para consultar pessoas de uma determinada UF;

- [x] 5. Uma rota de gravar pessoa, que deve retornar o objeto “salvo”; 
    O método deve ser capaz de validar as informações recebidas;
    
- [x] 6. Uma rota para atualizar os dados de uma pessoa, que deve retorno o objeto atualizado;

- [x] 7. Uma rota para excluir uma pessoa;

- [ ] 8. Todas rotas, com exceção da de autenticação, devem validar se a requisição possui um Token
autenticado.

### Observações
- O objeto de pessoas possui apenas código, nome, CPF, UF e data de nascimento.

- A validação do token da requisição não foi implementada

- Não foi implementada uma camada View. Para testes, importar collection de requests no Postman.

(Json with collection) [https://github.com/Viniciusalopes/api-csharp/blob/master/api-csharp.postman_collection.json]







