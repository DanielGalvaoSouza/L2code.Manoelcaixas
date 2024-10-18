using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using L2code.Manoelcaixas.Application.Interfaces;
using L2code.Manoelcaixas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.Services
{
    public class PackagingService : IPackagingService
    {
        private PackagingInBoxes _packagingInBoxes = new PackagingInBoxes();

        public PackagingService()
        {

        }

        public PackagingFeedbackDTO PackagingProducts(InputOrdersDTO caixasDTO)
        {
            return ReportOnThePackagingStrategy(caixasDTO);
            
            //// Ordena produtos por volume decrescente
            //var item = new PackagingFeedbackDTO();
            //item.Orders = new List<OrdersFeedbackDTO>();

            //List<BoxWithProducts> boxWithProducts = new();

            //foreach (var orderItem in caixasDTO.Orders)
            //{
            //    boxWithProducts = new();

            //    var AllBoxToPackagingInOrder = new List<Boxes>();
            //    orderItem.Boxes = new List<Boxes>();
                
            //    var produtosOrdenados = orderItem.Products.OrderByDescending(p => p.Dimensions.Volume).ToList();
            //    foreach (var productItem in produtosOrdenados)
            //    {
            //        //apenas verifica se o produto cabe em uma caixa disponível.
            //        var boxToPackagingProduct = _packagingInBoxes.SelectBoxToPackaging(productItem);
            //        var hasBoxToPackaging = boxToPackagingProduct != null;

            //        //verificar se o pedido já tem uma caixa aberta e se houver verificar se o volume dela comporta mais um produto
            //        //var orderHasBoxWithVolumeAvailable = false;
            //        var hasBoxInOrder = orderItem.Boxes.Count > 0;

            //        var boxWithVolumeAvaliable = orderItem.Boxes
            //            .Where(f => f.VolumeAvailable >= productItem.Dimensions.Volume);
            //        var hasBoxWithVolumeAvaliableInOrder = boxWithVolumeAvaliable
            //            .FirstOrDefault() != null;
            //        var boxOpenWithVolumeAvaliable = boxWithVolumeAvaliable
            //            .FirstOrDefault();

            //        //var orderHasOpenBox = boxOpenWithVolumeAvaliable != null;
                    
            //        //para o pedido receber uma caixa ele deve: ter uma caixa compatível com o produto, ter uma caixa compatível com o produto e esta caixa ter espaço disponível
            //        if ((!hasBoxInOrder || !hasBoxWithVolumeAvaliableInOrder) && hasBoxToPackaging)
            //        {
            //            //inclui caixa no pedido
            //            orderItem.Boxes.Add(boxToPackagingProduct);
            //            boxOpenWithVolumeAvaliable = boxToPackagingProduct;
            //            hasBoxWithVolumeAvaliableInOrder = true;
            //        }

            //        //se couber então deve incluir na mesma caixa o produto.
            //        //se não deve encontrar outra caixa que permita a inclusão do produto.
            //        //se o pedido já tiver uma caixa aberta então deve incluir o produto na mesma caixa, caso contrário deve incluir em outra

            //        if (hasBoxWithVolumeAvaliableInOrder)
            //        {
            //            //valida informações sobre o pedido
            //            productItem.ProductIsSmall = _packagingInBoxes.IsSmallProduct(productItem, boxOpenWithVolumeAvaliable);
            //            productItem.HasBoxToThisProduct = _packagingInBoxes.ProductFitsInBox(productItem, boxOpenWithVolumeAvaliable);

            //            boxOpenWithVolumeAvaliable.Products.Add(productItem);

            //            boxWithProducts.Add(new BoxWithProducts()
            //            {
            //                Product = new ProductsDTO()
            //                {
            //                    ProductsId = productItem.ProductsId
            //                },
            //                Box = boxOpenWithVolumeAvaliable
            //            });

            //        }
            //        else
            //        {
            //            productItem.ProductIsSmall = false;
            //            productItem.HasBoxToThisProduct = false;

            //            orderItem.Boxes.Add(new Boxes()
            //            {
            //                BoxId = null,
            //                Products = new List<ProductsDTO>() { productItem }
            //            });
            //        }
                                        
            //    }

            //    var boxFeedback = new BoxesFeedbackDTO();

            //    item.Orders.Add(new OrdersFeedbackDTO()
            //    {
            //        OrderId = orderItem.OrderId.ToString(),
            //        Boxes = GetBoxesFeedbackOrders(boxWithProducts)
            //    });

            //}

            //após a validação dos produtos com relação a adequação a embalagem para postagem deve ser preparada a resposta do serviço com a orientação final.

            
        }

        public PackagingFeedbackDTO ReportOnThePackagingStrategy(InputOrdersDTO caixasDTO)
        {
            var packagingStrategy = _packagingInBoxes.ProductPackagingStrategy(caixasDTO);

            var feedback = new PackagingFeedbackDTO();
            feedback.Orders = new List<OrdersFeedbackDTO>();

            foreach (var orderItem in caixasDTO.Orders)
            {
                
                var boxesFeedback = new List<BoxesFeedbackDTO>();
                foreach(var boxItem in orderItem.Boxes)
                {
                    boxesFeedback.Add(new BoxesFeedbackDTO()
                    {
                        BoxeId = boxItem.BoxId,
                        Produts = boxItem.Products.Select(s => s.ProductsId).ToList(),
                        Note = boxItem.BoxId != null ? "" : "Produto não cabe em nenhuma caixa disponível."
                    });
                }

                feedback.Orders.Add(new OrdersFeedbackDTO()
                {
                    OrderId = orderItem.OrderId.ToString(),
                    Boxes = boxesFeedback
                });

            }

            return feedback;

        }

        

        private List<BoxesFeedbackDTO> GetBoxesFeedbackOrders(List<BoxWithProducts> boxWithProducts)
        {
            var BoxesFeedback = new List<BoxesFeedbackDTO>();
            string[] products;
            Dictionary<string, string[]> produtcsInBox = new Dictionary<string, string[]>();

            foreach (var boxItem in boxWithProducts)
            {
                if(boxItem.Box == null)
                {
                    break;
                }

                var boxId = boxItem.Box.BoxId;
                var produts = GetAllProducts(boxItem.Box.BoxId, boxWithProducts);

                if(BoxesFeedback.Where(f => f.BoxeId == boxId).Count() > 0)
                {
                    var boxes = BoxesFeedback.Find(s => s.BoxeId == boxId);

                    boxes.Produts.Add(boxItem.Product.ProductsId);

                }
                else
                {
                    BoxesFeedback.Add(new BoxesFeedbackDTO() {
                        BoxeId = boxId,
                        Produts = new string[] { boxItem.Product.ProductsId }.ToList()
                    });
                }
            }

            return BoxesFeedback;

        }

        private List<String> GetAllProducts(string boxId, List<BoxWithProducts> boxWithProducts)
        {
            var produts = new List<String>();
            foreach(var item in boxWithProducts)
            {
                if(item.Box.BoxId == boxId)
                {
                    produts.Add(item.Product.ProductsId);
                }
            }

            return produts;

        }

        

    }
}
