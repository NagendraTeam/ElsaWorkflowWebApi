namespace ElsaWorkflowDesigner.Models
{
    public class workflowInputs
    {
        public int id { get; set; }
        public string input { get; set; }

        public string Body { get; set; }

        public Author auther { get; set; }
    }
    public class Author
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
