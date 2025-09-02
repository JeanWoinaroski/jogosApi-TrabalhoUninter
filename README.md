🎮 Jogos API

Olá! Este é meu projeto de API para gerenciar jogos.
Ela permite ver, adicionar, atualizar e remover jogos de forma simples e prática.

🏃 Como rodar a API

Abra o projeto no IntelliJ ou em outra IDE que suporte Java e Maven.

Execute o projeto usando Maven (mvn spring-boot:run) ou diretamente pelo IntelliJ.

A API ficará disponível em: http://localhost:8080

📋 Rotas da API
Método	Rota	O que faz
GET	/jogos	Lista todos os jogos
GET	/jogos/{id}	Mostra os detalhes de um jogo
POST	/jogos	Adiciona um novo jogo
PUT	/jogos/{id}	Atualiza um jogo existente
DELETE	/jogos/{id}	Remove um jogo do sistema
💻 Exemplos de requisição e resposta
1️⃣ Listar todos os jogos

GET /jogos

Exemplo de resposta:


  {
    "id": "1",
    "nome": "The Legend of Zelda",
    "descricao": "Jogo de aventura e exploração",
    "preco": 299.99
  },
  {
    "id": "2",
    "nome": "Super Mario Odyssey",
    "descricao": "Jogo de plataforma",
    "preco": 249.99
  }


2️⃣ Buscar jogo por ID

GET /jogos/1

Exemplo de resposta:

{
  "id": "1",
  "nome": "The Legend of Zelda",
  "descricao": "Jogo de aventura e exploração",
  "preco": 299.99
}

3️⃣ Adicionar um jogo

POST /jogos

Exemplo de requisição:

{
  "nome": "Minecraft",
  "descricao": "Jogo de construção em blocos",
  "preco": 120.00
}


Retorna 201 Created se adicionado com sucesso.

4️⃣ Atualizar um jogo

PUT /jogos/1

Exemplo de requisição:

{
  "nome": "Minecraft Dungeons",
  "descricao": "Versão de aventura do Minecraft",
  "preco": 150.00
}


Retorna 200 OK se atualizado com sucesso.

5️⃣ Remover um jogo

DELETE /jogos/1

Retorna 200 OK se removido com sucesso.

⚠️ Observações

O banco de dados é em memória (H2), então os dados somem quando a aplicação é desligada.

Para testar as rotas, use Postman ou outro cliente HTTP.

Nome e preço são obrigatórios ao adicionar ou atualizar um jogo.

Retorna 400 Bad Request se os dados forem inválidos e 404 Not Found se o jogo não existir.

📌 Licença

Projeto acadêmico desenvolvido apenas para fins de estudo.
