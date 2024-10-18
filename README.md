Após inicializar o container o seguinte serviço deve ser acionado através do swagger:
/api/Auth/token

Informar o seguinte payload:
{
  "userName": "string",
  "password": "string"
}

A aplicação deve retornar algo como o seguinte payload:
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InN0cmluZyIsIm5iZiI6MTcyOTIzNzIwNywiZXhwIjoxNzI5MjQwODA3LCJpYXQiOjE3MjkyMzcyMDcsImlzcyI6InlvdXJJc3N1ZXIiLCJhdWQiOiJ5b3VyQXVkaWVuY2UifQ.3ABxbIP6G76FXh9dZLIWIpLOxHZZ_ytmbl_NuV5hYYU"
}

Copie o conteúdo da chave token e inclua no formulário Authorize do Swagger para realizar a autenticação.
Em value coloque o valor gerado seguido da palavra Bearer. Exemplo:

Value: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InN0cmluZyIsIm5iZiI6MTcyOTIzNzIwNywiZXhwIjoxNzI5MjQwODA3LCJpYXQiOjE3MjkyMzcyMDcsImlzcyI6InlvdXJJc3N1ZXIiLCJhdWQiOiJ5b3VyQXVkaWVuY2UifQ.3ABxbIP6G76FXh9dZLIWIpLOxHZZ_ytmbl_NuV5hYYU 

Após realizar a autenticação é necessário acionar o serviço:
/api/Packaging

Tente o seguinte payload:

{
    "pedidos": [
      {
        "pedido_id": 1,
        "produtos": [
          {"produto_id": "PS5", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
          {"produto_id": "XBOX Series X", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
          {"produto_id": "XBOX Series S", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
          {"produto_id": "XBOX One", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
          {"produto_id": "Volante", "dimensoes": {"altura": 40, "largura": 30, "comprimento": 30}},
          {"produto_id": "Pistola", "dimensoes": {"altura": 40, "largura": 30, "comprimento": 30}},
          {"produto_id": "Óculos Meta Verso", "dimensoes": {"altura": 40, "largura": 30, "comprimento": 30}},
          {"produto_id": "Metal Gear Solid", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}},
          {"produto_id": "Fifa 25", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}},
          {"produto_id": "Lol", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}},
          {"produto_id": "Tomp Raider", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}}
        ]
      },
      {
        "pedido_id": 2,
        "produtos": [
          {"produto_id": "Joystick", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}},
          {"produto_id": "Fifa 24", "dimensoes": {"altura": 10, "largura": 30, "comprimento": 10}},
          {"produto_id": "Call of Duty", "dimensoes": {"altura": 30, "largura": 15, "comprimento": 10}}
        ]
      },
      {
        "pedido_id": 3,
        "produtos": [
          {"produto_id": "Headset", "dimensoes": {"altura": 25, "largura": 15, "comprimento": 20}}
        ]
      },
      {
        "pedido_id": 4,
        "produtos": [
          {"produto_id": "Mouse Gamer", "dimensoes": {"altura": 5, "largura": 8, "comprimento": 12}},
          {"produto_id": "Teclado Mecânico", "dimensoes": {"altura": 4, "largura": 45, "comprimento": 15}}
        ]
      },
      {
        "pedido_id": 5,
        "produtos": [
          {"produto_id": "Cadeira Gamer", "dimensoes": {"altura": 120, "largura": 60, "comprimento": 70}}
        ]
      },
      {
        "pedido_id": 6,
        "produtos": [
          {"produto_id": "Webcam", "dimensoes": {"altura": 7, "largura": 10, "comprimento": 5}},
          {"produto_id": "Microfone", "dimensoes": {"altura": 25, "largura": 10, "comprimento": 10}},
          {"produto_id": "Monitor", "dimensoes": {"altura": 50, "largura": 60, "comprimento": 20}},
          {"produto_id": "Notebook", "dimensoes": {"altura": 2, "largura": 35, "comprimento": 25}}
        ]
      },
      {
        "pedido_id": 7,
        "produtos": [
          {"produto_id": "Jogo de Cabos", "dimensoes": {"altura": 5, "largura": 15, "comprimento": 10}}
        ]
      },
      {
        "pedido_id": 8,
        "produtos": [
          {"produto_id": "Controle Xbox", "dimensoes": {"altura": 10, "largura": 15, "comprimento": 10}},
          {"produto_id": "Carregador", "dimensoes": {"altura": 3, "largura": 8, "comprimento": 8}}
        ]
      },
      {
        "pedido_id": 9,
        "produtos": [
          {"produto_id": "Tablet", "dimensoes": {"altura": 1, "largura": 25, "comprimento": 17}}
        ]
      },
      {
        "pedido_id": 10,
        "produtos": [
          {"produto_id": "HD Externo", "dimensoes": {"altura": 2, "largura": 8, "comprimento": 12}},
          {"produto_id": "Pendrive", "dimensoes": {"altura": 1, "largura": 2, "comprimento": 5}}
        ]
      },
      {
        "pedido_id": 11,
        "produtos": [
            {
                "produto_id": "PRD-9410",
                "dimensoes": {
                    "altura": 46,
                    "largura": 20,
                    "comprimento": 31
                }
            },
            {
                "produto_id": "PRD-8052",
                "dimensoes": {
                    "altura": 32,
                    "largura": 39,
                    "comprimento": 21
                }
            },
            {
                "produto_id": "PRD-4150",
                "dimensoes": {
                    "altura": 45,
                    "largura": 33,
                    "comprimento": 13
                }
            },
            {
                "produto_id": "PRD-5309",
                "dimensoes": {
                    "altura": 20,
                    "largura": 38,
                    "comprimento": 13
                }
            },
            {
                "produto_id": "PRD-7622",
                "dimensoes": {
                    "altura": 15,
                    "largura": 35,
                    "comprimento": 33
                }
            },
            {
                "produto_id": "PRD-5644",
                "dimensoes": {
                    "altura": 41,
                    "largura": 28,
                    "comprimento": 16
                }
            },
            {
                "produto_id": "PRD-2279",
                "dimensoes": {
                    "altura": 39,
                    "largura": 39,
                    "comprimento": 19
                }
            },
            {
                "produto_id": "PRD-5623",
                "dimensoes": {
                    "altura": 48,
                    "largura": 11,
                    "comprimento": 13
                }
            },
            {
                "produto_id": "PRD-7605",
                "dimensoes": {
                    "altura": 35,
                    "largura": 10,
                    "comprimento": 29
                }
            },
            {
                "produto_id": "PRD-9041",
                "dimensoes": {
                    "altura": 30,
                    "largura": 28,
                    "comprimento": 25
                }
            },
            {
                "produto_id": "PRD-8539",
                "dimensoes": {
                    "altura": 36,
                    "largura": 33,
                    "comprimento": 25
                }
            },
            {
                "produto_id": "PRD-1291",
                "dimensoes": {
                    "altura": 24,
                    "largura": 38,
                    "comprimento": 28
                }
            },
            {
                "produto_id": "PRD-4163",
                "dimensoes": {
                    "altura": 49,
                    "largura": 15,
                    "comprimento": 29
                }
            },
            {
                "produto_id": "PRD-7173",
                "dimensoes": {
                    "altura": 40,
                    "largura": 28,
                    "comprimento": 33
                }
            },
            {
                "produto_id": "PRD-6583",
                "dimensoes": {
                    "altura": 46,
                    "largura": 16,
                    "comprimento": 33
                }
            }
        ]
      }
    ]
  }
  
A aplicação deve retornar a validação do pedido, verificando em quas caixas os produtos devem ser acomodados.
