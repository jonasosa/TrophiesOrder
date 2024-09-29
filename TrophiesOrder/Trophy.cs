using System.Xml.Linq;

public class Trophy
{
    public int Id { get; set; }
    public string Competition { get; set; }
    public int Year { get; set; }


    public void ValidateCompetition()
    {
        if (Competition == null)
        {
            throw new ArgumentNullException("the Trophy needs a Competition");
        }
        if (Competition.Trim().Length < 3)
        {
            throw new ArgumentOutOfRangeException("Competition needs to have at least 3 letters");
        }
    }
    public void ValidateYear()
    {

        if (1970 > Year || Year > 2024)
        {
            throw new ArgumentOutOfRangeException("invalid Year sould be at least 1970 or more and no more then 2024");
        }

    }
     public override string ToString()
    {
        return $"this Trophy was gotten from the {Competition} Competition. in the year of {Year}"; 
    }
    public void Validate()
    {
        ValidateCompetition();
        ValidateYear();
    }
}

