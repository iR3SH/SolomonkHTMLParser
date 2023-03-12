using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    [Table("monsters")]
    public class Monsters
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GfxId { get; set; }
        public int Align { get; set; }
        public string? Grades { get; set; }
        public string? Colors { get; set; }
        public string? Stats { get; set; }
        public string? StatsInfos { get; set; }
        public string? Spells { get; set; }
        public string? Pdvs { get; set; }
        public string? Points { get; set; }
        public string? Inits { get; set; }
        public int MinKamas { get; set; }
        public int MaxKamas { get; set; }
        public string? Exps { get; set; }
        public int AI_Type { get; set; }
        public int Capturable { get; set; }
        public int Type { get; set; }
        public int AggroDistance { get; set; }
    }
}
