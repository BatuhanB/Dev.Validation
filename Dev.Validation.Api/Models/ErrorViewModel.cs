namespace Dev.Validation.Models
{
    public class ErrorViewModel(string fieldName, List<string> errors)
    {
        public string FieldName { get; set; } = fieldName;
        public List<string> Errors { get; set; } = errors;
    }
}
