namespace RudzBreakfast.Models;
using ErrorOr;
using RudzBreakfast.ServiceErrors;

//Breakfast internal model
public class Breakfast
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 30;

    public const int MinDescriptionLength = 30;
    public const int MaxDescriptionLength = 150;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory {get; }
    public List<string> Sweet {get; }

    // constructor
    private Breakfast(Guid id, string name, string description, DateTime startDateTime,
        DateTime endDateTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet)
    {
        
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

    // enforcing business rules on internal model
    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {

        if (name.Length is < MinNameLength or > MaxNameLength){
            return Errors.Breakfast.InvalidName;
        }

        //enforce invariants
        var breakfast = new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet
        );
        return breakfast;


    }


}