namespace SalaryHolderDataBase.DAL.Models
{
    public class Bogcha
    {
        public int? BogCha_ID { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? FireDate { get; set; }

        public decimal? Salary { get; set; }

        public bool IsWorking { get; set; } = false;

        public int? GroupAmount { get; set; } = 1;

        public string? ZavName { get; set; }

        public int? UserID { get; set; } = 1;
    }

}
