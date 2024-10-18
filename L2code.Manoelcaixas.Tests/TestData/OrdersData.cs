using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Tests.TestData
{
    public static class OrdersData
    {
        public static readonly string orderWithProductWithoutPackaging = @$"{{
  ""pedidos"": [
    {{
      ""pedido_id"": 5,
      ""produtos"": [
        {{""produto_id"": ""Cadeira Gamer"", ""dimensoes"": {{""altura"": 120, ""largura"": 60, ""comprimento"": 70}}}}
      ]
    }}
  ]
}}";
        public static readonly string orderWithProductWithPackaging = @"{
    ""pedidos"": [
      {
        ""pedido_id"": 1,
        ""produtos"": [
          {""produto_id"": ""PS5"", ""dimensoes"": {""altura"": 40, ""largura"": 10, ""comprimento"": 25}},
          {""produto_id"": ""XBOX Series X"", ""dimensoes"": {""altura"": 40, ""largura"": 10, ""comprimento"": 25}},
          {""produto_id"": ""XBOX Series S"", ""dimensoes"": {""altura"": 40, ""largura"": 10, ""comprimento"": 25}},
          {""produto_id"": ""XBOX One"", ""dimensoes"": {""altura"": 40, ""largura"": 10, ""comprimento"": 25}},
          {""produto_id"": ""Volante"", ""dimensoes"": {""altura"": 40, ""largura"": 30, ""comprimento"": 30}},
          {""produto_id"": ""Pistola"", ""dimensoes"": {""altura"": 40, ""largura"": 30, ""comprimento"": 30}},
          {""produto_id"": ""Óculos Meta Verso"", ""dimensoes"": {""altura"": 40, ""largura"": 30, ""comprimento"": 30}},
          {""produto_id"": ""Metal Gear Solid"", ""dimensoes"": {""altura"": 15, ""largura"": 20, ""comprimento"": 10}},
          {""produto_id"": ""Fifa 25"", ""dimensoes"": {""altura"": 15, ""largura"": 20, ""comprimento"": 10}},
          {""produto_id"": ""Lol"", ""dimensoes"": {""altura"": 15, ""largura"": 20, ""comprimento"": 10}},
          {""produto_id"": ""Tomp Raider"", ""dimensoes"": {""altura"": 15, ""largura"": 20, ""comprimento"": 10}}
        ]
      }
    ]
  }";

        public static readonly string orderWithManyBoxProduct = @"{
  ""pedidos"": [
    {
      ""pedido_id"": 11,
      ""produtos"": [
          {
              ""produto_id"": ""PRD-9410"",
              ""dimensoes"": {
                  ""altura"": 46,
                  ""largura"": 20,
                  ""comprimento"": 31
              }
          },
          {
              ""produto_id"": ""PRD-8052"",
              ""dimensoes"": {
                  ""altura"": 32,
                  ""largura"": 39,
                  ""comprimento"": 21
              }
          },
          {
              ""produto_id"": ""PRD-4150"",
              ""dimensoes"": {
                  ""altura"": 45,
                  ""largura"": 33,
                  ""comprimento"": 13
              }
          },
          {
              ""produto_id"": ""PRD-5309"",
              ""dimensoes"": {
                  ""altura"": 20,
                  ""largura"": 38,
                  ""comprimento"": 13
              }
          },
          {
              ""produto_id"": ""PRD-7622"",
              ""dimensoes"": {
                  ""altura"": 15,
                  ""largura"": 35,
                  ""comprimento"": 33
              }
          },
          {
              ""produto_id"": ""PRD-5644"",
              ""dimensoes"": {
                  ""altura"": 41,
                  ""largura"": 28,
                  ""comprimento"": 16
              }
          },
          {
              ""produto_id"": ""PRD-2279"",
              ""dimensoes"": {
                  ""altura"": 39,
                  ""largura"": 39,
                  ""comprimento"": 19
              }
          },
          {
              ""produto_id"": ""PRD-5623"",
              ""dimensoes"": {
                  ""altura"": 48,
                  ""largura"": 11,
                  ""comprimento"": 13
              }
          },
          {
              ""produto_id"": ""PRD-7605"",
              ""dimensoes"": {
                  ""altura"": 35,
                  ""largura"": 10,
                  ""comprimento"": 29
              }
          },
          {
              ""produto_id"": ""PRD-9041"",
              ""dimensoes"": {
                  ""altura"": 30,
                  ""largura"": 28,
                  ""comprimento"": 25
              }
          },
          {
              ""produto_id"": ""PRD-8539"",
              ""dimensoes"": {
                  ""altura"": 36,
                  ""largura"": 33,
                  ""comprimento"": 25
              }
          },
          {
              ""produto_id"": ""PRD-1291"",
              ""dimensoes"": {
                  ""altura"": 24,
                  ""largura"": 38,
                  ""comprimento"": 28
              }
          },
          {
              ""produto_id"": ""PRD-4163"",
              ""dimensoes"": {
                  ""altura"": 49,
                  ""largura"": 15,
                  ""comprimento"": 29
              }
          },
          {
              ""produto_id"": ""PRD-7173"",
              ""dimensoes"": {
                  ""altura"": 40,
                  ""largura"": 28,
                  ""comprimento"": 33
              }
          },
          {
              ""produto_id"": ""PRD-6583"",
              ""dimensoes"": {
                  ""altura"": 46,
                  ""largura"": 16,
                  ""comprimento"": 33
              }
          }
      ]
    }
  ]
}";

        public static readonly string productWithOutBoxMessage = "Produto não cabe em nenhuma caixa disponível.";


        public static readonly string result = @"{
  ""pedidos"": [
    {
      ""pedido_id"": ""5"",
      ""caixas"": [
        {
          ""caixa_id"": null,
          ""produtos"": [
            ""Cadeira Gamer""
          ],
          ""observacao"": ""Produto não cabe em nenhuma caixa disponível.""
        }
      ]
    }
  ]
}";
    }
}
