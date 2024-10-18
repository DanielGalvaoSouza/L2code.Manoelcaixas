using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;

namespace L2code.Manoelcaixas.Application.Interfaces
{
    public interface IPackagingService
    {
        PackagingFeedbackDTO PackagingProducts(InputOrdersDTO caixasDTO);
    }
}
