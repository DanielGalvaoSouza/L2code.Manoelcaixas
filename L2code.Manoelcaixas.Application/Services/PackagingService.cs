using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using L2code.Manoelcaixas.Application.Interfaces;

namespace L2code.Manoelcaixas.Application.Services
{
    public class PackagingService : IPackagingService
    {
        private PackagingInBoxes _packagingInBoxes = new PackagingInBoxes();

        public PackagingService()
        {

        }

        /// <summary>
        ///     Read the order, check which package would be best for each product and then returns a report indicating which boxes can be used for delivery.
        /// </summary>
        /// <param name="caixasDTO"></param>
        /// <returns></returns>
        public PackagingFeedbackDTO PackagingProducts(InputOrdersDTO caixasDTO)
        {
            return ReportOnThePackagingStrategy(caixasDTO);

        }

        /// <summary>
        ///     Prepare the report to pack the order products.
        /// </summary>
        /// <param name="caixasDTO"></param>
        /// <returns></returns>
        private PackagingFeedbackDTO ReportOnThePackagingStrategy(InputOrdersDTO caixasDTO)
        {
            var packagingStrategy = _packagingInBoxes.ProductPackagingStrategy(caixasDTO);

            var feedback = new PackagingFeedbackDTO();
            feedback.Orders = new List<OrdersFeedbackDTO>();

            foreach (var orderItem in caixasDTO.Orders)
            {

                var boxesFeedback = new List<BoxesFeedbackDTO>();
                foreach (var boxItem in orderItem.Boxes)
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

    }
}
