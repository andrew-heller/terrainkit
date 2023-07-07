


// classes are REFERENCE TYPES, numbers etc are Value Types

public class MapZone {


 public MapZone()
{
    Terrain = new List<Terrain>();

}

public ZoneType ZoneType {get;set;}

// Optional
public MapObjective? Objective   {get;set;}

//terrain
public List<Terrain> Terrain {get;set;}

}

