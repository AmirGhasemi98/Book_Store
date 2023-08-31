using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Translator
{
    public class UpdateTranslatorDto : BaseDto, ITranslatorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
