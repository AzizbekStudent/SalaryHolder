﻿namespace SalaryHolderDataBase.DAL.Models
{
    public class SalTable
    {
        public int? Sal_ID { get; set; }

        public DateTime? SalaryDate { get; set; }

        public decimal? SalaryAmount { get; set; } = 0;

        public string? Description { get; set; }

        public int? BogCha_ID { get; set; }
        public Bogcha? Bogcha_ {  get; set; }

        public int? UserID { get; set; }
        public UserList? User_ { get; set; }
    }

}
