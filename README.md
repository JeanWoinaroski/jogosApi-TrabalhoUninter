🎮 Jogos API

Olá! 👋
Este é meu projeto de API para gerenciar jogos.
Você pode ver, adicionar, atualizar e remover jogos de forma simples e prática.

🏃 Como rodar a API

Abra o projeto no IntelliJ ou outra IDE que suporte Java e Maven.

Execute o projeto.

A API ficará disponível em: http://localhost:8080

✅ Assim você consegue testar todas as rotas rapidamente.

📋 Rotas da API

💡 Nota: Nome e preço são obrigatórios para criar ou atualizar um jogo.

GET /jogos → Lista todos os jogos

✅ Retorna 200 OK

GET /jogos/{id} → Mostra os detalhes de um jogo

✅ Retorna 200 OK

⚠️ Retorna 404 Not Found se o jogo não existir

POST /jogos → Adiciona um novo jogo

✅ Retorna 201 Created

⚠️ Retorna 400 Bad Request se nome ou preço não forem preenchidos

PUT /jogos/{id} → Atualiza um jogo existente

✅ Retorna 200 OK

⚠️ Retorna 400 Bad Request se os dados forem inválidos

⚠️ Retorna 404 Not Found se o jogo não existir

DELETE /jogos/{id} → Remove um jogo do sistema

✅ Retorna 200 OK

⚠️ Retorna 404 Not Found se o jogo não existir

💻 Exemplos de uso
1️⃣ Listar todos os jogos

GET /jogos

Exemplo de resposta:

[
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
]

2️⃣ Buscar um jogo por ID

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

4️⃣ Atualizar um jogo

PUT /jogos/1

Exemplo de requisição:

{
  "nome": "Minecraft Dungeons",
  "descricao": "Versão de aventura do Minecraft",
  "preco": 150.00
}

5️⃣ Remover um jogo

DELETE /jogos/1

⚠️ Observações importantes

O banco de dados é em memória (H2) → os dados somem quando a aplicação é desligada.

Nome e preço são obrigatórios ao adicionar ou atualizar jogos.

Use Postman
 ou outro cliente HTTP para testar as rotas.

📌 Licença

Projeto acadêmico desenvolvido apenas para estudo.
