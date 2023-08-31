namespace Book_Store.Application.DTOs.Translator
{
    public class CreateTranslatorDto : ITranslatorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
