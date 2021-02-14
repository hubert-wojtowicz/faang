/**
<name>,<actor ID>,<height>,<date of birth>
**/
/**
Sandra Bullock,1001,1.71,26 July 1964
Jeff Bridges,1002,1.85,4 December 1949
Mia Wasikowska,1003,1.62,14 October 1989
Johnny Depp,1004,1.78,9 June 1963
**/
/**
class FileIO(String pathToFile) {
    // returns the next unread line in the file
    String getNextLine()

    // returns all the lines in the file
    List<String> getAllLines()

    // writes the provided string to the end of the file
    void writeLine(String)

    // overwrites the entire file with the lines provided
    void writeAllLines(List<String> Lines)
}
**/

// lookup by Id
// lookup by Name

public class FileIO 
{
    public FileIO(String pathToFile)
    {
        
    }
    
    // returns the next unread line in the file
    String getNextLine()

    // returns all the lines in the file
    List<String> getAllLines()

    // writes the provided string to the end of the file
    void writeLine(String)

    // overwrites the entire file with the lines provided
    void writeAllLines(List<String> Lines)
}

public class Actor
{
    public string Name {get; set;}
    public int ActorId {get; set;}
    public float Height {get; set;}
    public DateTime DateOfBith  {get; set;}
}

public interface IActorLibrary
{
    Actor GetActorById(int id);
    
    IEnumerable<Actor> GetActorByName(string name);
}

public class ActorLibrary : IActorLibrary
{
    public string PathToFile {get;set;}
    
    public ActorLibrary(string pathToFile)
    {
        PathToFile = pathToFile;
    }

    public Actor GetActorById(int id)
    {
        if(!File.Exist(PathToFile))
            throw new ArgumentException("File does not exist");
        
        var reader = new FileIO(PathToFile);
        var allActors = reader.getAllLines()
            .Select(x=>string.Split(",",x))
            .Select(x=> new Actor
            {
                Name = x[0],
                ActorId = int.Parse(x[1]),
                Height = float.Pase(x[2]),
                DateOfBith = DateTime.Pase(x[3])
            })
            .ToDictonary(x=>x.ActorId, x=>x);
        
        if(allActors.TryGet(id, out var actor)) // O(1)
        {
            return actor;
        }
        else
        {
            return null;
        }
    }
    
    public IEnumerable<Actor> GetActorByName(string name)
    {
        if(!File.Exist(PathToFile))
            throw new ArgumentException("File does not exist");
            
        var reader = new FileIO(PathToFile);
        return allActors = reader.getAllLines()            
            .Select(x=>string.Split(",",x))
            .Select(x=> new Actor
            {
                Name = x[0],
                ActorId = int.Parse(x[1]),
                Height = float.Pase(x[2]),
                DateOfBith = DateTime.Pase(x[3])
            })
            .Where(x=>x.Name == name);
    }
}










