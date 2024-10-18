using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.Services
{
    public class PackagingInBoxes
    {
        //public PackagingFeedbackDTO Packaging(List<Packaging> pedidos)
        //{
        //    var resposta = new PackagingFeedbackDTO
        //    {
        //        Pedidos = new List<OrderFeedbackDTO>()
        //    };

        //    foreach (var pedido in pedidos)
        //    {
        //        var pedidoResposta = new OrderFeedbackDTO
        //        {
        //            PedidoId = pedido.PedidoId,
        //            Caixas = new List<BoxesFeedbackDTO>()
        //        };

        //        // Aqui, implementaria a lógica de empacotamento dos produtos nas caixas disponíveis.
        //        // Preenchendo as caixas com os produtos

        //        resposta.Pedidos.Add(pedidoResposta);
        //    }

        //    return resposta;
        //}

        //public void ValidadeVolumeOfProduct(InputOrdersDTO caixasDTO)
        //{
        //    foreach (var orderItem in caixasDTO.Orders)
        //    {
        //        orderItem.Products
        //    }
        //}
        //public void PossiblesBoxForProducts()
        //{
        //}

        public InputOrdersDTO ProductPackagingStrategy(InputOrdersDTO caixasDTO)
        {
            // Ordena produtos por volume decrescente
            var item = new PackagingFeedbackDTO();
            item.Orders = new List<OrdersFeedbackDTO>();

            foreach (var orderItem in caixasDTO.Orders)
            {
                var AllBoxToPackagingInOrder = new List<Boxes>();
                orderItem.Boxes = new List<Boxes>();

                var produtosOrdenados = orderItem.Products.OrderByDescending(p => p.Dimensions.Volume).ToList();
                foreach (var productItem in produtosOrdenados)
                {
                    //apenas verifica se o produto cabe em uma caixa disponível.
                    var boxToPackagingProduct = this.SelectBoxToPackaging(productItem);
                    var hasBoxToPackaging = boxToPackagingProduct != null;

                    //verificar se o pedido já tem uma caixa aberta e se houver verificar se o volume dela comporta mais um produto
                    //var orderHasBoxWithVolumeAvailable = false;
                    var hasBoxInOrder = orderItem.Boxes.Count > 0;

                    var boxWithVolumeAvaliable = orderItem.Boxes
                        .Where(f => f.VolumeAvailable >= productItem.Dimensions.Volume);
                    var hasBoxWithVolumeAvaliableInOrder = boxWithVolumeAvaliable
                        .FirstOrDefault() != null;
                    var boxOpenWithVolumeAvaliable = boxWithVolumeAvaliable
                        .FirstOrDefault();

                    //var orderHasOpenBox = boxOpenWithVolumeAvaliable != null;

                    //para o pedido receber uma caixa ele deve: ter uma caixa compatível com o produto, ter uma caixa compatível com o produto e esta caixa ter espaço disponível
                    if ((!hasBoxInOrder || !hasBoxWithVolumeAvaliableInOrder) && hasBoxToPackaging)
                    {
                        //inclui caixa no pedido
                        orderItem.Boxes.Add(boxToPackagingProduct);
                        boxOpenWithVolumeAvaliable = boxToPackagingProduct;
                        hasBoxWithVolumeAvaliableInOrder = true;
                    }

                    //se couber então deve incluir na mesma caixa o produto.
                    //se não deve encontrar outra caixa que permita a inclusão do produto.
                    //se o pedido já tiver uma caixa aberta então deve incluir o produto na mesma caixa, caso contrário deve incluir em outra

                    if (hasBoxWithVolumeAvaliableInOrder)
                    {
                        //valida informações sobre o pedido
                        productItem.ProductIsSmall = this.IsSmallProduct(productItem, boxOpenWithVolumeAvaliable);
                        productItem.HasBoxToThisProduct = this.ProductFitsInBox(productItem, boxOpenWithVolumeAvaliable);

                        boxOpenWithVolumeAvaliable.Products.Add(productItem);

                    }
                    else
                    {
                        productItem.ProductIsSmall = false;
                        productItem.HasBoxToThisProduct = false;

                        orderItem.Boxes.Add(new Boxes()
                        {
                            BoxId = null,
                            Products = new List<ProductsDTO>() { productItem }
                        });
                    }

                }

            }

            //após a validação dos produtos com relação a adequação a embalagem para postagem deve ser preparada a resposta do serviço com a orientação final.

            return caixasDTO;

        }

        public bool IsSmallProduct(ProductsDTO product, Boxes? box)
        {
            // Definir um limite de "pequeno" como produtos que ocupam menos de 20% da caixa
            decimal boxVolume;
            
            if (box != null)
            {
                boxVolume = box.Dimensions.Volume;
            }
            else
            {
                boxVolume = 0;
            }
            
            decimal limitePequeno = boxVolume * Convert.ToDecimal(0.20);

            return product.Dimensions.Volume <= limitePequeno;
        }

        public bool ProductFitsInBox(ProductsDTO products, DTOs.Boxes box)
        {
            if(box == null)
            {
                return false;
            }

            return products.Dimensions.Height <= box.Dimensions.Height &&
                   products.Dimensions.Width <= box.Dimensions.Width &&
                   products.Dimensions.Length <= box.Dimensions.Length && 
                   products.Dimensions.Volume <= box.Dimensions.Volume;

        }

        public DTOs.Boxes SelectBoxToPackaging(ProductsDTO produto)
        {
            // Lista de caixas disponíveis
            var boxes = new List<DTOs.Boxes>
            {
                new DTOs.Boxes("Caixa 1", 30, 40, 80),
                new DTOs.Boxes("Caixa 2", 80, 50, 40),
                new DTOs.Boxes("Caixa 3", 50, 80, 60)
            };

            // Tenta encontrar a primeira caixa onde o produto cabe
            foreach (var caixa in boxes)
            {
                if (ProductFitsInBox(produto, caixa))
                {
                    return caixa;
                }
            }

            // Se não houver caixa onde o produto caiba
            return null;
        }
    }
}
