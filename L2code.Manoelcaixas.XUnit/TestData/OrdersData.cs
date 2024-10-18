using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.XUnit.TestData
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
        public static readonly string orderWithProductWithPackaging = @"";
        public static readonly string orderWithManyBoxProduct = @"";


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
