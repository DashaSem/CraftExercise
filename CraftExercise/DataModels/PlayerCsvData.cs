using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftExercise.Models
{
    public class PlayerCsvData
    {
        public string PlayerID { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public string BirthCountry { get; set; }
        public string BirthState { get; set; }
        public string BirthCity { get; set; }
        public int? DeathYear { get; set; }
        public int? DeathMonth { get; set; }
        public int? DeathDay { get; set; }
        public string DeathCountry { get; set; }
        public string DeathState { get; set; }
        public string DeathCity { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameGiven { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Debut { get; set; }
        public string FinalGame { get; set; }
        public string RetroID { get; set; }
        public string BbrefID { get; set; }
    }

    public class PlayerCsvDataMap : ClassMap<PlayerCsvData>
    {
        public PlayerCsvDataMap()
        {
            Map(m => m.PlayerID).Name("playerID");
            Map(m => m.BirthYear).Name("birthYear");
            Map(m => m.BirthMonth).Name("birthMonth");
            Map(m => m.BirthDay).Name("birthDay");
            Map(m => m.BirthCountry).Name("birthCountry");
            Map(m => m.BirthState).Name("birthState");
            Map(m => m.BirthCity).Name("birthCity");
            Map(m => m.DeathYear).Name("deathYear");
            Map(m => m.DeathMonth).Name("deathMonth");
            Map(m => m.DeathDay).Name("deathDay");
            Map(m => m.DeathCountry).Name("deathCountry");
            Map(m => m.DeathState).Name("deathState");
            Map(m => m.DeathCity).Name("deathCity");
            Map(m => m.NameFirst).Name("nameFirst");
            Map(m => m.NameLast).Name("nameLast");
            Map(m => m.NameGiven).Name("nameGiven");
            Map(m => m.Weight).Name("weight");
            Map(m => m.Height).Name("height");
            Map(m => m.Bats).Name("bats");
            Map(m => m.Throws).Name("throws");
            Map(m => m.Debut).Name("debut");
            Map(m => m.FinalGame).Name("finalGame");
            Map(m => m.RetroID).Name("retroID");
            Map(m => m.BbrefID).Name("bbrefID");
        }
    }
}
