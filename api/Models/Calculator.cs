namespace api.Models;

public class Calculator
{
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Expression { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public double Result { get; set; }
}
