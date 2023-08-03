namespace ASP.net_React_Project.Validators
{
    public class ValidationData
    {
        public List<string> ListOfErrors  { get; set; } = new();
        public string errorMessage = "";
        public bool IsValid {
        get {  return ListOfErrors.Count == 0; }
        }
    }
}
