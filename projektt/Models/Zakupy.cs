using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace projektt.Models
{
    public class Zakupy
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Amount + ")";
        }
    }
}
