using System.Globalization;
using System.Xml.Linq;

public class TrophyRepository
{
    private int NextId = 1;
    private List<Trophy> trophys = new List<Trophy>();
    public Trophy Addtrophy(Trophy trophy)
    {

        trophy.Validate();
        trophy.Id = NextId++;
        trophys.Add(trophy);
        return trophy;
    }
    public List<Trophy> Get(int? minYear = null, string? competition = null, string? sortBy = null)
    {
        List<Trophy> result = new List<Trophy>(trophys);
        if (minYear != null)
        {
            result = result.Where(t => t.Year >= minYear).ToList();
        }
        else if (competition != null)
        {
            result = result.Where(t => t.Competition == competition).ToList();
        }
        else if (sortBy != null)
        {
            switch (sortBy.ToLower())
            {
                case "Competition":
                    result.Sort((t1, t2) => t1.Competition.CompareTo(t2.Competition));
                    break;
                case "Competitiondesc":
                    result.Sort((t1, t2) => t2.Competition.CompareTo(t1.Competition));
                    break;
                case "Year":
                    result.Sort((t1, t2) => t1.Year - t2.Year);
                    break;
                case "Yeardesc":
                    result.Sort((t1, t2) => t2.Year - t1.Year);
                    break;
                default:
                    throw new ArgumentException("Can't sorte it like that, here are the options. Competition, Competitiondesc, Year and Yeardesc ");
            }
        }
        return result;
    }
    public Trophy? Get(int id)
    {
        return trophys.FirstOrDefault(t => t.Id == id);
    }
    public Trophy? Remove(int id)
    {
        Trophy? trophy = Get(id);
        if (trophy == null)
        {
            return null;
        }
        trophys.Remove(trophy);
        return trophy;
    }
    public Trophy? Update(int id, Trophy trophy)
    {
        trophy.Validate();
        Trophy? existingTrophy = Get(id);
        if (existingTrophy == null)
        {
            return null;
        }

        existingTrophy.Competition = trophy.Competition;
        existingTrophy.Year = trophy.Year;
        return existingTrophy;
    }
}

